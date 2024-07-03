using System;

namespace FluffyUnderware.Curvy
{
	[Flags]
	public enum CurvySplineGizmos
	{
		None = 0x0,
		Curve = 0x2,
		Approximation = 0x4,
		Tangents = 0x8,
		Orientation = 0x10,
		Labels = 0x20,
		[Obsolete("Use Metadata instead")]
		UserValues = 0x40,
		Metadata = 0x40,
		Bounds = 0x80,
		All = 0xFFFF
	}
}
