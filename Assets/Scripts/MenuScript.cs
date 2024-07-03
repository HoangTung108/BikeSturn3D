using System.Collections.Generic;
//using GooglePlayGames;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class MenuScript : MonoBehaviour
{
	public GameObject MenuPanel;

	public GameObject BikeSelectionPanel;

	public GameObject ModeSelectionPanel;

	public GameObject ModeUnlockMsg;

	public GameObject SettingsPanel;

	public GameObject LevelSelectionPanel;

	public GameObject LevelSelectionPage1;

	public GameObject LevelSelectionPage2;

	public GameObject CoinOfferBtn;

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

	public InputField inputField;

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

	private string HighScoreleaderBoardID = "com.monstergamesproductions.ramp.moto.rider.highscore";

	private string CrazyStunterAchID = "com.monstergamesproductions.ramp.moto.rider.ach.crazy.stunter";

	private string ProStunterAchID = "com.monstergamesproductions.ramp.moto.rider.ach.pro.stunter";

	public GameObject StarterPackMSG;

	public GameObject CoinsOfferMSG;

	public Text ProfileText;

	public Text ProfilePercentageText;

	public Text NamePlayer;

	public Scrollbar ProfileScrollBar;

	public Scrollbar PowerScrollBar;

	public Scrollbar HandlingScrollBar;

	public Scrollbar BrakingScrollBar;

	public static bool LevelPageNoBool;

	public static bool LoginBool;

	private string HighScoreleaderBoardIDAndroid = "CgkI2ZOc-_kPEAIQAA";

	private string CrazyStunterAchIDAndroid = "CgkI2ZOc-_kPEAIQAQ";

	private string ProStunterAchIDAndroid = "CgkI2ZOc-_kPEAIQAg";

	private void Awake(){

	}

	private void Start()
	{
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
			MenuPanel.SetActive(false);
			BikeSelectionPanel.SetActive(false);
			ModeSelectionPanel.SetActive(true);
			PlayerPrefs.SetInt("Next", 0);
		}
		else
		{
			ScreenNumber = 0;
			MenuPanel.SetActive(true);
			BikeSelectionPanel.SetActive(false);
			ModeSelectionPanel.SetActive(false);
		}
		if (!LevelPageNoBool)
		{
			PlayerPrefs.SetInt("PageNo", 0);
			LevelPageNoBool = true;
		}
		PlayerPrefs.SetInt("UnlockTimeModeDB",0);
		BikeIns();
		ProfileBuildCall();
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
		
		 
		// StorageData loadData = StorageData.CreateFromJSON(DataBikeSave);

		
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
		if (Advertisement.IsReady()){
			Advertisement.Show();
		}
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
		if (PlayerPrefs.GetString("Sound Status") == "False")
		{
			SondOffBtn.SetActive(true);
			SondONBtn.SetActive(false);
			PlayerPrefs.SetString("Sound Status", "False");
			PlayerPrefs.Save();
		}
		else
		{
			SondOffBtn.SetActive(false);
			SondONBtn.SetActive(true);
			PlayerPrefs.SetString("Sound Status", "True");
			PlayerPrefs.Save();
		}
		if (PlayerPrefs.GetString("Music Status") == "False")
		{
			MUSICOffBtn.SetActive(true);
			MUSICONBtn.SetActive(false);
			BackgroundMusic.SetActive(false);
			PlayerPrefs.SetString("Music Status", "False");
			PlayerPrefs.Save();
		}
		else
		{
			MUSICOffBtn.SetActive(false);
			MUSICONBtn.SetActive(true);
			BackgroundMusic.SetActive(true);
			PlayerPrefs.SetString("Music Status", "True");
			PlayerPrefs.Save();
		}
		PowerScrollBar.value = 0f;
		HandlingScrollBar.value = 0f;
		BrakingScrollBar.value = 0f;
	}

	public void PlayClick_Btn()
	{
		LevelSelectionPanel.SetActive(false);
		MenuPanel.SetActive(false);
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
		MenuPanel.SetActive(false);
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
		MenuPanel.SetActive(false);
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
		MenuPanel.SetActive(false);
		BikeSelectionPanel.SetActive(false);
		ModeSelectionPanel.SetActive(true);
		ScreenNumber = 3;
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void BikeSelectBackClick_Btn()
	{
		PlayerPrefs.SetInt("MultiPlyerGameDB", 0);
		MenuPanel.SetActive(true);
		CoinOfferBtn.SetActive(true);
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
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void BikeSelectGo_Btn()
	{
		if (PlayerPrefs.GetInt("MultiPlyerGameDB") == 0)
		{
			LevelSelectionPanel.SetActive(false);
			ModeSelectionPanel.SetActive(true);
			CoinOfferBtn.SetActive(false);
			MenuPanel.SetActive(false);
			BikeSelectionPanel.SetActive(false);
			PlayerPrefs.SetInt("BikeSelDB", counter);
			ScreenNumber = 3;
			CheckBike();
		}
		else
		{
			PlayerPrefs.SetInt("MultiPlayerBikeSelDB", MultiplayerBikecounter);
			Application.LoadLevel(22);
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}
	private void CheckBike(){
		switch (counter){
			case 2: 
				SplashScript.BikeTwo.ValueData =1;
				break;
			case 3:
				SplashScript.BikeThree.ValueData =1;
				break;
			case 4:
				SplashScript.BikeFour.ValueData =1;
				break;
			case 5:
				SplashScript.BikeFive.ValueData =1;
				break;
			case 6:
				SplashScript.BikeSix.ValueData =1;
				break;
			case 7:
				SplashScript.BikeSeven.ValueData =1;
				break;
			case 8:
				SplashScript.BikeEight.ValueData =1;
				break;
			case 9:
				SplashScript.BikeNine.ValueData =1;
				break;
			case 10:
				SplashScript.BikeTen.ValueData =1;
				break;
			case 11:
				SplashScript.BikeEleven.ValueData =1;
				break;
			default:
				break;

		}
		
	}

	public void FreeMode_Btn()
	{
		LevelSelectionPanel.SetActive(true);
		ModeSelectionPanel.SetActive(false);
		MenuPanel.SetActive(false);
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
		if (PlayerPrefs.GetInt("UnlockTimeModeDB") == 0)
		{
			
			ModeUnlockMsg.SetActive(true);
		}
		else
		{
			LevelSelectionPanel.SetActive(true);
			ModeSelectionPanel.SetActive(false);
			MenuPanel.SetActive(false);
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
		MenuPanel.SetActive(false);
		BikeSelectionPanel.SetActive(true);
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
			Application.OpenURL("http://www.facebook.com/sharer/sharer.php?u=https://play.google.com/store/apps/details?id=com.monstergamesproductions.ramp.moto.rider");
		}
		else if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Application.OpenURL("http://www.facebook.com/sharer/sharer.php?u=https://itunes.apple.com/us/app/3d-boat-racing-simulator-2018/id1326126127?ls=1&mt=8");
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
			Application.OpenURL("https://plus.google.com/share?url=https://play.google.com/store/apps/details?id=com.monstergamesproductions.ramp.moto.rider");
		}
		else if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Application.OpenURL("https://plus.google.com/share?url=https://itunes.apple.com/us/app/3d-boat-racing-simulator-2018/id1326126127?ls=1&mt=8");
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
			Application.OpenURL("http://twitter.com/share?text=Superhero Mega ramp Moto Rider: 3D GT Auto stunts&url=https://play.google.com/store/apps/details?id=com.monstergamesproductions.ramp.moto.rider");
		}
		else if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Application.OpenURL("http://twitter.com/share?text=Superhero Mega ramp Moto Rider: 3D GT Auto stunts&url=https://itunes.apple.com/us/app/3d-boat-racing-simulator-2018/id1326126127?ls=1&mt=8");
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void BikeBuyBtn_Click()
	{
		if (counter == 2 && PlayerPrefs.GetInt("CashDB") >= 2000)
		{
			SplashScript.BikeTwo.ValueData =1;
			PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 2000);
			BikeSelectBtn.SetActive(true);
			Bike2PriceText.SetActive(false);
		
			
			
		}
		else if (counter == 3 && PlayerPrefs.GetInt("CashDB") >= 5000)
		{
			SplashScript.BikeThree.ValueData =1;
			PlayerPrefs.SetInt("BikeThreePurcahsed", 1);
			PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 5000);
			BikeSelectBtn.SetActive(true);
			Bike3PriceText.SetActive(false);
		
		}
		else if (counter == 4 && PlayerPrefs.GetInt("CashDB") >= 20000)
		{
			SplashScript.BikeFour.ValueData =1;
			PlayerPrefs.SetInt("BikeFourPurcahsed", 1);
			PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 20000);
			BikeSelectBtn.SetActive(true);
		
			Bike4PriceText.SetActive(false);
		
		}
		else if (counter == 5 && PlayerPrefs.GetInt("CashDB") >= 40000)
		{
			SplashScript.BikeFive.ValueData =1;
			PlayerPrefs.SetInt("BikeFivePurcahsed", 1);
			PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 40000);
			BikeSelectBtn.SetActive(true);

			Bike5PriceText.SetActive(false);
			
		}
		else if (counter == 6 && PlayerPrefs.GetInt("CashDB") >= 50000)
		{
			SplashScript.BikeSix.ValueData =1;
			PlayerPrefs.SetInt("BikeSixPurcahsed", 1);
			PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 50000);
			BikeSelectBtn.SetActive(true);

			Bike6PriceText.SetActive(false);
			
		}
		else if (counter == 7 && PlayerPrefs.GetInt("CashDB") >= 60000)
		{
			SplashScript.BikeSeven.ValueData =1;
			PlayerPrefs.SetInt("BikeSevenPurcahsed", 1);
			PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 60000);
			BikeSelectBtn.SetActive(true);
	
			Bike7PriceText.SetActive(false);
		
		}
		else if (counter == 8 && PlayerPrefs.GetInt("CashDB") >= 70000)
		{
			SplashScript.BikeEight.ValueData =1;
			PlayerPrefs.SetInt("BikeEightPurcahsed", 1);
			PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 70000);
			BikeSelectBtn.SetActive(true);
	
			Bike8PriceText.SetActive(false);
			
		}
		else if (counter == 9 && PlayerPrefs.GetInt("CashDB") >= 80000)
		{
			SplashScript.BikeNine.ValueData =1;
			PlayerPrefs.SetInt("BikeNinePurcahsed", 1);
			PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 80000);
			BikeSelectBtn.SetActive(true);
		
			Bike9PriceText.SetActive(false);
			
		}
		else if (counter == 10 && PlayerPrefs.GetInt("CashDB") >= 90000)
		{
			SplashScript.BikeTen.ValueData =1;
			PlayerPrefs.SetInt("BikeTenPurcahsed", 1);
			PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 90000);
			BikeSelectBtn.SetActive(true);

			Bike10PriceText.SetActive(false);
			
		}
		else if (counter == 11 && PlayerPrefs.GetInt("CashDB") >= 100000)
		{
			SplashScript.BikeEleven.ValueData =1;
			PlayerPrefs.SetInt("BikeElevenPurcahsed", 1);
			PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") - 100000);
			BikeSelectBtn.SetActive(true);

			Bike11PriceText.SetActive(false);
			
		}
		else
		{
			NotEnoughCash.SetActive(true);
		}
		CashText.text = PlayerPrefs.GetInt("CashDB").ToString();
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_1_Btn()
	{
		LoadingPanel.SetActive(true);
		LevelCounter = 2;
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
			LevelCounter = 3;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel2") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 3;
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
			LevelCounter = 4;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel3") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 4;
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
			LevelCounter = 5;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel4") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 5;
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
			LevelCounter = 6;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel5") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 6;
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
			LevelCounter = 7;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel6") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 7;
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
			LevelCounter = 8;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel7") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 8;
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
			LevelCounter = 9;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel8") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 9;
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
			LevelCounter = 10;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel9") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 10;
			StartCoroutine(LoadNewScene());
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelLoad_10_Btn()
	{
		if (PlayerPrefs.GetInt("FUnlockedLevel10") == 1 && PlayerPrefs.GetInt("ModeDB") == 0)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 11;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel10") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 11;
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
			LevelCounter = 12;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel11") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 12;
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
			LevelCounter = 13;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel12") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 13;
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
			LevelCounter = 14;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel13") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 14;
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
			LevelCounter = 15;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel14") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 15;
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
			LevelCounter = 16;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel15") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 16;
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
			LevelCounter = 17;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel16") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 17;
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
			LevelCounter = 18;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel17") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 18;
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
			LevelCounter = 19;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel18") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 19;
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
			LevelCounter = 20;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel19") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			LoadingPanel.SetActive(true);
			LevelCounter = 20;
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
			LevelCounter = 21;
			StartCoroutine(LoadNewScene());
		}
		else if (PlayerPrefs.GetInt("TUnlockedLevel20") == 1 && PlayerPrefs.GetInt("ModeDB") == 1)
		{
			PlayerPrefs.SetInt("UnlockALLLevelsDB", 1);
			LoadingPanel.SetActive(true);
			LevelCounter = 21;
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
		AsyncOperation async = Application.LoadLevelAsync(LevelCounter);
		while (!async.isDone)
		{
			yield return null;
		}
	}

	public void SoundBtn_Click()
	{
		if (PlayerPrefs.GetString("Sound Status") == "False")
		{
			SondOffBtn.SetActive(true);
			SondONBtn.SetActive(false);
			PlayerPrefs.SetString("Sound Status", "True");
			PlayerPrefs.Save();
		}
		else if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			SondOffBtn.SetActive(false);
			SondONBtn.SetActive(true);
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
			MUSICOffBtn.SetActive(true);
			MUSICONBtn.SetActive(false);
			BackgroundMusic.SetActive(false);
			PlayerPrefs.SetString("Music Status", "True");
			PlayerPrefs.Save();
		}
		else if (PlayerPrefs.GetString("Music Status") == "True")
		{
			MUSICOffBtn.SetActive(false);
			MUSICONBtn.SetActive(true);
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
		string DB = JsonUtility.ToJson(SplashScript.db_value);
		Debug.Log(DB);
		System.IO.File.WriteAllText(SplashScript.datapath,DB);
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

	public void EnglishLanguage_Select()
	{
		PlayerPrefs.SetInt("LanguageSet", 0);
		LanguageSelection();
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void ChinaLanguage_Select()
	{
		PlayerPrefs.SetInt("LanguageSet", 1);
		LanguageSelection();
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void FrenchLanguage_Select()
	{
		PlayerPrefs.SetInt("LanguageSet", 2);
		LanguageSelection();
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void GermanLanguage_Select()
	{
		PlayerPrefs.SetInt("LanguageSet", 3);
		LanguageSelection();
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void SpainishLanguage_Select()
	{
		PlayerPrefs.SetInt("LanguageSet", 4);
		LanguageSelection();
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void IndianLanguage_Select()
	{
		PlayerPrefs.SetInt("LanguageSet", 5);
		LanguageSelection();
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	private void LanguageSelection()
	{
		switch (PlayerPrefs.GetInt("LanguageSet"))
		{
		case 0:
			EnglishLangBtn.image.color = Color.white;
			ChinaLangBtn.image.color = Color.grey;
			FrenchLangBtn.image.color = Color.grey;
			GermanLangBtn.image.color = Color.grey;
			SpainishLangBtn.image.color = Color.grey;
			IndianLangBtn.image.color = Color.grey;
			break;
		case 1:
			EnglishLangBtn.image.color = Color.grey;
			ChinaLangBtn.image.color = Color.white;
			FrenchLangBtn.image.color = Color.grey;
			GermanLangBtn.image.color = Color.grey;
			SpainishLangBtn.image.color = Color.grey;
			IndianLangBtn.image.color = Color.grey;
			break;
		case 2:
			EnglishLangBtn.image.color = Color.grey;
			ChinaLangBtn.image.color = Color.grey;
			FrenchLangBtn.image.color = Color.white;
			GermanLangBtn.image.color = Color.grey;
			SpainishLangBtn.image.color = Color.grey;
			IndianLangBtn.image.color = Color.grey;
			break;
		case 3:
			EnglishLangBtn.image.color = Color.grey;
			ChinaLangBtn.image.color = Color.grey;
			FrenchLangBtn.image.color = Color.grey;
			GermanLangBtn.image.color = Color.white;
			SpainishLangBtn.image.color = Color.grey;
			IndianLangBtn.image.color = Color.grey;
			break;
		case 4:
			EnglishLangBtn.image.color = Color.grey;
			ChinaLangBtn.image.color = Color.grey;
			FrenchLangBtn.image.color = Color.grey;
			GermanLangBtn.image.color = Color.grey;
			SpainishLangBtn.image.color = Color.white;
			IndianLangBtn.image.color = Color.grey;
			break;
		case 5:
			EnglishLangBtn.image.color = Color.grey;
			ChinaLangBtn.image.color = Color.grey;
			FrenchLangBtn.image.color = Color.grey;
			GermanLangBtn.image.color = Color.grey;
			SpainishLangBtn.image.color = Color.grey;
			IndianLangBtn.image.color = Color.white;
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
			PowerScrollBar.size = 0.1f;
			HandlingScrollBar.size = 0.15f;
			BrakingScrollBar.size = 0.12f;
		}
		else if (counter == 2)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (SplashScript.BikeTwo.KeyData == "BikeTwoPurcahsed" && SplashScript.BikeTwo.ValueData == 1)
			{
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
				
			}
			else
			{
				BikeSelectBtn.SetActive(false);
				Bike2PriceText.SetActive(true);
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
			PowerScrollBar.size = 0.15f;
			HandlingScrollBar.size = 0.1f;
			BrakingScrollBar.size = 0.12f;
		}
		else if (counter == 3)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (SplashScript.BikeThree.KeyData == "BikeThreePurcahsed" && SplashScript.BikeThree.ValueData == 1)
			{
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
			}
			else
			{	
				BikeSelectBtn.SetActive(false);
				Bike3PriceText.SetActive(true);
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
			PowerScrollBar.size = 0.25f;
			HandlingScrollBar.size = 0.12f;
			BrakingScrollBar.size = 0.2f;
		}
		else if (counter == 4)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (SplashScript.BikeFour.KeyData == "BikeFourPurcahsed" && SplashScript.BikeFour.ValueData == 1)
			{
			
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
			}
			else
			{
				
				BikeSelectBtn.SetActive(false);
				Bike4PriceText.SetActive(true);
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
			PowerScrollBar.size = 0.35f;
			HandlingScrollBar.size = 0.22f;
			BrakingScrollBar.size = 0.4f;
		}
		else if (counter == 5)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (SplashScript.BikeFive.KeyData == "BikeFivePurcahsed" && SplashScript.BikeFive.ValueData == 1)
			{
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
			}
			else
			{
				BikeSelectBtn.SetActive(false);

				Bike5PriceText.SetActive(true);
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
			PowerScrollBar.size = 0.55f;
			HandlingScrollBar.size = 0.42f;
			BrakingScrollBar.size = 0.6f;
		}
		else if (counter == 6)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (SplashScript.BikeSix.KeyData == "BikeSixPurcahsed" && SplashScript.BikeSix.ValueData == 1)
			{
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
			}
			else
			{
				BikeSelectBtn.SetActive(false);
	
				Bike6PriceText.SetActive(true);
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
			PowerScrollBar.size = 0.65f;
			HandlingScrollBar.size = 0.52f;
			BrakingScrollBar.size = 0.62f;
		}
		else if (counter == 7)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (SplashScript.BikeSeven.KeyData == "BikeSevenPurcahsed" &&SplashScript.BikeSeven.ValueData == 1)
			{
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
			}
			else
			{
				BikeSelectBtn.SetActive(false);
		
				Bike7PriceText.SetActive(true);
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
			PowerScrollBar.size = 0.75f;
			HandlingScrollBar.size = 0.62f;
			BrakingScrollBar.size = 0.52f;
		}
		else if (counter == 8)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (SplashScript.BikeEight.KeyData == "BikeEightPurcahsed" && SplashScript.BikeEight.ValueData == 1)
			{
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
			}
			else
			{
				BikeSelectBtn.SetActive(false);
		
				Bike8PriceText.SetActive(true);
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
			PowerScrollBar.size = 0.85f;
			HandlingScrollBar.size = 0.72f;
			BrakingScrollBar.size = 0.62f;
		}
		else if (counter == 9)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (SplashScript.BikeNine.KeyData == "BikeNinePurcahsed" &&SplashScript. BikeNine.ValueData == 1)
			{
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
			}
			else
			{
				BikeSelectBtn.SetActive(false);
				Bike9PriceText.SetActive(true);
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
			PowerScrollBar.size = 0.85f;
			HandlingScrollBar.size = 0.8f;
			BrakingScrollBar.size = 0.7f;
		}
		else if (counter == 10)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (SplashScript.BikeTen.KeyData == "BikeTenPurcahsed" && SplashScript.BikeTen.ValueData == 1)
			{
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
			}
			else
			{
				BikeSelectBtn.SetActive(false);
				Bike10PriceText.SetActive(true);
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
			PowerScrollBar.size = 0.9f;
			HandlingScrollBar.size = 0.82f;
			BrakingScrollBar.size = 0.75f;
		}
		else if (counter == 11)
		{
			BikeArrayDes = Object.Instantiate(BikeArray[counter - 1], Target.transform.position, Target.transform.rotation);
			if (SplashScript.BikeEleven.KeyData == "BikeElevenPurcahsed" && SplashScript.BikeEleven.ValueData == 1)
			{
				BikeSelectBtn.SetActive(true);
				CloseAllPricePanel();
				
			}
			else
			{
				BikeSelectBtn.SetActive(false);
				Bike11PriceText.SetActive(true);
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
			PowerScrollBar.size = 0.95f;
			HandlingScrollBar.size = 0.85f;
			BrakingScrollBar.size = 0.8f;
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

	public void CoinsOfferPackClick_Btn()
	{
		CoinsOfferMSG.SetActive(true);
	}

	public void CoinsOfferPack_Cross_Click_Btn()
	{
		CoinsOfferMSG.SetActive(false);
	}

	private void ProfileBuildCall()
	{
		if (PlayerPrefs.GetInt("BikeTwoPurcahsed") == 0 && PlayerPrefs.GetInt("BikeThreePurcahsed") == 0 && PlayerPrefs.GetInt("BikeFourPurcahsed") == 0 && PlayerPrefs.GetInt("BikeFivePurcahsed") == 0 && PlayerPrefs.GetInt("BikeSixPurcahsed") == 0 && PlayerPrefs.GetInt("BikeSevenPurcahsed") == 0 && PlayerPrefs.GetInt("BikeEightPurcahsed") == 0 && PlayerPrefs.GetInt("BikeNinePurcahsed") == 0 && PlayerPrefs.GetInt("BikeTenPurcahsed") == 0 && PlayerPrefs.GetInt("BikeElevenPurcahsed") == 0)
		{
			ProfileText.text = "NOVICE";
			ProfilePercentageText.text = "0%";
			ProfileScrollBar.size = 0f;
		}
		else if (PlayerPrefs.GetInt("BikeTwoPurcahsed") == 1 && PlayerPrefs.GetInt("BikeThreePurcahsed") == 0 && PlayerPrefs.GetInt("BikeFourPurcahsed") == 0 && PlayerPrefs.GetInt("BikeFivePurcahsed") == 0 && PlayerPrefs.GetInt("BikeSixPurcahsed") == 0 && PlayerPrefs.GetInt("BikeSevenPurcahsed") == 0 && PlayerPrefs.GetInt("BikeEightPurcahsed") == 0 && PlayerPrefs.GetInt("BikeNinePurcahsed") == 0 && PlayerPrefs.GetInt("BikeTenPurcahsed") == 0 && PlayerPrefs.GetInt("BikeElevenPurcahsed") == 0)
		{
			ProfileText.text = "AMATEUR";
			ProfilePercentageText.text = "10%";
			ProfileScrollBar.size = 0.1f;
		}
		else if (PlayerPrefs.GetInt("BikeTwoPurcahsed") == 1 && PlayerPrefs.GetInt("BikeThreePurcahsed") == 1 && PlayerPrefs.GetInt("BikeFourPurcahsed") == 0 && PlayerPrefs.GetInt("BikeFivePurcahsed") == 0 && PlayerPrefs.GetInt("BikeSixPurcahsed") == 0 && PlayerPrefs.GetInt("BikeSevenPurcahsed") == 0 && PlayerPrefs.GetInt("BikeEightPurcahsed") == 0 && PlayerPrefs.GetInt("BikeNinePurcahsed") == 0 && PlayerPrefs.GetInt("BikeTenPurcahsed") == 0 && PlayerPrefs.GetInt("BikeElevenPurcahsed") == 0)
		{
			ProfileText.text = "BEGINNER";
			ProfilePercentageText.text = "20%";
			ProfileScrollBar.size = 0.2f;
		}
		else if (PlayerPrefs.GetInt("BikeTwoPurcahsed") == 1 && PlayerPrefs.GetInt("BikeThreePurcahsed") == 1 && PlayerPrefs.GetInt("BikeFourPurcahsed") == 1 && PlayerPrefs.GetInt("BikeFivePurcahsed") == 0 && PlayerPrefs.GetInt("BikeSixPurcahsed") == 0 && PlayerPrefs.GetInt("BikeSevenPurcahsed") == 0 && PlayerPrefs.GetInt("BikeEightPurcahsed") == 0 && PlayerPrefs.GetInt("BikeNinePurcahsed") == 0 && PlayerPrefs.GetInt("BikeTenPurcahsed") == 0 && PlayerPrefs.GetInt("BikeElevenPurcahsed") == 0)
		{
			ProfileText.text = "ROOKIE";
			ProfilePercentageText.text = "30%";
			ProfileScrollBar.size = 0.3f;
		}
		else if (PlayerPrefs.GetInt("BikeTwoPurcahsed") == 1 && PlayerPrefs.GetInt("BikeThreePurcahsed") == 1 && PlayerPrefs.GetInt("BikeFourPurcahsed") == 1 && PlayerPrefs.GetInt("BikeFivePurcahsed") == 1 && PlayerPrefs.GetInt("BikeSixPurcahsed") == 0 && PlayerPrefs.GetInt("BikeSevenPurcahsed") == 0 && PlayerPrefs.GetInt("BikeEightPurcahsed") == 0 && PlayerPrefs.GetInt("BikeNinePurcahsed") == 0 && PlayerPrefs.GetInt("BikeTenPurcahsed") == 0 && PlayerPrefs.GetInt("BikeElevenPurcahsed") == 0)
		{
			ProfileText.text = "COMPETITOR";
			ProfilePercentageText.text = "40%";
			ProfileScrollBar.size = 0.4f;
		}
		else if (PlayerPrefs.GetInt("BikeTwoPurcahsed") == 1 && PlayerPrefs.GetInt("BikeThreePurcahsed") == 1 && PlayerPrefs.GetInt("BikeFourPurcahsed") == 1 && PlayerPrefs.GetInt("BikeFivePurcahsed") == 1 && PlayerPrefs.GetInt("BikeSixPurcahsed") == 1 && PlayerPrefs.GetInt("BikeSevenPurcahsed") == 0 && PlayerPrefs.GetInt("BikeEightPurcahsed") == 0 && PlayerPrefs.GetInt("BikeNinePurcahsed") == 0 && PlayerPrefs.GetInt("BikeTenPurcahsed") == 0 && PlayerPrefs.GetInt("BikeElevenPurcahsed") == 0)
		{
			ProfileText.text = "STUNTER";
			ProfilePercentageText.text = "50%";
			ProfileScrollBar.size = 0.5f;
		}
		else if (PlayerPrefs.GetInt("BikeTwoPurcahsed") == 1 && PlayerPrefs.GetInt("BikeThreePurcahsed") == 1 && PlayerPrefs.GetInt("BikeFourPurcahsed") == 1 && PlayerPrefs.GetInt("BikeFivePurcahsed") == 1 && PlayerPrefs.GetInt("BikeSixPurcahsed") == 1 && PlayerPrefs.GetInt("BikeSevenPurcahsed") == 1 && PlayerPrefs.GetInt("BikeEightPurcahsed") == 0 && PlayerPrefs.GetInt("BikeNinePurcahsed") == 0 && PlayerPrefs.GetInt("BikeTenPurcahsed") == 0 && PlayerPrefs.GetInt("BikeElevenPurcahsed") == 0)
		{
			ProfileText.text = "SEMI-PRO";
			ProfilePercentageText.text = "60%";
			ProfileScrollBar.size = 0.6f;
		}
		else if (PlayerPrefs.GetInt("BikeTwoPurcahsed") == 1 && PlayerPrefs.GetInt("BikeThreePurcahsed") == 1 && PlayerPrefs.GetInt("BikeFourPurcahsed") == 1 && PlayerPrefs.GetInt("BikeFivePurcahsed") == 1 && PlayerPrefs.GetInt("BikeSixPurcahsed") == 1 && PlayerPrefs.GetInt("BikeSevenPurcahsed") == 1 && PlayerPrefs.GetInt("BikeEightPurcahsed") == 1 && PlayerPrefs.GetInt("BikeNinePurcahsed") == 0 && PlayerPrefs.GetInt("BikeTenPurcahsed") == 0 && PlayerPrefs.GetInt("BikeElevenPurcahsed") == 0)
		{
			ProfileText.text = "PRO";
			ProfilePercentageText.text = "70%";
			ProfileScrollBar.size = 0.7f;
		}
		else if (PlayerPrefs.GetInt("BikeTwoPurcahsed") == 1 && PlayerPrefs.GetInt("BikeThreePurcahsed") == 1 && PlayerPrefs.GetInt("BikeFourPurcahsed") == 1 && PlayerPrefs.GetInt("BikeFivePurcahsed") == 1 && PlayerPrefs.GetInt("BikeSixPurcahsed") == 1 && PlayerPrefs.GetInt("BikeSevenPurcahsed") == 1 && PlayerPrefs.GetInt("BikeEightPurcahsed") == 1 && PlayerPrefs.GetInt("BikeNinePurcahsed") == 1 && PlayerPrefs.GetInt("BikeTenPurcahsed") == 0 && PlayerPrefs.GetInt("BikeElevenPurcahsed") == 0)
		{
			ProfileText.text = "MASTER";
			ProfilePercentageText.text = "80%";
			ProfileScrollBar.size = 0.8f;
		}
		else if (PlayerPrefs.GetInt("BikeTwoPurcahsed") == 1 && PlayerPrefs.GetInt("BikeThreePurcahsed") == 1 && PlayerPrefs.GetInt("BikeFourPurcahsed") == 1 && PlayerPrefs.GetInt("BikeFivePurcahsed") == 1 && PlayerPrefs.GetInt("BikeSixPurcahsed") == 1 && PlayerPrefs.GetInt("BikeSevenPurcahsed") == 1 && PlayerPrefs.GetInt("BikeEightPurcahsed") == 1 && PlayerPrefs.GetInt("BikeNinePurcahsed") == 1 && PlayerPrefs.GetInt("BikeTenPurcahsed") == 1 && PlayerPrefs.GetInt("BikeElevenPurcahsed") == 0)
		{
			ProfileText.text = "ELITE";
			ProfilePercentageText.text = "90%";
			ProfileScrollBar.size = 0.9f;
		}
		else if (PlayerPrefs.GetInt("BikeTwoPurcahsed") == 1 && PlayerPrefs.GetInt("BikeThreePurcahsed") == 1 && PlayerPrefs.GetInt("BikeFourPurcahsed") == 1 && PlayerPrefs.GetInt("BikeFivePurcahsed") == 1 && PlayerPrefs.GetInt("BikeSixPurcahsed") == 1 && PlayerPrefs.GetInt("BikeSevenPurcahsed") == 1 && PlayerPrefs.GetInt("BikeEightPurcahsed") == 1 && PlayerPrefs.GetInt("BikeNinePurcahsed") == 1 && PlayerPrefs.GetInt("BikeTenPurcahsed") == 1 && PlayerPrefs.GetInt("BikeElevenPurcahsed") == 1)
		{
			ProfileText.text = "LEGEND";
			ProfilePercentageText.text = "100%";
			ProfileScrollBar.size = 1f;
		}
	}

	public void ProfileCheck_Click()
	{
	 	string input = inputField.text;
		NamePlayer.text =  input;
	}

	public void LikeUS_Click_Btn()
	{
		Application.OpenURL("https://www.facebook.com/monstergamesproductions");
	}
}
