using System.Collections;
using FluffyUnderware.Curvy.Controllers;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	[ExecuteInEditMode]
	public class TrainCarDrifter : MonoBehaviour
	{
		public float speed = 30f;

		public float wheelSpacing = 9.72f;

		public Vector3 bodyOffset = new Vector3(0f, 1f, 0f);

		public SplineController controllerWheelLeading;

		public SplineController controllerWheelTrailing;

		public Transform trainCar;

		private IEnumerator Start()
		{
			if ((bool)controllerWheelLeading)
			{
				while (!controllerWheelLeading.Spline.IsInitialized)
				{
					yield return 0;
				}
			}
			if ((bool)controllerWheelTrailing)
			{
				while (!controllerWheelTrailing.Spline.IsInitialized)
				{
					yield return 0;
				}
			}
			controllerWheelLeading.Speed = speed;
		}

		private void Update()
		{
			if ((bool)controllerWheelLeading && (bool)controllerWheelTrailing && (bool)controllerWheelLeading.Spline && (bool)controllerWheelTrailing.Spline && controllerWheelLeading.Spline != controllerWheelTrailing.Spline && controllerWheelLeading.Spline.IsInitialized && controllerWheelTrailing.Spline.IsInitialized && (bool)trainCar)
			{
				Vector3 p = controllerWheelTrailing.Spline.transform.InverseTransformPoint(controllerWheelLeading.transform.position);
				float nearestPointTF = controllerWheelTrailing.Spline.GetNearestPointTF(p);
				Vector3 b = controllerWheelTrailing.Spline.Interpolate(nearestPointTF);
				controllerWheelTrailing.RelativePosition = nearestPointTF;
				float num = Vector3.Distance(controllerWheelLeading.transform.position, b);
				float num2 = Mathf.Clamp(Mathf.Sqrt(wheelSpacing * wheelSpacing - num * num), 0f, 20f);
				controllerWheelTrailing.AbsolutePosition -= num2;
				trainCar.position = (controllerWheelLeading.transform.position + controllerWheelTrailing.transform.position) / 2f + bodyOffset;
				Vector3 worldPosition = new Vector3(controllerWheelLeading.transform.position.x, trainCar.transform.position.y, controllerWheelLeading.transform.position.z);
				trainCar.LookAt(worldPosition, controllerWheelLeading.transform.up);
			}
		}
	}
}
