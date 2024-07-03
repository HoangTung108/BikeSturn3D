using System.Collections;
using FluffyUnderware.Curvy.Controllers;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	public class RunnerController : SplineController
	{
		private enum GuideMode
		{
			Guided,
			Jumping,
			FreeFall
		}

		[Section("Jump", true, false, 100)]
		public float JumpHeight = 20f;

		public float JumpSpeed = 0.5f;

		public AnimationCurve JumpCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		public float Gravity = 10f;

		private GuideMode mMode;

		private GuideMode mNewMode;

		private float mHeightOverGround;

		private float mDownSpeed;

		private SplineRefMetadata mPossibleSwitchTarget;

		private CurvySpline mFreeFallTarget;

		private int mSwitchInProgress;

		protected override void OnDisable()
		{
			base.OnDisable();
			StopAllCoroutines();
		}

		protected override void Update()
		{
			if (Input.GetButtonDown("Fire1") && mMode == GuideMode.Guided)
			{
				StartCoroutine(Jump());
			}
			if (mPossibleSwitchTarget != null && mSwitchInProgress == 0)
			{
				float axisRaw = Input.GetAxisRaw("Horizontal");
				if (mPossibleSwitchTarget.Options == "Right" && axisRaw > 0f)
				{
					Switch(1);
				}
				else if (mPossibleSwitchTarget.Options == "Left" && axisRaw < 0f)
				{
					Switch(-1);
				}
			}
			else if (mSwitchInProgress != 0 && !base.IsSwitching)
			{
				mSwitchInProgress = 0;
				OnCPReached(new CurvySplineMoveEventArgs(this, base.Spline, base.Spline.TFToSegment(base.RelativePosition), 0f, 0f, 0));
			}
			if (mMode != GuideMode.FreeFall)
			{
				base.Update();
				if (mHeightOverGround > 0f && mMode == GuideMode.Jumping)
				{
					base.transform.Translate(new Vector3(0f, mHeightOverGround, 0f), Space.Self);
				}
				return;
			}
			mDownSpeed += Gravity * Time.deltaTime;
			base.transform.Translate(new Vector3(0f, 0f - mDownSpeed, base.Speed * Time.deltaTime));
			Vector3 vector = mFreeFallTarget.transform.InverseTransformPoint(base.transform.position);
			Vector3 nearest;
			float nearestPointTF = mFreeFallTarget.GetNearestPointTF(vector, out nearest);
			if ((nearest - vector).magnitude <= 2f)
			{
				base.Spline = mFreeFallTarget;
				base.RelativePosition = nearestPointTF;
				mMode = GuideMode.Guided;
				mDownSpeed = 0f;
				mFreeFallTarget = null;
			}
		}

		private void Switch(int dir)
		{
			mSwitchInProgress = dir;
			Vector3 vector = mPossibleSwitchTarget.Spline.transform.InverseTransformPoint(base.transform.position);
			Vector3 nearest;
			float nearestPointTF = mPossibleSwitchTarget.Spline.GetNearestPointTF(vector, out nearest, mPossibleSwitchTarget.CP.SegmentIndex);
			float duration = (nearest - vector).magnitude / base.Speed;
			SwitchTo(mPossibleSwitchTarget.Spline, nearestPointTF, duration);
		}

		private IEnumerator Jump()
		{
			mMode = GuideMode.Jumping;
			mNewMode = GuideMode.Guided;
			float start = Time.time;
			float f = 0f;
			while (f < 1f)
			{
				f = (Time.time - start) / JumpSpeed;
				mHeightOverGround = JumpCurve.Evaluate(f) * JumpHeight;
				yield return new WaitForEndOfFrame();
			}
			mMode = mNewMode;
			mDownSpeed = 0f;
		}

		public void OnCPReached(CurvySplineMoveEventArgs e)
		{
			mPossibleSwitchTarget = e.ControlPoint.GetMetadata<SplineRefMetadata>(false);
			if ((bool)mPossibleSwitchTarget && !mPossibleSwitchTarget.Spline)
			{
				mPossibleSwitchTarget = null;
			}
		}

		public void UseFollowUpOrFall(CurvySplineMoveEventArgs e)
		{
			if (!(e.Sender is SplineController))
			{
				return;
			}
			if ((bool)e.ControlPoint.FollowUp)
			{
				e.Follow(e.ControlPoint.FollowUp, e.ControlPoint.FollowUpHeading);
				SplineController splineController = (SplineController)e.Sender;
				splineController.Spline = e.Spline;
				splineController.RelativePosition = e.TF;
				splineController.OnControlPointReached.Invoke(e);
			}
			else if ((bool)e.ControlPoint.Connection)
			{
				CurvySplineSegment curvySplineSegment = e.ControlPoint.Connection.OtherControlPoints(e.ControlPoint)[0];
				mFreeFallTarget = curvySplineSegment.Spline;
				if (mMode == GuideMode.Jumping)
				{
					e.Follow(curvySplineSegment);
					base.Spline = mFreeFallTarget;
					base.RelativePosition = curvySplineSegment.LocalFToTF(0f);
					mNewMode = GuideMode.FreeFall;
				}
				else
				{
					mMode = GuideMode.FreeFall;
				}
			}
			else
			{
				Debug.Log("YOU DIED!");
				Application.Quit();
			}
		}
	}
}
