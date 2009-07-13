using System;
using System.Collections.Generic;
using System.Text;

namespace Transitions
{
    /// <summary>
    /// This transition method 'bounces' the properties a specified number of times, ending
    /// up by reverting them to their initial values. You specify the number of bounces and
    /// the length of each bounce. 
    /// 
    /// Although this transition is called 'bounce' - which implies movement - it is also 
    /// good for operations like flashing the color of a control to highlight it.
    /// </summary>
    public class TransitionMethod_Bounce : ITransitionMethod
    {
        #region Public methods

        /// <summary>
        /// You specify the number of bounces
        /// </summary>
        public TransitionMethod_Bounce(int iNumberOfBounces, int iBounceTime)
        {
            m_dBounceTime = iBounceTime / 2.0; // We store the number of half-bounces
            m_dTransitionTime = iBounceTime * iNumberOfBounces;
        }

        #endregion

        #region ITransitionMethod Members

        /// <summary>
        /// Calculates the current position for the transition given the total
        /// elapsed time.
        /// </summary>
        public void onTimer(int iTime, out double dPercentage, out bool bCompleted)
        {
            // The transition is broken into a number of half-bounces, i.e. each bounce
            // consists of a 'there' and a 'back' movement. We need to work out how
            // far we have traveled within each bounce, and the direction we are currently
            // traveling in...

            // We find the elapsed time within this bounce...
            double dElapsedWithinBounce = iTime % m_dBounceTime;
            double dElapsedFraction = dElapsedWithinBounce / m_dBounceTime;

            // We convert this to a distance traveled with the ease-in-ease-out method...
            double dDistance = Utility.convertLinearToEaseInEaseOut(dElapsedFraction);

            // We need to work out which direction the bounce is in. To do this we 
            // work out which bounce it is (0, 1, ...). The even bounces are "positive" bounces,
            // and the odd ones are negative bounces...
            dPercentage = dDistance;

            int iBounceDirection = (int)Math.Floor(iTime / m_dBounceTime) % 2;
            if (iBounceDirection == 1)
            {
                dPercentage = 1.0 - dDistance;
            }

            // Has the transition completed?
            if (iTime >= m_dTransitionTime)
            {
                dPercentage = 0.0;
                bCompleted = true;
            }
            else
            {
                bCompleted = false;
            }
        }

        #endregion

        #region Private data

        private double m_dTransitionTime = 0.0;
        private double m_dBounceTime = 0.0;

        #endregion
    }
}
