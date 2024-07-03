using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class BikeUIController : MonoBehaviour
{
	[Serializable]
	public class BikeUIClass
	{
		public Image tachometerNeedle;

		public Image barShiftGUI;

		public Text speedText;

		public Text GearText;
	}

	public GameObject[] CheckpointObj;

	public GameObject NextSkipBtn;

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

	public GameObject CheckpointRewardAdPanel;

	public GameObject VideoNotAvailablePanel;

	private bool CheckPointRewardBool;

	public GameObject LevelCompletePanel;

	public GameObject LevelFailedPanel;

	public GameObject PausePanel;

	private bool LevelCompleteBool = true;

	private bool LevelFailedBool = true;

	public Text CashText;

	public Text TimeCount;

	public GameObject Bike1;

	public GameObject Bike2;

	public GameObject Bike3;

	public GameObject Bike4;

	public GameObject Bike5;

	public GameObject Bike6;

	public GameObject Bike7;

	public GameObject Bike8;

	public GameObject Bike9;

	public GameObject Bike10;

	public GameObject Bike11;

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

	public BikeControl bikeScript;

	private BikeAnimation BikeAnimationScript;

	public GameObject ParachutePlayer;

	public GameObject ParachuteCamera;

	public GameObject ParachuteControls;

	public GameObject BikeCamera;

	public GameObject BikeControls;

	public GameObject BikeSpeedometer;

	public GameObject Nosmeter;

	public GameObject PauseBTN;

	public ParachutController ParachutControllerScript;

	public GameObject UpgradePanel;

	public GameObject UpgradeBtn;

	public GameObject CrossPromo;

	public GameObject RateUsDialogue;

	private int PLValue;

	private bool InitBool;

	private float count = 5f;

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
			if (PlayerPrefs.GetInt("RespawnAdCallDB") >= 5)
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
			else if (PlayerPrefs.GetInt("BikeSelDB") == 5)
			{
				InsBike = UnityEngine.Object.Instantiate(Bike5, Spwanpoints[0].transform.position, Spwanpoints[0].transform.rotation);
			}
			else if (PlayerPrefs.GetInt("BikeSelDB") == 6)
			{
				InsBike = UnityEngine.Object.Instantiate(Bike6, Spwanpoints[0].transform.position, Spwanpoints[0].transform.rotation);
			}
			else if (PlayerPrefs.GetInt("BikeSelDB") == 7)
			{
				InsBike = UnityEngine.Object.Instantiate(Bike7, Spwanpoints[0].transform.position, Spwanpoints[0].transform.rotation);
			}
			else if (PlayerPrefs.GetInt("BikeSelDB") == 8)
			{
				InsBike = UnityEngine.Object.Instantiate(Bike8, Spwanpoints[0].transform.position, Spwanpoints[0].transform.rotation);
			}
			else if (PlayerPrefs.GetInt("BikeSelDB") == 9)
			{
				InsBike = UnityEngine.Object.Instantiate(Bike9, Spwanpoints[0].transform.position, Spwanpoints[0].transform.rotation);
			}
			else if (PlayerPrefs.GetInt("BikeSelDB") == 10)
			{
				InsBike = UnityEngine.Object.Instantiate(Bike10, Spwanpoints[0].transform.position, Spwanpoints[0].transform.rotation);
			}
			else if (PlayerPrefs.GetInt("BikeSelDB") == 11)
			{
				InsBike = UnityEngine.Object.Instantiate(Bike11, Spwanpoints[0].transform.position, Spwanpoints[0].transform.rotation);
			}
		}
		if (PlayerPrefs.GetInt("MultiPlyerGameDB") == 0)
		{
			if (PlayerPrefs.GetInt("BikeSelDB") == 1 && Application.loadedLevel > 4)
			{
				UpgradeBtn.SetActive(true);
			}
			else if (PlayerPrefs.GetInt("BikeSelDB") == 2 && Application.loadedLevel > 8)
			{
				UpgradeBtn.SetActive(true);
			}
			else if (PlayerPrefs.GetInt("BikeSelDB") == 3 && Application.loadedLevel > 12)
			{
				UpgradeBtn.SetActive(true);
			}
			else if (PlayerPrefs.GetInt("BikeSelDB") == 4 && Application.loadedLevel > 15)
			{
				UpgradeBtn.SetActive(true);
			}
		}
	}

	private void Start()
	{
		Time.timeScale = 1f;
		Invoke("InitControls", 1.2f);
		PlayerPrefs.SetInt("RespawnAdCallDB", 0);
	}

	private void InitControls()
	{
		RewardAdPanel.SetActive(false);
		CheckpointRewardAdPanel.SetActive(false);
		VideoNotAvailablePanel.SetActive(false);
		LevelCompletePanel.SetActive(false);
		LevelFailedPanel.SetActive(false);
		PausePanel.SetActive(false);
		PlayerPrefs.SetInt("MenuTutDB", 1);
		PlayerPrefs.SetInt("SelTutDB", 1);
		if (PlayerPrefs.GetInt("MultiPlyerGameDB") == 0)
		{
			if (PlayerPrefs.GetInt("trainDb") == 0)
			{
				if (Application.loadedLevel == 2 && TrainingPanel != null)
				{
					TrainingPanel.SetActive(true);
				}
				PlayerPrefs.SetInt("trainDb", 1);
			}
			else if (PlayerPrefs.GetInt("trainDb") == 1)
			{
				if (Application.loadedLevel == 3 && TrainingPanel != null)
				{
					TrainingPanel.SetActive(true);
				}
				PlayerPrefs.SetInt("trainDb", 2);
			}
			if (PauseBTN == null)
			{
				PauseBTN = GameObject.Find("BikeCanvas/Pause");
			}
			Player = GameObject.FindGameObjectWithTag("Player");
			myRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
			bikeScript = UnityEngine.Object.FindObjectOfType<BikeControl>();
			BikerMan = GameObject.FindGameObjectWithTag("pelvis").transform;
			BikerMan = bikeScript.bikeSetting.bikerMan;
			bikeScript.activeControl = true;
		}
		minutes = 0;
		seconds = 0;
		fraction = 0;
		BikeAnimationScript = UnityEngine.Object.FindObjectOfType<BikeAnimation>();
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
			else if (Application.loadedLevel > 6 && Application.loadedLevel <= 21)
			{
				timer = 240f;
			}
		}
		else if (PlayerPrefs.GetInt("ModeDB") == 0)
		{
			TimerObject = GameObject.Find("BikeCanvas/Control/Timer");
			TimerObject.SetActive(false);
		}
		if (PlayerPrefs.GetInt("ModeDB") == 0)
		{
			int num = Application.loadedLevel - 1;
			string customEventName = "level_start" + num;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("Level_Num", num);
			Analytics.CustomEvent(customEventName, dictionary);
		}
		else if (PlayerPrefs.GetInt("ModeDB") == 1)
		{
			int num2 = Application.loadedLevel - 1;
			string customEventName2 = "Time_level_start" + num2;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("TimeLevel_Num", num2);
			Analytics.CustomEvent(customEventName2, dictionary);
		}
		Invoke("DelayLoadingFalseee", 0.4f);
	}

	private void DelayLoadingFalseee()
	{
		LoadingPanel.SetActive(false);
		InitBool = true;
		// Handheld.StopActivityIndicator();
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			PausePanel.SetActive(true);
			ParachuteControls.SetActive(false);
			Time.timeScale = 0f;
		}
		if (!InitBool)
		{
			return;
		}
		if (Application.loadedLevel > 15 && Application.loadedLevel <= 19)
		{
			if (bikeScript.CheckpointCounter == 3)
			{
				NextSkipBtn.SetActive(false);
			}
		}
		else if (Application.loadedLevel == 20)
		{
			if (bikeScript.CheckpointCounter == 2)
			{
				NextSkipBtn.SetActive(false);
			}
		}
		else if (bikeScript.CheckpointCounter == 4)
		{
			NextSkipBtn.SetActive(false);
		}
		if (PlayerPrefs.GetInt("RewardWacthed") == 1)
		{
			Analytics.CustomEvent("RewardAdWatchedSuccess");
			if (CheckPointRewardBool)
			{
				if (bikeScript.CheckpointCounter < 5)
				{
					CheckpointObj[bikeScript.CheckpointCounter].SetActive(false);
					bikeScript.CheckpointCounter++;
				}
				Invoke("RestBike", 0.3f);
				CheckpointRewardAdPanel.SetActive(false);
				CheckPointRewardBool = false;
			}
			else
			{
				timer = 60f;
				RewardAdPanel.SetActive(false);
			}
			PlayerPrefs.SetInt("RewardWacthed", 0);
		}
		else if (PlayerPrefs.GetInt("RewardWacthed") == 2)
		{
			if (CheckPointRewardBool)
			{
				VideoNotAvailablePanel.SetActive(true);
				CheckpointRewardAdPanel.SetActive(false);
				CheckPointRewardBool = false;
			}
			else if (LevelFailedBool)
			{
				Analytics.CustomEvent("WantRewardAdbutFailed");
				if (Application.loadedLevel > 2)
				{
					PlayerPrefs.SetInt("LvlFailedAdCallDB", 1);
				}
				if (PlayerPrefs.GetInt("ModeDB") == 0)
				{
					int num = Application.loadedLevel - 1;
					string customEventName = "level_failed" + num;
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					dictionary.Add("Level_Num", num);
					Analytics.CustomEvent(customEventName, dictionary);
				}
				else if (PlayerPrefs.GetInt("ModeDB") == 1)
				{
					int num2 = Application.loadedLevel - 1;
					string customEventName2 = "Time_level_failed" + num2;
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					dictionary.Add("TimeLevel_Num", num2);
					Analytics.CustomEvent(customEventName2, dictionary);
				}
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
			Invoke("LevelComepleteCall", 1f);
			LevelCompleteBool = false;
		}
		if (bikeScript.CityLevelComplete && LevelCompleteBool)
		{
			Invoke("LevelComepleteCall", 1f);
			LevelCompleteBool = false;
		}
		if (ParachutControllerScript.LandingFailedBool && LevelFailedBool)
		{
			if (Application.loadedLevel > 2)
			{
				PlayerPrefs.SetInt("LvlFailedAdCallDB", 1);
			}
			if (PlayerPrefs.GetInt("ModeDB") == 0)
			{
				int num3 = Application.loadedLevel - 1;
				string customEventName3 = "level_failed" + num3;
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("Level_Num", num3);
				Analytics.CustomEvent(customEventName3, dictionary);
			}
			else if (PlayerPrefs.GetInt("ModeDB") == 1)
			{
				int num4 = Application.loadedLevel - 2;
				string customEventName4 = "Time_level_failed" + num4;
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("TimeLevel_Num", num4);
				Analytics.CustomEvent(customEventName4, dictionary);
			}
			ParachuteControls.SetActive(false);
			LevelFailedPanel.SetActive(true);
			Time.timeScale = 0f;
			if (PlayerPrefs.GetInt("ModeDB") == 0)
			{
				Analytics.CustomEvent("FreeModeLevelFailedP");
			}
			else if (PlayerPrefs.GetInt("ModeDB") == 1)
			{
				Analytics.CustomEvent("TimeTrialModeLevelFailedP");
			}
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
				StartCoroutine(TimeCoolDown());
				timer = 0f;
				
			}
		}	
	}

	private IEnumerator TimeCoolDown(){
		yield return new WaitForSeconds(1f);
		if (count >0){
			TimeCount.text = "Yes " + "(" +((int)count).ToString() +")";
			count -= Time.deltaTime;
		}
		else {
			TimeCount.text = "Yes";
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
		PauseBTN.SetActive(false);
		UpgradeBtn.SetActive(false);
	}

	private void LevelComepleteCall()
	{
		if (Application.loadedLevel > 2 && PlayerPrefs.GetInt("NoAdsPurchase") == 0)
		{
			if (PlayerPrefs.GetInt("ADCounter") == 2)
			{
				CrossPromo.SetActive(true);
				Time.timeScale = 0f;
			}
			else if (PlayerPrefs.GetInt("ADCounter") == 4)
			{
				CrossPromo.SetActive(true);
				Time.timeScale = 0f;
			}
			else
			{
				PlayerPrefs.SetInt("LvlCompleteAdCallDB", 1);
			}
			if (PlayerPrefs.GetInt("ADCounter") >= 5)
			{
				PlayerPrefs.SetInt("ADCounter", 5);
			}
			else
			{
				PlayerPrefs.SetInt("ADCounter", PlayerPrefs.GetInt("ADCounter") + 1);
			}
		}
		if (PlayerPrefs.GetInt("RateUsDB") == 0 && (Application.loadedLevel == 3 || Application.loadedLevel == 6))
		{
			RateUsDialogue.SetActive(true);
		}
		ParachuteControls.SetActive(false);
		LevelCompletePanel.SetActive(true);
		if (PlayerPrefs.GetInt("ModeDB") == 0)
		{
			if (PlayerPrefs.GetInt("DoubleCoinsPurcahsed") == 1)
			{
				PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") + 1000);
			}
			else
			{
				PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") + 500);
			}
			if (Application.loadedLevel == 2)
			{
				SplashScript.FUnlocked_level2.ValueData = 1;
				
			}
			else if (Application.loadedLevel == 3)
			{
				SplashScript.FUnlocked_level3.ValueData = 1;
			
			}
			else if (Application.loadedLevel == 4)
			{
				SplashScript.FUnlocked_level4.ValueData = 1;
			}
			else if (Application.loadedLevel == 5)
			{
				SplashScript.FUnlocked_level5.ValueData = 1;
			}
			else if (Application.loadedLevel == 6)
			{
				SplashScript.FUnlocked_level6.ValueData = 1;
			}
			else if (Application.loadedLevel == 7)
			{
				SplashScript.FUnlocked_level7.ValueData = 1;
			}
			else if (Application.loadedLevel == 8)
			{
				SplashScript.FUnlocked_level8.ValueData = 1;
			}
			else if (Application.loadedLevel == 9)
			{
				SplashScript.FUnlocked_level9.ValueData = 1;
			}
			else if (Application.loadedLevel == 10)
			{
				SplashScript.FUnlocked_level10.ValueData = 1;
				PlayerPrefs.SetInt("UnlockTimeModeDB", 1);
			}
			else if (Application.loadedLevel == 11)
			{
				SplashScript.FUnlocked_level11.ValueData = 1;
			}
			else if (Application.loadedLevel == 12)
			{
				SplashScript.FUnlocked_level12.ValueData = 1;
			}
			else if (Application.loadedLevel == 13)
			{
				SplashScript.FUnlocked_level13.ValueData = 1;
			}
			else if (Application.loadedLevel == 14)
			{
				SplashScript.FUnlocked_level14.ValueData = 1;
			}
			else if (Application.loadedLevel == 15)
			{
				SplashScript.FUnlocked_level15.ValueData = 1;
			}
			else if (Application.loadedLevel == 16)
			{
				SplashScript.FUnlocked_level16.ValueData = 1;
			}
			else if (Application.loadedLevel == 17)
			{
				SplashScript.FUnlocked_level17.ValueData = 1;
			}
			else if (Application.loadedLevel == 18)
			{
				SplashScript.FUnlocked_level8.ValueData = 1;
			}
			else if (Application.loadedLevel == 19)
			{
				SplashScript.FUnlocked_level19.ValueData = 1;
			}
			else if (Application.loadedLevel == 20)
			{
				SplashScript.FUnlocked_level20.ValueData = 1;
			}
			CashText.text = "+ 500";
			int num = Application.loadedLevel - 1;
			string customEventName = "FreeModeLevel" + num;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("FreeMode_Level_Num", num);
			Analytics.CustomEvent(customEventName, dictionary);
			int num2 = Application.loadedLevel - 1;
			string customEventName2 = "level_complete" + num2;
			dictionary = new Dictionary<string, object>();
			dictionary.Add("Level_Num", num2);
			Analytics.CustomEvent(customEventName2, dictionary);
			Analytics.CustomEvent("FreeModeLevelComplete");
		}
		else if (PlayerPrefs.GetInt("ModeDB") == 1)
		{
			if (PlayerPrefs.GetInt("DoubleCoinsPurcahsed") == 1)
			{
				PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") + 2000);
			}
			else
			{
				PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") + 1000);
			}
			if (Application.loadedLevel == 2)
			{
				PlayerPrefs.SetInt("TUnlockedLevel2", 1);
			}
			else if (Application.loadedLevel == 3)
			{
				PlayerPrefs.SetInt("TUnlockedLevel3", 1);
			}
			else if (Application.loadedLevel == 4)
			{
				PlayerPrefs.SetInt("TUnlockedLevel4", 1);
			}
			else if (Application.loadedLevel == 5)
			{
				PlayerPrefs.SetInt("TUnlockedLevel5", 1);
			}
			else if (Application.loadedLevel == 6)
			{
				PlayerPrefs.SetInt("TUnlockedLevel6", 1);
			}
			else if (Application.loadedLevel == 7)
			{
				PlayerPrefs.SetInt("TUnlockedLevel7", 1);
			}
			else if (Application.loadedLevel == 8)
			{
				PlayerPrefs.SetInt("TUnlockedLevel8", 1);
			}
			else if (Application.loadedLevel == 9)
			{
				PlayerPrefs.SetInt("TUnlockedLevel9", 1);
			}
			else if (Application.loadedLevel == 10)
			{
				PlayerPrefs.SetInt("TUnlockedLevel10", 1);
			}
			else if (Application.loadedLevel == 11)
			{
				PlayerPrefs.SetInt("TUnlockedLevel11", 1);
			}
			else if (Application.loadedLevel == 12)
			{
				PlayerPrefs.SetInt("TUnlockedLevel12", 1);
			}
			else if (Application.loadedLevel == 13)
			{
				PlayerPrefs.SetInt("TUnlockedLevel13", 1);
			}
			else if (Application.loadedLevel == 14)
			{
				PlayerPrefs.SetInt("TUnlockedLevel14", 1);
			}
			else if (Application.loadedLevel == 15)
			{
				PlayerPrefs.SetInt("TUnlockedLevel15", 1);
			}
			else if (Application.loadedLevel == 16)
			{
				PlayerPrefs.SetInt("TUnlockedLevel16", 1);
			}
			else if (Application.loadedLevel == 17)
			{
				PlayerPrefs.SetInt("TUnlockedLevel17", 1);
			}
			else if (Application.loadedLevel == 18)
			{
				PlayerPrefs.SetInt("TUnlockedLevel18", 1);
			}
			else if (Application.loadedLevel == 19)
			{
				PlayerPrefs.SetInt("TUnlockedLevel19", 1);
			}
			else if (Application.loadedLevel == 20)
			{
				PlayerPrefs.SetInt("TUnlockedLevel20", 1);
			}
			CashText.text = "+ 1000";
			int num3 = Application.loadedLevel - 1;
			string customEventName3 = "TimeTrialModeLevel" + num3;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("TimeTrialMode_Level_Num", num3);
			Analytics.CustomEvent(customEventName3, dictionary);
			int loadedLevel = Application.loadedLevel;
			string customEventName4 = "Time_level_complete" + loadedLevel;
			dictionary = new Dictionary<string, object>();
			dictionary.Add("TimeLevel_Num", loadedLevel);
			Analytics.CustomEvent(customEventName4, dictionary);
			Analytics.CustomEvent("TimeTrialModeLevelComplete");
		}
		Time.timeScale = 0f;
	}

	public void Pausebtn_Click()
	{
		if (Application.loadedLevel > 2)
		{
			PlayerPrefs.SetInt("PauseAdCallDB", 1);
		}
		PausePanel.SetActive(true);
		Analytics.CustomEvent("PauseGameCall");
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
		Time.timeScale = 1f;
		PlayerPrefs.SetInt("Next", 1);
		StartCoroutine(LoadNewScene(1));
	}

	public void Nextbtn_Click(int LevelNum)
	{
		Time.timeScale = 1f;
		if(Application.loadedLevel == LevelNum){
			StartCoroutine(LoadNewScene(LevelNum+1));
		}
		
	}

	public void Yesbtn_Click()
	{
		Time.timeScale = 1f;
		PlayerPrefs.SetInt("RewardAdCallDB", 1);
	}

	public void Nobtn_Click()
	{
		Analytics.CustomEvent("NotWantRewardAd");
		if (PlayerPrefs.GetInt("ModeDB") == 0)
		{
			int num = Application.loadedLevel - 1;
			string customEventName = "level_failed" + num;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("Level_Num", num);
			Analytics.CustomEvent(customEventName, dictionary);
		}
		else if (PlayerPrefs.GetInt("ModeDB") == 1)
		{
			int num2 = Application.loadedLevel - 1;
			string customEventName2 = "Time_level_failed" + num2;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("TimeLevel_Num", num2);
			Analytics.CustomEvent(customEventName2, dictionary);
		}
		TimeBool = false;
		Time.timeScale = 1f;
		if (Application.loadedLevel > 2)
		{
			PlayerPrefs.SetInt("LvlFailedAdCallDB", 1);
		}
		ParachuteControls.SetActive(false);
		LevelFailedPanel.SetActive(true);
		RewardAdPanel.SetActive(false);
	}

	public void CheckPoint_Skip_Btn_Click()
	{
		CheckpointRewardAdPanel.SetActive(true);
	}

	public void CheckPoint_Reward_YesBtn_Click()
	{
		Time.timeScale = 1f;
		CheckPointRewardBool = true;
		PlayerPrefs.SetInt("RewardAdCallDB", 1);
	}

	public void CheckPoint_Reward_NoBtn_Click()
	{
		CheckpointRewardAdPanel.SetActive(false);
		CheckPointRewardBool = false;
	}

	public void VideoNotAvailable_Reward_OKBtn_Click()
	{
		VideoNotAvailablePanel.SetActive(false);
		CheckpointRewardAdPanel.SetActive(false);
		CheckPointRewardBool = false;
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
		if (IsInvoking("DelayLoadingFalseee"))
		{
			CancelInvoke("DelayLoadingFalseee");
		}
	}

	private IEnumerator LoadNewScene(int LevelScene)
	{
		yield return new WaitForSeconds(1f);
		AsyncOperation async = Application.LoadLevelAsync(LevelScene);
		while (!async.isDone)
		{
			yield return null;
		}
	}

	public void TestCheckBtn()
	{
		if (bikeScript.CheckpointCounter < 5)
		{
			CheckpointObj[bikeScript.CheckpointCounter].SetActive(false);
			bikeScript.CheckpointCounter++;
		}
		Invoke("RestBike", 0.3f);
	}

	public void Upgrade_Click_Btn()
	{
		UpgradePanel.SetActive(true);
	}

	public void Upgrade_Cross_Click_Btn()
	{
		UpgradePanel.SetActive(false);
	}

	public void RateUS_Click_Btn()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			Application.OpenURL("https://play.google.com/store/apps/details?id=com.monstergamesproductions.ramp.moto.rider");
		}
		else if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Application.OpenURL(string.Empty);
		}
		RateUsDialogue.SetActive(false);
		PlayerPrefs.SetInt("RateUsDB", 1);
		Analytics.CustomEvent("RateUSClick");
	}

	public void Cancel_RateUs_Click_Btn()
	{
		RateUsDialogue.SetActive(false);
	}

	public void LikeUS_Click_Btn()
	{
		Application.OpenURL("https://www.facebook.com/monstergamesproductions");
		Analytics.CustomEvent("FBLikeClick");
	}

	public void Download_Click_Btn()
	{
		Time.timeScale = 1f;
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.monstergamesproductions.formula.racing");
		PlayerPrefs.SetInt("ADCounter", 5);
		Analytics.CustomEvent("CrossAdClick");
		CrossPromo.SetActive(false);
	}

	public void Cancel_Click_Btn()
	{
		Time.timeScale = 1f;
		CrossPromo.SetActive(false);
	}
}
