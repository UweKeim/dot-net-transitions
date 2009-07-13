using System;
using System.Collections.Generic;
using System.Text;

namespace Transitions
{
    public class TransitionMethod_UserDefined : ITransitionMethod
    {
        #region Public methods



        #endregion

        #region ITransitionMethod Members

        public void onTimer(int iTime, out double dPercentage, out bool bCompleted)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
