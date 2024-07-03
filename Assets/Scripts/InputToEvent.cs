using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InputToEvent : MonoBehaviour
{
	private GameObject lastGo;

	public static Vector3 inputHitPos;

	public bool DetectPointedAtGameObject;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static GameObject _003CgoPointedAt_003Ek__BackingField;

	private Vector2 pressedPosition = Vector2.zero;

	private Vector2 currentPos = Vector2.zero;

	public bool Dragging;

	private Camera m_Camera;

	public static GameObject goPointedAt
	{
		[CompilerGenerated]
		get
		{
			return _003CgoPointedAt_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CgoPointedAt_003Ek__BackingField = value;
		}
	}

	public Vector2 DragVector
	{
		get
		{
			return (!Dragging) ? Vector2.zero : (currentPos - pressedPosition);
		}
	}

	private void Start()
	{
		m_Camera = GetComponent<Camera>();
	}

	private void Update()
	{
		if (DetectPointedAtGameObject)
		{
			goPointedAt = RaycastObject(Input.mousePosition);
		}
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			currentPos = touch.position;
			if (touch.phase == TouchPhase.Began)
			{
				Press(touch.position);
			}
			else if (touch.phase == TouchPhase.Ended)
			{
				Release(touch.position);
			}
			return;
		}
		currentPos = Input.mousePosition;
		if (Input.GetMouseButtonDown(0))
		{
			Press(Input.mousePosition);
		}
		if (Input.GetMouseButtonUp(0))
		{
			Release(Input.mousePosition);
		}
		if (Input.GetMouseButtonDown(1))
		{
			pressedPosition = Input.mousePosition;
			lastGo = RaycastObject(pressedPosition);
			if (lastGo != null)
			{
				lastGo.SendMessage("OnPressRight", SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	private void Press(Vector2 screenPos)
	{
		pressedPosition = screenPos;
		Dragging = true;
		lastGo = RaycastObject(screenPos);
		if (lastGo != null)
		{
			lastGo.SendMessage("OnPress", SendMessageOptions.DontRequireReceiver);
		}
	}

	private void Release(Vector2 screenPos)
	{
		if (lastGo != null)
		{
			GameObject gameObject = RaycastObject(screenPos);
			if (gameObject == lastGo)
			{
				lastGo.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
			}
			lastGo.SendMessage("OnRelease", SendMessageOptions.DontRequireReceiver);
			lastGo = null;
		}
		pressedPosition = Vector2.zero;
		Dragging = false;
	}

	private GameObject RaycastObject(Vector2 screenPos)
	{
		RaycastHit hitInfo;
		if (Physics.Raycast(m_Camera.ScreenPointToRay(screenPos), out hitInfo, 200f))
		{
			inputHitPos = hitInfo.point;
			return hitInfo.collider.gameObject;
		}
		return null;
	}
}
