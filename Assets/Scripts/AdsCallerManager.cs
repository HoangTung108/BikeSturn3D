using System;
using System.Collections;
//using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsCallerManager : MonoBehaviour
{
	private static AdsCallerManager _instance;

	//private BannerView bannerView;

	//private InterstitialAd interstitial;

	//private RewardBasedVideoAd rewardBasedVideo;

	private float deltaTime;

	private static string outputMessage = string.Empty;

	private string AdmobAppId;

	private string AdmobBannerAdId;

	private string AdmobIntestritialAdId;

	private string RewardedAdmobAdID;

	private string UnityAdId;

	private bool BannerLoadedBool;

	[Header("Android Ad id's")]
	[SerializeField]
	public string Android_AdmobAppId;

	[SerializeField]
	public string Android_AdmobBannerAdId;

	[SerializeField]
	public string Android_AdmobIntestritialAdId;

	[SerializeField]
	public string Android_RewardedAdmobAdID;

	[SerializeField]
	public string Android_UnityAdId;

	[SerializeField]
	[Header("ios Ad id's")]
	public string ios_AdmobAppId;

	[SerializeField]
	public string ios_AdmobBannerAdId;

	[SerializeField]
	public string ios_AdmobIntestritialAdId;

	[SerializeField]
	public string ios_RewardedAdmobAdID;

	[SerializeField]
	public string ios_UnityAdId;

	public GameObject VideoNotAvailbleMSG;

	public Text CashText;

	public static string OutputMessage
	{
		set
		{
			outputMessage = value;
		}
	}

	public static AdsCallerManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = UnityEngine.Object.FindObjectOfType<AdsCallerManager>();
				UnityEngine.Object.DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		}
	}

	private void Awake()
	{
		AdmobAppId = Android_AdmobAppId;
		AdmobBannerAdId = Android_AdmobBannerAdId;
		AdmobIntestritialAdId = Android_AdmobIntestritialAdId;
		RewardedAdmobAdID = Android_RewardedAdmobAdID;
		UnityAdId = Android_UnityAdId;
		PlayerPrefs.SetInt("RewardWacthed", 0);
		if (_instance == null)
		{
			_instance = this;
			UnityEngine.Object.DontDestroyOnLoad(this);
		}
		else if (this != _instance)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public void Start()
	{
		//MobileAds.Initialize(AdmobAppId);
		//rewardBasedVideo = RewardBasedVideoAd.Instance;
		//rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
		//rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
		//rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
		//rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
		//rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
		//rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
		//rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
		Advertisement.Initialize(UnityAdId, false);
		RequestRewardBasedVideo();
		if (SystemInfo.systemMemorySize > 1024 && PlayerPrefs.GetInt("NoAdsPurchase") == 0)
		{
			RequestInterstitial();
		}
	}

	public void Update()
	{
		if (SystemInfo.systemMemorySize > 1024 && PlayerPrefs.GetInt("NoAdsPurchase") == 0)
		{
			if (PlayerPrefs.GetInt("LoadAdCallDB") == 1)
			{
				LoadAdCall();
				PlayerPrefs.SetInt("LoadAdCallDB", 0);
			}
			else if (PlayerPrefs.GetInt("PauseAdCallDB") == 1)
			{
				PauseAdCall();
				PlayerPrefs.SetInt("PauseAdCallDB", 0);
			}
			else if (PlayerPrefs.GetInt("LvlCompleteAdCallDB") == 1)
			{
				LevelCompleteAdCall();
				PlayerPrefs.SetInt("LvlCompleteAdCallDB", 0);
			}
			else if (PlayerPrefs.GetInt("LvlFailedAdCallDB") == 1)
			{
				LevelFailedAdCall();
				PlayerPrefs.SetInt("LvlFailedAdCallDB", 0);
			}
		}
		if (PlayerPrefs.GetInt("RewardAdCallDB") == 1)
		{
			RewardedAdShowMultiple();
			PlayerPrefs.SetInt("RewardAdCallDB", 0);
		}
	}

	public void IntestritialAdCall()
	{
		//if (PlayerPrefs.GetInt("NoAdsPurchase") == 0 && interstitial.IsLoaded())
		//{
		//	interstitial.Show();
		//	RequestInterstitial();
		//}
	}

	public void LoadAdCall()
	{
		if (PlayerPrefs.GetInt("NoAdsPurchase") != 0)
		{
		}
	}

	public void LevelCompleteAdCall()
	{
		if (PlayerPrefs.GetInt("NoAdsPurchase") == 0)
		{
			//if (interstitial.IsLoaded())
			//{
			//	interstitial.Show();
			//	RequestInterstitial();
			//}
			//else if (Advertisement.IsReady("video"))
			//{
			//	Advertisement.Show("video");
			//}
		}
	}

	public void LevelFailedAdCall()
	{
		if (PlayerPrefs.GetInt("NoAdsPurchase") == 0)
		{
			if (Advertisement.IsReady("video"))
			{
				Advertisement.Show("video");
			}
			//else if (interstitial.IsLoaded())
			//{
			//	interstitial.Show();
			//	RequestInterstitial();
			//}
		}
	}

	public void PauseAdCall()
	{
		if (PlayerPrefs.GetInt("NoAdsPurchase") == 0)
		{
			//if (interstitial.IsLoaded())
			//{
			//	interstitial.Show();
			//	RequestInterstitial();
			//}
			//else if (Advertisement.IsReady("video"))
			//{
			//	Advertisement.Show("video");
			//}
		}
	}

	public void RewardedAdShowMultiple()
	{
		//if (rewardBasedVideo.IsLoaded())
		//{
		//	rewardBasedVideo.Show();
		//}
		//else
		//{
		//	ShowAd("rewardedVideo");
		//}
	}

	public void ShowAd(string zone = "rewardedVideo")
	{
		ShowOptions showOptions = new ShowOptions();
		showOptions.resultCallback = AdCallbackhandler;
		if (Advertisement.IsReady(zone))
		{
			Advertisement.Show(zone, showOptions);
			return;
		}
		if (Application.loadedLevel == 1)
		{
			VideoNotAvailbleMSG.SetActive(true);
		}
		else
		{
			PlayerPrefs.SetInt("RewardWacthed", 2);
		}
		Advertisement.Initialize(UnityAdId, false);
		RequestRewardBasedVideo();
	}

	private void AdCallbackhandler(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			if (Application.loadedLevel == 1)
			{
				PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") + 300);
				CashText.text = PlayerPrefs.GetInt("CashDB").ToString();
			}
			else
			{
				PlayerPrefs.SetInt("RewardWacthed", 1);
			}
			Advertisement.Initialize(UnityAdId, false);
			RequestRewardBasedVideo();
			break;
		case ShowResult.Skipped:
			Debug.Log("Ad skipped. Son, I am dissapointed in you");
			if (Application.loadedLevel == 1)
			{
				VideoNotAvailbleMSG.SetActive(true);
			}
			else
			{
				PlayerPrefs.SetInt("RewardWacthed", 2);
			}
			break;
		case ShowResult.Failed:
			Debug.Log("I swear this has never happened to me before");
			if (Application.loadedLevel == 1)
			{
				VideoNotAvailbleMSG.SetActive(true);
			}
			else
			{
				PlayerPrefs.SetInt("RewardWacthed", 2);
			}
			Advertisement.Initialize(UnityAdId, false);
			RequestRewardBasedVideo();
			break;
		}
	}

	private IEnumerator WaitForAd()
	{
		float currentTimeScale = Time.timeScale;
		Time.timeScale = 0f;
		yield return null;
		while (Advertisement.isShowing)
		{
			yield return null;
		}
		Time.timeScale = currentTimeScale;
	}

	//private AdRequest CreateAdRequest()
	//{
	//	return new AdRequest.Builder().AddTestDevice("SIMULATOR").AddTestDevice("0123456789ABCDEF0123456789ABCDEF").AddKeyword("game")
	//		.SetGender(Gender.Male)
	//		.SetBirthday(new DateTime(1985, 1, 1))
	//		.TagForChildDirectedTreatment(false)
	//		.AddExtra("color_bg", "9B30FF")
	//		.Build();
	//}

	public void RequestBanner()
	{
		//if (PlayerPrefs.GetInt("NoAdsPurchase") != 0)
		//{
		//	return;
		//}
		//if (BannerLoadedBool)
		//{
		//	bannerView.Show();
		//	return;
		//}
		//if (bannerView != null)
		//{
		//	bannerView.Destroy();
		//}
		//bannerView = new BannerView(AdmobBannerAdId, AdSize.SmartBanner, AdPosition.Top);
		//bannerView.OnAdLoaded += HandleAdLoaded;
		//bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
		//bannerView.OnAdOpening += HandleAdOpened;
		//bannerView.OnAdClosed += HandleAdClosed;
		//bannerView.OnAdLeavingApplication += HandleAdLeftApplication;
		//bannerView.LoadAd(CreateAdRequest());
	}

	public void HideBanner()
	{
		//if (PlayerPrefs.GetInt("NoAdsPurchase") == 0 && BannerLoadedBool)
		//{
		//	bannerView.Hide();
		//}
	}

	private void RequestInterstitial()
	{
		//if (interstitial != null)
		//{
		//	interstitial.Destroy();
		//}
		//interstitial = new InterstitialAd(AdmobIntestritialAdId);
		//interstitial.OnAdLoaded += HandleInterstitialLoaded;
		//interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
		//interstitial.OnAdOpening += HandleInterstitialOpened;
		//interstitial.OnAdClosed += HandleInterstitialClosed;
		//interstitial.OnAdLeavingApplication += HandleInterstitialLeftApplication;
		//interstitial.LoadAd(CreateAdRequest());
	}

	private void RequestRewardBasedVideo()
	{
		//rewardBasedVideo.LoadAd(CreateAdRequest(), RewardedAdmobAdID);
	}

	private void ShowInterstitial()
	{
		//if (interstitial.IsLoaded())
		//{
		//	interstitial.Show();
		//}
		//else
		//{
		//	MonoBehaviour.print("Interstitial is not ready yet");
		//}
	}

	private void ShowRewardBasedVideo()
	{
		//if (rewardBasedVideo.IsLoaded())
		//{
		//	rewardBasedVideo.Show();
		//}
		//else
		//{
		//	MonoBehaviour.print("Reward based video ad is not ready yet");
		//}
	}

	public void HandleAdLoaded(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdLoaded event received");
		BannerLoadedBool = true;
	}

	//public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	//{
	//	MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.Message);
	//	BannerLoadedBool = false;
	//}

	public void HandleAdOpened(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdOpened event received");
	}

	public void HandleAdClosed(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdClosed event received");
	}

	public void HandleAdLeftApplication(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdLeftApplication event received");
	}

	public void HandleInterstitialLoaded(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleInterstitialLoaded event received");
	}

	//public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	//{
	//	MonoBehaviour.print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
	//}

	public void HandleInterstitialOpened(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleInterstitialOpened event received");
	}

	public void HandleInterstitialClosed(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleInterstitialClosed event received");
	}

	public void HandleInterstitialLeftApplication(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleInterstitialLeftApplication event received");
	}

	public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
	}

	//public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	//{
	//	MonoBehaviour.print("HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
	//}

	public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
	}

	public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
	}

	public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
	}

	//public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	//{
	//	string type = args.Type;
	//	MonoBehaviour.print("HandleRewardBasedVideoRewarded event received for " + args.Amount + " " + type);
	//	if (Application.loadedLevel == 1)
	//	{
	//		PlayerPrefs.SetInt("CashDB", PlayerPrefs.GetInt("CashDB") + 300);
	//		CashText.text = PlayerPrefs.GetInt("CashDB").ToString();
	//	}
	//	else
	//	{
	//		PlayerPrefs.SetInt("RewardWacthed", 1);
	//	}
	//}

	public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
	}
}
