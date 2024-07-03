using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	public class HeightMetadata : CurvyMetadataBase, ICurvyInterpolatableMetadata<float>, ICurvyInterpolatableMetadata, ICurvyMetadata
	{
		[RangeEx(0f, 1f, "", "", Slider = true)]
		[SerializeField]
		private float m_Height;

		public object Value
		{
			get
			{
				return m_Height;
			}
		}

		public object InterpolateObject(ICurvyMetadata b, float f)
		{
			HeightMetadata heightMetadata = b as HeightMetadata;
			return (!(heightMetadata != null)) ? Value : ((object)Mathf.Lerp((float)Value, (float)heightMetadata.Value, f));
		}

		public float Interpolate(ICurvyMetadata b, float f)
		{
			return (float)InterpolateObject(b, f);
		}
	}
}
