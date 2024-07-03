using FluffyUnderware.Curvy.Controllers;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	public class UserValuesController : SplineController
	{
		[RangeEx(0f, 30f, "", "")]
		[SerializeField]
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
			Vector3 vector = base.Spline.InterpolateUserValue(base.RelativePosition, 0);
			base.transform.Translate(0f, vector.x * MaxHeight, 0f, Space.Self);
		}
	}
}
