using System.Collections;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	[ExecuteInEditMode]
	public class TrainManager : MonoBehaviour
	{
		public CurvySpline Spline;

		public float Speed;

		public float Position;

		public float CarSize = 10f;

		public float AxisDistance = 8f;

		public float CarGap = 1f;

		public float Limit = 0.2f;

		private TrainCarManager[] Cars;

		private void Awake()
		{
			setup();
		}

		private IEnumerator Start()
		{
			while (!Spline.IsInitialized)
			{
				yield return 0;
			}
			setup();
		}

		private void LateUpdate()
		{
			if (!Spline.IsInitialized || Cars.Length <= 1)
			{
				return;
			}
			TrainCarManager trainCarManager = Cars[0];
			TrainCarManager trainCarManager2 = Cars[Cars.Length - 1];
			if (!(trainCarManager.FrontAxis.Spline == trainCarManager2.BackAxis.Spline) || !(trainCarManager.FrontAxis.RelativePosition > trainCarManager2.BackAxis.RelativePosition))
			{
				return;
			}
			for (int i = 1; i < Cars.Length; i++)
			{
				float num = Cars[i - 1].Position - Cars[i].Position - CarSize - CarGap;
				if (Mathf.Abs(num) >= Limit)
				{
					Cars[i].Position += num;
				}
			}
		}

		private void setup()
		{
			Cars = GetComponentsInChildren<TrainCarManager>();
			float num = Position - CarSize / 2f;
			for (int i = 0; i < Cars.Length; i++)
			{
				Cars[i].setup();
				Cars[i].Position = num;
				num -= CarSize + CarGap;
			}
		}
	}
}
