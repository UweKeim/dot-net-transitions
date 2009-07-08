using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

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
    /// a.      Transition t = new Transition(form1, new TransitionMethod_Linear(500));
    /// b.      form1.Width = 600;
    /// c.      form1.Height = 800;
    /// d.      t.go();
    ///   
    /// Line a:         Creates a new transition. You specify which object(s) it will act on, 
    ///                 and the transition method.
    ///                 
    /// Lines b. and c: Set the destination values of the properties you are animating.
    /// 
    /// Line d:         Starts the transition, specifying which transition method will be used 
    ///                 and any parameters it needs.
    ///  
    /// When the transition starts, any properties will be returned to their initial values
    /// at the point the transition was constructed and then animated to the destination
    /// values.
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
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Constructor. You pass in the object that holds the properties 
        /// that you are performing transitions on.
        /// </summary>
        public Transition(object target, ITransitionMethod transitionMethod)
        {
            setupTransition(new object[] { target }, transitionMethod);
        }

        /// <summary>
        /// Constructor. You pass in the set of objects that hold the properties 
        /// that you are performing transitions on.
        /// </summary>
        public Transition(object[] targets, ITransitionMethod transitionMethod)
        {
            setupTransition(targets, transitionMethod);
        }

        /// <summary>
        /// Starts the transition.
        /// </summary>
        public void go()
        {
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Sets up a new transition. Called by the constructors.
        /// </summary>
        private void setupTransition(object[] targets, ITransitionMethod transitionMethod)
        {
            // When a transition is run we need to work out which properties
            // on the targets have been changed between the construction of the
            // transition and the go() method being called. The changes properties
            // are the ones we animate.
            //
            // To find the changed properties, we first find the collection of
            // properties that we can manage for each of the targets and take a
            // snapshot of these properties. (Then later in the go method we
            // see which properties have changed.)
            foreach (object target in targets)
            {
                snapshotProperties(target);
            }
        }

        /// <summary>
        /// We take a snapshot of the properties (of the types we know how to manage)
        /// from the target passed in.
        /// </summary>
        private void snapshotProperties(object target)
        {
			// We find all the properties that we know how to manage for 
			// the target...
            IList<PropertyInfo> propertyInfos = getManagableProperties(target.GetType());

			// We take a snapshot of the property values...
			foreach (PropertyInfo propertyInfo in propertyInfos)
			{
			}
        }

        #endregion

		#region Private static functions

		/// <summary>
		/// Returns the set of managable properties for the type passed in.
		/// </summary>
		private static IList<PropertyInfo> getManagableProperties(Type type)
		{
			// We may have the information cached...
			if (m_mapManagableFields.ContainsKey(type) == true)
			{
				return m_mapManagableFields[type];
			}

			// The information isn't cached, so we work out which fields 
			// are managable for the type passed in. To dop this, we iterate
			// through the properties for the type and see which ones:
			// - Are both getable and setable
			// - Are of one of the types we know how to manage

			IList<PropertyInfo> managableProperties = new List<PropertyInfo>();

			// We get all the properties for the type and check to see if they match
			// our constraints...
			PropertyInfo[] propertyInfos = type.GetProperties();
			foreach (PropertyInfo propertyInfo in propertyInfos)
			{
				// Is the property getable and setable?
				if (propertyInfo.CanRead == false || propertyInfo.CanWrite == false)
				{
					// The property is either read-only or write-only...
					continue;
				}

				// Is the property of a type we know how to manage?
				Type propertyType = propertyInfo.PropertyType;
				if (m_mapManagedTypes.ContainsKey(propertyType) == false)
				{
					// We don't know how to manage this type...
					continue;
				}

				// We can manage this property, so we add it to the managable list
				// for this type...
				managableProperties.Add(propertyInfo);
			}

			// We store the list for this type...
			m_mapManagableFields[type] = managableProperties;

			return managableProperties;
		}

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

        // A map of Type info to a collection of properties for that type that we are able
        // to perform transitions on. For example, the type might be "Form" and the
        // managable properties would be Width, Height, BackColor etc. Only properties
        // with both gets and sets, and which are in the map of managed types are included...
        private static IDictionary<Type, IList<PropertyInfo>> m_mapManagableFields = new Dictionary<Type, IList<PropertyInfo>>();

        #endregion
    }
}
