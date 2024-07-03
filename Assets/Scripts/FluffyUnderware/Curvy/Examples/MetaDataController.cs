using FluffyUnderware.Curvy.Controllers;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	public class MetaDataController : SplineController
	{
		[RangeEx(0f, 30f, "", "")]
		[SerializeField]
		[Section("MetaController", true, false, 100, Sort = 0)]
		private float m_MaxHeight = 5f;

		public float MaxHeight
		{
			get
			{
				return m_MaxHeight;
			}
			set
			{
				if (m_MaxHeight != value)
				{
					m_MaxHeight = value;
				}
			}
		}

		protected override void UserAfterInit()
		{
			setHeight();
		}

		protected override void UserAfterUpdate()
		{
			setHeight();
		}

		private void setHeight()
		{
			float num = base.Spline.InterpolateMetadata<HeightMetadata, float>(base.RelativePosition);
			base.transform.Translate(0f, num * MaxHeight, 0f, Space.Self);
		}
	}
}
