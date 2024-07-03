using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class BikeUIControllerN : MonoBehaviour
{
	[Serializable]
	public class BikeUIClass
	{
		public Image tachometerNeedle;

		public Image barShiftGUI;

		public Text speedText;

		public Text GearText;
	}

	public BikeCamActive BikeCameraFollowNScript;

	public Text RankText;

	public Text TimeShow;

	public float timer;

	private bool TimeBool = true;

	private int minutes;

	private int seconds;

	private int fraction;

	public GameObject TimerObject;

	public GameObject LoadingPanel;

	public GameObject RewardAdPanel;

	public GameObject TrainingPanel;

	public GameObject LevelCompletePanel;

	public GameObject LevelFailedPanel;

	public GameObject PausePanel;

	private bool LevelCompleteBool = true;

	private bool LevelFailedBool = true;

	public Text CashText;

	public GameObject Bike1;

	public GameObject Bike2;

	public GameObject Bike3;

	public GameObject Bike4;

	private GameObject InsBike;

	public Transform[] Spwanpoints;

	public GameObject Player;

	public Transform BikerMan;

	public BikeUIClass BikeUI;

	public float distance = 5f;

	private int gearst;

	private float thisAngle = -150f;

	private float restTime;

	public Rigidbody myRigidbody;

	public BikeControlN bikeScript;

	private BikeAnimationN BikeAnimationScript;

	public GameObject ParachutePlayer;

	public GameObject ParachuteCamera;

	public GameObject ParachuteControls;

	public GameObject BikeCamera;

	public GameObject BikeControls;

	public GameObject BikeSpeedometer;

	public GameObject Nosmeter;

	public ParachutController ParachutControllerScript;

	private int PLValue;

	private bool InitBool;

	public void BikeAccelForward(float amount)
	{
		if (InitBool)
		{
			bikeScript.accelFwd = amount;
		}
	}

	public void BikeAccelBack(float amount)
	{
		if (InitBool)
		{
			bikeScript.accelBack = amount;
		}
	}

	public void BikeSteer(float amount)
	{
		if (InitBool)
		{
			bikeScript.steerAmount = amount;
		}
	}

	public void BikeHandBrake(bool HBrakeing)
	{
		if (InitBool)
		{
			bikeScript.brake = HBrakeing;
		}
	}

	public void BikeShift(bool Shifting)
	{
		if (InitBool)
		{
			bikeScript.shift = Shifting;
		}
	}

	public void RestBike()
	{
		if (!InitBool)
		{
			return;
		}
		if (restTime == 0f)
		{
			Player.transform.position = Spwanpoints[bikeScript.CheckpointCounter].transform.position;
			Player.transform.rotation = Spwanpoints[bikeScript.CheckpointCounter].transform.rotation;
			myRigidbody.constraints = RigidbodyConstraints.FreezeAll;
			Invoke("delayUnpauseCall", 0.2f);
			restTime = 2f;
		}
		if (Application.loadedLevel > 2)
		{
			if (PlayerPrefs.GetInt("RespawnAdCallDB") == 2)
			{
				PlayerPrefs.SetInt("PauseAdCallDB", 1);
				PlayerPrefs.SetInt("RespawnAdCallDB", 0);
			}
			else
			{
				PlayerPrefs.SetInt("RespawnAdCallDB", PlayerPrefs.GetInt("RespawnAdCallDB") + 1);
			}
		}
	}

	public void setTarget(Transform targetP)
	{
		Player = targetP.gameObject;
		myRigidbody = Player.GetComponent<Rigidbody>();
		bikeScript = Player.GetComponent<BikeControlN>();
		BikerMan = bikeScript.bikeSetting.bikerMan;
	}

	private void delayUnpauseCall()
	{
		myRigidbody.constraints = RigidbodyConstraints.None;
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
		BikeUI.barShiftGUI.fillAmount = bikeScript.powerShift / 100f;
	}

	private void Awake()
	{
		if (PlayerPrefs.GetInt("MultiPlyerGameDB") == 0)
		{
			if (PlayerPrefs.GetInt("BikeSelDB") == 1)
			{
				InsBike = UnityEngine.Object.Instantiate(Bike1, Spwanpoints[0].transform.position, Spwanpoints[0].transform.rotation);
			}
			else if (PlayerPrefs.GetInt("BikeSelDB") == 2)
			{
				InsBike = UnityEngine.Object.Instantiate(Bike2, Spwanpoints[0].transform.position, Spwanpoints[0].transform.rotation);
			}
			else if (PlayerPrefs.GetInt("BikeSelDB") == 3)
			{
				InsBike = UnityEngine.Object.Instantiate(Bike3, Spwanpoints[0].transform.position, Spwanpoints[0].transform.rotation);
			}
			else if (PlayerPrefs.GetInt("BikeSelDB") == 4)
			{
				InsBike = UnityEngine.Object.Instantiate(Bike4, Spwanpoints[0].transform.position, Spwanpoints[0].transform.rotation);
			}
		}
	}

	private void OnEnable()
	{
		Time.timeScale = 1f;
		Invoke("InitControls", 1.2f);
	}

	private void InitControls()
	{
		LevelCompletePanel.SetActive(false);
		LevelFailedPanel.SetActive(false);
		PausePanel.SetActive(false);
		RewardAdPanel.SetActive(false);
		if (PlayerPrefs.GetInt("MultiPlyerGameDB") == 0)
		{
			if (PlayerPrefs.GetInt("trainDb") == 0)
			{
				if (Application.loadedLevel == 2)
				{
					TrainingPanel.SetActive(true);
				}
				PlayerPrefs.SetInt("trainDb", 1);
			}
			else if (PlayerPrefs.GetInt("trainDb") == 1)
			{
				if (Application.loadedLevel == 3)
				{
					TrainingPanel.SetActive(true);
				}
				PlayerPrefs.SetInt("trainDb", 2);
			}
		}
		minutes = 0;
		seconds = 0;
		fraction = 0;
		BikeAnimationScript = UnityEngine.Object.FindObjectOfType<BikeAnimationN>();
		BikeUI.tachometerNeedle = GameObject.Find("BikeCanvas/Tachometer/Needle").GetComponent<Image>();
		BikeUI.barShiftGUI = GameObject.Find("BikeCanvas/CarShiftUI/Bar").GetComponent<Image>();
		BikeUI.speedText = GameObject.Find("BikeCanvas/Tachometer/Speed").GetComponent<Text>();
		BikeUI.GearText = GameObject.Find("BikeCanvas/Tachometer/Gear").GetComponent<Text>();
		if (PlayerPrefs.GetInt("ModeDB") == 1)
		{
			TimeShow = GameObject.Find("BikeCanvas/Control/Timer/TimerText").GetComponent<Text>();
			if (Application.loadedLevel > 1 && Application.loadedLevel <= 3)
			{
				timer = 360f;
			}
			else if (Application.loadedLevel > 3 && Application.loadedLevel <= 6)
			{
				timer = 300f;
			}
			else if (Application.loadedLevel > 6 && Application.loadedLevel <= 11)
			{
				timer = 240f;
			}
		}
		else if (PlayerPrefs.GetInt("ModeDB") == 0)
		{
			TimerObject = GameObject.Find("BikeCanvas/Control/Timer");
			TimerObject.SetActive(false);
		}
		Invoke("DelayLoadingFalseee", 0.4f);
	}

	private void DelayLoadingFalseee()
	{
		Analytics.CustomEvent("Multiplayerstarted");
		if (Application.loadedLevel == 18)
		{
			Analytics.CustomEvent("MultiPlayerLevel1");
		}
		else if (Application.loadedLevel == 19)
		{
			Analytics.CustomEvent("MultiPlayerLevel2");
		}
		else if (Application.loadedLevel == 20)
		{
			Analytics.CustomEvent("MultiPlayerLevel3");
		}
		else if (Application.loadedLevel == 21)
		{
			Analytics.CustomEvent("MultiPlayerLevel4");
		}
		else if (Application.loadedLevel == 22)
		{
			Analytics.CustomEvent("MultiPlayerLevel5");
		}
		else if (Application.loadedLevel == 23)
		{
			Analytics.CustomEvent("MultiPlayerLevel6");
		}
		else if (Application.loadedLevel == 24)
		{
			Analytics.CustomEvent("MultiPlayerLevel7");
		}
		else if (Application.loadedLevel == 25)
		{
			Analytics.CustomEvent("MultiPlayerLevel8");
		}
		else if (Application.loadedLevel == 26)
		{
			Analytics.CustomEvent("MultiPlayerLevel9");
		}
		LoadingPanel.SetActive(false);
		InitBool = true;
		// Handheld.StopActivityIndicator();
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			PausePanel.SetActive(true);
			Time.timeScale = 0f;
		}
		if (!InitBool)
		{
			return;
		}
		if (PlayerPrefs.GetInt("RewardWacthed") == 1)
		{
			timer = 60f;
			RewardAdPanel.SetActive(false);
			PlayerPrefs.SetInt("RewardWacthed", 0);
		}
		else if (PlayerPrefs.GetInt("RewardWacthed") == 2)
		{
			if (LevelFailedBool)
			{
				ParachuteControls.SetActive(false);
				LevelFailedPanel.SetActive(true);
				TimeBool = false;
				LevelFailedBool = false;
			}
			PlayerPrefs.SetInt("RewardWacthed", 0);
		}
		if (restTime != 0f)
		{
			restTime = Mathf.MoveTowards(restTime, 0f, Time.deltaTime);
		}
		ShowBikeUI();
		if (bikeScript.crash)
		{
			Vector3 forward = BikerMan.position - base.transform.position;
			base.transform.rotation = Quaternion.LookRotation(forward);
		}
		if (bikeScript.BikeFallBool)
		{
			RestBike();
			bikeScript.BikeFallBool = false;
		}
		if (ParachutControllerScript.LandingBool && LevelCompleteBool)
		{
			LevelCompleteBool = false;
		}
		if (ParachutControllerScript.LandingFailedBool && LevelFailedBool)
		{
			ParachuteControls.SetActive(false);
			LevelFailedPanel.SetActive(true);
			Time.timeScale = 0f;
			LevelFailedBool = false;
		}
		if (bikeScript.ParachuteBool)
		{
			Invoke("ParachuteControlsActive_Call", 0.5f);
			bikeScript.ParachuteBool = false;
		}
		if (PlayerPrefs.GetInt("ModeDB") == 1)
		{
			if (!ParachutControllerScript.LandingBool)
			{
				timer -= Time.deltaTime;
			}
			minutes = (int)timer / 60;
			seconds = (int)timer % 60;
			fraction = (int)(timer * 100f) % 100;
			TimeShow.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
			if (TimeBool && timer <= 0f)
			{
				RewardAdPanel.SetActive(true);
				timer = 0f;
			}
		}
	}

	private void ParachuteControlsActive_Call()
	{
		ParachutePlayer.SetActive(true);
		ParachuteCamera.SetActive(true);
		ParachuteControls.SetActive(true);
		ParachutePlayer.transform.position = Player.transform.position;
		ParachutePlayer.transform.rotation = Player.transform.rotation;
		ParachuteCamera.transform.position = BikeCamera.transform.position;
		ParachuteCamera.transform.rotation = BikeCamera.transform.rotation;
		Player.SetActive(false);
		BikeCamera.SetActive(false);
		BikeControls.SetActive(false);
		BikeSpeedometer.SetActive(false);
		Nosmeter.SetActive(false);
	}

	private void LevelComepleteCall()
	{
		ParachuteControls.SetActive(false);
		LevelCompletePanel.SetActive(true);
		Time.timeScale = 0f;
	}

	public void Pausebtn_Click()
	{
		PausePanel.SetActive(true);
		Time.timeScale = 0f;
	}

	public void Resumebtn_Click()
	{
		Time.timeScale = 1f;
		PausePanel.SetActive(false);
	}

	public void Restartbtn_Click()
	{
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void Menubtn_Click()
	{
		Analytics.CustomEvent("Multiplayerended");
		Time.timeScale = 1f;
		//PhotonNetwork.LoadLevel(17);
	}

	public void Nextbtn_Click()
	{
		Time.timeScale = 1f;
		PlayerPrefs.SetInt("Next", 1);
		StartCoroutine(LoadNewScene());
	}

	public void Yesbtn_Click()
	{
		Time.timeScale = 1f;
	}

	public void Nobtn_Click()
	{
		TimeBool = false;
		Time.timeScale = 1f;
		ParachuteControls.SetActive(false);
		LevelFailedPanel.SetActive(true);
		RewardAdPanel.SetActive(false);
	}

	private void OnApplicationPause(bool isPause)
	{
		if (isPause)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
		}
	}

	private void OnDisable()
	{
		if (IsInvoking("ParachuteControlsActive_Call"))
		{
			CancelInvoke("ParachuteControlsActive_Call");
		}
		if (IsInvoking("LevelComepleteCall"))
		{
			CancelInvoke("LevelComepleteCall");
		}
		if (IsInvoking("delayUnpauseCall"))
		{
			CancelInvoke("delayUnpauseCall");
		}
		if (IsInvoking("InitControls"))
		{
			CancelInvoke("InitControls");
		}
	}

	private IEnumerator LoadNewScene()
	{
		yield return new WaitForSeconds(1f);
		AsyncOperation async = Application.LoadLevelAsync(1);
		while (!async.isDone)
		{
			yield return null;
		}
	}
}
