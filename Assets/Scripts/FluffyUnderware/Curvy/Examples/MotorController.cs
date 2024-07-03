using FluffyUnderware.Curvy.Controllers;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	public class MotorController : SplineController
	{
		[Section("Motor", true, false, 100)]
		public float MaxSpeed = 30f;

		protected override void Update()
		{
			base.Speed = Input.GetAxis("Vertical") * MaxSpeed;
			base.Update();
		}
	}
}
