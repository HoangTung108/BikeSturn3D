using UnityEngine;

public class CameraRot : MonoBehaviour
{
	private bool clicked;

	private float xAxis;

	private float yAxis;

	public SmoothFollowMenu SmoothFollowCamera;

	public GameObject RotatePanel;

	public Transform CarCamObj;

	private float xSpeed;

	private float yspeed;

	private bool AutoRotate = true;

	private void Start()
	{
		xSpeed = 65f;
		yspeed = 10f;
		yAxis = 1f;
	}

	private void LateUpdate()
	{
		if (clicked)
		{
			xAxis += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
			yAxis -= Input.GetAxis("Mouse Y") * yspeed * Time.deltaTime;
			CarCamObj.rotation = Quaternion.Euler(0f, xAxis, 0f);
			yAxis = Mathf.Clamp(yAxis, 0f, 2f);
			SmoothFollowCamera.GetComponent<SmoothFollowMenu>().height = yAxis;
		}
		else
		{
			xAxis = CarCamObj.eulerAngles.y;
		}
		if (AutoRotate)
		{
			xAxis += 7.5f * Time.deltaTime;
			CarCamObj.rotation = Quaternion.Euler(0f, xAxis, 0f);
		}
	}

	public void Click1()
	{
		clicked = true;
		AutoRotate = false;
	}

	public void click2()
	{
		clicked = false;
		AutoRotate = true;
	}
}
