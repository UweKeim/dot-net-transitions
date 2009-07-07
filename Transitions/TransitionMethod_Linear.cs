using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transitions
{
    public class TransitionMethod_Linear : ITransitionMethod
    {
        #region Public methods

        /// <summary>
        /// Constructor. You pass in the time (in milliseconds) that the
        /// transition will take.
        /// </summary>
        public TransitionMethod_Linear(int iTransitionTime)
        {
        }

        #endregion
    }
}
