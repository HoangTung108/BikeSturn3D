using FluffyUnderware.Curvy.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace FluffyUnderware.Curvy.Examples
{
	public class PaintSpline : MonoBehaviour
	{
		public float StepDistance = 30f;

		public SplineController Controller;

		public Text InfoText;

		private CurvySpline mSpline;

		private Vector2 mLastControlPointPos;

		private bool mResetSpline = true;

		private void Awake()
		{
			mSpline = GetComponent<CurvySpline>();
		}

		private void OnGUI()
		{
			if (mSpline == null || !mSpline.IsInitialized || !Controller)
			{
				return;
			}
			Event current = Event.current;
			switch (current.type)
			{
			case EventType.MouseDrag:
				if (mResetSpline)
				{
					mSpline.Clear();
					Controller.gameObject.SetActive(true);
					Controller.Position = 0f;
					mLastControlPointPos = current.mousePosition;
					addCP(current.mousePosition);
					mResetSpline = false;
				}
				else
				{
					float magnitude = (current.mousePosition - mLastControlPointPos).magnitude;
					if (magnitude >= StepDistance)
					{
						mLastControlPointPos = current.mousePosition;
						addCP(current.mousePosition);
					}
				}
				break;
			case EventType.MouseUp:
				mResetSpline = true;
				break;
			}
		}

		private CurvySplineSegment addCP(Vector3 mousePos)
		{
			Vector3 localPosition = Camera.main.ScreenToWorldPoint(mousePos);
			localPosition.y *= -1f;
			CurvySplineSegment curvySplineSegment = mSpline.Add();
			curvySplineSegment.localPosition = localPosition;
			InfoText.text = "Control Points: " + mSpline.ControlPointCount;
			return curvySplineSegment;
		}

		public void ToggleAdaptOnChange()
		{
			if ((bool)Controller)
			{
				Controller.AdaptOnChange = !Controller.AdaptOnChange;
			}
		}
	}
}
