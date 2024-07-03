using UnityEngine;

public class BikesPurchaseCheck : MonoBehaviour
{
	private void OnEnable()
	{
		if (Application.internetReachability != 0)
		{
			if (PlayerPrefs.GetInt("BikeTwoPurcahsed") == 1 && PlayerPrefs.GetInt("BikeThreePurcahsed") == 1 && PlayerPrefs.GetInt("BikeFourPurcahsed") == 1 && PlayerPrefs.GetInt("BikeFivePurcahsed") == 1 && PlayerPrefs.GetInt("BikeSixPurcahsed") == 1 && PlayerPrefs.GetInt("BikeSevenPurcahsed") == 1 && PlayerPrefs.GetInt("BikeEightPurcahsed") == 1 && PlayerPrefs.GetInt("BikeNinePurcahsed") == 1 && PlayerPrefs.GetInt("BikeTenPurcahsed") == 1 && PlayerPrefs.GetInt("BikeElevenPurcahsed") == 1)
			{
				base.gameObject.SetActive(false);
			}
			else
			{
				base.gameObject.SetActive(true);
			}
		}
		else
		{
			base.gameObject.SetActive(false);
		}
	}
}
