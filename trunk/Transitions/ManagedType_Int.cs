using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transitions
{
    /// <summary>
    /// Manages transitions for int properties.
    /// </summary>
    internal class ManagedType_Int : IManagedType
    {
        #region ITransitionType Members

        /// <summary>
        /// Returns the type we are managing.
        /// </summary>
        public Type getManagedType()
        {
            return typeof(int);
        }

        /// <summary>
        /// Returns a copy of the int passed in.
        /// </summary>
        public object copy(object o)
        {
            int value = (int)o;
            return value;
        }

        #endregion
    }
}
