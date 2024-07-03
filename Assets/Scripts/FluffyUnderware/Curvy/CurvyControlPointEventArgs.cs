using UnityEngine;

namespace FluffyUnderware.Curvy
{
	public class CurvyControlPointEventArgs : CurvySplineEventArgs
	{
		public enum AddMode
		{
			Before,
			After,
			None
		}

		public AddMode Mode;

		public CurvySplineSegment ControlPoint;

		public CurvyControlPointEventArgs(MonoBehaviour sender, CurvySpline spline, CurvySplineSegment cp, AddMode mode = AddMode.None, object data = null)
			: base(sender, spline, data)
		{
			ControlPoint = cp;
			Mode = mode;
		}

		public CurvyControlPointEventArgs(CurvySpline spline)
			: base(spline)
		{
			Mode = AddMode.After;
		}
	}
}
