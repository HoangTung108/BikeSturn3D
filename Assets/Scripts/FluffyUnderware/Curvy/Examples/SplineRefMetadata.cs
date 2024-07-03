using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	public class SplineRefMetadata : MonoBehaviour, ICurvyMetadata
	{
		public CurvySpline Spline;

		public CurvySplineSegment CP;

		public string Options;
	}
}
