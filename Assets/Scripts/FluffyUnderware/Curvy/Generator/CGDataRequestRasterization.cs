using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	public class CGDataRequestRasterization : CGDataRequestParameter
	{
		public enum ModeEnum
		{
			Even,
			Optimized
		}

		public float Start;

		public float Length;

		public int Resolution;

		public float AngleThreshold;

		public ModeEnum Mode;

		public CGDataRequestRasterization(float start, float length, int resolution, float angle, ModeEnum mode = ModeEnum.Even)
		{
			Start = Mathf.Repeat(start, 1f);
			Length = Mathf.Clamp01(length);
			Resolution = resolution;
			AngleThreshold = angle;
			Mode = mode;
		}

		public CGDataRequestRasterization(CGDataRequestRasterization source)
			: this(source.Start, source.Length, source.Resolution, source.AngleThreshold, source.Mode)
		{
		}

		public static CGDataRequestRasterization RequestEven(float start, float length, int samplePoints)
		{
			return new CGDataRequestRasterization(start, length, samplePoints, 0f);
		}

		public static CGDataRequestRasterization RequestOptimized(float start, float length, int resolution, float angle)
		{
			return new CGDataRequestRasterization(start, length, resolution, angle, ModeEnum.Optimized);
		}

		public override bool Equals(object obj)
		{
			CGDataRequestRasterization cGDataRequestRasterization = obj as CGDataRequestRasterization;
			if (cGDataRequestRasterization == null)
			{
				return false;
			}
			return Start == cGDataRequestRasterization.Start && Length == cGDataRequestRasterization.Length && Resolution == cGDataRequestRasterization.Resolution && AngleThreshold == cGDataRequestRasterization.AngleThreshold && Mode == cGDataRequestRasterization.Mode;
		}

		public override int GetHashCode()
		{
			return new _003C_003E__AnonType1<float, float, int, float, ModeEnum>(Start, Length, Resolution, AngleThreshold, Mode).GetHashCode();
		}
	}
}
