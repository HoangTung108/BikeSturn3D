using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BikeCamera : MonoBehaviour
{
	[Serializable]
	public class BikeUIClass
	{
		public Image tachometerNeedle;

		public Image barShiftGUI;

		public Text speedText;

		public Text GearText;
	}

	public Transform target;

	public Transform BikerMan;

	public float smooth = 0.3f;

	public float distance = 5f;

	public float height = 1f;

	public float Angle = 20f;

	public List<Transform> cameraSwitchView;

	public BikeUIClass BikeUI;

	public LayerMask lineOfSightMask = 0;

	private float yVelocity;

	private float xVelocity;

	[HideInInspector]
	public int Switch;

	private int gearst;

	private float thisAngle = -150f;

	private float restTime;

	private Rigidbody myRigidbody;

	private BikeControl bikeScript;

	private int PLValue;

	public void PoliceLightSwitch()
	{
		if ((bool)target.gameObject.GetComponent<PoliceLights>())
		{
			PLValue++;
			if (PLValue > 1)
			{
				PLValue = 0;
			}
			if (PLValue == 1)
			{
				target.gameObject.GetComponent<PoliceLights>().activeLight = true;
			}
			if (PLValue == 0)
			{
				target.gameObject.GetComponent<PoliceLights>().activeLight = false;
			}
		}
	}

	public void CameraSwitch()
	{
		Switch++;
		if (Switch > cameraSwitchView.Count)
		{
			Switch = 0;
		}
	}

	public void BikeAccelForward(float amount)
	{
		bikeScript.accelFwd = amount;
	}

	public void BikeAccelBack(float amount)
	{
		bikeScript.accelBack = amount;
	}

	public void BikeSteer(float amount)
	{
		bikeScript.steerAmount = amount;
	}

	public void BikeHandBrake(bool HBrakeing)
	{
		bikeScript.brake = HBrakeing;
	}

	public void BikeShift(bool Shifting)
	{
		bikeScript.shift = Shifting;
	}

	public void RestBike()
	{
		if (restTime == 0f)
		{
			myRigidbody.AddForce(Vector3.up * 500000f);
			myRigidbody.MoveRotation(Quaternion.Euler(0f, base.transform.eulerAngles.y, 0f));
			restTime = 2f;
		}
	}

	public void ShowBikeUI()
	{
		gearst = bikeScript.currentGear;
		BikeUI.speedText.text = ((int)bikeScript.speed).ToString();
		if (bikeScript.bikeSetting.automaticGear)
		{
			if (gearst > 0 && bikeScript.speed > 1f)
			{
				BikeUI.GearText.color = Color.green;
				BikeUI.GearText.text = gearst.ToString();
			}
			else if (bikeScript.speed > 1f)
			{
				BikeUI.GearText.color = Color.red;
				BikeUI.GearText.text = "R";
			}
			else
			{
				BikeUI.GearText.color = Color.white;
				BikeUI.GearText.text = "N";
			}
		}
		else if (bikeScript.NeutralGear)
		{
			BikeUI.GearText.color = Color.white;
			BikeUI.GearText.text = "N";
		}
		else if (bikeScript.currentGear != 0)
		{
			BikeUI.GearText.color = Color.green;
			BikeUI.GearText.text = gearst.ToString();
		}
		else
		{
			BikeUI.GearText.color = Color.red;
			BikeUI.GearText.text = "R";
		}
		thisAngle = bikeScript.motorRPM / 20f - 175f;
		thisAngle = Mathf.Clamp(thisAngle, -180f, 90f);
		BikeUI.tachometerNeedle.rectTransform.rotation = Quaternion.Euler(0f, 0f, 0f - thisAngle);
		BikeUI.barShiftGUI.rectTransform.localScale = new Vector3(bikeScript.powerShift / 100f, 1f, 1f);
	}

	private void Start()
	{
		bikeScript = target.GetComponent<BikeControl>();
		myRigidbody = target.GetComponent<Rigidbody>();
		cameraSwitchView = bikeScript.bikeSetting.cameraSwitchView;
		BikerMan = bikeScript.bikeSetting.bikerMan;
	}

	private void Update()
	{
		if (!target)
		{
			return;
		}
		bikeScript = target.GetComponent<BikeControl>();
		myRigidbody = target.GetComponent<Rigidbody>();
		if (Input.GetKeyDown(KeyCode.G))
		{
			RestBike();
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			PoliceLightSwitch();
		}
		if (restTime != 0f)
		{
			restTime = Mathf.MoveTowards(restTime, 0f, Time.deltaTime);
		}
		ShowBikeUI();
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
			Vector3 forward = BikerMan.position - base.transform.position;
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
