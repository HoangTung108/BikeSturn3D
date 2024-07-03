using System.Collections;
using FluffyUnderware.DevTools;
using UnityEngine;
using UnityEngine.UI;

namespace FluffyUnderware.Curvy.Examples
{
	[ExecuteInEditMode]
	public class MoveToNearestPoint : MonoBehaviour
	{
		public Transform Lookup;

		public CurvySpline Spline;

		public Text StatisticsText;

		public Slider Density;

		private TimeMeasure Timer = new TimeMeasure(30);

		private IEnumerator Start()
		{
			if ((bool)Spline)
			{
				while (!Spline.IsInitialized)
				{
					yield return 0;
				}
			}
		}

		private void Update()
		{
			if ((bool)Spline && Spline.IsInitialized && (bool)Lookup)
			{
				Vector3 p = Spline.transform.InverseTransformPoint(Lookup.position);
				Timer.Start();
				float nearestPointTF = Spline.GetNearestPointTF(p);
				Timer.Stop();
				base.transform.position = Spline.transform.TransformPoint(Spline.Interpolate(nearestPointTF));
				StatisticsText.text = string.Format("Blue Curve Cache Points: {0} \nAverage Lookup (ms): {1:0.000}", Spline.CacheSize, Timer.AverageMS);
			}
		}

		public void OnSliderChange()
		{
			Spline.CacheDensity = (int)Density.value;
		}
	}
}
