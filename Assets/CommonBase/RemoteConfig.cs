using Firebase;
using Firebase.Extensions;
using Firebase.RemoteConfig;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Trip;
using UnityEngine.SceneManagement;

public class RemoteConfig : Trip.Singleton<RemoteConfig>
{
	public Dictionary<string, object> gameConfig = new Dictionary<string, object>();

    private void Start()
    {
        InitializeFirebase();
        StartCoroutine(AddLocaPush());
    }
    public override void Init()
    {
		
	}
   
	IEnumerator AddLocaPush()
	{
		yield return new WaitForSeconds(10);
		//Notifications.CancelAllPendingLocalNotifications();

		//CreateLocalPush("Dress Up Game", "Come and play game.", 1);
		//CreateLocalPush("Dress Up Game", "Come on. I want to go to party!", 3);
		//CreateLocalPush("Dress Up Game", "My dress is old. I need go to shopping", 5);
		//CreateLocalPush("Dress Up Game", "It's time to relax!", 7);
		//CreateLocalPush("Dress Up Game", "Dress Up missing you. Play game now", 15);
		//CreateLocalPush("Dress Up Game", "Dress Up missing you. Play game now", 30);
	}
	void CreateLocalPush(string title, string body, int day)
	{
		//NotificationContent content = new NotificationContent();
		//content.title = title;
		//content.body = body;

		//DateTime dateTime = DateTime.Now.AddDays(day);
		//Notifications.ScheduleLocalNotification(dateTime, content);
	}
	private void InitializeFirebase()
    {
		gameConfig.Add("InterstitialAdDuration", GameConfig.InterstitialAdDuration);
		gameConfig.Add("InterstitialAdDurationSomeTime", GameConfig.InterstitialAdDurationSomeTime);
		gameConfig.Add("InterstitialAdDurationInGame", GameConfig.InterstitialAdDurationInGame);
        gameConfig.Add("InterstitialShowInGame", GameConfig.InterstitialShowInGame);
        gameConfig.Add("ShowOpenAdsFirstOpen", GameConfig.ShowOpenAdsFirstOpen);
        gameConfig.Add("ShowBanner", GameConfig.ShowBanner);
        gameConfig.Add("InReview", GameConfig.InReview);
        gameConfig.Add("UseCollapseBanner", GameConfig.UseCollapseBanner);
        gameConfig.Add("ShowOpenAdsInterClose", GameConfig.ShowOpenAdsInterClose);
        FirebaseRemoteConfig.DefaultInstance.SetDefaultsAsync(gameConfig).ContinueWithOnMainThread(task => {
			FetchDataAsync();
		});
	}
	public Task FetchDataAsync()
	{
		Debug.Log("Fetching data...");
		System.Threading.Tasks.Task fetchTask =
        FirebaseRemoteConfig.DefaultInstance.FetchAsync(
			TimeSpan.Zero);
		return fetchTask.ContinueWithOnMainThread(FetchComplete);
	}
	private void FetchComplete(Task fetchTask)
	{
		if (fetchTask.IsCanceled)
		{
			Debug.Log("Fetch canceled.");
		}
		else if (fetchTask.IsFaulted)
		{
			Debug.Log("Fetch encountered an error.");
		}
		else if (fetchTask.IsCompleted)
		{
			Debug.Log("Fetch completed successfully!");
		}

		var info = FirebaseRemoteConfig.DefaultInstance.Info;
		switch (info.LastFetchStatus)
		{
			case LastFetchStatus.Success:
                FirebaseRemoteConfig.DefaultInstance.ActivateAsync()
				.ContinueWithOnMainThread(task => {
					Debug.Log(String.Format("Remote data loaded and ready (last fetch time {0}).",
								   info.FetchTime));
					SetAllKeys();
				});
				break;
			case LastFetchStatus.Failure:
				switch (info.LastFetchFailureReason)
				{
					case Firebase.RemoteConfig.FetchFailureReason.Error:
						Debug.Log("Fetch failed for unknown reason");
						break;
					case Firebase.RemoteConfig.FetchFailureReason.Throttled:
						Debug.Log("Fetch throttled until " + info.ThrottledEndTime);
						break;
				}
				break;
			case Firebase.RemoteConfig.LastFetchStatus.Pending:
				Debug.Log("Latest Fetch call still pending.");
				break;
		}
	}

	private void SetAllKeys()
    {
		GameConfig.InterstitialAdDuration = (int)FirebaseRemoteConfig.DefaultInstance.GetValue("InterstitialAdDuration").LongValue;
		GameConfig.InterstitialAdDurationSomeTime = (int)FirebaseRemoteConfig.DefaultInstance.GetValue("InterstitialAdDurationSomeTime").LongValue;
		GameConfig.InterstitialAdDurationInGame = (int)FirebaseRemoteConfig.DefaultInstance.GetValue("InterstitialAdDurationInGame").LongValue;
        GameConfig.InterstitialShowInGame = FirebaseRemoteConfig.DefaultInstance.GetValue("InterstitialShowInGame").BooleanValue;
        GameConfig.ShowOpenAdsFirstOpen = FirebaseRemoteConfig.DefaultInstance.GetValue("ShowOpenAdsFirstOpen").BooleanValue;
        GameConfig.ShowBanner = FirebaseRemoteConfig.DefaultInstance.GetValue("ShowBanner").BooleanValue;
        GameConfig.InReview = FirebaseRemoteConfig.DefaultInstance.GetValue("InReview").BooleanValue;
        GameConfig.UseCollapseBanner = FirebaseRemoteConfig.DefaultInstance.GetValue("UseCollapseBanner").BooleanValue;
        GameConfig.ShowOpenAdsInterClose = FirebaseRemoteConfig.DefaultInstance.GetValue("ShowOpenAdsInterClose").BooleanValue;

		Debug.Log("Complete remote :" + GameConfig.InReview);

		//AdsManager.Instance.InitAdsComponent();
	}
}
