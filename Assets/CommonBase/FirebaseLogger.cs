using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using AppsFlyerSDK;

public class FirebaseLogger : Trip.Singleton<FirebaseLogger>
{

    private List<OfflineLog> offlineLogs = new List<OfflineLog>();
    private bool isInited;


    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;

    private void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                isInited = true;
                RemoteConfig.Instance.Init();
            }
            else
            {
                Debug.LogError(
                  "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }

           
        });
        InvokeRepeating("SendOfflineLogs", 3, 10);
    }
    public void SendOfflineLogs()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable || !isInited)
        {
            return;
        }
        foreach (OfflineLog offlineLog in this.offlineLogs)
        {
            FirebaseAnalytics.LogEvent(offlineLog.EventName, offlineLog.Parameters);
        }
        this.offlineLogs.Clear();
    }
    public void OnAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo impressionData)
    {
        double revenue = impressionData.Revenue;
        var impressionParameters = new[] {
               new Firebase.Analytics.Parameter("ad_platform", "AppLovin"),
               new Firebase.Analytics.Parameter("ad_source", impressionData.NetworkName),
               new Firebase.Analytics.Parameter("ad_unit_name", impressionData.AdUnitIdentifier),
               new Firebase.Analytics.Parameter("ad_format", impressionData.Placement), // Please check this - as we couldn't find format refereced in your unity docs https://dash.applovin.com/documentation/mediation/unity/getting-started/advanced-settings#impression-level-user-revenue - api
               new Firebase.Analytics.Parameter("value", revenue),
               new Firebase.Analytics.Parameter("currency", "USD"), // All Applovin revenue is sent in USD
           };

        if (isInited)
        {
            Debug.Log("Up Revenue ad............");
            FirebaseAnalytics.LogEvent("ad_impression_max", impressionParameters);
            FirebaseAnalytics.LogEvent("ad_impression", impressionParameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_impression_max", impressionParameters));
            this.offlineLogs.Add(new OfflineLog("ad_impression", impressionParameters));
        }

        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("ad_unit_name", impressionData.AdUnitIdentifier);
        dic.Add("ad_format", impressionData.Placement);
        AppsFlyer.logAdRevenue(new AFAdRevenueData(impressionData.NetworkName, MediationNetwork.ApplovinMax, "USD", revenue), dic);
    }

#if ADMOB_MEDIATION
    public void OnAdRevenuePaidEvent(double revenue, AdapterResponseInfo responseInfo)
    {
        string adSourceId = responseInfo.AdSourceId;
        string adSourceInstanceId = responseInfo.AdSourceInstanceId;
        string adSourceInstanceName = responseInfo.AdSourceInstanceName;
        string adSourceName = responseInfo.AdSourceName;
        string adapterClassName = responseInfo.AdapterClassName;

        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("ad_unit_name", adSourceId);
        dic.Add("ad_format", adSourceInstanceName);

        AppsFlyer.logAdRevenue(new AFAdRevenueData(adSourceName, MediationNetwork.GoogleAdMob, "USD", revenue), dic);
    }
#endif

    public void OpenItemAds(string name)
    {
        Parameter[] parameters = new Parameter[]
                     {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks),
                            new Parameter("item_name", name)
                     };

        if (isInited)
        {
            FirebaseAnalytics.LogEvent("open_item_ads", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("open_item_ads", parameters));
        }
    }
    public void BuyInapp(string product)
    {
        Parameter[] parameters = new Parameter[]
                     {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks),
                            new Parameter("product", product)
                     };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("buy_inapp", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("buy_inapp", parameters));
        }
    }

    public void SaveScreenShoot(string error)
    {
        Parameter[] parameters = new Parameter[]
                   {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks),
                            new Parameter("error_save", string.IsNullOrEmpty(error)?"Success": error),
                            new Parameter("game", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
                   };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("save_screen_shoot", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("save_screen_shoot", parameters));
        }
    }

    public void PlayGame()
    {
        Parameter[] parameters = new Parameter[]
                   {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks),
                            new Parameter("game", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
                   };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("play_game", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("play_game", parameters));
        }
    }

    public void RateGame(int rate)
    {
        Parameter[] parameters = new Parameter[]
                   {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks),
                            new Parameter("game", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name),
                            new Parameter("rate", rate.ToString())
                   };

        if (isInited)
        {
            FirebaseAnalytics.LogEvent("rate_store", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("rate_store", parameters));
        }
    }

    public void SelectContent(string contentId)
    {
        Parameter[] parameters = new Parameter[] {
            new Parameter(
              FirebaseAnalytics.ParameterItemId, contentId),
            new Parameter(
              FirebaseAnalytics.ParameterContentType,  UnityEngine.SceneManagement.SceneManager.GetActiveScene().name),
          };

        if (isInited)
        {
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventSelectContent, parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog(FirebaseAnalytics.EventSelectContent, parameters));
        }

    }

    public void SelectListItem(string listId)
    {
        Parameter[] parameters = new Parameter[] {
            new Parameter(
              FirebaseAnalytics.ParameterItemListID, listId)
        };

        if (isInited)
        {
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventViewItemList, parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog(FirebaseAnalytics.EventViewItemList, parameters));
        }
    }

    public void SelectItem(string item)
    {
        Parameter[] parameters = new Parameter[] {
            new Parameter(
              FirebaseAnalytics.ParameterItemId, item)
        };

        if (isInited)
        {
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventViewItem, parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog(FirebaseAnalytics.EventViewItem, parameters));
        }
    }

    #region Interstial Logger
    public void ShowInterstialSomeTime()
    {
        Parameter[] parameters = new Parameter[]
                    {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks),
                            new Parameter("game", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
                    };

        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_inter_sometime", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_inter_sometime", parameters));
        }
    }
    public void ShowInterstialOpenAds()
    {
        Parameter[] parameters = new Parameter[]
                    {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks),
                            new Parameter("game", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
                    };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_inter_show_open_ads", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_inter_show_open_ads", parameters));
        }
    }
    public void ShowInterstialOpenGame()
    {
        Parameter[] parameters = new Parameter[]
                    {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks),
                            new Parameter("game", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
                    };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_inter_show_open_game", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_inter_show_open_game", parameters));
        }
    }
    public void ShowInter()
    {
        Parameter[] parameters = new Parameter[]
                   {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                   };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_inter_show", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_inter_show", parameters));
        }
    }
    public void ShowInterAdmobFirstOpen()
    {
        Parameter[] parameters = new Parameter[]
                   {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                   };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_inter_firstopen", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_inter_firstopen", parameters));
        }
    }
    public void ShowFailInterAdmobFirstOpen()
    {
        Parameter[] parameters = new Parameter[]
                   {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                   };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_inter_firstopen_fail", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_inter_firstopen_fail", parameters));
        }
    }
    public void ShowInterReward()
    {
        Parameter[] parameters = new Parameter[]
                   {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                   };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_inter_reward_show", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_inter_show", parameters));
        }
    }
    public void LoadInterFail(string errorCode, int count)
    {
        Parameter[] parameters = new Parameter[]
                  {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks),
                            new Parameter("errorCode", errorCode),
                            new Parameter("count", count)
                  };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_inter_loadfail", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_inter_loadfail", parameters));
        }
    }
    public void InterstialNotAvailable()
    {
        Parameter[] parameters = new Parameter[2]
      {
          new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks),
          new Parameter("timeStart", Time.realtimeSinceStartupAsDouble)
      };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_inter_unable_to_show", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_inter_unable_to_show", parameters));
        }
    }
    public void InterNoInternet()
    {
        Parameter[] parameters = new Parameter[]
                   {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                   };

        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_inter_no_internet", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_inter_no_internet", parameters));
        }
    }
    public void InterstialShowFail(string errorCode)
    {
        Parameter[] parameters = new Parameter[]
                   {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks),
                            new Parameter("errorCode", errorCode)
                   };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_inter_showfail", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_inter_showfail", parameters));
        }
    }

    public void ShowInterComplete(string network)
    {
        Parameter[] parameters = new Parameter[]
                  {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks),
                            new Parameter("network", network)
                  };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_inter_complete", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_inter_complete", parameters));
        }
    }
    public void ShowInterInGame()
    {
        Parameter[] parameters = new Parameter[]
                  {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                  };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_inter_ingame", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_inter_ingame", parameters));
        }
    }
    public void ShowInterRewardInGame()
    {
        Parameter[] parameters = new Parameter[]
                  {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                  };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_inter_reward_ingame", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_inter_reward_ingame", parameters));
        }
    }
    #endregion

    #region Reward Logger
    public void LoadRewardFail(string errorCode)
    {
        Parameter[] parameters = new Parameter[2]
                 {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                 };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_reward_load_fail", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_reward_load_fail", parameters));
        }
    }

    public void ShowRewardFail(string errorCode)
    {
        Parameter[] parameters = new Parameter[2]
                 {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                 };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_reward_show_fail", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_reward_show_fail", parameters));
        }
    }
    public void ShowReward()
    {
        Parameter[] parameters = new Parameter[]
                 {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                 };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_reward_show", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_reward_show", parameters));
        }
    }
    public void ShowRewardComplete(string network)
    {
        Parameter[] parameters = new Parameter[]
                 {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks),
                            new Parameter("network", network)
                 };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_reward_complete", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_reward_complete", parameters));
        }
    }
    public void RewardNotReady()
    {
        Parameter[] parameters = new Parameter[]
                 {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                 };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_reward_unable_to_show", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_reward_unable_to_show", parameters));
        }
    }
    #endregion

    #region Open Ads
    public void ShowOpenAdsAdmob()
    {
        Parameter[] parameters = new Parameter[]
                 {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                 };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_openads_admob", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_openads_admob", parameters));
        }
    }
    public void ShowOpenFail()
    {
        Parameter[] parameters = new Parameter[]
                 {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                 };

        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_openads_fail", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_openads_fail", parameters));
        }
    }
    public void ShowOpenAds()
    {
        Parameter[] parameters = new Parameter[]
                 {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                 };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_openads", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_openads", parameters));
        }
    }
    public void ShowOpenAdsFirstOpen()
    {
        Parameter[] parameters = new Parameter[]
                 {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                 };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_openads_first_max", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_openads_first_max", parameters));
        }
    }
    #endregion

    #region Loading screen
    public void SelectAge(int age)
    {
        Parameter[] parameters = new Parameter[]
                 {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks),
                            new Parameter("age", age.ToString())
                 };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("select_age", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("select_age", parameters));
        }
    }

    public void ShowInterAdmob(bool isBeforeSelectAge)
    {
        Parameter[] parameters = new Parameter[]
                 {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks),
                            new Parameter("isbeforeselect",isBeforeSelectAge?"1":"0")
                 };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_show_inter_admob_time", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_show_inter_admob_time", parameters));
        }
    }

    public void InterAdmobLoadedTime(double time)
    {
        Debug.Log("Time inter admobloaded:" + time);
        Parameter[] parameters = new Parameter[]
                 {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks),
                            new Parameter("time",time)
                 };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_inter_admob_loaded", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_inter_admob_loaded", parameters));
        }
    }
    #endregion

    public void UnlockByAds()
    {
        Parameter[] parameters = new Parameter[]
                 {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                 };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_reward_unlock_ads", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_reward_unlock_ads", parameters));
        }
    }

    public void BannerShow()
    {
        Parameter[] parameters = new Parameter[]
                {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_banner_show", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_banner_show", parameters));
        }
    }
    public void BannerCollapseShow()
    {
        Parameter[] parameters = new Parameter[]
                {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_banner_collapse_show", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_banner_collapse_show", parameters));
        }
    }
    public void MRECShow()
    {
        Parameter[] parameters = new Parameter[]
                {
                            new Parameter("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
                            new Parameter("timeStamp", DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks)
                };
        if (isInited)
        {
            FirebaseAnalytics.LogEvent("ad_mrec_show", parameters);
        }
        else
        {
            this.offlineLogs.Add(new OfflineLog("ad_mrec_show", parameters));
        }
    }
}
