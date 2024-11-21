using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig
{
    public static int InterstitialAdDuration = 30;
    public static int InterstitialAdDurationSomeTime = 30;
    public static int InterstitialAdDurationInGame = 30;
    public static int RewardUnlock = 5;

    public static bool UseCollapseBanner = true;
    public static bool InterstitialShowInGame = true;
    public static bool ShowOpenAdsInterClose = true;
#if UNITY_ANDROID
    public static bool ShowOpenAdsFirstOpen = true;
#else
    public static bool ShowOpenAdsFirstOpen = false;
#endif

#if UNITY_ANDROID
    public static bool ShowBanner = true;
#else
    public static bool ShowBanner = false;
#endif

#if UNITY_ANDROID
    public static bool InReview = false;
#else
    public static bool InReview = false;
#endif
}
