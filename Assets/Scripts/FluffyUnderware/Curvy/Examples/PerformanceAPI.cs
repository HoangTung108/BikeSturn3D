using System.Collections.Generic;
using System.Reflection;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	public class PerformanceAPI : MonoBehaviour
	{
		private const int LOOPS = 20;

		private List<string> mTests = new List<string>();

		private List<string> mTestResults = new List<string>();

		private CurvyInterpolation mInterpolation = CurvyInterpolation.CatmullRom;

		private CurvyOrientation mOrientation = CurvyOrientation.Dynamic;

		private int mCacheSize = 50;

		private int mControlPointCount = 20;

		private int mTotalSplineLength = 100;

		private bool mUseCache;

		private bool mUseMultiThreads = true;

		private int mCurrentTest = -1;

		private bool mExecuting;

		private TimeMeasure Timer = new TimeMeasure(20);

		private MethodInfo mGUIMethod;

		private MethodInfo mRunMethod;

		private bool mInterpolate_UseDistance;

		private int mRefresh_Mode;

		private void Awake()
		{
			mTests.Add("Interpolate");
			mTests.Add("Refresh");
		}

		private void OnGUI()
		{
			GUILayout.BeginVertical(GUI.skin.box);
			GUILayout.Label("Curvy offers various options to fine-tune performance vs. precision balance:");
			GUILayout.BeginHorizontal();
			GUILayout.Label("Interpolation: ");
			if (GUILayout.Toggle(mInterpolation == CurvyInterpolation.Linear, "Linear", GUI.skin.button))
			{
				mInterpolation = CurvyInterpolation.Linear;
			}
			if (GUILayout.Toggle(mInterpolation == CurvyInterpolation.Bezier, "Bezier", GUI.skin.button))
			{
				mInterpolation = CurvyInterpolation.Bezier;
			}
			if (GUILayout.Toggle(mInterpolation == CurvyInterpolation.CatmullRom, "CatmullRom", GUI.skin.button))
			{
				mInterpolation = CurvyInterpolation.CatmullRom;
			}
			if (GUILayout.Toggle(mInterpolation == CurvyInterpolation.TCB, "TCB", GUI.skin.button))
			{
				mInterpolation = CurvyInterpolation.TCB;
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			GUILayout.Label("Orientation: ");
			if (GUILayout.Toggle(mOrientation == CurvyOrientation.None, "None", GUI.skin.button))
			{
				mOrientation = CurvyOrientation.None;
			}
			if (GUILayout.Toggle(mOrientation == CurvyOrientation.Static, "Static", GUI.skin.button))
			{
				mOrientation = CurvyOrientation.Static;
			}
			if (GUILayout.Toggle(mOrientation == CurvyOrientation.Dynamic, "Dynamic", GUI.skin.button))
			{
				mOrientation = CurvyOrientation.Dynamic;
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			GUILayout.Label("Control Points (max): " + mControlPointCount);
			mControlPointCount = (int)GUILayout.HorizontalSlider(mControlPointCount, 2f, 1000f);
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			GUILayout.Label("Total spline length: " + mTotalSplineLength);
			mTotalSplineLength = (int)GUILayout.HorizontalSlider(mTotalSplineLength, 5f, 10000f);
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			GUILayout.Label("Cache Density: " + mCacheSize);
			mCacheSize = (int)GUILayout.HorizontalSlider(mCacheSize, 1f, 100f);
			GUILayout.EndHorizontal();
			mUseCache = GUILayout.Toggle(mUseCache, "Use Cache (where applicable)");
			mUseMultiThreads = GUILayout.Toggle(mUseMultiThreads, "Use Multiple Threads (where applicable)");
			GUILayout.Label("Select Test:");
			int num = GUILayout.SelectionGrid(Mathf.Max(0, mCurrentTest), mTests.ToArray(), 4);
			if (num != mCurrentTest)
			{
				mCurrentTest = num;
				Timer.Clear();
				mTestResults.Clear();
				mGUIMethod = GetType().GetMethod("GUI_" + mTests[mCurrentTest], BindingFlags.Instance | BindingFlags.NonPublic);
				mRunMethod = GetType().GetMethod("Test_" + mTests[mCurrentTest], BindingFlags.Instance | BindingFlags.NonPublic);
			}
			GUILayout.Space(5f);
			if (mGUIMethod != null)
			{
				mGUIMethod.Invoke(this, null);
			}
			GUI.enabled = !mExecuting && mRunMethod != null;
			string text = ((!mExecuting) ? ("Run (" + 20 + " times)") : "Please wait...");
			if (GUILayout.Button(text))
			{
				mExecuting = true;
				Timer.Clear();
				mTestResults.Clear();
				Invoke("runTest", 0.5f);
			}
			GUI.enabled = true;
			if (Timer.Count > 0)
			{
				foreach (string mTestResult in mTestResults)
				{
					GUILayout.Label(mTestResult);
				}
				GUILayout.Label(string.Format("Average (ms): {0:0.0000}", Timer.AverageMS));
				GUILayout.Label(string.Format("Minimum (ms): {0:0.0000}", Timer.MinimumMS));
				GUILayout.Label(string.Format("Maximum (ms): {0:0.0000}", Timer.MaximumMS));
			}
			GUILayout.EndVertical();
		}

		private void GUI_Interpolate()
		{
			GUILayout.Label("Interpolates position");
			mInterpolate_UseDistance = GUILayout.Toggle(mInterpolate_UseDistance, "By Distance");
		}

		private void Test_Interpolate()
		{
			CurvySpline spline = getSpline();
			addRandomCP(ref spline, mControlPointCount, mTotalSplineLength);
			mTestResults.Add("Cache Points: " + spline.CacheSize);
			mTestResults.Add(string.Format("Cache Point Distance: {0:0.000}", (float)mTotalSplineLength / (float)spline.CacheSize));
			Vector3 vector = Vector3.zero;
			if (mInterpolate_UseDistance)
			{
				for (int i = 0; i < 20; i++)
				{
					float distance = Random.Range(0f, spline.Length);
					if (mUseCache)
					{
						Timer.Start();
						vector = spline.InterpolateByDistanceFast(distance);
						Timer.Stop();
					}
					else
					{
						Timer.Start();
						vector = spline.InterpolateByDistance(distance);
						Timer.Stop();
					}
				}
			}
			else
			{
				for (int j = 0; j < 20; j++)
				{
					float tf = Random.Range(0, 1);
					if (mUseCache)
					{
						Timer.Start();
						vector = spline.InterpolateFast(tf);
						Timer.Stop();
					}
					else
					{
						Timer.Start();
						vector = spline.Interpolate(tf);
						Timer.Stop();
					}
				}
			}
			Object.Destroy(spline.gameObject);
			vector.Set(0f, 0f, 0f);
		}

		private void GUI_Refresh()
		{
			GUILayout.Label("Refresh Spline or Single segment!");
			GUILayout.BeginHorizontal();
			GUILayout.Label("Mode:");
			mRefresh_Mode = GUILayout.SelectionGrid(mRefresh_Mode, new string[2] { "All", "Single random segment" }, 2);
			GUILayout.EndHorizontal();
		}

		private void Work()
		{
			for (int i = 0; i < 1000; i++)
			{
				new Vector3(1f, 2f, 3f).Normalize();
			}
		}

		private void work()
		{
			for (int i = 0; i < 1000; i++)
			{
				new Vector3(1f, 2f, 3f).Normalize();
			}
		}

		private void Test_Refresh()
		{
			CurvySpline spline = getSpline();
			addRandomCP(ref spline, mControlPointCount, mTotalSplineLength);
			mTestResults.Add("Cache Points: " + spline.CacheSize);
			mTestResults.Add(string.Format("Cache Point Distance: {0:0.000}", (float)mTotalSplineLength / (float)spline.CacheSize));
			for (int i = 0; i < 20; i++)
			{
				int idx = Random.Range(0, spline.Count - 1);
				if (mRefresh_Mode == 0)
				{
					Timer.Start();
					spline.SetDirtyAll(true, true);
					spline.Refresh();
					Timer.Stop();
				}
				else
				{
					Timer.Start();
					spline[idx].SetDirty(true, true);
					spline.Refresh();
					Timer.Stop();
				}
			}
			Object.Destroy(spline.gameObject);
		}

		private CurvySpline getSpline()
		{
			CurvySpline curvySpline = CurvySpline.Create();
			curvySpline.Interpolation = mInterpolation;
			curvySpline.Orientation = mOrientation;
			curvySpline.CacheDensity = mCacheSize;
			curvySpline.UseThreading = mUseMultiThreads;
			curvySpline.Refresh();
			return curvySpline;
		}

		private void addRandomCP(ref CurvySpline spline, int count, int totalLength)
		{
			Vector3[] array = new Vector3[count];
			float num = (float)totalLength / (float)(count - 1);
			array[0] = Vector3.zero;
			for (int i = 1; i < count; i++)
			{
				int num2 = Random.Range(0, 2);
				int num3 = ((Random.Range(0f, 1f) > 0.5f) ? 1 : (-1));
				switch (num2)
				{
				case 0:
					array[i] = array[i - 1] + new Vector3(num * (float)num3, 0f, 0f);
					break;
				case 1:
					array[i] = array[i - 1] + new Vector3(0f, num * (float)num3, 0f);
					break;
				case 2:
					array[i] = array[i - 1] + new Vector3(0f, 0f, num * (float)num3);
					break;
				}
			}
			spline.Add(array);
			spline.Refresh();
		}

		private void runTest()
		{
			mRunMethod.Invoke(this, null);
			mExecuting = false;
		}
	}
}
