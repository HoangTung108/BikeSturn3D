using System;
using System.Collections;
using FluffyUnderware.Curvy.Generator;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	public class PerformanceDynamicSpline : MonoBehaviour
	{
		private CurvySpline mSpline;

		public CurvyGenerator Generator;

		[Positive]
		public int UpdateInterval = 200;

		[RangeEx(2f, 2000f, "", "")]
		public int CPCount = 100;

		[Positive]
		public float Radius = 20f;

		public bool AlwaysClear;

		public bool UpdateCG;

		private float mAngleStep;

		private float mCurrentAngle;

		private float mLastUpdateTime;

		private TimeMeasure ExecTimes = new TimeMeasure(10);

		private void Awake()
		{
			mSpline = GetComponent<CurvySpline>();
		}

		private IEnumerator Start()
		{
			while (!mSpline.IsInitialized)
			{
				yield return 0;
			}
			for (int i = 0; i < CPCount; i++)
			{
				addCP();
			}
			mSpline.Refresh();
			mLastUpdateTime = Time.timeSinceLevelLoad + 0.1f;
		}

		private void Update()
		{
			if (Time.timeSinceLevelLoad - (float)UpdateInterval * 0.001f > mLastUpdateTime)
			{
				mLastUpdateTime = Time.timeSinceLevelLoad;
				ExecTimes.Start();
				if (AlwaysClear)
				{
					mSpline.Clear();
				}
				while (mSpline.ControlPointCount > CPCount)
				{
					mSpline.ControlPoints[0].Delete();
				}
				while (mSpline.ControlPointCount <= CPCount)
				{
					addCP();
				}
				mSpline.Refresh();
				ExecTimes.Stop();
			}
		}

		private void addCP()
		{
			mAngleStep = (float)Math.PI * 2f / ((float)CPCount + (float)CPCount * 0.25f);
			CurvySplineSegment curvySplineSegment = mSpline.Add();
			curvySplineSegment.localPosition = new Vector3(Mathf.Sin(mCurrentAngle) * Radius, Mathf.Cos(mCurrentAngle) * Radius, 0f);
			mCurrentAngle = Mathf.Repeat(mCurrentAngle + mAngleStep, (float)Math.PI * 2f);
		}

		private void OnGUI()
		{
			GUILayout.BeginVertical(GUI.skin.box);
			GUILayout.BeginHorizontal();
			GUILayout.Label("Interval", GUILayout.Width(130f));
			UpdateInterval = (int)GUILayout.HorizontalSlider(UpdateInterval, 0f, 5000f, GUILayout.Width(200f));
			GUILayout.Label(UpdateInterval.ToString());
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			GUILayout.Label("# of Control Points", GUILayout.Width(130f));
			CPCount = (int)GUILayout.HorizontalSlider(CPCount, 2f, 200f, GUILayout.Width(200f));
			GUILayout.Label(CPCount.ToString());
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			GUILayout.Label("Radius", GUILayout.Width(130f));
			Radius = GUILayout.HorizontalSlider(Radius, 10f, 100f, GUILayout.Width(200f));
			GUILayout.Label(Radius.ToString("0.00"));
			GUILayout.EndHorizontal();
			AlwaysClear = GUILayout.Toggle(AlwaysClear, "Always clear");
			bool updateCG = UpdateCG;
			UpdateCG = GUILayout.Toggle(UpdateCG, "Use Curvy Generator");
			if (updateCG != UpdateCG)
			{
				Generator.gameObject.SetActive(UpdateCG);
			}
			GUILayout.Label("Avg. Execution Time (ms): " + ExecTimes.AverageMS.ToString("0.000"));
			GUILayout.EndVertical();
		}
	}
}
