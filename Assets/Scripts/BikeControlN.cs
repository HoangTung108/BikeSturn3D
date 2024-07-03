using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BikeControlN : MonoBehaviour
{
	[Serializable]
	public class BikeWheels
	{
		public ConnectWheel wheels;

		public WheelSetting setting;
	}

	[Serializable]
	public class ConnectWheel
	{
		public Transform wheelFront;

		public Transform wheelBack;

		public Transform AxleFront;

		public Transform AxleBack;
	}

	[Serializable]
	public class WheelSetting
	{
		public float Radius = 0.3f;

		public float Weight = 1000f;

		public float Distance = 0.2f;
	}

	[Serializable]
	public class BikeLights
	{
		public Light[] brakeLights;
	}

	[Serializable]
	public class BikeSounds
	{
		public AudioSource IdleEngine;

		public AudioSource LowEngine;

		public AudioSource HighEngine;

		public AudioSource lowCrash;

		public AudioSource nitro;

		public AudioSource switchGear;
	}

	[Serializable]
	public class BikeParticles
	{
		public GameObject brakeParticlePrefab;

		public ParticleSystem shiftParticle1;

		public ParticleSystem shiftParticle2;
	}

	[Serializable]
	public class HitGround
	{
		public string tag = "street";

		public bool grounded;

		public AudioClip brakeSound;

		public AudioClip groundSound;

		public Color brakeColor;
	}

	[Serializable]
	public class BikeSetting
	{
		public bool showNormalGizmos;

		public HitGround[] hitGround;

		public Transform bikerMan;

		public List<Transform> cameraSwitchView;

		public Transform MainBody;

		public Transform bikeSteer;

		public float maxWheelie = 40f;

		public float speedWheelie = 30f;

		public float slipBrake = 3f;

		public float springs = 35000f;

		public float dampers = 4000f;

		public float bikePower = 120f;

		public float shiftPower = 150f;

		public float brakePower = 8000f;

		public Vector3 shiftCentre = new Vector3(0f, -0.6f, 0f);

		public float maxSteerAngle = 30f;

		public float maxTurn = 1.5f;

		public float shiftDownRPM = 1500f;

		public float shiftUpRPM = 4000f;

		public float idleRPM = 700f;

		public float stiffness = 1f;

		public bool automaticGear = true;

		public float[] gears = new float[6] { -10f, 9f, 6f, 4.5f, 3f, 2.5f };

		public float LimitBackwardSpeed = 60f;

		public float LimitForwardSpeed = 220f;
	}

	private class WheelComponent
	{
		public Transform wheel;

		public Transform axle;

		public WheelCollider collider;

		public Vector3 startPos;

		public float rotation;

		public float maxSteer;

		public bool drive;

		public float pos_y;
	}

	//private PhotonView m_PhotonView;

	public GameObject Winobj;

	public GameObject Loseobj;

	public Text P1Name;

	public Text P2Name;

	public Text P1Pos;

	public Text P2Pos;

	public BikeUIControllerN BikeUIControllerScript;

	public BikeCameraFollowN BikeCameraFollowNScript;

	public static int Counter;

	public int RaceWinCounter_1;

	public int RaceWinCounter_2;

	public static int StaticHostCounterz;

	public static int StaticClienttCounterz;

	private Vector3 velocity;

	public bool rampStart;

	public bool junctionBool;

	public bool BikeFallBool;

	public int CheckpointCounter;

	public static int CheckDistanceCounter;

	public ControlModeN controlMode = ControlModeN.simple;

	public bool activeControl;

	public bool ParachuteBool;

	public BikeWheels bikeWheels;

	public BikeLights bikeLights;

	public BikeSounds bikeSounds;

	public BikeParticles bikeParticles;

	private GameObject[] Particle = new GameObject[4];

	public GameObject shiftParticle1Obj;

	public GameObject shiftParticle2Obj;

	public BikeSetting bikeSetting;

	private Quaternion SteerRotation;

	[HideInInspector]
	public bool grounded = true;

	private float MotorRotation;

	[HideInInspector]
	public bool crash;

	[HideInInspector]
	public float steer;

	[HideInInspector]
	public bool brake;

	private float slip;

	[HideInInspector]
	public bool Backward;

	[HideInInspector]
	public float steer2;

	private float accel;

	private bool shifmotor;

	[HideInInspector]
	public float curTorque = 100f;

	[HideInInspector]
	public float powerShift = 100f;

	[HideInInspector]
	public bool shift;

	private float flipRotate;

	[HideInInspector]
	public float speed;

	private float[] efficiencyTable = new float[22]
	{
		0.6f, 0.65f, 0.7f, 0.75f, 0.8f, 0.85f, 0.9f, 1f, 1f, 0.95f,
		0.8f, 0.7f, 0.6f, 0.5f, 0.45f, 0.4f, 0.36f, 0.33f, 0.3f, 0.2f,
		0.1f, 0.05f
	};

	private float efficiencyTableStep = 250f;

	private float shiftDelay;

	private float Pitch;

	private float PitchDelay;

	private float shiftTime;

	[HideInInspector]
	public int currentGear;

	[HideInInspector]
	public bool NeutralGear = true;

	[HideInInspector]
	public float motorRPM;

	private float wantedRPM;

	private float w_rotate;

	public Rigidbody myRigidbody;

	private bool shifting;

	private float Wheelie;

	private Quaternion deltaRotation1;

	private Quaternion deltaRotation2;

	[HideInInspector]
	public float accelFwd;

	[HideInInspector]
	public float accelBack;

	[HideInInspector]
	public float steerAmount;

	private WheelComponent[] wheels;

	public GameObject StartSpwanPoint1;

	public GameObject StartSpwanPoint2;

	private WheelComponent SetWheelComponent(Transform wheel, Transform axle, bool drive, float maxSteer, float pos_y)
	{
		WheelComponent wheelComponent = new WheelComponent();
		GameObject gameObject = new GameObject(wheel.name + "WheelCollider");
		gameObject.transform.parent = base.transform;
		gameObject.transform.position = wheel.position;
		gameObject.transform.eulerAngles = base.transform.eulerAngles;
		pos_y = gameObject.transform.localPosition.y;
		gameObject.AddComponent(typeof(WheelCollider));
		wheelComponent.drive = drive;
		wheelComponent.wheel = wheel;
		wheelComponent.axle = axle;
		wheelComponent.collider = gameObject.GetComponent<WheelCollider>();
		wheelComponent.pos_y = pos_y;
		wheelComponent.maxSteer = maxSteer;
		wheelComponent.startPos = axle.transform.localPosition;
		return wheelComponent;
	}

	private void Awake()
	{
		//m_PhotonView = GetComponent<PhotonView>();
		Debug.Log("Counterzzzz:" + Counter);
		StaticHostCounterz = 0;
		StaticClienttCounterz = 0;
		CheckDistanceCounter = 0;
		if (Counter == 0)
		{
			base.gameObject.layer = 16;
			base.gameObject.tag = "P1";
			base.gameObject.name = PlayerPrefs.GetString("PlayerNameDB");
		}
		else if (Counter == 1)
		{
			base.gameObject.layer = 17;
			base.gameObject.tag = "P2";
			base.gameObject.name = PlayerPrefs.GetString("PlayerNameDB");
		}
		Counter++;
		Winobj = GameObject.Find("BikeCanvas/YouWinPanel");
		Loseobj = GameObject.Find("BikeCanvas/YouLostPanel");
		if (bikeSetting.automaticGear)
		{
			NeutralGear = false;
		}
		SteerRotation = bikeSetting.bikeSteer.localRotation;
		wheels = new WheelComponent[2];
		wheels[0] = SetWheelComponent(bikeWheels.wheels.wheelFront, bikeWheels.wheels.AxleFront, false, bikeSetting.maxSteerAngle, bikeWheels.wheels.AxleFront.localPosition.y);
		wheels[1] = SetWheelComponent(bikeWheels.wheels.wheelBack, bikeWheels.wheels.AxleBack, true, 0f, bikeWheels.wheels.AxleBack.localPosition.y);
		wheels[0].collider.transform.localPosition = new Vector3(0f, wheels[0].collider.transform.localPosition.y, wheels[0].collider.transform.localPosition.z);
		wheels[1].collider.transform.localPosition = new Vector3(0f, wheels[1].collider.transform.localPosition.y, wheels[1].collider.transform.localPosition.z);
		WheelComponent[] array = wheels;
		foreach (WheelComponent wheelComponent in array)
		{
			WheelCollider collider = wheelComponent.collider;
			collider.suspensionDistance = bikeWheels.setting.Distance;
			JointSpring suspensionSpring = collider.suspensionSpring;
			suspensionSpring.spring = bikeSetting.springs;
			suspensionSpring.damper = bikeSetting.dampers;
			collider.suspensionSpring = suspensionSpring;
			collider.radius = bikeWheels.setting.Radius;
			collider.mass = bikeWheels.setting.Weight;
			WheelFrictionCurve forwardFriction = collider.forwardFriction;
			forwardFriction.asymptoteValue = 0.5f;
			forwardFriction.extremumSlip = 0.4f;
			forwardFriction.asymptoteSlip = 0.8f;
			forwardFriction.stiffness = bikeSetting.stiffness;
			collider.forwardFriction = forwardFriction;
			forwardFriction = collider.sidewaysFriction;
			forwardFriction.asymptoteValue = 0.75f;
			forwardFriction.extremumSlip = 0.2f;
			forwardFriction.asymptoteSlip = 0.5f;
			forwardFriction.stiffness = bikeSetting.stiffness;
			collider.sidewaysFriction = forwardFriction;
		}
		if (Application.platform == RuntimePlatform.Android)
		{
			controlMode = ControlModeN.touch;
		}
		else if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			controlMode = ControlModeN.touch;
		}
		else
		{
			controlMode = ControlModeN.simple;
		}
		shiftParticle1Obj.SetActive(false);
		shiftParticle2Obj.SetActive(false);
		//if (m_PhotonView.isMine)
		//{
		//	BikeUIControllerScript = UnityEngine.Object.FindObjectOfType<BikeUIControllerN>();
		//	BikeUIControllerScript.setTarget(base.gameObject.transform);
		//	BikeCameraFollowNScript = UnityEngine.Object.FindObjectOfType<BikeCameraFollowN>();
		//	BikeCameraFollowNScript.setTarget(base.gameObject.transform);
		//}
		Invoke("SetDelaDisable", 0.2f);
	}

	private void SetDelaDisable()
	{
		//if (m_PhotonView.isMine)
		//{
		//	Winobj.SetActive(false);
		//	Loseobj.SetActive(false);
		//}
	}

	private void OnDisable()
	{
		Counter = 0;
	}

	public void ShiftUp()
	{
		//if (!m_PhotonView.isMine)
		//{
		//	return;
		//}
		float timeSinceLevelLoad = Time.timeSinceLevelLoad;
		if (timeSinceLevelLoad < shiftDelay || currentGear >= bikeSetting.gears.Length - 1)
		{
			return;
		}
		bikeSounds.switchGear.GetComponent<AudioSource>().Play();
		if (!bikeSetting.automaticGear)
		{
			if (currentGear == 0)
			{
				if (NeutralGear)
				{
					currentGear++;
					NeutralGear = false;
				}
				else
				{
					NeutralGear = true;
				}
			}
			else
			{
				currentGear++;
			}
		}
		else
		{
			currentGear++;
		}
		shiftDelay = timeSinceLevelLoad + 1f;
		shiftTime = 1f;
	}

	public void ShiftDown()
	{
		//if (!m_PhotonView.isMine)
		//{
		//	return;
		//}
		float timeSinceLevelLoad = Time.timeSinceLevelLoad;
		if (timeSinceLevelLoad < shiftDelay || (currentGear <= 0 && !NeutralGear))
		{
			return;
		}
		bikeSounds.switchGear.GetComponent<AudioSource>().Play();
		if (!bikeSetting.automaticGear)
		{
			if (currentGear == 1)
			{
				if (!NeutralGear)
				{
					currentGear--;
					NeutralGear = true;
				}
			}
			else if (currentGear == 0)
			{
				NeutralGear = false;
			}
			else
			{
				currentGear--;
			}
		}
		else
		{
			currentGear--;
		}
		shiftDelay = timeSinceLevelLoad + 0.1f;
		shiftTime = 2f;
	}

	public void OnCollisionEnter(Collision collision)
	{
		//if (m_PhotonView.isMine)
		//{
		//	bikeSounds.lowCrash.Play();
		//}
	}

	private void Update()
	{
		//if (!m_PhotonView.isMine)
		//{
		//	return;
		//}
		if (activeControl && !bikeSetting.automaticGear)
		{
			if (Input.GetKeyDown("page up"))
			{
				ShiftUp();
			}
			if (Input.GetKeyDown("page down"))
			{
				ShiftDown();
			}
		}
		steer2 = Mathf.LerpAngle(steer2, steer * (0f - bikeSetting.maxSteerAngle), Time.deltaTime * 10f);
		MotorRotation = Mathf.LerpAngle(MotorRotation, steer2 * bikeSetting.maxTurn * Mathf.Clamp(speed / 100f, 0f, 1f), Time.deltaTime * 5f);
		if ((bool)bikeSetting.bikeSteer)
		{
			bikeSetting.bikeSteer.localRotation = SteerRotation * Quaternion.Euler(0f, wheels[0].collider.steerAngle, 0f);
		}
		if (!crash)
		{
			flipRotate = ((!(base.transform.eulerAngles.z > 90f) || !(base.transform.eulerAngles.z < 270f)) ? 0f : 180f);
			Wheelie = Mathf.Clamp(Wheelie, 0f, bikeSetting.maxWheelie);
			if (shifting)
			{
				Wheelie += bikeSetting.speedWheelie * Time.deltaTime / (speed / 50f);
			}
			else
			{
				Wheelie = Mathf.MoveTowards(Wheelie, 0f, bikeSetting.speedWheelie * 2f * Time.deltaTime * 1.3f);
			}
			deltaRotation1 = Quaternion.Euler(0f - Wheelie, 0f, flipRotate - base.transform.localEulerAngles.z + MotorRotation);
			deltaRotation2 = Quaternion.Euler(0f, 0f, flipRotate - base.transform.localEulerAngles.z);
			myRigidbody.MoveRotation(myRigidbody.rotation * deltaRotation2);
			bikeSetting.MainBody.localRotation = deltaRotation1;
		}
		else
		{
			bikeSetting.MainBody.localRotation = Quaternion.identity;
			Wheelie = 0f;
		}
	}

	private void FixedUpdate()
	{
		//if (!m_PhotonView.isMine)
		//{
		//	return;
		//}
		speed = myRigidbody.velocity.magnitude * 2.7f;
		if (crash)
		{
			myRigidbody.constraints = RigidbodyConstraints.None;
			myRigidbody.centerOfMass = Vector3.zero;
		}
		else
		{
			myRigidbody.constraints = RigidbodyConstraints.FreezeRotationZ;
			myRigidbody.centerOfMass = bikeSetting.shiftCentre;
		}
		if (activeControl)
		{
			if (controlMode == ControlModeN.simple)
			{
				accel = 0f;
				shift = false;
				brake = false;
				if (!crash)
				{
					steer = Mathf.MoveTowards(steer, Input.GetAxis("Horizontal"), 0.1f);
					accel = Input.GetAxis("Vertical");
					brake = Input.GetButton("Jump");
					shift = Input.GetKey(KeyCode.LeftShift) | Input.GetKey(KeyCode.RightShift);
				}
				else
				{
					steer = 0f;
				}
			}
			else if (controlMode == ControlModeN.touch)
			{
				if (accelFwd != 0f)
				{
					accel = accelFwd;
				}
				else
				{
					accel = accelBack;
				}
				steer = Mathf.MoveTowards(steer, steerAmount, 0.07f);
			}
		}
		else
		{
			accel = 0f;
			steer = 0f;
			shift = false;
			brake = false;
		}
		Light[] brakeLights = bikeLights.brakeLights;
		foreach (Light light in brakeLights)
		{
			if (accel < 0f || speed < 1f)
			{
				light.intensity = Mathf.Lerp(light.intensity, 8f, 0.1f);
			}
			else
			{
				light.intensity = Mathf.Lerp(light.intensity, 0f, 0.1f);
			}
		}
		if (bikeSetting.automaticGear && currentGear == 1 && accel < 0f)
		{
			if (speed < 1f)
			{
				ShiftDown();
			}
		}
		else if (bikeSetting.automaticGear && currentGear == 0 && accel > 0f)
		{
			if (speed < 5f)
			{
				ShiftUp();
			}
		}
		else if (bikeSetting.automaticGear && motorRPM > bikeSetting.shiftUpRPM && accel > 0f && speed > 10f && !brake)
		{
			ShiftUp();
		}
		else if (bikeSetting.automaticGear && motorRPM < bikeSetting.shiftDownRPM && currentGear > 1)
		{
			ShiftDown();
		}
		if (speed < 1f)
		{
			Backward = true;
		}
		if (currentGear == 0 && Backward)
		{
			if (speed < bikeSetting.gears[0] * -10f)
			{
				accel = 0f - accel;
			}
		}
		else
		{
			Backward = false;
		}
		wantedRPM = 5500f * accel * 0.1f + wantedRPM * 0.9f;
		float num = 0f;
		int num2 = 0;
		bool flag = false;
		int num3 = 0;
		WheelComponent[] array = wheels;
		foreach (WheelComponent wheelComponent in array)
		{
			WheelCollider collider = wheelComponent.collider;
			if (wheelComponent.drive)
			{
				num = ((!NeutralGear && brake && currentGear < 2) ? (num + accel * bikeSetting.idleRPM) : (NeutralGear ? (num + bikeSetting.idleRPM * 2f * accel) : (num + collider.rpm)));
				num2++;
			}
			if (crash)
			{
				wheelComponent.collider.enabled = false;
				wheelComponent.wheel.GetComponent<Collider>().enabled = true;
			}
			else
			{
				wheelComponent.collider.enabled = true;
				wheelComponent.wheel.GetComponent<Collider>().enabled = false;
			}
			if (brake || accel < 0f)
			{
				if (accel < 0f || (brake && wheelComponent == wheels[1]))
				{
					if (brake && accel > 0f)
					{
						slip = Mathf.Lerp(slip, bikeSetting.slipBrake, accel * 0.01f);
					}
					else if (speed > 1f)
					{
						slip = Mathf.Lerp(slip, 1f, 0.002f);
					}
					else
					{
						slip = Mathf.Lerp(slip, 1f, 0.02f);
					}
					wantedRPM = 0f;
					collider.brakeTorque = bikeSetting.brakePower;
					wheelComponent.rotation = w_rotate;
				}
			}
			else
			{
				float brakeTorque;
				if (accel == 0f)
				{
					float num5 = (collider.brakeTorque = 3000f);
					brakeTorque = num5;
				}
				else
				{
					float num5 = (collider.brakeTorque = 0f);
					brakeTorque = num5;
				}
				collider.brakeTorque = brakeTorque;
				slip = Mathf.Lerp(slip, 1f, 0.02f);
				w_rotate = wheelComponent.rotation;
			}
			WheelFrictionCurve forwardFriction = collider.forwardFriction;
			if (wheelComponent == wheels[1])
			{
				forwardFriction.stiffness = bikeSetting.stiffness / slip;
				collider.forwardFriction = forwardFriction;
				forwardFriction = collider.sidewaysFriction;
				forwardFriction.stiffness = bikeSetting.stiffness / slip;
				collider.sidewaysFriction = forwardFriction;
			}
			if (shift && currentGear > 1 && speed > 50f && shifmotor)
			{
				shifting = true;
				if (powerShift == 0f)
				{
					shifmotor = false;
				}
				powerShift = Mathf.MoveTowards(powerShift, 0f, Time.deltaTime * 10f);
				bikeSounds.nitro.volume = Mathf.Lerp(bikeSounds.nitro.volume, 1f, Time.deltaTime * 10f);
				if (!bikeSounds.nitro.isPlaying)
				{
					bikeSounds.nitro.GetComponent<AudioSource>().Play();
				}
				shiftParticle1Obj.SetActive(true);
				shiftParticle2Obj.SetActive(true);
				curTorque = ((!(powerShift > 0f)) ? bikeSetting.bikePower : bikeSetting.shiftPower);
				bikeParticles.shiftParticle1.emissionRate = Mathf.Lerp(bikeParticles.shiftParticle1.emissionRate, (powerShift > 0f) ? 50 : 0, Time.deltaTime * 10f);
				bikeParticles.shiftParticle2.emissionRate = Mathf.Lerp(bikeParticles.shiftParticle2.emissionRate, (powerShift > 0f) ? 50 : 0, Time.deltaTime * 10f);
			}
			else
			{
				shifting = false;
				if (powerShift > 20f)
				{
					shifmotor = true;
				}
				bikeSounds.nitro.volume = Mathf.MoveTowards(bikeSounds.nitro.volume, 0f, Time.deltaTime * 2f);
				if (bikeSounds.nitro.volume == 0f)
				{
					bikeSounds.nitro.Stop();
				}
				shiftParticle1Obj.SetActive(false);
				shiftParticle2Obj.SetActive(false);
				powerShift = Mathf.MoveTowards(powerShift, 100f, Time.deltaTime * 5f);
				curTorque = bikeSetting.bikePower;
				bikeParticles.shiftParticle1.emissionRate = Mathf.Lerp(bikeParticles.shiftParticle1.emissionRate, 0f, Time.deltaTime * 10f);
				bikeParticles.shiftParticle2.emissionRate = Mathf.Lerp(bikeParticles.shiftParticle2.emissionRate, 0f, Time.deltaTime * 10f);
			}
			wheelComponent.rotation = Mathf.Repeat(wheelComponent.rotation + Time.deltaTime * collider.rpm * 360f / 60f, 360f);
			wheelComponent.wheel.localRotation = Quaternion.Euler(wheelComponent.rotation, 0f, 0f);
			Vector3 localPosition = wheelComponent.axle.localPosition;
			WheelHit hit;
			if (collider.GetGroundHit(out hit) && (wheelComponent == wheels[1] || (wheelComponent == wheels[0] && Wheelie == 0f)))
			{
				if ((bool)bikeParticles.brakeParticlePrefab)
				{
					if (Particle[num3] == null)
					{
						Particle[num3] = UnityEngine.Object.Instantiate(bikeParticles.brakeParticlePrefab, wheelComponent.wheel.position, Quaternion.identity);
						Particle[num3].name = "WheelParticle";
						Particle[num3].transform.parent = base.transform;
						Particle[num3].AddComponent<AudioSource>();
					}
					ParticleSystem component = Particle[num3].GetComponent<ParticleSystem>();
					bool flag2 = false;
					for (int k = 0; k < bikeSetting.hitGround.Length; k++)
					{
						if (hit.collider.CompareTag(bikeSetting.hitGround[k].tag))
						{
							flag2 = bikeSetting.hitGround[k].grounded;
							if ((brake || Mathf.Abs(hit.sidewaysSlip) > 0.5f) && speed > 1f)
							{
								Particle[num3].GetComponent<AudioSource>().clip = bikeSetting.hitGround[k].brakeSound;
							}
							else if (Particle[num3].GetComponent<AudioSource>().clip != bikeSetting.hitGround[k].groundSound && !Particle[num3].GetComponent<AudioSource>().isPlaying)
							{
								Particle[num3].GetComponent<AudioSource>().clip = bikeSetting.hitGround[k].groundSound;
							}
							Particle[num3].GetComponent<ParticleSystem>().startColor = bikeSetting.hitGround[k].brakeColor;
						}
					}
					if (flag2 && speed > 5f && !brake)
					{
						component.enableEmission = true;
						Particle[num3].GetComponent<AudioSource>().volume = 0.5f;
						if (!Particle[num3].GetComponent<AudioSource>().isPlaying)
						{
							Particle[num3].GetComponent<AudioSource>().Play();
						}
					}
					else if ((brake || Mathf.Abs(hit.sidewaysSlip) > 0.6f) && speed > 1f)
					{
						if (accel < 0f || ((brake || Mathf.Abs(hit.sidewaysSlip) > 0.6f) && wheelComponent == wheels[1]))
						{
							if (!Particle[num3].GetComponent<AudioSource>().isPlaying)
							{
								Particle[num3].GetComponent<AudioSource>().Play();
							}
							component.enableEmission = true;
							Particle[num3].GetComponent<AudioSource>().volume = Mathf.Clamp(speed / 60f, 0f, 1f);
						}
					}
					else
					{
						component.enableEmission = false;
						Particle[num3].GetComponent<AudioSource>().volume = Mathf.Lerp(Particle[num3].GetComponent<AudioSource>().volume, 0f, Time.deltaTime * 10f);
					}
				}
				localPosition.y -= Vector3.Dot(wheelComponent.wheel.position - hit.point, base.transform.TransformDirection(0f, 1f, 0f)) - collider.radius;
				localPosition.y = Mathf.Clamp(localPosition.y, wheelComponent.startPos.y - bikeWheels.setting.Distance, wheelComponent.startPos.y + bikeWheels.setting.Distance);
				flag = flag || wheelComponent.drive;
				if (!crash)
				{
					myRigidbody.angularDrag = 10f;
				}
				else
				{
					myRigidbody.angularDrag = 0f;
				}
				grounded = true;
				if ((bool)wheelComponent.collider.GetComponent<WheelSkidmarks>())
				{
					wheelComponent.collider.GetComponent<WheelSkidmarks>().enabled = true;
				}
			}
			else
			{
				grounded = false;
				if ((bool)wheelComponent.collider.GetComponent<WheelSkidmarks>())
				{
					wheelComponent.collider.GetComponent<WheelSkidmarks>().enabled = false;
				}
				if (Particle[num3] != null)
				{
					ParticleSystem component2 = Particle[num3].GetComponent<ParticleSystem>();
					component2.enableEmission = false;
				}
				localPosition.y = wheelComponent.startPos.y - bikeWheels.setting.Distance;
				if (!wheels[0].collider.isGrounded && !wheels[1].collider.isGrounded)
				{
					myRigidbody.centerOfMass = new Vector3(0f, 0.2f, 0f);
					myRigidbody.angularDrag = 1f;
					myRigidbody.AddForce(0f, -10000f, 0f);
				}
			}
			num3++;
			wheelComponent.axle.localPosition = localPosition;
		}
		if (num2 > 1)
		{
			num /= (float)num2;
		}
		motorRPM = 0.95f * motorRPM + 0.05f * Mathf.Abs(num * bikeSetting.gears[currentGear]);
		if (motorRPM > 5500f)
		{
			motorRPM = 5200f;
		}
		int num7 = (int)(motorRPM / efficiencyTableStep);
		if (num7 >= efficiencyTable.Length)
		{
			num7 = efficiencyTable.Length - 1;
		}
		if (num7 < 0)
		{
			num7 = 0;
		}
		float num8 = curTorque * bikeSetting.gears[currentGear] * efficiencyTable[num7];
		WheelComponent[] array2 = wheels;
		foreach (WheelComponent wheelComponent2 in array2)
		{
			WheelCollider collider2 = wheelComponent2.collider;
			if (wheelComponent2.drive)
			{
				if (Mathf.Abs(collider2.rpm) > Mathf.Abs(wantedRPM))
				{
					collider2.motorTorque = 0f;
				}
				else
				{
					float motorTorque = collider2.motorTorque;
					if (!brake && accel != 0f && !NeutralGear)
					{
						if ((speed < bikeSetting.LimitForwardSpeed && currentGear > 0) || (speed < bikeSetting.LimitBackwardSpeed && currentGear == 0))
						{
							collider2.motorTorque = motorTorque * 0.9f + num8 * 1f;
						}
						else
						{
							collider2.motorTorque = 0f;
							collider2.brakeTorque = 2000f;
						}
					}
					else
					{
						collider2.motorTorque = 0f;
					}
				}
			}
			float num9 = Mathf.Clamp(speed / bikeSetting.maxSteerAngle, 1f, bikeSetting.maxSteerAngle);
			collider2.steerAngle = steer * (wheelComponent2.maxSteer / num9);
		}
		Pitch = Mathf.Clamp(1.2f + (motorRPM - bikeSetting.idleRPM) / (bikeSetting.shiftUpRPM - bikeSetting.idleRPM), 1f, 10f);
		shiftTime = Mathf.MoveTowards(shiftTime, 0f, 0.1f);
		if (Pitch == 1f || currentGear == 0)
		{
			bikeSounds.IdleEngine.volume = Mathf.Lerp(bikeSounds.IdleEngine.volume, 1f, 0.1f);
			bikeSounds.LowEngine.volume = Mathf.Lerp(bikeSounds.LowEngine.volume, 0.5f, 0.1f);
			bikeSounds.HighEngine.volume = Mathf.Lerp(bikeSounds.HighEngine.volume, 0f, 0.1f);
			return;
		}
		bikeSounds.IdleEngine.volume = Mathf.Lerp(bikeSounds.IdleEngine.volume, 1.8f - Pitch, 0.1f);
		if ((Pitch > PitchDelay || accel > 0f) && shiftTime == 0f)
		{
			bikeSounds.LowEngine.volume = Mathf.Lerp(bikeSounds.LowEngine.volume, 0f, 0.2f);
			bikeSounds.HighEngine.volume = Mathf.Lerp(bikeSounds.HighEngine.volume, 1f, 0.2f);
		}
		else
		{
			bikeSounds.LowEngine.volume = Mathf.Lerp(bikeSounds.LowEngine.volume, 1f, 0.2f);
			bikeSounds.HighEngine.volume = Mathf.Lerp(bikeSounds.HighEngine.volume, 0f, 0.2f);
		}
		bikeSounds.HighEngine.pitch = Pitch;
		bikeSounds.LowEngine.pitch = Pitch;
		PitchDelay = Pitch;
	}

	private void OnDrawGizmos()
	{
		if (bikeSetting.showNormalGizmos && !Application.isPlaying)
		{
			Matrix4x4 matrix4x2 = (Gizmos.matrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, Vector3.one));
			Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
			Gizmos.DrawCube(Vector3.up / 1.6f, new Vector3(0.5f, 1f, 2.5f));
			Gizmos.DrawSphere(bikeSetting.shiftCentre, 0.2f);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 16 && other.gameObject.tag == "checkdis")
		{
			CheckDistanceCounter++;
			UnityEngine.Object.Destroy(other.gameObject);
		}
		if (other.gameObject.layer == 17 && other.gameObject.tag == "checkdis")
		{
			CheckDistanceCounter++;
			UnityEngine.Object.Destroy(other.gameObject);
		}
		if (other.gameObject.layer == 16 && other.gameObject.tag == "checkpoint")
		{
			base.gameObject.GetComponent<BikeControlN>().CheckpointCounter++;
			UnityEngine.Object.Destroy(other.gameObject);
		}
		if (other.gameObject.layer == 17 && other.gameObject.tag == "checkpoint")
		{
			base.gameObject.GetComponent<BikeControlN>().CheckpointCounter++;
			UnityEngine.Object.Destroy(other.gameObject);
		}
		if (other.gameObject.layer == 16 && other.gameObject.tag == "RaceFinish")
		{
			base.gameObject.GetComponent<BikeControlN>().RaceWinCounter_1 = 1;
			StaticHostCounterz = 1;
			if (StaticHostCounterz == 1 && StaticClienttCounterz == 0)
			{
				//	if (m_PhotonView.isMine)
				//	{
				//		Winobj.SetActive(true);
				//		Invoke("DelayWinCall", 0.2f);
				//	}
			}
			else if (StaticHostCounterz == 1 && StaticClienttCounterz == 1 )
				//&& m_PhotonView.isMine)
			{
				Loseobj.SetActive(true);
				Invoke("DelayLostCall", 0.2f);
			}
			UnityEngine.Object.Destroy(other.gameObject);
		}
		if (other.gameObject.layer == 17 && other.gameObject.tag == "RaceFinish")
		{
			base.gameObject.GetComponent<BikeControlN>().RaceWinCounter_2 = 1;
			StaticClienttCounterz = 1;
			if (StaticHostCounterz == 0 && StaticClienttCounterz == 1)
			{
				//if (m_PhotonView.isMine)
				//{
				//	Winobj.SetActive(true);
				//	Invoke("DelayWinCall", 0.2f);
				//}
			}
			else if (StaticHostCounterz == 1 && StaticClienttCounterz == 1)// && m_PhotonView.isMine)
			{
				Loseobj.SetActive(true);
				Invoke("DelayLostCall", 0.2f);
			}
			UnityEngine.Object.Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "FinishCol")
		{
			ParachuteBool = true;
			UnityEngine.Object.Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "nospush")
		{
		}
		if (other.gameObject.tag == "rampstart")
		{
			rampStart = true;
			Debug.Log("Start Trigger");
		}
		if (other.gameObject.tag == "Junction")
		{
			junctionBool = true;
		}
		if (other.gameObject.tag == "BikeFall")
		{
			BikeFallBool = true;
		}
	}

	private void DelayWinCall()
	{
		if (Application.loadedLevel > 23)
		{
			PlayerPrefs.SetInt("LvlCompleteAdCallDB", 1);
		}
		P1Name = GameObject.Find("YouWinPanel/BackGround/InfoBack/P1NameText").GetComponent<Text>();
		P2Name = GameObject.Find("YouWinPanel/BackGround/InfoBack/P2NameText").GetComponent<Text>();
		P1Pos = GameObject.Find("YouWinPanel/BackGround/InfoBack/P1PosText").GetComponent<Text>();
		P2Pos = GameObject.Find("YouWinPanel/BackGround/InfoBack/P2PosText").GetComponent<Text>();
		PScoreN componentInChildren = GameObject.FindGameObjectWithTag("P1").GetComponentInChildren<PScoreN>();
		PScoreN componentInChildren2 = GameObject.FindGameObjectWithTag("P2").GetComponentInChildren<PScoreN>();
		P1Name.text = componentInChildren.NameText.text;
		P1Pos.text = componentInChildren.ScoreText.text;
		P2Name.text = componentInChildren2.NameText.text;
		P2Pos.text = componentInChildren2.ScoreText.text;
		Time.timeScale = 0f;
	}

	private void DelayLostCall()
	{
		if (Application.loadedLevel > 23)
		{
			PlayerPrefs.SetInt("LvlFailedAdCallDB", 1);
		}
		P1Name = GameObject.Find("YouLostPanel/BackGround/InfoBack/P1NameText").GetComponent<Text>();
		P2Name = GameObject.Find("YouLostPanel/BackGround/InfoBack/P2NameText").GetComponent<Text>();
		P1Pos = GameObject.Find("YouLostPanel/BackGround/InfoBack/P1PosText").GetComponent<Text>();
		P2Pos = GameObject.Find("YouLostPanel/BackGround/InfoBack/P2PosText").GetComponent<Text>();
		PScoreN componentInChildren = GameObject.FindGameObjectWithTag("P1").GetComponentInChildren<PScoreN>();
		PScoreN componentInChildren2 = GameObject.FindGameObjectWithTag("P2").GetComponentInChildren<PScoreN>();
		P1Name.text = componentInChildren.NameText.text;
		P1Pos.text = componentInChildren.ScoreText.text;
		P2Name.text = componentInChildren2.NameText.text;
		P2Pos.text = componentInChildren2.ScoreText.text;
		Time.timeScale = 0f;
	}
}
