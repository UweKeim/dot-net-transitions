using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Timers;
using System.Diagnostics;
using System.Windows.Forms;

namespace Transitions
{
    /// <summary>
    /// Lets you perform animated transitions of properties on arbitrary objects. These 
    /// will often be transitions of UI properties, for example an animated fade-in of 
    /// a UI object, or an animated move of a UI object from one position to another.
    /// 
    /// Each transition can simulataneously change multiple properties, including properties
    /// across multiple objects.
    /// 
    /// Example transition
    /// ------------------
    /// a.      Transition t = new Transition(new TransitionMethod_Linear(500));
    /// b.      t.add(form1, "Width", 500);
    /// c.      t.add(form1, "BackColor", Color.Red);
    /// d.      t.run();
    ///   
    /// Line a:         Creates a new transition. You specify the transition method.
    ///                 
    /// Lines b. and c: Set the destination values of the properties you are animating.
    /// 
    /// Line d:         Starts the transition.
    /// 
    /// Transition methods
    /// ------------------
    /// TransitionMethod objects specify how the transition is made. Examples include
    /// linear transition, ease-in-ease-out and so on. Different transition methods may
    /// need different parameters.
    /// 
    /// </summary>
    public class Transition
	{
		#region Registration

		/// <summary>
        /// You should register all managed-types here.
        /// </summary>
        static Transition()
        {
            registerType(new ManagedType_Int());
            registerType(new ManagedType_Float());
			registerType(new ManagedType_Double());
            registerType(new ManagedType_Color());
            registerType(new ManagedType_String());
        }

        #endregion

        #region Events

        /// <summary>
        /// Args passed with the TransitionCompletedEvent.
        /// </summary>
        public class Args : EventArgs
        {
        }

        /// <summary>
        /// Event raised when the transition hass completed.
        /// </summary>
        public event EventHandler<Args> TransitionCompletedEvent;

        #endregion

        #region Public static methods

        /// <summary>
        /// Creates and immediately runs a transition on the property passed in.
        /// </summary>
        public static void run(object target, string strPropertyName, object destinationValue, ITransitionMethod transitionMethod)
        {
            Transition t = new Transition(transitionMethod);
            t.add(target, strPropertyName, destinationValue);
            t.run();
        }

        /// <summary>
        /// Sets the property passed in to the initial value passed in, then creates and 
        /// immediately runs a transition on it.
        /// </summary>
        public static void run(object target, string strPropertyName, object initialValue, object destinationValue, ITransitionMethod transitionMethod)
        {
            Utility.setValue(target, strPropertyName, initialValue);
            run(target, strPropertyName, destinationValue, transitionMethod);
        }

        /// <summary>
        /// Creates a TransitionChain and runs it.
        /// </summary>
        public static void runChain(params Transition[] transitions)
        {
            TransitionChain chain = new TransitionChain(transitions);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Constructor. You pass in the object that holds the properties 
        /// that you are performing transitions on.
        /// </summary>
        public Transition(ITransitionMethod transitionMethod)
        {
			m_TransitionMethod = transitionMethod;
        }

		/// <summary>
		/// Adds a property that should be animated as part of this transition.
		/// </summary>
		public void add(object target, string strPropertyName, object destinationValue)
		{
			// We get the property info...
			Type targetType = target.GetType();
			PropertyInfo propertyInfo = targetType.GetProperty(strPropertyName);
			if (propertyInfo == null)
			{
				throw new Exception("Object: " + target.ToString() + " does not have the property: " + strPropertyName);
			}

			// We check that we support the property type...
			Type propertyType = propertyInfo.PropertyType;
			if (m_mapManagedTypes.ContainsKey(propertyType) == false)
			{
				throw new Exception("Transition does not handle properties of type: " + propertyType.ToString());
			}

            // We can only transition properties that are both getable and setable...
            if (propertyInfo.CanRead == false || propertyInfo.CanWrite == false)
            {
                throw new Exception("Property is not both getable and setable: " + strPropertyName);
            }

            IManagedType managedType = m_mapManagedTypes[propertyType];
            
            // We can manage this type, so we store the information for the
			// transition of this property...
			TransitionedPropertyInfo info = new TransitionedPropertyInfo();
			info.endValue = destinationValue;
			info.target = target;
			info.propertyInfo = propertyInfo;
			info.managedType = managedType;

			m_listTransitionedProperties.Add(info);
		}

        /// <summary>
        /// Starts the transition.
        /// </summary>
        public void run()
        {
            // We find the current start values for the properties we 
            // are animating...
            foreach (TransitionedPropertyInfo info in m_listTransitionedProperties)
            {
                object value = info.propertyInfo.GetValue(info.target, null);
                info.startValue = info.managedType.copy(value);
            }

			// We start the stopwatch. We use this when the timer ticks to measure 
			// how long the transition has been runnning for...
			m_Stopwatch.Reset();
			m_Stopwatch.Start();

            // We register this transition with the transition manager...
            TransitionManager.getInstance().register(this);
		}

        #endregion

        #region Private functions

		/// <summary>
		/// Called when the transition timer ticks.
		/// </summary>
		internal void onTimer()
		{
			// When the timer ticks we:
			// a. Find the elapsed time since the transition started.
			// b. Work out the percentage movement for the properties we're managing.
			// c. Find the actual values of each property, and set them.

			// a.
			int iElapsedTime = (int)m_Stopwatch.ElapsedMilliseconds;

			// b.
			double dPercentage;
			bool bCompleted;
			m_TransitionMethod.onTimer(iElapsedTime, out dPercentage, out bCompleted);

			// c. 
			foreach (TransitionedPropertyInfo info in m_listTransitionedProperties)
			{
				// We get the current value for this property...
				object value = info.managedType.getIntermediateValue(info.startValue, info.endValue, dPercentage);

				// We set it...
				PropertyUpdateArgs args = new PropertyUpdateArgs(info.target, info.propertyInfo, value);
				setProperty(this, args);
			}

			// Has the transition completed?
			if (bCompleted == true)
			{
                // We stop the stopwatch and the timer...
                m_Stopwatch.Stop();

                // We raise an event to notify any observers that the transition has completed...
                Utility.raiseEvent(TransitionCompletedEvent, this, new Args());
			}
		}

		/// <summary>
		/// Sets a property on the object passed in to the value passed in. This method
		/// invokes itself on the GUI thread if the property is being invoked on a GUI 
		/// object.
		/// </summary>
		private void setProperty(object sender, PropertyUpdateArgs args)
		{
            try
            {
                Control control = args.target as Control;
                if (control != null && control.InvokeRequired)
                {
                    // We need to invoke the method on the GUI thread.
                    // Note: We change the property synchronously with Invoke rather than
                    //       asynchronously with BeginInvoke as the transition can generate
                    //       a large number of changes, and these can "pile up" and cause
                    //       problems. It is better to slow the transition down to the speed
                    //       at which it can realistically be rendered. (The transition will 
                    //       not actually slow down, but the frame-rate may decrease.)
                    control.Invoke(new EventHandler<PropertyUpdateArgs>(setProperty), new object[] { sender, args });
                }
                else
                {
                    // We are on the correct thread, so we update the property...
                    args.propertyInfo.SetValue(args.target, args.value, null);
                }
            }
            catch (Exception)
            {
                // We silently catch any exceptions. These could be things like 
                // bounds exceptions when setting properties.
            }
		}

		#endregion

		#region Private static functions

		/// <summary>
		/// Registers a transition-type. We hold them in a map.
		/// </summary>
		private static void registerType(IManagedType transitionType)
		{
			Type type = transitionType.getManagedType();
			m_mapManagedTypes[type] = transitionType;
		}

		#endregion
		
		#region Private static data

		// A map of Type info to IManagedType objects. These are all the types that we
        // know how to perform transactions on...
        private static IDictionary<Type, IManagedType> m_mapManagedTypes = new Dictionary<Type, IManagedType>();

        #endregion

		#region Private data

		// The transition method used by this transition...
		private ITransitionMethod m_TransitionMethod = null;

		// Holds information about one property on one taregt object that we are performing
		// a transition on...
		private class TransitionedPropertyInfo
		{
			public object startValue;
			public object endValue;
			public object target;
			public PropertyInfo propertyInfo;
			public IManagedType managedType;
		}

		// The collection of properties that the current transition is animating...
		private IList<TransitionedPropertyInfo> m_listTransitionedProperties = new List<TransitionedPropertyInfo>();

		// Helps us find the time interval from the time the transition starts to each timer tick...
		private Stopwatch m_Stopwatch = new Stopwatch();

        // Event args used for the event we raise when updating a property...
		private class PropertyUpdateArgs : EventArgs
		{
			public PropertyUpdateArgs(object t, PropertyInfo pi, object v)
			{
				target = t;
				propertyInfo = pi;
				value = v;
			}
			public object target;
			public PropertyInfo propertyInfo;
			public object value;
		}

		#endregion
	}
}
