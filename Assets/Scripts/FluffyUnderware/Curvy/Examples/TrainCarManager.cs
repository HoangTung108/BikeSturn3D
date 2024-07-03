using FluffyUnderware.Curvy.Components;
using FluffyUnderware.Curvy.Controllers;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	[ExecuteInEditMode]
	public class TrainCarManager : MonoBehaviour
	{
		public SplineController Waggon;

		public SplineController FrontAxis;

		public SplineController BackAxis;

		private TrainManager mTrain;

		public float Position
		{
			get
			{
				return Waggon.AbsolutePosition;
			}
			set
			{
				if (Waggon.AbsolutePosition != value)
				{
					setPos(Waggon, value);
					setPos(FrontAxis, value + mTrain.AxisDistance / 2f);
					setPos(BackAxis, value - mTrain.AxisDistance / 2f);
				}
			}
		}

		private void LateUpdate()
		{
			if ((bool)mTrain && BackAxis.Spline == FrontAxis.Spline && FrontAxis.RelativePosition > BackAxis.RelativePosition)
			{
				float absolutePosition = Waggon.AbsolutePosition;
				float absolutePosition2 = FrontAxis.AbsolutePosition;
				float absolutePosition3 = BackAxis.AbsolutePosition;
				if (Mathf.Abs(Mathf.Abs(absolutePosition2 - absolutePosition3) - mTrain.AxisDistance) >= mTrain.Limit)
				{
					float num = absolutePosition2 - absolutePosition - mTrain.AxisDistance / 2f;
					float delta = absolutePosition - absolutePosition3 - mTrain.AxisDistance / 2f;
					FrontAxis.Warp(0f - num);
					BackAxis.Warp(delta);
				}
			}
		}

		public void setup()
		{
			mTrain = GetComponentInParent<TrainManager>();
			if ((bool)mTrain.Spline)
			{
				setController(Waggon, mTrain.Spline, mTrain.Speed);
				setController(FrontAxis, mTrain.Spline, mTrain.Speed);
				setController(BackAxis, mTrain.Spline, mTrain.Speed);
			}
		}

		private void setPos(SplineController c, float pos)
		{
			if (c.IsPlaying)
			{
				c.Position = pos;
			}
			else
			{
				c.InitialPosition = pos;
			}
		}

		private void setController(SplineController c, CurvySpline spline, float speed)
		{
			c.Spline = spline;
			c.Speed = speed;
			c.OnControlPointReached.AddListenerOnce(OnCPReached);
			c.OnEndReached.AddListenerOnce(CurvyDefaultEventHandler.UseFollowUpStatic);
		}

		private void OnCPReached(CurvySplineMoveEventArgs e)
		{
			MDJunctionControl metadata = e.ControlPoint.GetMetadata<MDJunctionControl>(false);
			if ((bool)metadata && metadata.UseJunction)
			{
				e.Follow(e.ControlPoint.Connection.OtherControlPoints(e.ControlPoint)[0]);
				SplineController splineController = (SplineController)e.Sender;
				splineController.Spline = e.Spline;
				splineController.RelativePosition = e.TF;
			}
		}
	}
}
