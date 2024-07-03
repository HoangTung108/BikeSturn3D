using System.Collections;
using FluffyUnderware.Curvy.Controllers;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	public class SplineControllerInputRail : MonoBehaviour
	{
		public float acceleration = 0.1f;

		public float limit = 30f;

		public SplineController splineController;

		private IEnumerator Start()
		{
			while (!splineController.IsInitialized)
			{
				yield return 0;
			}
		}

		private void Update()
		{
			float num = Mathf.Clamp(Input.GetAxis("Vertical"), -1f, 1f);
			splineController.Speed = Mathf.Clamp(splineController.Speed + num * acceleration * Time.deltaTime, 0.001f, limit);
		}
	}
}
