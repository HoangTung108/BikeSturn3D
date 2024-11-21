using System.Collections;
using UnityEngine;

public class SplashScript : MonoBehaviour
{
	public GameObject Splashobj;

	public GameObject SplashoSmallbj;

	public static StorageData  BikeTwo;

	public static  StorageData  BikeThree;
	
	public static  StorageData  BikeFour;
	
	public static  StorageData  BikeFive;
	
	public static  StorageData  BikeSix;
	
	public static  StorageData  BikeSeven;

	public static  StorageData  BikeEight;

	public static StorageData BikeNine;

	public static StorageData BikeTen;

	public static StorageData BikeEleven;


	public static StorageData FUnlocked_level2;

	public static StorageData FUnlocked_level3;

	public static StorageData FUnlocked_level4;

	public static StorageData FUnlocked_level5;

	public static StorageData FUnlocked_level6;

	public static StorageData FUnlocked_level7;

	public static StorageData FUnlocked_level8;

	public static StorageData FUnlocked_level9;

	public static StorageData FUnlocked_level10;

	public static StorageData FUnlocked_level11;

	public static StorageData FUnlocked_level12;

	public static StorageData FUnlocked_level13;

	public static StorageData FUnlocked_level14;
	
	public static StorageData FUnlocked_level15;

	public static StorageData FUnlocked_level16;

	public static StorageData FUnlocked_level17;

	public static StorageData FUnlocked_level18;

	public static StorageData FUnlocked_level19;

	public static StorageData FUnlocked_level20;

	public static StorageData TUnlocked_level2;

	public static StorageData TUnlocked_level3;

	public static StorageData TUnlocked_level4;

	public static StorageData TUnlocked_level5;

	public static StorageData TUnlocked_level6;

	public static StorageData TUnlocked_level7;

	public static StorageData TUnlocked_level8;

	public static StorageData TUnlocked_level9;

	public static StorageData TUnlocked_level10;

	public static StorageData TUnlocked_level11;

	public static StorageData TUnlocked_level12;

	public static StorageData TUnlocked_level13;

	public static StorageData TUnlocked_level14;
	
	public static StorageData TUnlocked_level15;

	public static StorageData TUnlocked_level16;

	public static StorageData TUnlocked_level17;

	public static StorageData TUnlocked_level18;

	public static StorageData TUnlocked_level19;

	public static StorageData TUnlocked_level20;

	public static string dataFirst;

	public static StreamData db_value;

	public static string DataLoad;

	[RuntimeInitializeOnLoadMethod]
	static void CreateData()
	{
#if UNITY_EDITOR
		PlayerPrefs.DeleteAll();
#endif
		PlayerPrefs.SetInt("bike_1", 1);
        if(PlayerPrefs.GetInt("bike_2") == null) PlayerPrefs.SetInt("bike_2", 0);
		for(int i =2; i <21; i++)
		{
			if (PlayerPrefs.GetInt("FUnlockedLevel" +i) == null)
			{
				PlayerPrefs.SetInt("FUnlockedLevel" +i, 0);
			}
			if (PlayerPrefs.GetInt("TUnlockedLevel" +i) == null)
			{
				PlayerPrefs.SetInt("TUnlockedLevel" +i, 0);
			}
			
		}
	
	}
	[RuntimeInitializeOnLoadMethod]
	static void LoadData()
	{
		
	}

	private void Awake()
	{
		StartCoroutine(Load());
	
	}

	private void Start()
	{
		// Handheld.StartActivityIndicator();
		//SplashoSmallbj.SetActive(false);
		//Splashobj.SetActive(true);
		
		//Invoke("MenuLoadCall", 1f);

	}

	private void MenuLoadCall()
	{
		//Application.LoadLevel(1);
	}

	private IEnumerator Load()
	{
		// Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
		// Handheld.StartActivityIndicator();
		yield return new WaitForSeconds(0f);
		
	}
}
