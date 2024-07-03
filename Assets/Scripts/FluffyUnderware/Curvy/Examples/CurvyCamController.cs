using FluffyUnderware.Curvy.Controllers;
using FluffyUnderware.DevTools;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace FluffyUnderware.Curvy.Examples
{
	public class CurvyCamController : SplineController
	{
		[Section("Curvy Cam", true, false, 100)]
		public float MinSpeed;

		public float MaxSpeed;

		public float Mass;

		public float Down;

		public float Up;

		public float Fric = 0.9f;

		private DepthOfField FX_DOF;

		protected override void OnEnable()
		{
			base.OnEnable();
			FX_DOF = GetComponent<DepthOfField>();
			base.Speed = MinSpeed;
		}

		protected override void Advance(ref float tf, ref int direction, MoveModeEnum mode, float absSpeed, CurvyClamping clamping)
		{
			base.Advance(ref tf, ref direction, mode, absSpeed, clamping);
			Vector3 tangent = GetTangent(tf);
			float num = ((!(tangent.y < 0f)) ? (Up * (0f - tangent.y) * Fric) : (Down * tangent.y * Fric));
			base.Speed = Mathf.Clamp(base.Speed + Mass * num * base.DeltaTime, MinSpeed, MaxSpeed);
			if (tf == 1f)
			{
				base.Speed = 0f;
			}
		}

		private void OnPreRender()
		{
			FX_DOF.aperture = Mathf.Lerp(0f, 15f, (base.Speed - MinSpeed) / (MaxSpeed - MinSpeed));
		}
	}
}
