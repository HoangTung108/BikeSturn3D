using FluffyUnderware.Curvy.Controllers;
using UnityEngine;

public class BikeRampController : MonoBehaviour
{
	private GameObject RampBike;

	public GameObject RampBike2;

	public GameObject RampBike3;

	public GameObject RampBike4;

	public GameObject RampBike5;

	public GameObject RampBike6;

	public GameObject RampBike7;

	public GameObject RampBike8;

	public GameObject RampBike9;

	public GameObject RampBike10;

	public GameObject RampBike11;

	public GameObject RampCamera;

	public GameObject BikeCamera;

	public GameObject PlayerBike;

	public BikeControl BikeControlScript;

	private BikeRampAI BikeRampAIScript;

	public BikeRampAI BikeRampAIScript2;

	public BikeRampAI BikeRampAIScript3;

	public BikeRampAI BikeRampAIScript4;

	public BikeRampAI BikeRampAIScript5;

	public BikeRampAI BikeRampAIScript6;

	public BikeRampAI BikeRampAIScript7;

	public BikeRampAI BikeRampAIScript8;

	public BikeRampAI BikeRampAIScript9;

	public BikeRampAI BikeRampAIScript10;

	public BikeRampAI BikeRampAIScript11;

	private SplineController splineControllerScript;

	public SplineController splineControllerScript2;

	public SplineController splineControllerScript3;

	public SplineController splineControllerScript4;

	public SplineController splineControllerScript5;

	public SplineController splineControllerScript6;

	public SplineController splineControllerScript7;

	public SplineController splineControllerScript8;

	public SplineController splineControllerScript9;

	public SplineController splineControllerScript10;

	public SplineController splineControllerScript11;

	private bool InitBool;

	public GameObject RampCamPos1;

	public GameObject RampCamPos2;

	public GameObject RampCamPos3;

	private void Start()
	{
		Debug.Log("BIKE SEL DB:" + PlayerPrefs.GetInt("BikeSelDB"));
		Invoke("InitControls", 1.2f);
	}

	private void InitControls()
	{
		PlayerBike = GameObject.FindGameObjectWithTag("Player");
		BikeControlScript = Object.FindObjectOfType<BikeControl>();
	
	 	if (PlayerPrefs.GetInt("BikeSelDB") == 2)
		{
			BikeRampAIScript = BikeRampAIScript2;
			RampBike = RampBike2;
			splineControllerScript = splineControllerScript2;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 3)
		{
			BikeRampAIScript = BikeRampAIScript3;
			RampBike = RampBike3;
			splineControllerScript = splineControllerScript3;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 4)
		{
			BikeRampAIScript = BikeRampAIScript4;
			RampBike = RampBike4;
			splineControllerScript = splineControllerScript4;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 5)
		{
			BikeRampAIScript = BikeRampAIScript5;
			RampBike = RampBike5;
			splineControllerScript = splineControllerScript5;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 6)
		{
			BikeRampAIScript = BikeRampAIScript6;
			RampBike = RampBike6;
			splineControllerScript = splineControllerScript6;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 7)
		{
			BikeRampAIScript = BikeRampAIScript7;
			RampBike = RampBike7;
			splineControllerScript = splineControllerScript7;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 8)
		{
			BikeRampAIScript = BikeRampAIScript8;
			RampBike = RampBike8;
			splineControllerScript = splineControllerScript8;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 9)
		{
			BikeRampAIScript = BikeRampAIScript9;
			RampBike = RampBike9;
			splineControllerScript = splineControllerScript9;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 10)
		{
			BikeRampAIScript = BikeRampAIScript10;
			RampBike = RampBike10;
			splineControllerScript = splineControllerScript10;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 11)
		{
			BikeRampAIScript = BikeRampAIScript11;
			RampBike = RampBike11;
			splineControllerScript = splineControllerScript11;
		}
		InitBool = true;
	}

	private void Update()
	{
		if (!InitBool)
		{
			return;
		}
		if (BikeControlScript != null)
		{
			if (BikeControlScript.rampStart)
			{
				RampBike.SetActive(true);
				RampBike.transform.position = PlayerBike.transform.position;
				RampBike.transform.rotation = PlayerBike.transform.rotation;
				RampCamera.SetActive(true);
				if (BikeControlScript.junctionBool)
				{
					RampCamera.transform.position = RampCamPos2.transform.position;
					RampCamera.transform.rotation = RampCamPos2.transform.rotation;
				}
				else if (BikeControlScript.CheckpointCounter == 3)
				{
					RampCamera.transform.position = RampCamPos3.transform.position;
					RampCamera.transform.rotation = RampCamPos3.transform.rotation;
				}
				else
				{
					RampCamera.transform.position = RampCamPos1.transform.position;
					RampCamera.transform.rotation = RampCamPos1.transform.rotation;
				}
				BikeControlScript.junctionBool = false;
				BikeCamera.SetActive(false);
				PlayerBike.gameObject.SetActive(false);
				BikeControlScript.rampStart = false;
			}
		}
		if (BikeRampAIScript != null && BikeRampAIScript.rampStop)
		{
			BikeCamera.SetActive(true);
			PlayerBike.gameObject.SetActive(true);
			PlayerBike.transform.position = RampBike.transform.position;
			PlayerBike.transform.rotation = RampBike.transform.rotation;
			BikeCamera.transform.position = PlayerBike.transform.position;
			BikeCamera.transform.rotation = PlayerBike.transform.rotation;
			PlayerBike.GetComponent<Rigidbody>().AddForce(PlayerBike.transform.forward * 25f, ForceMode.VelocityChange);
			splineControllerScript.Position = splineControllerScript.InitialPosition;
			RampBike.SetActive(false);
			RampCamera.SetActive(false);
			BikeRampAIScript.rampStop = false;
		}
	}
}
