using System.ComponentModel;
using UnityEngine;

namespace FluffyUnderware.Curvy
{
	public class CurvySplineEventArgs : CancelEventArgs
	{
		public MonoBehaviour Sender;

		public CurvySpline Spline;

		public object Data;

		public CurvySplineEventArgs(MonoBehaviour sender, CurvySpline spline = null, object data = null)
		{
			Sender = sender;
			Spline = spline;
			Data = data;
		}
	}
}
