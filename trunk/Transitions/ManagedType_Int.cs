using System;
using System.Collections.Generic;
using System.Text;

namespace Transitions
{
    /// <summary>
    /// Manages transitions for int properties.
    /// </summary>
    internal class ManagedType_Int : IManagedType
    {
		#region IManagedType Members

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

		/// <summary>
		/// Checks if the two objects are the same int.
		/// </summary>
		public bool isSameValue(object o1, object o2)
		{
			int i1 = (int)o1;
			int i2 = (int)o2;
			return (i1 == i2);
		}

		#endregion
	}
}
