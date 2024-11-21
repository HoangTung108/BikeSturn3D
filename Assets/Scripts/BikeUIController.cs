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
		public Image Speed;

		public Image tachometerNeedle;

		public Image barShiftGUI;

		public Text speedText;

		public Text GearText;
	}

	public GameObject[] CheckpointObj;

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

	private float angle = 0f;

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

	public static GameObject CheckPoint;
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
		if (PlayerPrefs.GetInt("LevelLoad") > 2)
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
		thisAngle = bikeScript.speed ;
		angle =  (-135f + thisAngle*2.5f +180f)/360f;
		
		BikeUI.tachometerNeedle.rectTransform.rotation = bikeScript.speed <=110 ? Quaternion.Euler(0f, 0f, 135f - thisAngle*2.5f ) : Quaternion.Euler(0f,0f, 230f);
		

		BikeUI.barShiftGUI.fillAmount = bikeScript.powerShift / 100f;
		BikeUI.Speed.fillAmount = angle ;
	}

	private void Awake()
	{
		QualitySettings.vSyncCount = 0; 
        Application.targetFrameRate = 120;
		int Level = PlayerPrefs.GetInt("LevelLoad");
	 	CheckPoint = GameObject.Find("CheckPointText");
		switch(Level)
		{
			case 1:
			GameObject mapObj1 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel1") as GameObject) as GameObject;
			break;
			case 2:
			GameObject mapObj2 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel2") as GameObject) as GameObject;
			break;
			case 3:
			GameObject mapOb3 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel3") as GameObject) as GameObject;
			break;
			case 4:
			GameObject mapObj4 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel4") as GameObject) as GameObject;
			break;
			case 5:
			GameObject mapObj5 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel5") as GameObject) as GameObject;
			break;
			case 6:
			GameObject mapObj6 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel6") as GameObject) as GameObject;
			break;
			case 7:
			GameObject mapObj7 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel7") as GameObject) as GameObject;
			break;
			case 8:
			GameObject mapObj8 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel8") as GameObject) as GameObject;
			break;
			case 9:
			GameObject mapObj9 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel9") as GameObject) as GameObject;
			break;
			case 10:
			GameObject mapObj10 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel10") as GameObject) as GameObject;
			break;
			case 11:
			GameObject mapObj11 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel11") as GameObject) as GameObject;
			break;
			case 12:
			GameObject mapObj12 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel12") as GameObject) as GameObject;
			break;
			case 13:
			GameObject mapObj13 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel13") as GameObject) as GameObject;
			break;
			case 14:
			GameObject mapObj14 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel14") as GameObject) as GameObject;
			break;
			case 15:
			GameObject mapObj15 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel15") as GameObject) as GameObject;
			break;
			case 16:
			GameObject mapObj16 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel16") as GameObject) as GameObject;
			break;
			case 17:
			GameObject mapObj17 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel17") as GameObject) as GameObject;
			break;
			case 18:
			GameObject mapObj18 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel18") as GameObject) as GameObject;
			break;
			case 19:
			GameObject mapObj19 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel19") as GameObject) as GameObject;
			break;
			case 20:
			GameObject mapObj20 = UnityEngine.Object.Instantiate(Resources.Load("MapLevel20") as GameObject) as GameObject;
			break;
		}
		
		Resources.UnloadUnusedAssets();
		for (int i =0; i <Spwanpoints.Length; i++)
		{
			Spwanpoints[i] = GameObject.Find(string.Format("Point{0}",i+1)).transform;
		}
	
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
			if (PlayerPrefs.GetInt("BikeSelDB") == 1 && PlayerPrefs.GetInt("LevelLoad") > 4)
			{
				UpgradeBtn.SetActive(true);
			}
			else if (PlayerPrefs.GetInt("BikeSelDB") == 2 && PlayerPrefs.GetInt("LevelLoad") > 8)
			{
				UpgradeBtn.SetActive(true);
			}
			else if (PlayerPrefs.GetInt("BikeSelDB") == 3 && PlayerPrefs.GetInt("LevelLoad") > 12)
			{
				UpgradeBtn.SetActive(true);
			}
			else if (PlayerPrefs.GetInt("BikeSelDB") == 4 && PlayerPrefs.GetInt("LevelLoad") > 15)
			{
				UpgradeBtn.SetActive(true);
			}
			else 
			{
				UpgradeBtn.SetActive(false);
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
			if (PlayerPrefs.GetInt("LevelLoad") == 2 && TrainingPanel != null)
				{
					TrainingPanel.SetActive(true);
				}
	
			
			if (PlayerPrefs.GetInt("LevelLoad") == 3 && TrainingPanel != null)
				{
					TrainingPanel.SetActive(true);
				}
				
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
		minutes = 0;
		seconds = 0;
		fraction = 0;
		BikeAnimationScript = UnityEngine.Object.FindObjectOfType<BikeAnimation>();
		BikeUI.Speed = GameObject.Find("BikeCanvas/Tachometer/Image").GetComponent<Image>();
		BikeUI.tachometerNeedle = GameObject.Find("BikeCanvas/Tachometer/Needle").GetComponent<Image>();
		BikeUI.barShiftGUI = GameObject.Find("BikeCanvas/CarShiftUI/Bar").GetComponent<Image>();
		BikeUI.speedText = GameObject.Find("BikeCanvas/Tachometer/Speed/SpeedText").GetComponent<Text>();
		BikeUI.GearText = GameObject.Find("BikeCanvas/Tachometer/Speed/Gear").GetComponent<Text>();
		if (PlayerPrefs.GetInt("ModeDB") == 1)
		{
			TimeShow = GameObject.Find("BikeCanvas/Control/Timer/TimerText").GetComponent<Text>();
			if (PlayerPrefs.GetInt("LevelLoad")> 1 && PlayerPrefs.GetInt("LevelLoad") <= 3)
			{
				timer = 360f;
			}
			else if (PlayerPrefs.GetInt("LevelLoad") > 3 && PlayerPrefs.GetInt("LevelLoad") <= 6)
			{
				timer = 300f;
			}
			else if (PlayerPrefs.GetInt("LevelLoad") > 6 && PlayerPrefs.GetInt("LevelLoad") <= 21)
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
			int num = PlayerPrefs.GetInt("LevelLoad") - 1;
			string customEventName = "level_start" + num;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("Level_Num", num);
			Analytics.CustomEvent(customEventName, dictionary);
		}
		else if (PlayerPrefs.GetInt("ModeDB") == 1)
		{
			int num2 = PlayerPrefs.GetInt("LevelLoad") - 1;
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
				if (PlayerPrefs.GetInt("LevelLoad") > 2)
				{
					PlayerPrefs.SetInt("LvlFailedAdCallDB", 1);
				}
				if (PlayerPrefs.GetInt("ModeDB") == 0)
				{
					int num = PlayerPrefs.GetInt("LevelLoad") - 1;
					string customEventName = "level_failed" + num;
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					dictionary.Add("Level_Num", num);
					Analytics.CustomEvent(customEventName, dictionary);
				}
				else if (PlayerPrefs.GetInt("ModeDB") == 1)
				{
					int num2 = PlayerPrefs.GetInt("LevelLoad") - 1;
					string customEventName2 = "Time_level_failed" + num2;
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					dictionary.Add("TimeLevel_Num", num2);
					Analytics.CustomEvent(customEventName2, dictionary);
				}
				ParachuteControls.SetActive(false);
				LevelFailedPanel.SetActive(true);
                AdsManager.Instance.UpdateBannerPosition(MaxSdkBase.BannerPosition.BottomCenter);
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
			if (PlayerPrefs.GetInt("LevelLoad") > 2)
			{
				PlayerPrefs.SetInt("LvlFailedAdCallDB", 1);
			}
			if (PlayerPrefs.GetInt("ModeDB") == 0)
			{
				int num3 = PlayerPrefs.GetInt("LevelLoad") - 1;
				string customEventName3 = "level_failed" + num3;
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("Level_Num", num3);
				Analytics.CustomEvent(customEventName3, dictionary);
			}
			else if (PlayerPrefs.GetInt("ModeDB") == 1)
			{
				int num4 = PlayerPrefs.GetInt("LevelLoad") - 2;
				string customEventName4 = "Time_level_failed" + num4;
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("TimeLevel_Num", num4);
				Analytics.CustomEvent(customEventName4, dictionary);
			}
			ParachuteControls.SetActive(false);
			LevelFailedPanel.SetActive(true);
            AdsManager.Instance.UpdateBannerPosition(MaxSdkBase.BannerPosition.BottomCenter);

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
		AdsManager.Instance.ShowMREC();
		AdsManager.Instance.ShowInterstial();
		if (PlayerPrefs.GetInt("LevelLoad") > 2 && PlayerPrefs.GetInt("NoAdsPurchase") == 0)
		{
			//if (PlayerPrefs.GetInt("ADCounter") == 2)
			//{
			//	CrossPromo.SetActive(true);
			//	Time.timeScale = 0f;
			//}
			//else if (PlayerPrefs.GetInt("ADCounter") == 4)
			//{
			//	CrossPromo.SetActive(true);
			//	Time.timeScale = 0f;
			//}
			//else
			//{
				PlayerPrefs.SetInt("LvlCompleteAdCallDB", 1);
			//}
			if (PlayerPrefs.GetInt("ADCounter") >= 5)
			{
				PlayerPrefs.SetInt("ADCounter", 5);
			}
			else
			{
				PlayerPrefs.SetInt("ADCounter", PlayerPrefs.GetInt("ADCounter") + 1);
			}
		}
		//if (PlayerPrefs.GetInt("RateUsDB") == 0 && (Application.loadedLevel == 3 || Application.loadedLevel == 6))
		//{
		//	RateUsDialogue.SetActive(true);
		//}
		ParachuteControls.SetActive(false);
		LevelCompletePanel.SetActive(true);
		AdsManager.Instance.UpdateBannerPosition(MaxSdkBase.BannerPosition.BottomCenter);
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
			int level_complete = PlayerPrefs.GetInt("LevelLoad");
			switch (level_complete)
			{
				case 1:
					PlayerPrefs.SetInt("FUnlockedLevel2",1) ;
					break;
				case 2:
					PlayerPrefs.SetInt("FUnlockedLevel3",1) ;
					break;
				case 3:
					PlayerPrefs.SetInt("FUnlockedLevel4",1) ;
					break;
				case 4:
					PlayerPrefs.SetInt("FUnlockedLevel5",1) ;
					break;
				case 5:
					PlayerPrefs.SetInt("FUnlockedLevel6",1) ;
					break;
				case 6:
					PlayerPrefs.SetInt("FUnlockedLevel7",1) ;
					break;
				case 7:
					PlayerPrefs.SetInt("FUnlockedLevel8",1) ;
					break;
				case 8:
					PlayerPrefs.SetInt("FUnlockedLevel9",1) ;
					break;
				case 9:
					PlayerPrefs.SetInt("FUnlockedLevel10",1) ;
					PlayerPrefs.SetInt("UnlockTimeModeDB", 1);
					break;
				case 10:
					PlayerPrefs.SetInt("FUnlockedLevel11",1) ;
					break;
				case 11:
					PlayerPrefs.SetInt("FUnlockedLevel12",1) ;
					break;
				case 12:
					PlayerPrefs.SetInt("FUnlockedLevel13",1) ;
					break;
				case 13:
					PlayerPrefs.SetInt("FUnlockedLevel14",1) ;
					break;
				case 14:
					PlayerPrefs.SetInt("FUnlockedLevel15",1) ;
					break;
				case 15:
					PlayerPrefs.SetInt("FUnlockedLevel16",1) ;
					break;
				case 16:
					PlayerPrefs.SetInt("FUnlockedLevel17",1) ;
					break;
				case 17:
					PlayerPrefs.SetInt("FUnlockedLevel18",1) ;
					break;
				case 18:
					PlayerPrefs.SetInt("FUnlockedLevel19",1) ;
					break;
				case 19:
					PlayerPrefs.SetInt("FUnlockedLevel20",1) ;
					break;
				default:
					break;
			}
	
			CashText.text = "+ 500";
			int num = PlayerPrefs.GetInt("LevelLoad") - 1;
			string customEventName = "FreeModeLevel" + num;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("FreeMode_Level_Num", num);
			Analytics.CustomEvent(customEventName, dictionary);
			int num2 = PlayerPrefs.GetInt("LevelLoad") - 1;
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
			int level_complete_time = PlayerPrefs.GetInt("LevelLoad");
			switch (level_complete_time)
			{
				case 1:
					PlayerPrefs.SetInt("TUnlockedLevel2",1) ;
					break;
				case 2:
					PlayerPrefs.SetInt("TUnlockedLevel3",1) ;
					break;
				case 3:
					PlayerPrefs.SetInt("TUnlockedLevel4",1) ;
					break;
				case 4:
					PlayerPrefs.SetInt("TUnlockedLevel5",1) ;
					break;
				case 5:
					PlayerPrefs.SetInt("TUnlockedLevel6",1) ;
					break;
				case 6:
					PlayerPrefs.SetInt("TUnlockedLevel7",1) ;
					break;
				case 7:
					PlayerPrefs.SetInt("TUnlockedLevel8",1) ;
					break;
				case 8:
					PlayerPrefs.SetInt("TUnlockedLevel9",1) ;
					break;
				case 9:
					PlayerPrefs.SetInt("TUnlockedLevel10",1) ;
					break;
				case 10:
					PlayerPrefs.SetInt("TUnlockedLevel11",1) ;
					break;
				case 11:
					PlayerPrefs.SetInt("TUnlockedLevel12",1) ;
					break;
				case 12:
					PlayerPrefs.SetInt("TUnlockedLevel13",1) ;
					break;
				case 13:
					PlayerPrefs.SetInt("TUnlockedLevel14",1) ;
					break;
				case 14:
					PlayerPrefs.SetInt("TUnlockedLevel15",1) ;
					break;
				case 15:
					PlayerPrefs.SetInt("TUnlockedLevel16",1) ;
					break;
				case 16:
					PlayerPrefs.SetInt("TUnlockedLevel17",1) ;
					break;
				case 17:
					PlayerPrefs.SetInt("TUnlockedLevel18",1) ;
					break;
				case 18:
					PlayerPrefs.SetInt("TUnlockedLevel19",1) ;
					break;
				case 19:
					PlayerPrefs.SetInt("TUnlockedLevel20",1) ;
					break;
				default:
					break;
			}
	
			
			CashText.text = "+ 1000";
			int num3 =PlayerPrefs.GetInt("LevelLoad") - 1;
			string customEventName3 = "TimeTrialModeLevel" + num3;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("TimeTrialMode_Level_Num", num3);
			Analytics.CustomEvent(customEventName3, dictionary);
			int loadedLevel = PlayerPrefs.GetInt("LevelLoad");
			string customEventName4 = "Time_level_complete" + loadedLevel;
			dictionary = new Dictionary<string, object>();
			dictionary.Add("TimeLevel_Num", loadedLevel);
			Analytics.CustomEvent(customEventName4, dictionary);
			Analytics.CustomEvent("TimeTrialModeLevelComplete");
		}
		PlayerPrefs.Save();
		Time.timeScale = 0f;
	}

	public void Pausebtn_Click()
	{
		AdsManager.Instance.ShowInterstial();
		if (PlayerPrefs.GetInt("LevelLoad") > 2)
		{
			PlayerPrefs.SetInt("PauseAdCallDB", 1);
		}
		TrainingPanel.SetActive(false);
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
        AdsManager.Instance.ShowInterstial();
        Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void Menubtn_Click()
	{
        AdsManager.Instance.ShowInterstial();
        Time.timeScale = 1f;
		PlayerPrefs.SetInt("Next", 1);
		StartCoroutine(LoadNewScene(1));
	}

	public void Nextbtn_Click()
	{
		AdsManager.Instance.ShowInterstial();
		Time.timeScale = 1f;
		PlayerPrefs.SetInt("LevelLoad", PlayerPrefs.GetInt("LevelLoad") +1);
	
		StartCoroutine(LoadNewScene(2));
	}

	public void Yesbtn_Click()
	{
		if (!AdsManager.Instance.IsRewardAvailable())
		{
			VideoNotAvailablePanel.SetActive(true);
			return;
		}
		AdsManager.Instance.ShowReward((b) =>
		{
            Time.timeScale = 1f;
            PlayerPrefs.SetInt("RewardAdCallDB", 1);
        });
	}

	public void Nobtn_Click()
	{
		Analytics.CustomEvent("NotWantRewardAd");
		if (PlayerPrefs.GetInt("ModeDB") == 0)
		{
			int num = PlayerPrefs.GetInt("LevelLoad") - 1;
			string customEventName = "level_failed" + num;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("Level_Num", num);
			Analytics.CustomEvent(customEventName, dictionary);
		}
		else if (PlayerPrefs.GetInt("ModeDB") == 1)
		{
			int num2 = PlayerPrefs.GetInt("LevelLoad") - 1;
			string customEventName2 = "Time_level_failed" + num2;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("TimeLevel_Num", num2);
			Analytics.CustomEvent(customEventName2, dictionary);
		}
		TimeBool = false;
		Time.timeScale = 1f;
		if (PlayerPrefs.GetInt("LevelLoad") > 2)
		{
			PlayerPrefs.SetInt("LvlFailedAdCallDB", 1);
		}
		ParachuteControls.SetActive(false);
		LevelFailedPanel.SetActive(true);
		RewardAdPanel.SetActive(false);
        AdsManager.Instance.UpdateBannerPosition(MaxSdkBase.BannerPosition.BottomCenter);
    }

	public void CheckPoint_Skip_Btn_Click()
	{
		CheckpointRewardAdPanel.SetActive(true);
	}

	public void CheckPoint_Reward_YesBtn_Click()
	{
		if (!AdsManager.Instance.IsRewardAvailable())
		{
			VideoNotAvailablePanel.SetActive(true);
			return;
		}
		AdsManager.Instance.ShowReward((b) =>
		{
            Time.timeScale = 1f;
            CheckPointRewardBool = true;
            PlayerPrefs.SetInt("RewardAdCallDB", 1);
        });
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
		AdsManager.Instance.HideMREC();
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
			Application.OpenURL("");
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
		Application.OpenURL("");
		Analytics.CustomEvent("FBLikeClick");
	}

	public void Download_Click_Btn()
	{
		Time.timeScale = 1f;
		Application.OpenURL("");
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
