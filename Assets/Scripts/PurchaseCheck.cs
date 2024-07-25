using UnityEngine;

public class PurchaseCheck : MonoBehaviour
{
	public GameObject DoubleCoinsPurchaseObj;

	public GameObject NoAdsPurchaseObj;

	public GameObject UnlockAllLevelsPurchaseObj;

	public GameObject UnlockAllBikesPurchaseObj;

	public GameObject StoreObj;

	public GameObject StoreNotAvailbleObj;

	public GameObject UnlockAllBikesMenuBTn;

	public GameObject UnlockAllLevelsMenuBTn;

	private void Start()
	{
		if (Application.internetReachability != 0)
		{
			Debug.Log("Internet Available");
			StoreObj.SetActive(true);
		
			StoreNotAvailbleObj.SetActive(false);
			if (PlayerPrefs.GetInt("NoAdsPurchase") == 1)
			{
				NoAdsPurchaseObj.SetActive(true);
			}
			else
			{
				NoAdsPurchaseObj.SetActive(false);
			}
			if (PlayerPrefs.GetInt("DoubleCoinsPurcahsed") == 1)
			{
				DoubleCoinsPurchaseObj.SetActive(true);
			}
			else
			{
				DoubleCoinsPurchaseObj.SetActive(false);
			}
			if (PlayerPrefs.GetInt("UnlockALLLevelsDB") == 1)
			{
				UnlockAllLevelsPurchaseObj.SetActive(true);
			}
			else
			{
				UnlockAllLevelsPurchaseObj.SetActive(false);
			}
			if (PlayerPrefs.GetInt("BikeTwoPurcahsed") == 1 && PlayerPrefs.GetInt("BikeThreePurcahsed") == 1 && PlayerPrefs.GetInt("BikeFourPurcahsed") == 1 && PlayerPrefs.GetInt("BikeFivePurcahsed") == 1 && PlayerPrefs.GetInt("BikeSixPurcahsed") == 1 && PlayerPrefs.GetInt("BikeSevenPurcahsed") == 1 && PlayerPrefs.GetInt("BikeEightPurcahsed") == 1 && PlayerPrefs.GetInt("BikeNinePurcahsed") == 1 && PlayerPrefs.GetInt("BikeTenPurcahsed") == 1 && PlayerPrefs.GetInt("BikeElevenPurcahsed") == 1)
			{
				UnlockAllBikesPurchaseObj.SetActive(true);
			}
			else
			{
				UnlockAllBikesPurchaseObj.SetActive(false);
			}
		
		}
		else
		{
		
			StoreNotAvailbleObj.SetActive(true);
			StoreObj.SetActive(false);
		
		}
	}

	private void Update()
	{
		if (PlayerPrefs.GetInt("BikeTwoPurcahsed") == 1 && PlayerPrefs.GetInt("BikeThreePurcahsed") == 1 && PlayerPrefs.GetInt("BikeFourPurcahsed") == 1 && PlayerPrefs.GetInt("BikeFivePurcahsed") == 1 && PlayerPrefs.GetInt("BikeSixPurcahsed") == 1 && PlayerPrefs.GetInt("BikeSevenPurcahsed") == 1 && PlayerPrefs.GetInt("BikeEightPurcahsed") == 1 && PlayerPrefs.GetInt("BikeNinePurcahsed") == 1 && PlayerPrefs.GetInt("BikeTenPurcahsed") == 1 && PlayerPrefs.GetInt("BikeElevenPurcahsed") == 1)
		{
			UnlockAllBikesMenuBTn.SetActive(false);
		}
		else
		{
			UnlockAllBikesMenuBTn.SetActive(true);
		}
		if (PlayerPrefs.GetInt("UnlockALLLevelsDB") == 1)
		{
			UnlockAllLevelsMenuBTn.SetActive(false);
		}
		else
		{
			UnlockAllLevelsMenuBTn.SetActive(true);
		}
	}
}
