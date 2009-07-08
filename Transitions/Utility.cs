using System;
using System.Collections.Generic;
using System.Text;

namespace Transitions
{
	/// <summary>
	/// A class holding static utility functions.
	/// </summary>
	internal class Utility
	{
		/// <summary>
		/// Returns a value between d1 and d2 for the percentage passed in.
		/// </summary>
		public static double interpolate(double d1, double d2, double dPercentage)
		{
			double dDifference = d2 - d1;
			double dDistance = dDifference * dPercentage;
			double dResult = d1 + dDistance;
			return dResult;
		}

		/// <summary>
		/// Returns a value betweeen i1 and i2 for the percentage passed in.
		/// </summary>
		public static int interpolate(int i1, int i2, double dPercentage)
		{
			return (int)interpolate((double)i1, (double)i2, dPercentage);
		}
	}
}
