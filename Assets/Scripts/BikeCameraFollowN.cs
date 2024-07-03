using System.Collections.Generic;
using UnityEngine;

public class BikeCameraFollowN : MonoBehaviour
{
	public Transform target;

	public float smooth = 0.3f;

	public float distance = 5f;

	public float height = 1f;

	public float Angle = 20f;

	public List<Transform> cameraSwitchView;

	public LayerMask lineOfSightMask = 0;

	private float yVelocity;

	private float xVelocity;

	[HideInInspector]
	public int Switch;

	public BikeControlN bikeScript;

	public void CameraSwitch()
	{
		Switch++;
		if (Switch > cameraSwitchView.Count)
		{
			Switch = 0;
		}
	}

	public void setTarget(Transform targetP)
	{
		target = targetP;
		bikeScript = target.GetComponent<BikeControlN>();
		cameraSwitchView = bikeScript.bikeSetting.cameraSwitchView;
	}

	private void InitControls()
	{
		bikeScript = target.GetComponent<BikeControlN>();
		cameraSwitchView = bikeScript.bikeSetting.cameraSwitchView;
	}

	private void Update()
	{
		if (!target)
		{
			return;
		}
		bikeScript = target.GetComponent<BikeControlN>();
		GetComponent<Camera>().fieldOfView = Mathf.Clamp(bikeScript.speed / 10f + 60f, 60f, 90f);
		if (Input.GetKeyDown(KeyCode.C))
		{
			Switch++;
			if (Switch > cameraSwitchView.Count)
			{
				Switch = 0;
			}
		}
		if (!bikeScript.crash)
		{
			if (Switch == 0)
			{
				float num = Mathf.SmoothDampAngle(base.transform.eulerAngles.x, target.eulerAngles.x + Angle, ref xVelocity, smooth);
				float y = Mathf.SmoothDampAngle(base.transform.eulerAngles.y, target.eulerAngles.y, ref yVelocity, smooth);
				base.transform.eulerAngles = new Vector3(Angle, y, 0f);
				Vector3 vector = base.transform.rotation * -Vector3.forward;
				float num2 = AdjustLineOfSight(target.position + new Vector3(0f, height, 0f), vector);
				base.transform.position = target.position + new Vector3(0f, height, 0f) + vector * num2;
			}
			else
			{
				base.transform.position = cameraSwitchView[Switch - 1].position;
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, cameraSwitchView[Switch - 1].rotation, Time.deltaTime * 5f);
			}
		}
		else
		{
			Vector3 forward = target.position - base.transform.position;
			base.transform.rotation = Quaternion.LookRotation(forward);
		}
	}

	private float AdjustLineOfSight(Vector3 target, Vector3 direction)
	{
		RaycastHit hitInfo;
		if (Physics.Raycast(target, direction, out hitInfo, distance, lineOfSightMask.value))
		{
			return hitInfo.distance;
		}
		return distance;
	}
}
