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

	public static string datapath;

	public static StreamData db_value;

	[RuntimeInitializeOnLoadMethod]
	static void CreateData()
	{
		datapath = Application.persistentDataPath + "/GameSave/datasave.json";
		db_value = new StreamData();
		FUnlocked_level2 = new StorageData();
		FUnlocked_level3 = new StorageData();
		FUnlocked_level4 = new StorageData();
		FUnlocked_level5 = new StorageData();
		FUnlocked_level6 = new StorageData();
		FUnlocked_level7 = new StorageData();
		FUnlocked_level8 = new StorageData();
		FUnlocked_level9 = new StorageData();
		FUnlocked_level10 = new StorageData();
		FUnlocked_level11 = new StorageData();
		FUnlocked_level12 = new StorageData();
		FUnlocked_level13 = new StorageData();
		FUnlocked_level14 = new StorageData();
		FUnlocked_level15 = new StorageData();
		FUnlocked_level16 = new StorageData();
		FUnlocked_level17 = new StorageData();
		FUnlocked_level18 = new StorageData();
		FUnlocked_level19 = new StorageData();
		FUnlocked_level20 = new StorageData();
		TUnlocked_level2 = new StorageData();
		TUnlocked_level3 = new StorageData();
		TUnlocked_level4 = new StorageData();
		TUnlocked_level5 = new StorageData();
		TUnlocked_level6 = new StorageData();
		TUnlocked_level7 = new StorageData();
		TUnlocked_level8 = new StorageData();
		TUnlocked_level9 = new StorageData();
		TUnlocked_level10 = new StorageData();
		TUnlocked_level11 = new StorageData();
		TUnlocked_level12 = new StorageData();
		TUnlocked_level13 = new StorageData();
		TUnlocked_level14 = new StorageData();
		TUnlocked_level15 = new StorageData();
		TUnlocked_level16 = new StorageData();
		TUnlocked_level17 = new StorageData();
		TUnlocked_level18 = new StorageData();
		TUnlocked_level19 = new StorageData();
		TUnlocked_level20 = new StorageData();
		BikeTwo = new StorageData();
		BikeThree = new StorageData();
		BikeFour = new StorageData();
		BikeFive = new StorageData();
		BikeSix = new StorageData();
		BikeSeven = new StorageData();
		BikeEight = new StorageData();
		BikeNine = new StorageData();
		BikeTen = new StorageData();
		BikeEleven = new StorageData();
	}
	[RuntimeInitializeOnLoadMethod]
	static void LoadData()
	{
		string DataLoad = System.IO.File.ReadAllText(datapath);
		db_value = JsonUtility.FromJson<StreamData>(DataLoad);
		FUnlocked_level2 = db_value.DataVal[0];
		FUnlocked_level3 = db_value.DataVal[1];
		FUnlocked_level4 = db_value.DataVal[2];
		FUnlocked_level5 = db_value.DataVal[3];
		FUnlocked_level6 = db_value.DataVal[4];
		FUnlocked_level7 = db_value.DataVal[5];
		FUnlocked_level8 = db_value.DataVal[6];
		FUnlocked_level9 = db_value.DataVal[7];
		FUnlocked_level10 = db_value.DataVal[8];
		FUnlocked_level11 = db_value.DataVal[9];
		FUnlocked_level12 = db_value.DataVal[10];
		FUnlocked_level13 = db_value.DataVal[11];
		FUnlocked_level14 = db_value.DataVal[12];
		FUnlocked_level15 = db_value.DataVal[13];
		FUnlocked_level16 = db_value.DataVal[14];
		FUnlocked_level17 = db_value.DataVal[15];
		FUnlocked_level18 = db_value.DataVal[16];
		FUnlocked_level19 = db_value.DataVal[17];
		FUnlocked_level20 = db_value.DataVal[18];
		TUnlocked_level2 = db_value.DataTime[0];
		TUnlocked_level3 = db_value.DataTime[1];
		TUnlocked_level4 = db_value.DataTime[2];
		TUnlocked_level5 = db_value.DataTime[3];
		TUnlocked_level6 = db_value.DataTime[4];
		TUnlocked_level7 = db_value.DataTime[5];
		TUnlocked_level8 = db_value.DataTime[6];
		TUnlocked_level9 = db_value.DataTime[7];
		TUnlocked_level10 = db_value.DataTime[8];
		TUnlocked_level11 = db_value.DataTime[9];
		TUnlocked_level12 = db_value.DataTime[10];
		TUnlocked_level13 = db_value.DataTime[11];
		TUnlocked_level14 = db_value.DataTime[12];
		TUnlocked_level15 = db_value.DataTime[13];
		TUnlocked_level16 = db_value.DataTime[14];
		TUnlocked_level17 = db_value.DataTime[15];
		TUnlocked_level18 = db_value.DataTime[16];
		TUnlocked_level19 = db_value.DataTime[17];
		TUnlocked_level20 = db_value.DataTime[18];
		BikeTwo = db_value.BikeData[0];
		BikeThree = db_value.BikeData[1];
		BikeFour = db_value.BikeData[2];
		BikeFive = db_value.BikeData[3];
		BikeSix =db_value.BikeData[4];
		BikeSeven = db_value.BikeData[5];
		BikeEight = db_value.BikeData[6];
		BikeNine = db_value.BikeData[7];
		BikeTen = db_value.BikeData[8];
		BikeEleven = db_value.BikeData[9];
	}

	private void Awake()
	{
		StartCoroutine(Load());
	
	}

	private void Start()
	{
		// Handheld.StartActivityIndicator();
		SplashoSmallbj.SetActive(false);
		Splashobj.SetActive(true);
		
		Invoke("MenuLoadCall", 1f);

	}

	private void MenuLoadCall()
	{
		Application.LoadLevel(1);
	}

	private IEnumerator Load()
	{
		// Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
		// Handheld.StartActivityIndicator();
		yield return new WaitForSeconds(0f);
		
	}
}
