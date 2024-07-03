using System;
using UnityEngine;

public class PlayservicesChecker : MonoBehaviour
{
	public GameObject AdsManagerGO;

	private bool serviceavlbl;

	public bool IsAppInstalled(string bundleID)
	{
		//AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		//AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		//AndroidJavaObject androidJavaObject = @static.Call<AndroidJavaObject>("getPackageManager", new object[0]);
		//Debug.Log(" ********LaunchOtherApp ");
		//AndroidJavaObject androidJavaObject2 = null;
		//try
		//{
		//	androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("getLaunchIntentForPackage", new object[1] { bundleID });
		//}
		//catch (Exception ex)
		//{
		//	Debug.Log("exception" + ex.Message);
		//}
		//if (androidJavaObject2 == null)
		//{
		//	return false;
		//}
		return true;
	}

	private void Awake()
	{
		serviceavlbl = IsAppInstalled("com.android.vending");
	}

	private void Start()
	{
		if (serviceavlbl)
		{
			AdsManagerGO.SetActive(true);
		}
		else
		{
			AdsManagerGO.SetActive(false);
		}
	}
}
