using System.Collections.Generic;
//using GooglePlayGames;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class MenuScript : MonoBehaviour
{

	public GameObject BikeSelectionPanel;

	public GameObject ModeSelectionPanel;

	public GameObject ModeUnlockMsg;

	public GameObject SettingsPanel;

	public GameObject LevelSelectionPanel;

	public GameObject LevelSelectionPage1;

	public GameObject LevelSelectionPage2;

	public GameObject LoadingPanel;

	public GameObject InApPanel;

	public GameObject QuitePanel;

	public GameObject ThanksPanel;

	public int counter =1;

	public GameObject[] BikeArray;

	public GameObject BikeArrayDes;

	public GameObject Bike1;

	public GameObject Bike2;

	public GameObject Bike3;

	public GameObject Bike4;

	public GameObject Bike5;

	public GameObject BikeRightBtn;

	public GameObject BikeLeftBtn;

	public GameObject Target;

	private int LevelCounter;

	public Text CashText;

	public GameObject BikeSelectBtn;

	public GameObject Bike2PriceText;

	public GameObject Bike3PriceText;

	public GameObject Bike4PriceText;

	public GameObject Bike5PriceText;

	public GameObject Bike6PriceText;

	public GameObject Bike7PriceText;

	public GameObject Bike8PriceText;

	public GameObject Bike9PriceText;

	public GameObject Bike10PriceText;

	public GameObject Bike11PriceText;

	public GameObject NotEnoughCash;

	private int inAppbackClick;

	public GameObject SondOffBtn;

	public GameObject SondONBtn;

	public GameObject MUSICOffBtn;

	public GameObject MUSICONBtn;

	public GameObject BackgroundMusic;

	private int ScreenNumber;

	public Button EnglishLangBtn;

	public Button ChinaLangBtn;

	public Button FrenchLangBtn;

	public Button GermanLangBtn;

	public Button SpainishLangBtn;

	public Button IndianLangBtn;

	public AudioClip btn_click;

	private int MultiplayerBikecounter;

	private string HighScoreleaderBoardID = "highscore";

	private string CrazyStunterAchID = ".crazy.stunter";

	private string ProStunterAchID = "aaaaa.rider.ach.pro.stunter";

	public GameObject StarterPackMSG;

	public Image PowerScrollBar;

	public Image HandlingScrollBar;

	public Image BrakingScrollBar;

	public GameObject backClick;

	public GameObject backClick2;

	public static bool LevelPageNoBool;

	public static bool LoginBool;

	public Text textSound;

	public Text textMusic;

	public Text textLanguage;

	public GameObject panelRewardNotAvailable, buttonBuyBike;

	private string HighScoreleaderBoardIDAndroid = "CgkI2ZOc-_kPEAIQAA";

	private string CrazyStunterAchIDAndroid = "CgkI2ZOc-_kPEAIQAQ";

	private string ProStunterAchIDAndroid = "CgkI2ZOc-_kPEAIQAg";

	private int Language_count = 0;

	private void Awake(){
		
	}

	private void Start()
	{
		backClick.SetActive(false);
		Time.timeScale = 1f;
		// Handheld.StopActivityIndicator();
		PlayerPrefs.SetInt("ModeDB", 0);
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			LeaderboardManager.AuthenticateToGameCenter();
		}
		if (Application.platform == RuntimePlatform.Android)
		{
			//PlayGamesPlatform.DebugLogEnabled = true;
			//PlayGamesPlatform.Activate();
			if (!LoginBool)
			{
				Social.localUser.Authenticate(delegate(bool success)
				{
					if (success)
					{
						LoginBool = true;
						Debug.Log("Login Sucess");
					}
					else
					{
						Debug.Log("Login failed");
					}
				});
			}
		}
		PlayerPrefs.SetInt("MultiPlyerGameDB", 0);
		Analytics.CustomEvent("menuStart");
		if (PlayerPrefs.GetInt("Next") == 1)
		{
			LevelSelectionPanel.SetActive(true);
			LevelSelectionPage1.SetActive(true);
			BikeSelectionPanel.SetActive(false);
			ModeSelectionPanel.SetActive(false);
			PlayerPrefs.SetInt("Next", 0);
		}
		else
		{
			ScreenNumber = 0;
			BikeSelectionPanel.SetActive(true);
			ModeSelectionPanel.SetActive(false);
			LevelSelectionPanel.SetActive(false);
		}
		if (!LevelPageNoBool)
		{
			PlayerPrefs.SetInt("PageNo", 0);
			LevelPageNoBool = true;
		}
		PlayerPrefs.SetInt("UnlockTimeModeDB",0);
		BikeIns();
		PlayerPrefs.SetInt("CashDB",1000000);
		CashText.text = PlayerPrefs.GetInt("CashDB").ToString();
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			LeaderboardManager.ReportScore(PlayerPrefs.GetInt("CashDB"), HighScoreleaderBoardID);
			if (PlayerPrefs.GetInt("Achive1DB") == 0 && PlayerPrefs.GetInt("FUnlockedLevel15") == 1)
			{
				PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") + 2000);
				LeaderboardManager.ReportProgress(CrazyStunterAchID, 100.0);
				PlayerPrefs.SetInt("Achive1DB", 1);
			}
			if (PlayerPrefs.GetInt("Achive2DB") == 0 && PlayerPrefs.GetInt("TUnlockedLevel15") == 1)
			{
				PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") + 3000);
				LeaderboardManager.ReportProgress(ProStunterAchID, 100.0);
				PlayerPrefs.SetInt("Achive2DB", 1);
			}
		}
		if (Application.platform == RuntimePlatform.Android)
		{
			Invoke("ReportScore", 1f);
		}
		
		ScreenNumber = 1;
		if (counter <= 1)
		{
			BikeLeftBtn.SetActive(false);
			BikeRightBtn.SetActive(true);
		}
		else if (counter >= 4)
		{
			BikeRightBtn.SetActive(false);
			BikeLeftBtn.SetActive(true);
		}
		PlayerPrefs.SetInt("MultiPlyerGameDB", 0);
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
		
		 

		
	}

	public void ClosePanelRewardMessage()
	{
		panelRewardNotAvailable.SetActive(false);	
	}

	public void ShowLeaderBoardBtn_Click()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			LeaderboardManager.ShowLeaderboard();
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	private void ReportScore()
	{
		if (Application.platform != RuntimePlatform.Android)
		{
			return;
		}
		if (Social.localUser.authenticated)
		{
			Social.ReportScore(PlayerPrefs.GetInt("CashDB"), HighScoreleaderBoardIDAndroid, delegate
			{
			});
		}
		if (PlayerPrefs.GetInt("Achive1DB") == 0 && PlayerPrefs.GetInt("FUnlockedLevel15") == 1)
		{
			PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") + 2000);
			if (Social.localUser.authenticated)
			{
				Social.ReportProgress(CrazyStunterAchIDAndroid, 100.0, delegate
				{
				});
			}
			PlayerPrefs.SetInt("Achive1DB", 1);
		}
		if (PlayerPrefs.GetInt("Achive2DB") == 0 && PlayerPrefs.GetInt("TUnlockedLevel15") == 1)
		{
			PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") + 3000);
			if (Social.localUser.authenticated)
			{
				Social.ReportProgress(ProStunterAchIDAndroid, 100.0, delegate
				{
				});
			}
			PlayerPrefs.SetInt("Achive2DB", 1);
		}
	}

	public void ShowLeaderBoardBtn_Android_Click()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			Social.ShowLeaderboardUI();
		}
	}

	public void ShowAchievementBtn_Android_Click()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			Social.ShowAchievementsUI();
		}
	}

	public void PlayAds(){
		//if (Advertisement.IsReady()){
		//	Advertisement.Show();
		//}
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.Escape) && ScreenNumber == 0)
		{
			QuitePanel.SetActive(true);
			if (PlayerPrefs.GetString("Sound Status") == "True")
			{
				GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
			}
		}
		else if (Input.GetKey(KeyCode.Escape) && ScreenNumber == 1)
		{
			BikeSelectBackClick_Btn();
		}
		else if (Input.GetKey(KeyCode.Escape) && ScreenNumber == 2)
		{
			InAppBackClick_Btn();
		}
		else if (Input.GetKey(KeyCode.Escape) && ScreenNumber == 3)
		{
			ModeSelectionBack_Click();
		}
		else if (Input.GetKey(KeyCode.Escape) && ScreenNumber == 4)
		{
			LevelSelectionBack_Click();
		}
		if (PlayerPrefs.GetString("Sound Status") == "False" )
		{
			textSound.text = "OFF";
			PlayerPrefs.SetString("Sound Status", "False");
			PlayerPrefs.Save();
		}
		else
		{
			textSound.text = "ON";
			PlayerPrefs.SetString("Sound Status", "True");
			PlayerPrefs.Save();
		}
		if (PlayerPrefs.GetString("Music Status") == "False")
		{
			textMusic.text = "OFF";
			BackgroundMusic.SetActive(false);
			PlayerPrefs.SetString("Music Status", "False");
			PlayerPrefs.Save();
		}
		else
		{
			textMusic.text = "ON";
			BackgroundMusic.SetActive(true);
			PlayerPrefs.SetString("Music Status", "True");
			PlayerPrefs.Save();
		}

	}

	public void PlayClick_Btn()
	{
		LevelSelectionPanel.SetActive(false);
		BikeSelectionPanel.SetActive(true);
		ScreenNumber = 1;
		if (counter <= 1)
		{
			BikeLeftBtn.SetActive(false);
			BikeRightBtn.SetActive(true);
		}
		else if (counter >= 4)
		{
			BikeRightBtn.SetActive(false);
			BikeLeftBtn.SetActive(true);
		}
		PlayerPrefs.SetInt("MultiPlyerGameDB", 0);
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void SettingsClick_Btn()
	{
		SettingsPanel.SetActive(true);
		ScreenNumber = 1;
		LanguageSelection();
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void Settings_Back_Click_Btn()
	{
		SettingsPanel.SetActive(false);
		ScreenNumber = 0;
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void MultiplayerClick_Btn()
	{
		Analytics.CustomEvent("menumultiplayer");
		LevelSelectionPanel.SetActive(false);
		BikeSelectionPanel.SetActive(true);
		ScreenNumber = 1;
		PlayerPrefs.SetInt("MultiPlyerGameDB", 1);
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void InAppClick_Btn()
	{
		inAppbackClick = 0;
		InApPanel.SetActive(true);
		ScreenNumber = 2;
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void InAppBackClick_Btn()
	{
		if (inAppbackClick == 0)
		{
			InApPanel.SetActive(false);
			ScreenNumber = 0;
		}
		else if (inAppbackClick == 1)
		{
			InApPanel.SetActive(false);
			PlayClick_Btn();
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void NotEnough_Buy_InAppClick_Btn()
	{
		inAppbackClick = 1;
		InApPanel.SetActive(true);
		BikeSelectionPanel.SetActive(false);
		ScreenNumber = 2;
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelSelectionBack_Click()
	{
		ScreenNumber = 1;
		LevelSelectionPanel.SetActive(false);
		BikeSelectionPanel.SetActive(false);
		ModeSelectionPanel.SetActive(true);
		backClick.SetActive(false);
		backClick2.SetActive(false);
		ScreenNumber = 3;
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void BikeSelectBackClick_Btn()
	{
		PlayerPrefs.SetInt("MultiPlyerGameDB", 0);

		BikeSelectionPanel.SetActive(false);
		ModeSelectionPanel.SetActive(false);
		ScreenNumber = 0;
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void RightClick_Btn()
	{
		if (counter >= 11)
		{
			BikeRightBtn.SetActive(false);
			BikeLeftBtn.SetActive(true);
			counter = 11;
		}
		else
		{
			counter++;
			BikeRightBtn.SetActive(true);
			BikeLeftBtn.SetActive(true);
			if (counter == 11) {
				BikeLeftBtn.SetActive(true);
				BikeRightBtn.SetActive(false);
			}
			DesBikeIns();
			BikeIns();
		}
		RefreshButtonState();

        if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LeftClick_Btn()
	{
		if (counter <=1)
		{
			BikeLeftBtn.SetActive(false);
			BikeRightBtn.SetActive(true);
			counter = 1;
			
		}
		else
		{
			counter--;
			BikeLeftBtn.SetActive(true);
			BikeRightBtn.SetActive(true);
			if (counter == 1) {
				BikeLeftBtn.SetActive(false);
				BikeRightBtn.SetActive(true);
			}
			DesBikeIns();
			BikeIns();
		}
		RefreshButtonState();
        if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	private void RefreshButtonState()
	{
		Debug.Log("Bike:" + counter);
        buttonBuyBike.SetActive(PlayerPrefs.GetInt("bike_" + counter, 0) == 0);
        BikeSelectBtn.SetActive(PlayerPrefs.GetInt("bike_" + counter, 0) == 1);
    }

	public void BikeSelectGo_Btn()
	{
		if (PlayerPrefs.GetInt("MultiPlyerGameDB") == 0)
		{
			LevelSelectionPanel.SetActive(false);
			ModeSelectionPanel.SetActive(true);
			BikeSelectionPanel.SetActive(false);
			PlayerPrefs.SetInt("BikeSelDB", counter);
			CheckBike();
		}
	
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}
	private void CheckBike(){
		switch (counter){
			case 2: 
				PlayerPrefs.SetInt("bike_2",1);
				break;
			case 3:
				PlayerPrefs.SetInt("bike_3",1);
				break;
			case 4:
				PlayerPrefs.SetInt("bike_4",1);
				break;
			case 5:
				PlayerPrefs.SetInt("bike_5",1);
				break;
			case 6:
				PlayerPrefs.SetInt("bike_6",1);
				break;
			case 7:
				PlayerPrefs.SetInt("bike_7",1);
				break;
			case 8:
				PlayerPrefs.SetInt("bike_8",1);
				break;
			case 9:
				PlayerPrefs.SetInt("bike_9",1);
				break;
			case 10:
				PlayerPrefs.SetInt("bike_10",1);
				break;
			case 11:
				PlayerPrefs.SetInt("bike_11",1);
				break;
			default:
				break;

		}
		
	}

	public void FreeMode_Btn()
	{ 	
		backClick.SetActive(true);
		StartCoroutine(TurnOnFree());
	}
	IEnumerator<WaitForSeconds> TurnOnFree()
	{
		yield return new WaitForSeconds(0.2f);
		LevelSelectionPanel.SetActive(true);
		ModeSelectionPanel.SetActive(false);
		BikeSelectionPanel.SetActive(false);
		LevelSelectionPage1.SetActive(true);
		LevelSelectionPage2.SetActive(false);
		if (PlayerPrefs.GetInt("PageNo") == 1)
		{
			LevelSelection_Next_Click();
		}
		else
		{
			LevelSelection_Back2_Click();
		}
		PlayerPrefs.SetInt("ModeDB", 0);
		ScreenNumber = 4;
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}

	}

	public void TimeMode_Btn()
	{
		backClick2.SetActive(true);
		StartCoroutine(TurnOnTime());
	}
	IEnumerator<WaitForSeconds> TurnOnTime()
	{
		yield return new WaitForSeconds(0.2f);
			if (PlayerPrefs.GetInt("FUnlockedLevel10")== 1){
				PlayerPrefs.SetInt("UnlockTimeModeDB", 1);
				
			}
		if (PlayerPrefs.GetInt("UnlockTimeModeDB") == 0)
		{
			
			ModeUnlockMsg.SetActive(true);
			backClick2.SetActive(false);
		}
		else
		{
			LevelSelectionPanel.SetActive(true);
			ModeSelectionPanel.SetActive(false);
			BikeSelectionPanel.SetActive(false);
			LevelSelectionPage1.SetActive(true);
			LevelSelectionPage2.SetActive(false);
			if (PlayerPrefs.GetInt("PageNo") == 1)
			{
				LevelSelection_Next_Click();
			}
			else
			{
				LevelSelection_Back2_Click();
			}
			PlayerPrefs.SetInt("ModeDB", 1);
			ScreenNumber = 4;
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}

	}
	public void ModeSelectionBack_Click()
	{
		LevelSelectionPanel.SetActive(false);
		ModeSelectionPanel.SetActive(false);
		BikeSelectionPanel.SetActive(true);
		backClick.SetActive(false);
		backClick2.SetActive(false);
		ScreenNumber = 1;
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelSelection_Next_Click()
	{
		PlayerPrefs.SetInt("PageNo", 1);
		LevelSelectionPage1.SetActive(false);
		LevelSelectionPage2.SetActive(true);
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelSelection_Back2_Click()
	{
		PlayerPrefs.SetInt("PageNo", 0);
		LevelSelectionPage1.SetActive(true);
		LevelSelectionPage2.SetActive(false);
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void FBBtn_Click()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			Application.OpenURL("");
		}
		else if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Application.OpenURL("");
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void g_plusBtn_Click()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			Application.OpenURL("");
		}
		else if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Application.OpenURL("");
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void TwitterBtn_Click()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
		}
		else if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void BikeBuyBtn_Click()
	{
		if(AdsManager.Instance.IsRewardAvailable())
		{
			AdsManager.Instance.ShowReward((b) =>
			{
				PlayerPrefs.SetInt("bike_" + counter, 1);
				buttonBuyBike.SetActive(false);
                BikeSelectBtn.SetActive(true);
				RefreshButtonState();
            });
		}
		else
		{
			Debug.Log("Calling panelRewardNotAvailable.......");
			panelRewardNotAvailable.SetActive(true);
		}

        #region Old
        //if (counter == 2 && PlayerPrefs.GetInt("CashDB") >= 2000)
        //{
        //	SplashScript.BikeTwo.ValueData =1;
        //	PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 2000);
        //	BikeSelectBtn.SetActive(true);
        //	Bike2PriceText.SetActive(false);
        //}
        //else if (counter == 3 && PlayerPrefs.GetInt("CashDB") >= 5000)
        //{
        //	SplashScript.BikeThree.ValueData =1;
        //	PlayerPrefs.SetInt("BikeThreePurcahsed", 1);
        //	PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 5000);
        //	BikeSelectBtn.SetActive(true);
        //	Bike3PriceText.SetActive(false);
        //}
        //else if (counter == 4 && PlayerPrefs.GetInt("CashDB") >= 20000)
        //{
        //	SplashScript.BikeFour.ValueData =1;
        //	PlayerPrefs.SetInt("BikeFourPurcahsed", 1);
        //	PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 20000);
        //	BikeSelectBtn.SetActive(true);

        //	Bike4PriceText.SetActive(false);

        //}
        //else if (counter == 5 && PlayerPrefs.GetInt("CashDB") >= 40000)
        //{
        //	SplashScript.BikeFive.ValueData =1;
        //	PlayerPrefs.SetInt("BikeFivePurcahsed", 1);
        //	PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 40000);
        //	BikeSelectBtn.SetActive(true);

        //	Bike5PriceText.SetActive(false);

        //}
        //else if (counter == 6 && PlayerPrefs.GetInt("CashDB") >= 50000)
        //{
        //	SplashScript.BikeSix.ValueData =1;
        //	PlayerPrefs.SetInt("BikeSixPurcahsed", 1);
        //	PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 50000);
        //	BikeSelectBtn.SetActive(true);

        //	Bike6PriceText.SetActive(false);

        //}
        //else if (counter == 7 && PlayerPrefs.GetInt("CashDB") >= 60000)
        //{
        //	SplashScript.BikeSeven.ValueData =1;
        //	PlayerPrefs.SetInt("BikeSevenPurcahsed", 1);
        //	PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 60000);
        //	BikeSelectBtn.SetActive(true);

        //	Bike7PriceText.SetActive(false);

        //}
        //else if (counter == 8 && PlayerPrefs.GetInt("CashDB") >= 70000)
        //{
        //	SplashScript.BikeEight.ValueData =1;
        //	PlayerPrefs.SetInt("BikeEightPurcahsed", 1);
        //	PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 70000);
        //	BikeSelectBtn.SetActive(true);

        //	Bike8PriceText.SetActive(false);

        //}
        //else if (counter == 9 && PlayerPrefs.GetInt("CashDB") >= 80000)
        //{
        //	SplashScript.BikeNine.ValueData =1;
        //	PlayerPrefs.SetInt("BikeNinePurcahsed", 1);
        //	PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 80000);
        //	BikeSelectBtn.SetActive(true);

        //	Bike9PriceText.SetActive(false);

        //}
        //else if (counter == 10 && PlayerPrefs.GetInt("CashDB") >= 90000)
        //{
        //	SplashScript.BikeTen.ValueData =1;
        //	PlayerPrefs.SetInt("BikeTenPurcahsed", 1);
        //	PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 90000);
        //	BikeSelectBtn.SetActive(true);

        //	Bike10PriceText.SetActive(false);

        //}
        //else if (counter == 11 && PlayerPrefs.GetInt("CashDB") >= 100000)
        //{
        //	SplashScript.BikeEleven.ValueData =1;
        //	PlayerPrefs.SetInt("BikeElevenPurcahsed", 1);
        //	PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 100000);
        //	BikeSelectBtn.SetActive(true);

        //	Bike11PriceText.SetActive(false);

        //}
        //else
        //{
        //	NotEnoughCash.SetActive(true);
        //}
        #endregion

        CashText.text = PlayerPrefs.GetInt("CashDB").ToString();
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_1_Btn()
	{
		LoadingPanel.SetActive(true);
		// LevelCounter = 2;
		PlayerPrefs.SetInt("LevelLoad",1);
		StartCoroutine(LoadNewScene());
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_2_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel2") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			PlayerPrefs.SetInt("LevelLoad",2);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel2") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			PlayerPrefs.SetInt("LevelLoad",2);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_3_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel3") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 4;
			PlayerPrefs.SetInt("LevelLoad",3);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel3") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 4;
			PlayerPrefs.SetInt("LevelLoad",3);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_4_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel4") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 5;
			PlayerPrefs.SetInt("LevelLoad",4);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel4") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 5;
			PlayerPrefs.SetInt("LevelLoad",4);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_5_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel5") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 6;
			PlayerPrefs.SetInt("LevelLoad",5);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel5") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 6;
			PlayerPrefs.SetInt("LevelLoad",5);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_6_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel6") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 7;
			PlayerPrefs.SetInt("LevelLoad",6);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel6") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 7;
			PlayerPrefs.SetInt("LevelLoad",6);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_7_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel7") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 8;
			PlayerPrefs.SetInt("LevelLoad",7);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel7") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 8;
			PlayerPrefs.SetInt("LevelLoad",7);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_8_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel8") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 9;
			PlayerPrefs.SetInt("LevelLoad",8);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel8") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 9;
			PlayerPrefs.SetInt("LevelLoad",8);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_9_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel9") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 10;
			PlayerPrefs.SetInt("LevelLoad",9);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel9") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 10;
			PlayerPrefs.SetInt("LevelLoad",9);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_10_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel10") == 1&& PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 11;
			PlayerPrefs.SetInt("LevelLoad",10);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel10") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 11;
			PlayerPrefs.SetInt("LevelLoad",10);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_11_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel11") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 12;
			PlayerPrefs.SetInt("LevelLoad",11);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel11") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 12;
			PlayerPrefs.SetInt("LevelLoad",11);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_12_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel12") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 13;
			PlayerPrefs.SetInt("LevelLoad",12);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel12") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 13;
			PlayerPrefs.SetInt("LevelLoad",12);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_13_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel13") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 14;
			PlayerPrefs.SetInt("LevelLoad",13);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel13") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 14;
			PlayerPrefs.SetInt("LevelLoad",13);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_14_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel14") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 15;
			PlayerPrefs.SetInt("LevelLoad",14);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel14") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 15;
			PlayerPrefs.SetInt("LevelLoad",14);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_15_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel15") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 16;
			PlayerPrefs.SetInt("LevelLoad",15);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel15") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 16;
			PlayerPrefs.SetInt("LevelLoad",15);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_16_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel16") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 17;
			PlayerPrefs.SetInt("LevelLoad",16);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel16") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 17;
			PlayerPrefs.SetInt("LevelLoad",16);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_17_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel17") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 18;
			PlayerPrefs.SetInt("LevelLoad",17);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel17") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 18;
			PlayerPrefs.SetInt("LevelLoad",17);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_18_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel18") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 19;
			PlayerPrefs.SetInt("LevelLoad",18);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel18") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 19;
			PlayerPrefs.SetInt("LevelLoad",18);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_19_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel19") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 20;
			PlayerPrefs.SetInt("LevelLoad",19);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel19") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 20;
			PlayerPrefs.SetInt("LevelLoad",19);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_20_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel20") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			// LevelCounter = 21;
			PlayerPrefs.SetInt("LevelLoad",20);
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel20") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			PlayerPrefs.SetInt("UnlockALLLevelsDB", 1);
			LoadingPanel.SetActive(true);
			// LevelCounter = 21;
			PlayerPrefs.SetInt("LevelLoad",20);
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	private IEnumerator<object> LoadNewScene()
	{
		yield return new WaitForSeconds(3f);
		AsyncOperation async = Application.LoadLevelAsync("gameplay");
		while (!async.isDone)
		{
			yield return null;
		}
	}

	public void SoundBtn_Click()
	{
		if (PlayerPrefs.GetString("Sound Status") == "False")
		{
			
			textSound.text = "OFF";
			PlayerPrefs.SetString("Sound Status", "True");
			PlayerPrefs.Save();
		}
		else if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			textSound.text = "ON";
			PlayerPrefs.SetString("Sound Status", "False");
			PlayerPrefs.Save();
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void MusicBtn_Click()
	{
		if (PlayerPrefs.GetString("Music Status") == "False")
		{
			textMusic.text = "OFF";
			BackgroundMusic.SetActive(false);
			PlayerPrefs.SetString("Music Status", "True");
			PlayerPrefs.Save();
		}
		else if (PlayerPrefs.GetString("Music Status") == "True")
		{
			textMusic.text = "ON";
			BackgroundMusic.SetActive(true);
			PlayerPrefs.SetString("Music Status", "False");
			PlayerPrefs.Save();
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	private void OnApplicationPause(bool isPause)
	{
		if (isPause)
		{
			Analytics.CustomEvent("menuexit");
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
		}
	}

	private bool WantsToQuit()
    {
		PlayAds();
        return true;
    }
	private void Quiting(){
		PlayerPrefs.Save();
	}
	public void Quit_Yes_Click()
	{
		Analytics.CustomEvent("menuexit");
		
		Application.wantsToQuit += WantsToQuit;
		
		Application.quitting += Quiting;
		Application.Quit();
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void Quit_No_Click()
	{
		Time.timeScale = 1f;
		QuitePanel.SetActive(false);
		BikeSelectionPanel.SetActive(true);
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void Thanks_ok_Click()
	{
		Time.timeScale = 1f;
		ThanksPanel.SetActive(false);
	}

	public void NextLanguage_Select()
	{
		if (Language_count != null && Language_count <6)
		{

			Language_count++;
		}
		if (Language_count >=6)
		{
			Language_count = 0;
		}
		PlayerPrefs.SetInt("LanguageSet", Language_count);
		LanguageSelection();
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
		PlayerPrefs.Save();
	}

	public void LastLanguage_Select()
	{
		if (Language_count != null && Language_count >0)
		{

			Language_count --;
		}
		if (Language_count <=0)
		{
			Language_count = 5;
		}
		PlayerPrefs.SetInt("LanguageSet", Language_count);
		LanguageSelection();
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
		PlayerPrefs.Save();
	}

	
	private void LanguageSelection()
	{
		switch (PlayerPrefs.GetInt("LanguageSet"))
		{
		case 0:
			textLanguage.text = "ENGLISH";
			break;
		case 1:
			textLanguage.text = "CHINA";
			
			break;
		case 2:
			textLanguage.text = "FRENCH";
			
			break;
		case 3:
			textLanguage.text = "GERMAN";
		
			break;
		case 4:
			textLanguage.text = "SPANISH";
		
			break;
		case 5:
			textLanguage.text = "INDIAN";
		
			break;
		}
	}

	public void DesBikeIns()
	{
		Object.Destroy(BikeArrayDes);
	}

	public void BikeIns()
	{
		
		if (counter == 1)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			CloseAllPricePanel();
			BikeSelectBtn.SetActive(true);
			MultiplayerBikecounter = 0;
			PowerScrollBar.fillAmount = 0.1f;
			HandlingScrollBar.fillAmount = 0.15f;
			BrakingScrollBar.fillAmount = 0.12f;
		}
		else if (counter == 2)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (PlayerPrefs.GetInt("bike_2") == 1)
			{
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
				
			}
			else
			{
				BikeSelectBtn.SetActive(false);
				//Bike2PriceText.SetActive(true);
				Bike3PriceText.SetActive(false);
				Bike4PriceText.SetActive(false);
				Bike5PriceText.SetActive(false);
				Bike6PriceText.SetActive(false);
				Bike7PriceText.SetActive(false);
				Bike8PriceText.SetActive(false);
				Bike9PriceText.SetActive(false);
				Bike10PriceText.SetActive(false);
				Bike11PriceText.SetActive(false);
			}
			MultiplayerBikecounter = 1;
			PowerScrollBar.fillAmount = 0.15f;
			HandlingScrollBar.fillAmount = 0.1f;
			BrakingScrollBar.fillAmount = 0.12f;
		}
		else if (counter == 3)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (PlayerPrefs.GetInt("bike_3")== 1)
			{
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
			}
			else
			{	
				BikeSelectBtn.SetActive(false);
				//Bike3PriceText.SetActive(true);
				Bike2PriceText.SetActive(false);
				Bike4PriceText.SetActive(false);
				Bike5PriceText.SetActive(false);
				Bike6PriceText.SetActive(false);
				Bike7PriceText.SetActive(false);
				Bike8PriceText.SetActive(false);
				Bike9PriceText.SetActive(false);
				Bike10PriceText.SetActive(false);
				Bike11PriceText.SetActive(false);
			}
		
			MultiplayerBikecounter = 2;
			PowerScrollBar.fillAmount = 0.25f;
			HandlingScrollBar.fillAmount = 0.12f;
			BrakingScrollBar.fillAmount = 0.2f;
		}
		else if (counter == 4)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (PlayerPrefs.GetInt("bike_4") == 1)
			{
			
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
			}
			else
			{
				
				BikeSelectBtn.SetActive(false);
				//Bike4PriceText.SetActive(true);
				Bike2PriceText.SetActive(false);
				Bike3PriceText.SetActive(false);
				Bike5PriceText.SetActive(false);
				Bike6PriceText.SetActive(false);
				Bike7PriceText.SetActive(false);
				Bike8PriceText.SetActive(false);
				Bike9PriceText.SetActive(false);
				Bike10PriceText.SetActive(false);
				Bike11PriceText.SetActive(false);
			}
			MultiplayerBikecounter = 3;
			PowerScrollBar.fillAmount = 0.35f;
			HandlingScrollBar.fillAmount = 0.22f;
			BrakingScrollBar.fillAmount = 0.4f;
		}
		else if (counter == 5)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (PlayerPrefs.GetInt("bike_5") == 1)
			{
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
			}
			else
			{
				BikeSelectBtn.SetActive(false);

				//Bike5PriceText.SetActive(true);
				Bike2PriceText.SetActive(false);
				Bike3PriceText.SetActive(false);
				Bike4PriceText.SetActive(false);
				
				Bike6PriceText.SetActive(false);
				Bike7PriceText.SetActive(false);
				Bike8PriceText.SetActive(false);
				Bike9PriceText.SetActive(false);
				Bike10PriceText.SetActive(false);
				Bike11PriceText.SetActive(false);
			}
			
			MultiplayerBikecounter = 4;
			PowerScrollBar.fillAmount = 0.55f;
			HandlingScrollBar.fillAmount = 0.42f;
			BrakingScrollBar.fillAmount = 0.6f;
		}
		else if (counter == 6)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (PlayerPrefs.GetInt("bike_6") == 1)
			{
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
			}
			else
			{
				BikeSelectBtn.SetActive(false);
	
				//Bike6PriceText.SetActive(true);
				Bike2PriceText.SetActive(false);
				Bike3PriceText.SetActive(false);
				Bike4PriceText.SetActive(false);
				Bike5PriceText.SetActive(false);
				
				Bike7PriceText.SetActive(false);
				Bike8PriceText.SetActive(false);
				Bike9PriceText.SetActive(false);
				Bike10PriceText.SetActive(false);
				Bike11PriceText.SetActive(false);
			}
			
			MultiplayerBikecounter = 5;
			PowerScrollBar.fillAmount = 0.65f;
			HandlingScrollBar.fillAmount = 0.52f;
			BrakingScrollBar.fillAmount = 0.62f;
		}
		else if (counter == 7)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (PlayerPrefs.GetInt("bike_7") == 1)
			{
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
			}
			else
			{
				BikeSelectBtn.SetActive(false);
		
				//Bike7PriceText.SetActive(true);
				Bike2PriceText.SetActive(false);
				Bike3PriceText.SetActive(false);
				Bike4PriceText.SetActive(false);
				Bike5PriceText.SetActive(false);
				Bike6PriceText.SetActive(false);
			
				Bike8PriceText.SetActive(false);
				Bike9PriceText.SetActive(false);
				Bike10PriceText.SetActive(false);
				Bike11PriceText.SetActive(false);
			}
			
			MultiplayerBikecounter = 6;
			PowerScrollBar.fillAmount = 0.75f;
			HandlingScrollBar.fillAmount = 0.62f;
			BrakingScrollBar.fillAmount = 0.52f;
		}
		else if (counter == 8)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (PlayerPrefs.GetInt("bike_8") == 1)
			{
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
			}
			else
			{
				BikeSelectBtn.SetActive(false);
		
				//Bike8PriceText.SetActive(true);
				Bike2PriceText.SetActive(false);
				Bike3PriceText.SetActive(false);
				Bike4PriceText.SetActive(false);
				Bike5PriceText.SetActive(false);
				Bike6PriceText.SetActive(false);
				Bike7PriceText.SetActive(false);
			
				Bike9PriceText.SetActive(false);
				Bike10PriceText.SetActive(false);
				Bike11PriceText.SetActive(false);
			}
			
			MultiplayerBikecounter = 7;
			PowerScrollBar.fillAmount= 0.85f;
			HandlingScrollBar.fillAmount = 0.72f;
			BrakingScrollBar.fillAmount = 0.62f;
		}
		else if (counter == 9)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (PlayerPrefs.GetInt("bike_9")== 1)
			{
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
			}
			else
			{
				BikeSelectBtn.SetActive(false);
				//Bike9PriceText.SetActive(true);
				Bike2PriceText.SetActive(false);
				Bike3PriceText.SetActive(false);
				Bike4PriceText.SetActive(false);
				Bike5PriceText.SetActive(false);
				Bike6PriceText.SetActive(false);
				Bike7PriceText.SetActive(false);
				Bike8PriceText.SetActive(false);
				Bike10PriceText.SetActive(false);
				Bike11PriceText.SetActive(false);
			}
		
			MultiplayerBikecounter = 8;
			PowerScrollBar.fillAmount = 0.85f;
			HandlingScrollBar.fillAmount= 0.8f;
			BrakingScrollBar.fillAmount = 0.7f;
		}
		else if (counter == 10)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (PlayerPrefs.GetInt("bike_10")== 1)
			{
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
			}
			else
			{
				BikeSelectBtn.SetActive(false);
				//Bike10PriceText.SetActive(true);
				Bike2PriceText.SetActive(false);
				Bike3PriceText.SetActive(false);
				Bike4PriceText.SetActive(false);
				Bike5PriceText.SetActive(false);
				Bike6PriceText.SetActive(false);
				Bike7PriceText.SetActive(false);
				Bike8PriceText.SetActive(false);
				Bike9PriceText.SetActive(false);
				Bike11PriceText.SetActive(false);
			}
			
			MultiplayerBikecounter = 9;
			PowerScrollBar.fillAmount = 0.9f;
			HandlingScrollBar.fillAmount = 0.82f;
			BrakingScrollBar.fillAmount = 0.75f;
		}
		else if (counter == 11)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (PlayerPrefs.GetInt("bike_11")== 1)
			{
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
				
			}
			else
			{
				BikeSelectBtn.SetActive(false);
				//Bike11PriceText.SetActive(true);
				Bike2PriceText.SetActive(false);
				Bike3PriceText.SetActive(false);
				Bike4PriceText.SetActive(false);
				Bike5PriceText.SetActive(false);
				Bike6PriceText.SetActive(false);
				Bike7PriceText.SetActive(false);
				Bike8PriceText.SetActive(false);
				Bike9PriceText.SetActive(false);
				Bike10PriceText.SetActive(false);
			
			}
			
			MultiplayerBikecounter = 10;
			PowerScrollBar.fillAmount = 0.95f;
			HandlingScrollBar.fillAmount = 0.85f;
			BrakingScrollBar.fillAmount = 0.8f;
		}
	}

	private void CloseAllPricePanel(){
			Bike11PriceText.SetActive(false);
			Bike2PriceText.SetActive(false);
			Bike3PriceText.SetActive(false);
			Bike4PriceText.SetActive(false);
			Bike5PriceText.SetActive(false);
			Bike6PriceText.SetActive(false);
			Bike7PriceText.SetActive(false);
			Bike8PriceText.SetActive(false);
			Bike9PriceText.SetActive(false);
			Bike10PriceText.SetActive(false);
	}

	public void StarterPackClick_Btn()
	{
		StarterPackMSG.SetActive(true);
	}

	public void StarterPack_Cross_Click_Btn()
	{
		StarterPackMSG.SetActive(false);
	}



	

	public void LikeUS_Click_Btn()
	{
		Application.OpenURL("");
	}
}
