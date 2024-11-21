using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Trip;
using AppsFlyerSDK;

#if ADMOB_MEDIATION
using GoogleMobileAds.Api;
using GoogleMobileAds.Ump.Api;
using GoogleMobileAds.Common;
#endif

public class AdsManager : Singleton<AdsManager>
{
    public event Action onMRECLoaded, onAppOpenLoaded, onAppOpenHidden, OnRewardReady, OnInterOpenLoaded, OnInterOpenDismiss, onInitDone;
    public bool isShowAds = false;
    public bool isFirstOpen = true;
    public DateTime lastAdTime = DateTime.MinValue, lastBannerCollapse = DateTime.MinValue;
    

    public bool IsRemoveAds
    {
        get
        {
            return PlayerPrefs.GetInt("remove_ads", 0) == 1;
        }
    }

#if MAX_MEDIATION
    private const string MaxSdkKey = "QaAezN7ygue2ntps0v8ps_eqaD9xpIlK_xH3-CWvfStCXdsN3kcF8Ffu3hWBt6X-gNueOSxX_w0179wXScblcS";

#if UNITY_ANDROID
    private const string InterstitialAdUnitId = "81016e57e5367685";
    private const string RewardedAdUnitId = "88fdef1b88f1051b";
    private const string BannerAdUnitId = "b7186555d2e602f4";
    private const string AppOpenAdUnitId = "b2de72bcb721a473";
    private const string mrecAdUnitId = "ce99a6b1259f74b7";
#elif UNITY_IOS
  private const string InterstitialAdUnitId = "ENTER_INTERSTITIAL_AD_UNIT_ID_HERE";
    private const string RewardedAdUnitId = "ENTER_REWARD_AD_UNIT_ID_HERE";
    private const string BannerAdUnitId = "ENTER_BANNER_AD_UNIT_ID_HERE";
    private const string AppOpenAdUnitId = "YOUR_AD_UNIT_ID";
    private const string mrecAdUnitId = "YOUR_MREC_AD_UNIT_ID";
#else
     private const string InterstitialAdUnitId = "ENTER_INTERSTITIAL_AD_UNIT_ID_HERE";
    private const string RewardedAdUnitId = "ENTER_REWARD_AD_UNIT_ID_HERE";
    private const string BannerAdUnitId = "ENTER_BANNER_AD_UNIT_ID_HERE";
    private const string AppOpenAdUnitId = "YOUR_AD_UNIT_ID";
    private const string mrecAdUnitId = "YOUR_MREC_AD_UNIT_ID";
#endif

    private bool isBannerShowing;
    private int interstitialRetryAttempt;
    private int rewardedRetryAttempt;
    public int AdsCount { get; private set; }

    private bool isShowFirstTime = false;
    private DateTime _lastTimeShowAds;
    private int showInterCount = 0;
    private Action onInterstialComplete;
    private Action<bool> onRewardComplete;

    public event Action OnOpenAdsFirstTimeRead;
    public event Action OnInterstialClose;

    //List<OpenAdsService> openAdsServices;
    private void Awake()
    {
        lastAdTime = DateTime.Now;
        Debug.LogWarning("Start AdsManager..........." + DateTime.Now.ToString("HH:mm:ss"));
        MaxSdkCallbacks.Interstitial.OnAdRevenuePaidEvent += OnAdRevenuePaidEvent;
        MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += OnAdRevenuePaidEvent;
        MaxSdkCallbacks.Banner.OnAdRevenuePaidEvent += OnAdRevenuePaidEvent;
        MaxSdkCallbacks.MRec.OnAdRevenuePaidEvent += OnAdRevenuePaidEvent;
        MaxSdkCallbacks.AppOpen.OnAdRevenuePaidEvent += OnAdRevenuePaidEvent;
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnSceneChanged(Scene arg0, Scene arg1)
    {
        UpdateBannerPosition(MaxSdkBase.BannerPosition.BottomCenter);
    }

    private void OnAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo impressionData)
    {
        FirebaseLogger.Instance.OnAdRevenuePaidEvent(adUnitId, impressionData);
    }
    private void Start()
    {

#if TESTING
PlayerPrefs.SetInt("remove_ads", 1);
return;
#endif
        MaxSdkCallbacks.OnSdkInitializedEvent += sdkConfiguration =>
        {
            // AppLovin SDK is initialized, configure and start loading ads.
            Debug.LogWarning("MAX SDK Initialized");

            if (PlayerPrefs.GetInt("remove_ads", 0) == 0)
            {
                InitOpenAds();
                InitializeMRecAds();
                InitializeInterstitialAds();
                //InitializeBannerAds();
                InitializeRewardedAds();
            }
            AppsFlyer.initSDK("Qhno4yJY6KHmZp9uS9DRe4", "", this);
            AppsFlyer.startSDK();

            FirebaseLogger.Instance.Init();
            onInitDone?.Invoke();
        };

        MaxSdk.InitializeSdk();

        AdsCount = PlayerPrefs.GetInt("ads_count", 0);
        //AppStateEventNotifier.AppStateChanged += OnAppStateChanged;
#if !UNITY_EDITOR
        //if (!Debug.isDebugBuild)
        //{
        //    Debug.unityLogger.logEnabled = false;
        //}
#endif

    }
    public void OnApplicationPause(bool paused)
    {
        // Display the app open ad when the app is foregrounded
        if (!paused)
        {
            if (isShowAds)
                return;
            if (PlayerPrefs.GetInt("remove_ads", 0) == 1)
                return;

            ShowOpenAds();
        }
    }

    #region MREC
    public void InitializeMRecAds()
    {
        // MRECs are sized to 300x250 on phones and tablets
        MaxSdk.CreateMRec(mrecAdUnitId, MaxSdkBase.AdViewPosition.CenterLeft);

        MaxSdkCallbacks.MRec.OnAdLoadedEvent += OnMRecAdLoadedEvent;
        MaxSdkCallbacks.MRec.OnAdLoadFailedEvent += OnMRecAdLoadFailedEvent;
        MaxSdkCallbacks.MRec.OnAdClickedEvent += OnMRecAdClickedEvent;
        MaxSdkCallbacks.MRec.OnAdRevenuePaidEvent += OnMRecAdRevenuePaidEvent;
        MaxSdkCallbacks.MRec.OnAdExpandedEvent += OnMRecAdExpandedEvent;
        MaxSdkCallbacks.MRec.OnAdCollapsedEvent += OnMRecAdCollapsedEvent;
    }

    public void OnMRecAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        onMRECLoaded?.Invoke();
        Debug.Log(">>>>>>>>OnMRecAdLoadedEvent..........:" + DateTime.Now.ToString("HH:mm:ss"));
    }

    public void OnMRecAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo error)
    {
        Debug.Log(">>>>>>>>OnMRecAdLoadFailedEvent..........");
    }

    public void OnMRecAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        Debug.Log(">>>>>>>>OnMRecAdClickedEvent..........");
    }

    public void OnMRecAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        Debug.Log(">>>>>>>>OnMRecAdRevenuePaidEvent..........");
    }

    public void OnMRecAdExpandedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        Debug.Log(">>>>>>>>OnMRecAdExpandedEvent..........");
    }

    public void OnMRecAdCollapsedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        Debug.Log(">>>>>>>>OnMRecAdCollapsedEvent..........");
    }

    public void ShowMREC()
    {
        MaxSdk.ShowMRec(mrecAdUnitId);
    }

    public void HideMREC()
    {
        MaxSdk.HideMRec(mrecAdUnitId);
    }
    #endregion

    #region Open Ads MAX

    public void InitOpenAds()
    {
        MaxSdkCallbacks.AppOpen.OnAdHiddenEvent += OnAppOpenDismissedEvent;
        MaxSdkCallbacks.AppOpen.OnAdLoadedEvent += OnAppOpenLoadedEvent;
        MaxSdkCallbacks.AppOpen.OnAdLoadFailedEvent += OnAppOpenLoadFailEvent;
        MaxSdk.LoadAppOpenAd(AppOpenAdUnitId);
    }

    private void OnAppOpenLoadFailEvent(string adUnitId, MaxSdkBase.ErrorInfo adInfo)
    {
        Debug.Log("OnAppOpenLoadFailEvent........");
    }

    private void OnAppOpenLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        onAppOpenLoaded?.Invoke();
        Debug.Log("OnAppOpenLoadedEvent........");
        //if (!isShowFirstTime)
        //{
        //    isShowFirstTime = true;
        //    ShowOpenAdIfReady();
        //}
    }
    public void ShowOpenAdsFirstOpen()
    {
        if (PlayerPrefs.GetInt("remove_ads", 0) == 1)
            return;

        if (MaxSdk.IsAppOpenAdReady(AppOpenAdUnitId))
        {
            isShowAds = true;
            MaxSdk.ShowAppOpenAd(AppOpenAdUnitId);
        }
    }
    private void OnAppOpenDismissedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        onAppOpenHidden?.Invoke();
        isShowAds = false;
        MaxSdk.LoadAppOpenAd(AppOpenAdUnitId);
    }
    public void ShowOpenAds()
    {
#if UNITY_EDITOR
        return;
#endif
        if (MaxSdk.IsAppOpenAdReady(AppOpenAdUnitId))
        {
            Debug.Log("ShowOpenAdIfReady........");
            isShowAds = true;
            MaxSdk.ShowAppOpenAd(AppOpenAdUnitId);
        }
        else
        {
            MaxSdk.LoadAppOpenAd(AppOpenAdUnitId);

            //if (MaxSdk.IsInterstitialReady(InterstitialAdUnitId))
            //{
            //    isShowAds = true;
            //    Debug.LogWarning(">>>>>>>>>>>>Calling show open ads........");
            //    MaxSdk.ShowInterstitial(InterstitialAdUnitId);
            //    FirebaseLogger.Instance.ShowInterstialOpenAds();
            //}
        }
    }
    public bool IsOpenAdsReady()
    {
        if (PlayerPrefs.GetInt("remove_ads", 0) == 1)
            return false;

        return MaxSdk.IsAppOpenAdReady(AppOpenAdUnitId);
    }

    private bool IsDurationOpenAdsPassed
    {
        get { return (DateTime.Now - lastAdTime).TotalSeconds > 5; }
    }
    #endregion

    #region Interstitial Ad Methods

    private void InitializeInterstitialAds()
    {
        // Attach callbacks
        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialFailedEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += InterstitialFailedToDisplayEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialDismissedEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstialOpenEvent;
        //MaxSdkCallbacks.Interstitial.OnAdRevenuePaidEvent += OnInterstitialRevenuePaidEvent;

        // Load the first interstitial
        LoadInterstitial();
    }

    private void OnInterstialOpenEvent(string arg1, MaxSdkBase.AdInfo arg2)
    {
        Debug.LogWarning(">>>>OnInterstialOpenEvent.Set isShowAds true");
    }

    void LoadInterstitial()
    {
        //interstitialStatusText.text = "Loading...";
        MaxSdk.LoadInterstitial(InterstitialAdUnitId);
    }

    void ShowInterstitial()
    {
        if (MaxSdk.IsInterstitialReady(InterstitialAdUnitId))
        {
            //interstitialStatusText.text = "Showing";
            MaxSdk.ShowInterstitial(InterstitialAdUnitId);
        }
        else
        {
            //interstitialStatusText.text = "Ad not ready";
        }
    }

    private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is ready to be shown. MaxSdk.IsInterstitialReady(interstitialAdUnitId) will now return 'true'
        //interstitialStatusText.text = "Loaded";
        Debug.LogWarning("Interstitial loaded");

        // Reset retry attempt
        interstitialRetryAttempt = 0;
    }

    private void OnInterstitialFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Interstitial ad failed to load. We recommend retrying with exponentially higher delays up to a maximum delay (in this case 64 seconds).
        interstitialRetryAttempt++;
        double retryDelay = Math.Pow(2, Math.Min(6, interstitialRetryAttempt));

        //interstitialStatusText.text = "Load failed: " + errorInfo.Code + "\nRetrying in " + retryDelay + "s...";
        Debug.LogWarning("Interstitial failed to load with error code: " + errorInfo.Code);

        Invoke("LoadInterstitial", (float)retryDelay);
        FirebaseLogger.Instance.LoadInterFail(errorInfo.Code.ToString(), interstitialRetryAttempt);
    }

    private void InterstitialFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        isShowAds = false;
        // Interstitial ad failed to display. We recommend loading the next ad
        Debug.LogWarning("Interstitial failed to display with error code: " + errorInfo.Code);
        LoadInterstitial();
        FirebaseLogger.Instance.InterstialShowFail(errorInfo.Code.ToString());
    }

    private void OnInterstitialDismissedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        isShowAds = false;
        // Interstitial ad is hidden. Pre-load the next ad
        Debug.LogWarning("Interstitial dismissed");
        lastAdTime = DateTime.Now;
        LoadInterstitial();
        onInterstialComplete?.Invoke();
        OnInterstialClose?.Invoke();
        FirebaseLogger.Instance.ShowInterComplete(adInfo.NetworkName);
        UpdateAdsCount();
    }

    //private void OnInterstitialRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    //{
    //    // Interstitial ad revenue paid. Use this callback to track user revenue.
    //    Debug.LogWarning("Interstitial revenue paid");

    //    // Ad revenue
    //    double revenue = adInfo.Revenue;

    //    // Miscellaneous data
    //    string countryCode = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD" in most cases!
    //    string networkName = adInfo.NetworkName; // Display name of the network that showed the ad (e.g. "AdColony")
    //    string adUnitIdentifier = adInfo.AdUnitIdentifier; // The MAX Ad Unit ID
    //    string placement = adInfo.Placement; // The placement this ad's postbacks are tied to

    //    //TrackAdRevenue(adInfo);
    //}

#endregion

    #region Rewarded Ad Methods

        private void InitializeRewardedAds()
        {
            // Attach callbacks
            MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardedAdLoadedEvent;
            MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedAdFailedEvent;
            MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedAdFailedToDisplayEvent;
            MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += OnRewardedAdDisplayedEvent;
            MaxSdkCallbacks.Rewarded.OnAdClickedEvent += OnRewardedAdClickedEvent;
            MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedAdDismissedEvent;
            MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;
            MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += OnRewardedAdRevenuePaidEvent;

            // Load the first RewardedAd
            LoadRewardedAd();
        }

        private void LoadRewardedAd()
        {
            //rewardedStatusText.text = "Loading...";
            MaxSdk.LoadRewardedAd(RewardedAdUnitId);
        }

        private void ShowRewardedAd()
        {
            if (MaxSdk.IsRewardedAdReady(RewardedAdUnitId))
            {
                //rewardedStatusText.text = "Showing";
                MaxSdk.ShowRewardedAd(RewardedAdUnitId);
            }
            else
            {
                //rewardedStatusText.text = "Ad not ready";
            }
        }

        private void OnRewardedAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            // Rewarded ad is ready to be shown. MaxSdk.IsRewardedAdReady(rewardedAdUnitId) will now return 'true'
            //rewardedStatusText.text = "Loaded";
            Debug.LogWarning("Rewarded ad loaded");

            // Reset retry attempt
            rewardedRetryAttempt = 0;
        }

        private void OnRewardedAdFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
        {
            // Rewarded ad failed to load. We recommend retrying with exponentially higher delays up to a maximum delay (in this case 64 seconds).
            rewardedRetryAttempt++;
            double retryDelay = Math.Pow(2, Math.Min(6, rewardedRetryAttempt));

            //rewardedStatusText.text = "Load failed: " + errorInfo.Code + "\nRetrying in " + retryDelay + "s...";
            Debug.LogWarning("Rewarded ad failed to load with error code: " + errorInfo.Code);

            Invoke("LoadRewardedAd", (float)retryDelay);

            FirebaseLogger.Instance.LoadRewardFail(errorInfo.Code.ToString());
        }

        private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
        {
            isShowAds = false;
            // Rewarded ad failed to display. We recommend loading the next ad
            Debug.LogWarning("Rewarded ad failed to display with error code: " + errorInfo.Code);
            LoadRewardedAd();
            FirebaseLogger.Instance.ShowRewardFail(errorInfo.Code.ToString());
        }

        private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            Debug.LogWarning("Rewarded ad displayed");
            FirebaseLogger.Instance.ShowReward();
        }

        private void OnRewardedAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            Debug.LogWarning("Rewarded ad clicked");
        }

        private void OnRewardedAdDismissedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            isShowAds = false;
            // Rewarded ad is hidden. Pre-load the next ad
            Debug.LogWarning("Rewarded ad dismissed");
            lastAdTime = DateTime.Now;
            LoadRewardedAd();
        }

        private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward, MaxSdkBase.AdInfo adInfo)
        {
            isShowAds = false;
            // Rewarded ad was displayed and user should receive the reward
            Debug.LogWarning("Rewarded ad received reward");
            onRewardComplete?.Invoke(true);
            FirebaseLogger.Instance.ShowRewardComplete(adInfo.NetworkName);
            UpdateAdsCount();
        }

        private void OnRewardedAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            // Rewarded ad revenue paid. Use this callback to track user revenue.
            Debug.LogWarning("Rewarded ad revenue paid");

            // Ad revenue
            double revenue = adInfo.Revenue;

            // Miscellaneous data
            string countryCode = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD" in most cases!
            string networkName = adInfo.NetworkName; // Display name of the network that showed the ad (e.g. "AdColony")
            string adUnitIdentifier = adInfo.AdUnitIdentifier; // The MAX Ad Unit ID
            string placement = adInfo.Placement; // The placement this ad's postbacks are tied to

            //TrackAdRevenue(adInfo);
        }

    #endregion

    #region Banner Ad Methods

    private void InitializeBannerAds()
    {
        // Attach Callbacks
        MaxSdkCallbacks.Banner.OnAdLoadedEvent += OnBannerAdLoadedEvent;
        MaxSdkCallbacks.Banner.OnAdLoadFailedEvent += OnBannerAdFailedEvent;
        MaxSdkCallbacks.Banner.OnAdClickedEvent += OnBannerAdClickedEvent;
        MaxSdkCallbacks.Banner.OnAdRevenuePaidEvent += OnBannerAdRevenuePaidEvent;

        // Banners are automatically sized to 320x50 on phones and 728x90 on tablets.
        // You may use the utility method `MaxSdkUtils.isTablet()` to help with view sizing adjustments.
        MaxSdk.CreateBanner(BannerAdUnitId, MaxSdkBase.BannerPosition.BottomCenter);

        // Set background or background color for banners to be fully functional.
        MaxSdk.SetBannerBackgroundColor(BannerAdUnitId, Color.black);
    }

    private void ToggleBannerVisibility()
    {
        if (!isBannerShowing)
        {
            MaxSdk.ShowBanner(BannerAdUnitId);
        }
        else
        {
            MaxSdk.HideBanner(BannerAdUnitId);
        }

        isBannerShowing = !isBannerShowing;
    }

    private void OnBannerAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
            // Banner ad is ready to be shown.
            // If you have already called MaxSdk.ShowBanner(BannerAdUnitId) it will automatically be shown on the next ad refresh.
            //Debug.LogWarning("Banner ad loaded");
            ShowBanner();
    }

    private void OnBannerAdFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Banner ad failed to load. MAX will automatically try loading a new ad internally.
        //Debug.LogWarning("Banner ad failed to load with error code: " + errorInfo.Code);
    }

    private void OnBannerAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        //Debug.LogWarning("Banner ad clicked");
    }

    private void OnBannerAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Banner ad revenue paid. Use this callback to track user revenue.
        //Debug.LogWarning("Banner ad revenue paid");

        // Ad revenue
        double revenue = adInfo.Revenue;

        // Miscellaneous data
        string countryCode = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD" in most cases!
        string networkName = adInfo.NetworkName; // Display name of the network that showed the ad (e.g. "AdColony")
        string adUnitIdentifier = adInfo.AdUnitIdentifier; // The MAX Ad Unit ID
        string placement = adInfo.Placement; // The placement this ad's postbacks are tied to

        //TrackAdRevenue(adInfo);
    }

    #endregion
    public void InitBanner()
    {
#if TESTING
        return;
#endif
        Debug.Log("Calling InitBanner..................");
        InitializeBannerAds();
    }

    public void ShowBanner()
    {
#if UNITY_EDITOR
        return;
#endif
        if (Application.platform == RuntimePlatform.OSXEditor)
            return;

        MaxSdk.ShowBanner(BannerAdUnitId);
    }

    public void UpdateBannerPosition(MaxSdkBase.BannerPosition position)
    {
        MaxSdk.UpdateBannerPosition(BannerAdUnitId, position);
    }
    public void HideBanner()
    {
        MaxSdk.HideBanner(BannerAdUnitId);
    }
    public void ForceShowInterstial()
    {
#if UNITY_EDITOR
        return;
#endif
        MaxSdk.ShowInterstitial(InterstitialAdUnitId);
    }
    public void ShowInterstial()
    {
#if UNITY_EDITOR
        return;
#endif
        if (GameConfig.InReview)
            return;

        if ((DateTime.Now - this.lastAdTime).TotalSeconds < GameConfig.InterstitialAdDuration)
            return;
        //if (PlayerPrefs.GetInt("remove_ads", 0) == 1)
        //    return;

        //if (!IsDurationBetweenAdsPassed())
        //    return;
        //inter reward.........
        //if (ShowInterReward())
        //{
        //    FirebaseLogger.Instance.ShowInterReward();
        //    return;
        //}
        if (IsInterstialAvaiable())
            isShowAds = true;
        onInterstialComplete = () =>
        {
            showInterCount++;
            Debug.Log(">>>>>>>>onInterstialComplete showInterCount:" + showInterCount);
        };
        MaxSdk.ShowInterstitial(InterstitialAdUnitId);
        FirebaseLogger.Instance.ShowInter();
    }

    public bool IsRewardAvailable()
    {
#if UNITY_EDITOR
        return true;
#endif
        return MaxSdk.IsRewardedAdReady(RewardedAdUnitId);
    }

    public void ShowReward(Action<bool> completeAction)
    {
#if UNITY_EDITOR
        completeAction?.Invoke(true);
        return;
#endif
        //if (IsRewardAvailable())
        //    isShowAds = true;

        onRewardComplete = (b) =>
        {
            completeAction?.Invoke(b);
        };
        MaxSdk.ShowRewardedAd(RewardedAdUnitId);
    }
    public bool IsDurationBetweenAdsPassed()
    {
#if UNITY_EDITOR
        return false;
#endif
        if (PlayerPrefs.GetInt("remove_ads", 0) == 1)
            return false;

        if (this.lastAdTime == DateTime.MinValue)
        {
            Debug.LogWarning("IsDurationBetweenAdsPassed false");
            this.lastAdTime = DateTime.Now;
            return false;
        }

        //var totalSecond = (DateTime.Now - this.lastAdTime).TotalSeconds;
        //Debug.LogWarning("Total second:" + totalSecond);
        //int timeCheck = 0;
        //switch (showInterCount)
        //{
        //    case 0:
        //        timeCheck = GameConfig.InterstitialAdDurationStep1;
        //        break;
        //    case 1:
        //        timeCheck = GameConfig.InterstitialAdDurationStep2;
        //        break;
        //    default:
        //        timeCheck = GameConfig.InterstitialAdDurationStep3;
        //        break;
        //}
        if ((DateTime.Now - this.lastAdTime).TotalSeconds > GameConfig.InterstitialAdDuration)
        {
            if (!MaxSdk.IsInterstitialReady(InterstitialAdUnitId))
            {
                if (Application.internetReachability != NetworkReachability.NotReachable)
                    FirebaseLogger.Instance.InterstialNotAvailable();
                else
                    FirebaseLogger.Instance.InterNoInternet();
                return false;
            }
            Debug.LogWarning("IsDurationBetweenAdsPassed true");
            return true;
        }
        return false;
    }
    public bool IsInterstialAvaiable()
    {
        return MaxSdk.IsInterstitialReady(InterstitialAdUnitId);
    }
    public void ShowSometimes()
    {
        if (!IsDurationBetweenAdsPassed())
            return;

        Debug.LogWarning("Show Sometime call...........");

        ShowInterstial();
        FirebaseLogger.Instance.ShowInterstialSomeTime();
    }

    public void ShowInterstialInGame()
    {
#if UNITY_EDITOR
        return;
#endif
        if (GameConfig.InReview)
            return;
        if (this.lastAdTime == DateTime.MinValue)
        {
            Debug.LogWarning("IsDurationBetweenAdsPassed false");
            return;
        }

        var totalSecond = (DateTime.Now - this.lastAdTime).TotalSeconds;
        if ((DateTime.Now - this.lastAdTime).TotalSeconds> GameConfig.InterstitialAdDurationInGame)
        {
            if (IsInterstialAvaiable())
            {
                //if (ShowInterReward())
                //{
                //    FirebaseLogger.Instance.ShowInterRewardInGame();
                //    return;
                //}
                isShowAds = true;
                MaxSdk.ShowInterstitial(InterstitialAdUnitId);
                FirebaseLogger.Instance.ShowInterInGame();
            }
            else
            {
                if (Application.internetReachability != NetworkReachability.NotReachable)
                    FirebaseLogger.Instance.InterstialNotAvailable();
                else
                    FirebaseLogger.Instance.InterNoInternet();
            }
        }
    }

    //private bool ShowInterReward()
    //{
    //    if (showInterCount >= GameConfig.InterRewardDuration && IsRewardAvailable())
    //    {
    //        ShowReward((b) =>
    //        {
    //            showInterCount = 0;
    //        });
    //        return true;
    //    }
    //    return false;
    //}
    
    private void UpdateAdsCount()
    {
        int count = PlayerPrefs.GetInt("ads_count", 0) + 1;
        PlayerPrefs.SetInt("ads_count", count);
        AdsCount = count;
    }
#endif


#if ADMOB_MEDIATION
        // Always use test ads.
        // https://developers.google.com/admob/unity/test-ads
        public static List<string> TestDeviceIds = new List<string>()
        {
            AdRequest.TestDeviceSimulator,
#if UNITY_IPHONE
            "8242ddf5ebce720f9494ade7e15a85e0",
#elif UNITY_ANDROID
            "8242ddf5ebce720f9494ade7e15a85e0"
#endif
        };
        // The Google Mobile Ads Unity plugin needs to be run only once.
        private static bool? _isInitialized;
        InterstitialAdController interstitialAdController;
        InterstitialAdController interstitialOpenAdController;
        RewardedAdController rewardedAdController;
        AppOpenAdController appOpenAdController;
        BannerViewController mrecViewController;
        BannerCollapseController bannerCollapseController;

#if UNITY_ANDROID
        private string
          _appOpenUnit = "ca-app-pub-9861239042906842/9940653018",
          _mrecUnit = "ca-app-pub-9861239042906842/8627571347",
          _interUnit = "ca-app-pub-9861239042906842/7314489675",
            _interOpenUnit = "ca-app-pub-9861239042906842/9108322618",
          _rewardUnit = "ca-app-pub-9861239042906842/7795240940";
#else
      private string
      _appOpenUnit = "",
      _mrecUnit = "",
      _interUnit = "",
          _interOpenUnit = "",
      _rewardUnit = "";
#endif
        public void OnApplicationPause(bool paused)
        {
            if (!paused)
            {
                if (isShowAds)
                    return;
                if (IsRemoveAds)
                    return;

                ShowOpenAds();
            }
        }
        public void InitAdmob()
        {
            if (IsRemoveAds) return;

            Debug.Log("Begin init admob unit........:" + GameConfig.InReview);

            if (!GameConfig.InReview)
            {
#if UNITY_IOS
 appOpenAdController = new AppOpenAdController(_appOpenUnit);

            appOpenAdController.onOAppOpenLoaded += () =>
            {
#if UNITY_EDITOR
                return;
#endif
                onAppOpenLoaded?.Invoke();
            };

            appOpenAdController.onAppOpenHidden += () =>
            {
                onAppOpenHidden?.Invoke();
            };
#endif
                interstitialOpenAdController = new InterstitialAdController(_interOpenUnit, true);
                interstitialOpenAdController.onLoaded += () =>
                {
                    OnInterOpenLoaded?.Invoke();
                };
                interstitialOpenAdController.onClose += () => {
                    OnInterOpenDismiss?.Invoke();
                };

                appOpenAdController = new AppOpenAdController(_appOpenUnit);

                appOpenAdController.onOAppOpenLoaded += () =>
                {
#if UNITY_EDITOR
                    return;
#endif
                    onAppOpenLoaded?.Invoke();
                };

                appOpenAdController.onAppOpenHidden += () =>
                {
                    onAppOpenHidden?.Invoke();
                };

                Debug.Log(">>>>>>>>>>select_age:" + PlayerPrefs.GetInt("select_age", 0));
                if (PlayerPrefs.GetInt("select_age", 0) == 0)
                {
                    Debug.Log("Calling init MREC...............");
                    mrecViewController = new BannerViewController(_mrecUnit, true, AdPosition.TopLeft);
                    mrecViewController.onBannerLoaded += () =>
                    {
                        Debug.Log(">>>>>>>>>>>>MREC loaded..........");
                        onMRECLoaded?.Invoke();
                    };
                }

             
            }

            rewardedAdController = new RewardedAdController(_rewardUnit);

            rewardedAdController.onRewardReady += () =>
            {
                OnRewardReady?.Invoke();
            };

            //AppStateEventNotifier.AppStateChanged += OnAppStateChanged;

            InvokeRepeating("RetryLoadAds", GameConfig.RetryReloadAd, GameConfig.RetryReloadAd);
        }

        private void RetryLoadAds()
        {
            Debug.Log("Calling RetryLoadAds...........");
            if (GameConfig.InReview || IsRemoveAds)
                return;

            if (!IsRewardAvailable())
            {
                if (rewardedAdController != null)
                    rewardedAdController.LoadAd();
            }

            if (!IsInterstialReady())
            {
                if (interstitialAdController != null)
                    interstitialAdController.LoadAd();
            }

            if (!IsOpenAdsReady())
            {
                if (appOpenAdController != null)
                    appOpenAdController.LoadAd();
            }

            //if (bannerCollapseController != null && !IsRemoveAds && isInitAdmob)
            //{
            //    if (SceneManager.GetActiveScene().buildIndex > 0)
            //    {
            //        if (!bannerCollapseController.IsBannerLoaded)
            //        {
            //            bannerCollapseController.LoadAd();
            //        }
            //    }
            //}
        }

        private void RefreshAds()
        {
            //RefreshBanner();

            //if (GameConfig.ShowOpenAdsInterClose)
            //{
            //    ShowOpenAds();
            //}
        }

        public void RefreshBanner()
        {
            if (bannerCollapseController != null)
                bannerCollapseController.LoadAd();
        }

        public void RefreshManualCollapse()
        {
            if ((DateTime.Now - lastBannerCollapse).TotalSeconds > GameConfig.CollapseAdDuration)
            {
                if (bannerCollapseController != null)
                {
                    bannerCollapseController.LoadAd();
                    FirebaseLogger.Instance.CollapseRefresh();
                }
            }
        }

        private void Awake()
        {
            //AppStateEventNotifier.AppStateChanged += OnAppStateChanged;
            Debug.Log(">>>>>>>>>>>>>>>>>AppStateChanged Register.........");
            lastAdTime = DateTime.Now;
            lastBannerCollapse = DateTime.Now;
        }
        public override void OnDestroy()
        {
            base.OnDestroy();

            //AppStateEventNotifier.AppStateChanged -= OnAppStateChanged;
        }

        private void OnAppStateChanged(AppState state)
        {
            Debug.Log("App State changed to : " + state);

            // If the app is Foregrounded and the ad is available, show it.
            if (state == AppState.Foreground)
            {
                if (PlayerPrefs.GetInt("remove_ads", 0) == 0)
                {
                    if (IsDurationBetweenOpenAdsPassed())
                    {
                        PanelLoadAds.Instance.ShowLoadOpenAds();
                    }
                }
            }
        }

        public void ShowOpenAds(AppState state)
        {
            if (state == AppState.Foreground)
            {
                if (PlayerPrefs.GetInt("remove_ads", 0) == 0)
                {
                    if (IsDurationBetweenOpenAdsPassed())
                    {
                        PanelLoadAds.Instance.ShowLoadOpenAds();
                    }
                }
            }
        }
        private void Start()
        {
#if UNITY_IOS
        if (ATTrackingStatusBinding.GetAuthorizationTrackingStatus() == ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
        {
            Debug.LogWarning("Start RequestAuthorizationTracking......");
            ATTrackingStatusBinding.RequestAuthorizationTracking((b) =>
            {
                //InitComponent();
                FirebaseLogger.Instance.Init();
                Debug.Log("Call back:" + b);

                //AudienceNetwork.AdSettings.SetAdvertiserTrackingEnabled(ATTrackingStatusBinding.GetAuthorizationTrackingStatus() == ATTrackingStatusBinding.AuthorizationTrackingStatus.AUTHORIZED);
            });
        }
        else
            InitComponent();
#else
            InitComponent();
#endif
        }

        public void InitComponent()
        {
#if TESTING
        PlayerPrefs.SetInt("remove_ads", 1);
        return;
#endif
            //Debug.Log("GetAuthorizationTrackingStatus:" + ATTrackingStatusBinding.GetAuthorizationTrackingStatus());
            Debug.Log("device id:" + SystemInfo.deviceUniqueIdentifier);
            // On Android, Unity is paused when displaying interstitial or rewarded video.
            // This setting makes iOS behave consistently with Android.
            MobileAds.SetiOSAppPauseOnBackground(true);

            // When true all events raised by GoogleMobileAds will be raised
            // on the Unity main thread. The default value is false.
            // https://developers.google.com/admob/unity/quick-start#raise_ad_events_on_the_unity_main_thread
            MobileAds.RaiseAdEventsOnUnityMainThread = true;

            // Configure your RequestConfiguration with Child Directed Treatment
            // and the Test Device Ids.
            MobileAds.SetRequestConfiguration(new RequestConfiguration
            {
                TestDeviceIds = TestDeviceIds
            });

            // If we can request ads, we should initialize the Google Mobile Ads Unity plugin.
            if (GoogleMobileAdsConsentController.Instance.CanRequestAds)
            {
                InitializeGoogleMobileAds();
            }

            // Ensures that privacy and consent information is up to date.
            InitializeGoogleMobileAdsConsent();
        }
        /// <summary>
        /// Ensures that privacy and consent information is up to date.
        /// </summary>
        private void InitializeGoogleMobileAdsConsent()
        {
            Debug.Log("Google Mobile Ads gathering consent.");

            GoogleMobileAdsConsentController.Instance.GatherConsent((string error) =>
            {
                if (error != null)
                {
                    Debug.LogError("Failed to gather consent with error: " +
                        error);
                }
                else
                {
                    Debug.Log("Google Mobile Ads consent updated: "
                        + ConsentInformation.ConsentStatus);
                }

                if (GoogleMobileAdsConsentController.Instance.CanRequestAds)
                {
                    InitializeGoogleMobileAds();
                }
            });
        }
        /// <summary>
        /// Initializes the Google Mobile Ads Unity plugin.
        /// </summary>
        private void InitializeGoogleMobileAds()
        {
            // The Google Mobile Ads Unity plugin needs to be run only once and before loading any ads.
            if (_isInitialized.HasValue)
            {
                return;
            }

            _isInitialized = false;

            // Initialize the Google Mobile Ads Unity plugin.
            Debug.Log("Google Mobile Ads Initializing.");
            MobileAds.Initialize((InitializationStatus initstatus) =>
            {
                AppsFlyer.initSDK("Qhno4yJY6KHmZp9uS9DRe4", "", this);
                AppsFlyer.startSDK();

#if UNITY_ANDROID
                FirebaseLogger.Instance.Init();
#endif

                if (initstatus == null)
                {
                    Debug.LogError("Google Mobile Ads initialization failed.");
                    _isInitialized = null;
                    return;
                }

                // If you use mediation, you can check the status of each adapter.
                var adapterStatusMap = initstatus.getAdapterStatusMap();
                if (adapterStatusMap != null)
                {
                    foreach (var item in adapterStatusMap)
                    {
                        Debug.Log(string.Format("Adapter {0} is {1}",
                            item.Key,
                            item.Value.InitializationState));
                    }
                }

                Debug.Log("Google Mobile Ads initialization complete.");
                _isInitialized = true;
                if (PlayerPrefs.GetInt("remove_ads", 0) == 0)
                    InitAdmob();

#if UNITY_ANDROID
                //Facebook.Unity.FB.Init(() =>
                //{
                //    Debug.Log("FB init :" + Facebook.Unity.FB.IsInitialized);
                //});
#endif
            });
        }

        //public float GetBannerHeight()
        //{
        //    Debug.Log(">>>>>>>>>>>>>>GetBannerHeight...........");
        //    if (bannerViewController == null)
        //        return 0f;

        //    Debug.Log("Banner height:" + bannerViewController.GetBannerHeight());
        //    return bannerViewController.GetBannerHeight();
        //}
        public void ShowOpenAds()
        {
#if UNITY_EDITOR
            return;
#endif
            if (IsDurationBetweenOpenAdsPassed())
            {
                if (appOpenAdController != null)
                    appOpenAdController.ShowAd();
            }
        }
        public void ShowMREC()
        {
            if (GameConfig.InReview)
                return;
            if (mrecViewController != null)
            {
                mrecViewController.ShowAd();
            }
        }
        public void HideMREC()
        {
            Debug.Log("Calling HideMREC");
            if (mrecViewController != null)
            {
                Debug.Log("Begin HideMREC");
                mrecViewController.HideAd();
            }
        }
        public bool IsOpenAdsReady()
        {
            if (GameConfig.InReview)
                return false;
#if UNITY_EDITOR
            return false;
#endif
            return appOpenAdController != null && appOpenAdController.IsReady();
        }

        //avoid call mulplicate
        private bool isInitAdmob = false;
        public void InitBanner()
        {
            if (IsRemoveAds || GameConfig.InReview)
                return;

            if (isInitAdmob)
                return;

            isInitAdmob = true;
//#if UNITY_ANDROID
//            bannerCollapseController = new BannerCollapseController("", AdPosition.Top);
//#else
//        bannerCollapseController = new BannerCollapseController("", AdPosition.Top);
//#endif

            if (interstitialOpenAdController != null)
                interstitialOpenAdController.DestroyAd();

            interstitialAdController = new InterstitialAdController(_interUnit);

            if (interstitialAdController != null)
            {
                interstitialAdController.onClose += () =>
                {
                    RefreshAds();
                };
            }
        }

        public void ShowBanner()
        {
            if (IsRemoveAds || GameConfig.InReview)
                return;
            if (bannerCollapseController != null)
                bannerCollapseController.ShowAd();
        }

        public void HideBanner()
        {
            if (bannerCollapseController != null)
                bannerCollapseController.HideAd();
        }

        public void ShowInterstial(string postition)
        {
            Debug.Log("Calling ShowInterstial........:" + postition);
            if (IsDurationBetweenInterstialPassed())
            {
                //interstitialAdController.ShowAd();
                PanelLoadAds.Instance.ShowLoadAds();
                FirebaseLogger.Instance.ShowInterPosition(postition);
            }
        }

        public void ShowInterSometime()
        {
            Debug.Log("Calling ShowInterstial........:");
            if (IsDurationBetweenInterstialPassed())
            {
                PanelLoadAds.Instance.ShowLoadAds();
                FirebaseLogger.Instance.ShowInterPosition("sometime");
            }
        }

        public void ShowInter()
        {
            isShowAds = true;
            interstitialAdController.ShowAd();
        }
        public bool IsInterOpenReady()
        {
            return interstitialOpenAdController != null && interstitialOpenAdController.IsReady();
        }
        public void ShowInterOpen()
        {
            if (interstitialOpenAdController != null && interstitialOpenAdController.IsReady())
                interstitialOpenAdController.ShowAd();
        }
        public void ShopLoadAds()
        {

        }

        public void HideLoadAds()
        {

        }
        public bool IsInterstialReady()
        {
            return interstitialAdController != null && interstitialAdController.IsReady();
        }
        public bool IsRewardAvailable()
        {
            return rewardedAdController != null && rewardedAdController.IsRewardAdReady();
        }
        public void ShowReward(Action<bool> completeAction)
        {
            if (IsRewardAvailable())
            {
                rewardedAdController.ShowAd((b) =>
                {
                    completeAction(b);
                    RefreshAds();
                });
            }
        }

        public bool IsDurationBetweenInterstialPassed()
        {
#if UNITY_EDITOR
            return false;
#endif
            if (GameConfig.InReview)
                return false;

            if (PlayerPrefs.GetInt("remove_ads", 0) == 1)
                return false;

            if ((DateTime.Now - this.lastAdTime).TotalSeconds > GameConfig.InterstitialAdDuration)
            {
                if (!IsInterstialReady())
                {
                    if (Application.internetReachability != NetworkReachability.NotReachable)
                        FirebaseLogger.Instance.InterstialNotAvailable();
                    else
                        FirebaseLogger.Instance.InterNoInternet();
                    return false;
                }
                Debug.LogWarning("IsDurationBetweenAdsPassed true");
                return true;
            }
            return false;
        }

        public bool IsDurationBetweenInterstialSometime()
        {
#if UNITY_EDITOR
            return false;
#endif
            if (GameConfig.InReview)
                return false;

            if (PlayerPrefs.GetInt("remove_ads", 0) == 1)
                return false;

            if ((DateTime.Now - this.lastAdTime).TotalSeconds > GameConfig.InterstitialAdDurationSomeTime)
            {
                if (!IsInterstialReady())
                {
                    if (Application.internetReachability != NetworkReachability.NotReachable)
                        FirebaseLogger.Instance.InterstialNotAvailable();
                    else
                        FirebaseLogger.Instance.InterNoInternet();
                    return false;
                }
                Debug.LogWarning("IsDurationBetweenAdsPassed true");
                return true;
            }
            return false;
        }

        public bool IsDurationBetweenOpenAdsPassed()
        {
#if UNITY_EDITOR
            return false;
#endif
            if (PlayerPrefs.GetInt("remove_ads", 0) == 1)
                return false;

            if ((DateTime.Now - this.lastAdTime).TotalSeconds > GameConfig.InterstitialAdDuration)
            {
                if (!IsOpenAdsReady())
                {
                    //if (Application.internetReachability != NetworkReachability.NotReachable)
                    //    FirebaseLogger.Instance.InterstialNotAvailable();
                    //else
                    //    FirebaseLogger.Instance.InterNoInternet();
                    return false;
                }
                Debug.LogWarning("IsDurationBetweenAdsPassed true");
                return true;
            }
            return false;
        }

        public float GetBannerViewSize()
        {
            if (bannerCollapseController != null)
                return bannerCollapseController.GetBannerHeight();

            return 0f;
        }
        public ENUM_Device_Type GetDeviceType()
        {
#if UNITY_IOS
    bool deviceIsIpad = UnityEngine.iOS.Device.generation.ToString().Contains("iPad");
            if (deviceIsIpad)
            {
                return ENUM_Device_Type.Tablet;
            }
        return ENUM_Device_Type.Phone;
            //bool deviceIsIphone = UnityEngine.iOS.Device.generation.ToString().Contains("iPhone");
            //if (deviceIsIphone)
            //{
            //    return ENUM_Device_Type.Phone;
            //}
#elif UNITY_ANDROID

            float aspectRatio = Mathf.Max(Screen.width, Screen.height) / Mathf.Min(Screen.width, Screen.height);
            bool isTablet = (DeviceDiagonalSizeInInches() > 6.5f && aspectRatio < 2f);

            if (isTablet)
            {
                return ENUM_Device_Type.Tablet;
            }
            else
            {
                return ENUM_Device_Type.Phone;
            }
#endif
        }
        float DeviceDiagonalSizeInInches()
        {
            float screenWidth = Screen.width / Screen.dpi;
            float screenHeight = Screen.height / Screen.dpi;
            float diagonalInches = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));

            return diagonalInches;
        }
#endif
}
public enum ENUM_Device_Type
{
    Tablet,
    Phone
}
