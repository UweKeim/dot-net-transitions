using System;
using System.Collections.Generic;
using System.Text;

namespace Transitions
{
    /// <summary>
    /// This class allows you to create user-defined transition types. You specify these
    /// as a list of TransitionElements. Each of these defines: 
    /// End time , End value, Interpolation method
    /// 
    /// For example, say you want to make a bouncing effect with a decay:
    /// 
    /// Time%   Value%  Interpolation
    /// ----    -----   -------------
    /// 50      100     Acceleration 
    /// 75      50      Deceleration
    /// 85      100     Acceleration
    /// 91      75      Deceleration
    /// 95      100     Acceleration
    /// 98      90      Deceleration
    /// 100     100     Acceleration
    /// 
    /// The time values are expressed as a percentage of the overall transition time. This 
    /// means that you can create a user-defined transition-type and then use it for transitions
    /// of different lengths.
    /// 
    /// The values are percentages of the values between the start and end values of the properties
    /// being animated in the transitions. 0% is the start value and 100% is the end value.
    /// 
    /// The interpolation is one of the values from the InterpolationMethod enum.
    /// 
    /// So the example above accelerates to the destination (as if under gravity) by
    /// t=50%, then bounces back up to half the initial height by t=75%, slowing down 
    /// (as if against gravity) before falling down again and bouncing to decreasing 
    /// heights each time.
    /// 
    /// </summary>
    public class TransitionType_UserDefined : ITransitionType
    {
        #region Public methods

        /// <summary>
        /// Constructor. You pass in the list of TransitionElements and the total time
        /// (in milliseconds) for the transition.
        /// </summary>
        public TransitionType_UserDefined(IList<TransitionElement> elements, int iTransitionTime)
        {
            m_Elements = elements;
            m_dTransitionTime = iTransitionTime;

            // We check that the elements list has some members...
            if (elements.Count == 0)
            {
                throw new Exception("The list of elements passed to the constructor of TransitionType_UserDefined had zero elements. It must have at least one element.");
            }
        }

        #endregion

        #region ITransitionMethod Members

        /// <summary>
        /// Called to find the value for the movement of properties for the time passed in.
        /// </summary>
        public void onTimer(int iTime, out double dPercentage, out bool bCompleted)
        {
            double dTimeFraction = iTime / m_dTransitionTime;

            dPercentage = 1.0;

            if (iTime >= m_dTransitionTime)
            {
                // The transition has completed, so we make sure that
                // it is at its final value...
                bCompleted = true;

                TransitionElement lastElement = m_Elements[m_Elements.Count - 1];
                double dLastValue = lastElement.Value / 100.0;
                dPercentage = dLastValue;
            }
            else
            {
                bCompleted = false;
            }
        }

        #endregion

        #region Private data

        private IList<TransitionElement> m_Elements = null;

        private double m_dTransitionTime = 0.0;

        #endregion
    }
}
