using System;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Utils
{
	public class CurvyUtility
	{
		public static float ClampTF(float tf, CurvyClamping clamping)
		{
			switch (clamping)
			{
			case CurvyClamping.Loop:
				return Mathf.Repeat(tf, 1f);
			case CurvyClamping.PingPong:
				return Mathf.PingPong(tf, 1f);
			default:
				return Mathf.Clamp01(tf);
			}
		}

		public static float ClampValue(float tf, CurvyClamping clamping, float minTF, float maxTF)
		{
			switch (clamping)
			{
			case CurvyClamping.Loop:
			{
				float t2 = DTMath.MapValue(0f, 1f, tf, minTF, maxTF);
				return DTMath.MapValue(minTF, maxTF, Mathf.Repeat(t2, 1f), 0f, 1f);
			}
			case CurvyClamping.PingPong:
			{
				float t = DTMath.MapValue(0f, 1f, tf, minTF, maxTF);
				return DTMath.MapValue(minTF, maxTF, Mathf.PingPong(t, 1f), 0f, 1f);
			}
			default:
				return Mathf.Clamp(tf, minTF, maxTF);
			}
		}

		public static float ClampTF(float tf, ref int dir, CurvyClamping clamping)
		{
			switch (clamping)
			{
			case CurvyClamping.Loop:
				return Mathf.Repeat(tf, 1f);
			case CurvyClamping.PingPong:
				if (Mathf.FloorToInt(tf) % 2 != 0)
				{
					dir *= -1;
				}
				return Mathf.PingPong(tf, 1f);
			default:
				return Mathf.Clamp01(tf);
			}
		}

		public static float ClampTF(float tf, ref int dir, CurvyClamping clamping, float minTF, float maxTF)
		{
			minTF = Mathf.Clamp01(minTF);
			maxTF = Mathf.Clamp(maxTF, minTF, 1f);
			switch (clamping)
			{
			case CurvyClamping.Loop:
				return minTF + Mathf.Repeat(tf, maxTF - minTF);
			case CurvyClamping.PingPong:
				if (Mathf.FloorToInt(tf / (maxTF - minTF)) % 2 != 0)
				{
					dir *= -1;
				}
				return minTF + Mathf.PingPong(tf, maxTF - minTF);
			default:
				return Mathf.Clamp(tf, minTF, maxTF);
			}
		}

		public static float ClampDistance(float distance, CurvyClamping clamping, float length)
		{
			if (length == 0f)
			{
				return 0f;
			}
			switch (clamping)
			{
			case CurvyClamping.Loop:
				return Mathf.Repeat(distance, length);
			case CurvyClamping.PingPong:
				return Mathf.PingPong(distance, length);
			default:
				return Mathf.Clamp(distance, 0f, length);
			}
		}

		public static float ClampDistance(float distance, CurvyClamping clamping, float length, float min, float max)
		{
			if (length == 0f)
			{
				return 0f;
			}
			min = Mathf.Clamp(min, 0f, length);
			max = Mathf.Clamp(max, min, length);
			switch (clamping)
			{
			case CurvyClamping.Loop:
				return min + Mathf.Repeat(distance, max - min);
			case CurvyClamping.PingPong:
				return min + Mathf.PingPong(distance, max - min);
			default:
				return Mathf.Clamp(distance, min, max);
			}
		}

		public static float ClampDistance(float distance, ref int dir, CurvyClamping clamping, float length)
		{
			if (length == 0f)
			{
				return 0f;
			}
			switch (clamping)
			{
			case CurvyClamping.Loop:
				return Mathf.Repeat(distance, length);
			case CurvyClamping.PingPong:
				if (Mathf.FloorToInt(distance / length) % 2 != 0)
				{
					dir *= -1;
				}
				return Mathf.PingPong(distance, length);
			default:
				return Mathf.Clamp(distance, 0f, length);
			}
		}

		public static float ClampDistance(float distance, ref int dir, CurvyClamping clamping, float length, float min, float max)
		{
			if (length == 0f)
			{
				return 0f;
			}
			min = Mathf.Clamp(min, 0f, length);
			max = Mathf.Clamp(max, min, length);
			switch (clamping)
			{
			case CurvyClamping.Loop:
				return min + Mathf.Repeat(distance, max - min);
			case CurvyClamping.PingPong:
				if (Mathf.FloorToInt(distance / (max - min)) % 2 != 0)
				{
					dir *= -1;
				}
				return min + Mathf.PingPong(distance, max - min);
			default:
				return Mathf.Clamp(distance, min, max);
			}
		}

		public static Material GetDefaultMaterial()
		{
			Material material = Resources.Load("CurvyDefaultMaterial") as Material;
			if (material == null)
			{
				material = new Material(Shader.Find("Diffuse"));
			}
			return material;
		}

		[Obsolete("Use CurvySpline.IsPlanar() instead")]
		public static bool IsPlanar(CurvySpline spline, out int ignoreAxis)
		{
			return spline.IsPlanar(out ignoreAxis);
		}

		[Obsolete("Use CurvySpline.IsPlanar() instead")]
		public static bool IsPlanar(CurvySpline spline, out bool xplanar, out bool yplanar, out bool zplanar)
		{
			return spline.IsPlanar(out xplanar, out yplanar, out zplanar);
		}

		[Obsolete("Use CurvySpline.MakePlanar() instead!")]
		public static void MakePlanar(CurvySpline spline, int axis)
		{
			spline.MakePlanar(axis);
		}

		[Obsolete("Use CurvySpline.SetPivot() instead!")]
		public static Vector3 SetPivot(CurvySpline spline, float xPercent = 0f, float yPercent = 0f, float zPercent = 0f, bool preview = false)
		{
			return spline.SetPivot(xPercent, yPercent, zPercent, preview);
		}

		[Obsolete("Use CurvySpline.SetPivot() instead!")]
		public static void CenterPivot(CurvySpline spline)
		{
			spline.SetPivot(0f, 0f, 0f, false);
		}

		[Obsolete("Use CurvySplineSegment.SetAsFirstCP() instead!")]
		public static void SetFirstCP(CurvySplineSegment newStartCP)
		{
			if ((bool)newStartCP)
			{
				newStartCP.SetAsFirstCP();
			}
		}

		[Obsolete("Use CurvySpline.Flip() instead")]
		public static void FlipSpline(CurvySpline spline)
		{
			spline.Flip();
		}

		[Obsolete("Use CurvySplineSegment.SplitSpline() instead!")]
		public static CurvySpline SplitSpline(CurvySplineSegment firstCP)
		{
			return firstCP.SplitSpline();
		}

		[Obsolete("Use CurvySpline.MoveControlPoints() instead!")]
		public static void MoveControlPoints(CurvySpline source, int startIndex, int count, CurvySplineSegment destCP)
		{
			source.MoveControlPoints(startIndex, count, destCP);
		}

		[Obsolete("Use CurvySpline.JoinWith() instead!")]
		public static void JoinSpline(CurvySpline source, CurvySplineSegment destCP)
		{
			source.JoinWith(destCP);
		}

		[Obsolete("Use CurvySplineSegment.SetBezierHandles() instead!")]
		public static void InterpolateBezierHandles(CurvyInterpolation interpolation, float offset, bool? freeMoveHandles, params CurvySplineSegment[] controlPoints)
		{
			if (controlPoints.Length == 0)
			{
				return;
			}
			offset = Mathf.Clamp01(offset);
			foreach (CurvySplineSegment curvySplineSegment in controlPoints)
			{
				bool flag = (curvySplineSegment.FreeHandles = ((!freeMoveHandles.HasValue) ? curvySplineSegment.FreeHandles : freeMoveHandles.Value));
				CurvySplineSegment previousSegment = curvySplineSegment.PreviousSegment;
				if ((bool)previousSegment)
				{
					curvySplineSegment.HandleIn = previousSegment.Interpolate(1f - offset, interpolation) - curvySplineSegment.transform.localPosition;
				}
				else
				{
					curvySplineSegment.HandleIn = curvySplineSegment.Interpolate(0f, interpolation);
				}
				if (curvySplineSegment.FreeHandles)
				{
					if (curvySplineSegment.IsValidSegment)
					{
						curvySplineSegment.HandleOut = curvySplineSegment.Interpolate(offset, interpolation) - curvySplineSegment.transform.localPosition;
					}
					else
					{
						curvySplineSegment.HandleIn = Vector3.zero;
					}
				}
			}
			controlPoints[0].Spline.Refresh();
		}
	}
}
