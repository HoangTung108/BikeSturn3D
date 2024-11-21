using UnityEngine;
using System;


public class LevelLockCheck : MonoBehaviour
{
	public GameObject FLockLevel2;

	public GameObject FLockLevel3;

	public GameObject FLockLevel4;

	public GameObject FLockLevel5;

	public GameObject FLockLevel6;

	public GameObject FLockLevel7;

	public GameObject FLockLevel8;

	public GameObject FLockLevel9;

	public GameObject FLockLevel10;

	public GameObject FLockLevel11;

	public GameObject FLockLevel12;

	public GameObject FLockLevel13;

	public GameObject FLockLevel14;

	public GameObject FLockLevel15;

	public GameObject FLockLevel16;

	public GameObject FLockLevel17;

	public GameObject FLockLevel18;

	public GameObject FLockLevel19;

	public GameObject FLockLevel20;

	public GameObject TLockLevel2;

	public GameObject TLockLevel3;

	public GameObject TLockLevel4;

	public GameObject TLockLevel5;

	public GameObject TLockLevel6;

	public GameObject TLockLevel7;

	public GameObject TLockLevel8;

	public GameObject TLockLevel9;

	public GameObject TLockLevel10;

	public GameObject TLockLevel11;

	public GameObject TLockLevel12;

	public GameObject TLockLevel13;

	public GameObject TLockLevel14;

	public GameObject TLockLevel15;

	public GameObject TLockLevel16;

	public GameObject TLockLevel17;

	public GameObject TLockLevel18;

	public GameObject TLockLevel19;

	public GameObject TLockLevel20;


	private void Update()
	{
		
		if (PlayerPrefs.GetInt("ModeDB") == 0)
		{
			if (PlayerPrefs.GetInt("FUnlockedLevel2") == 1)
			{
				FLockLevel2.SetActive(false);
			}
			else
			{
				FLockLevel2.SetActive(true);
			}
			if (PlayerPrefs.GetInt("FUnlockedLevel3") == 1)
			{
				FLockLevel3.SetActive(false);
			}
			else
			{
				FLockLevel3.SetActive(true);
			}
			if (PlayerPrefs.GetInt("FUnlockedLevel4") == 1)
			{
				FLockLevel4.SetActive(false);
			}
			else
			{
				FLockLevel4.SetActive(true);
			}
			if (PlayerPrefs.GetInt("FUnlockedLevel5") == 1)
			{
				FLockLevel5.SetActive(false);
			}
			else
			{
				FLockLevel5.SetActive(true);
			}
			if (PlayerPrefs.GetInt("FUnlockedLevel6") == 1)
			{
				FLockLevel6.SetActive(false);
			}
			else
			{
				FLockLevel6.SetActive(true);
			}
			if (PlayerPrefs.GetInt("FUnlockedLevel7")== 1)
			{
				FLockLevel7.SetActive(false);
			}
			else
			{
				FLockLevel7.SetActive(true);
			}
			if (PlayerPrefs.GetInt("FUnlockedLevel8") == 1)
			{
				FLockLevel8.SetActive(false);
			}
			else
			{
				FLockLevel8.SetActive(true);
			}
			if (PlayerPrefs.GetInt("FUnlockedLevel9") == 1)
			{
				FLockLevel9.SetActive(false);
			}
			else
			{
				FLockLevel9.SetActive(true);
			}
			if (PlayerPrefs.GetInt("FUnlockedLevel10") == 1)
			{
				FLockLevel10.SetActive(false);
			}
			else
			{
				FLockLevel10.SetActive(true);
			}
			if (PlayerPrefs.GetInt("FUnlockedLevel11") == 1)
			{
				FLockLevel11.SetActive(false);
			}
			else
			{
				FLockLevel11.SetActive(true);
			}
			if (PlayerPrefs.GetInt("FUnlockedLevel12") == 1)
			{
				FLockLevel12.SetActive(false);
			}
			else
			{
				FLockLevel12.SetActive(true);
			}
			if (PlayerPrefs.GetInt("FUnlockedLevel13") == 1)
			{
				FLockLevel13.SetActive(false);
			}
			else
			{
				FLockLevel13.SetActive(true);
			}
			if (PlayerPrefs.GetInt("FUnlockedLevel14") == 1)
			{
				FLockLevel14.SetActive(false);
			}
			else
			{
				FLockLevel14.SetActive(true);
			}
			if( PlayerPrefs.GetInt("FUnlockedLevel15") == 1)
			{
				FLockLevel15.SetActive(false);
			}
			else
			{
				FLockLevel15.SetActive(true);
			}
			if (PlayerPrefs.GetInt("FUnlockedLevel16") == 1)
			{
				FLockLevel16.SetActive(false);
			}
			else
			{
				FLockLevel16.SetActive(true);
			}
			if (PlayerPrefs.GetInt("FUnlockedLevel17") == 1)
			{
				FLockLevel17.SetActive(false);
			}
			else
			{
				FLockLevel17.SetActive(true);
			}
			if (PlayerPrefs.GetInt("FUnlockedLevel18") == 1)
			{
				FLockLevel18.SetActive(false);
			}
			else
			{
				FLockLevel18.SetActive(true);
			}
			if (PlayerPrefs.GetInt("FUnlockedLevel19") == 1)
			{
				FLockLevel19.SetActive(false);
			}
			else
			{
				FLockLevel19.SetActive(true);
			}
			if (PlayerPrefs.GetInt("FUnlockedLevel20") == 1)
			{
				FLockLevel20.SetActive(false);
			}
			else
			{
				FLockLevel20.SetActive(true);
			}
		}
		else if (PlayerPrefs.GetInt("ModeDB") == 1)
		{
			if (PlayerPrefs.GetInt("TUnlockedLevel2")== 1)
			{
				TLockLevel2.SetActive(false);
			}
			else
			{
				TLockLevel2.SetActive(true);
			}
			if (PlayerPrefs.GetInt("TUnlockedLevel3") == 1)
			{
				TLockLevel3.SetActive(false);
			}
			else
			{
				TLockLevel3.SetActive(true);
			}
			if (PlayerPrefs.GetInt("TUnlockedLevel4") == 1)
			{
				TLockLevel4.SetActive(false);
			}
			else
			{
				TLockLevel4.SetActive(true);
			}
			if (PlayerPrefs.GetInt("TUnlockedLevel5") == 1)
			{
				TLockLevel5.SetActive(false);
			}
			else
			{
				TLockLevel5.SetActive(true);
			}
			if (PlayerPrefs.GetInt("TUnlockedLevel6") == 1)
			{
				TLockLevel6.SetActive(false);
			}
			else
			{
				TLockLevel6.SetActive(true);
			}
			if (PlayerPrefs.GetInt("TUnlockedLevel7") == 1)
			{
				TLockLevel7.SetActive(false);
			}
			else
			{
				TLockLevel7.SetActive(true);
			}
			if (PlayerPrefs.GetInt("TUnlockedLevel8") == 1)
			{
				TLockLevel8.SetActive(false);
			}
			else
			{
				TLockLevel8.SetActive(true);
			}
			if (PlayerPrefs.GetInt("TUnlockedLevel9") == 1)
			{
				TLockLevel9.SetActive(false);
			}
			else
			{
				TLockLevel9.SetActive(true);
			}
			if (PlayerPrefs.GetInt("TUnlockedLevel10")== 1)
			{
				TLockLevel10.SetActive(false);
			}
			else
			{
				TLockLevel10.SetActive(true);
			}
			if (PlayerPrefs.GetInt("TUnlockedLevel11") == 1)
			{
				TLockLevel11.SetActive(false);
			}
			else
			{
				TLockLevel11.SetActive(true);
			}
			if (PlayerPrefs.GetInt("TUnlockedLevel12") == 1)
			{
				TLockLevel12.SetActive(false);
			}
			else
			{
				TLockLevel12.SetActive(true);
			}
			if (PlayerPrefs.GetInt("TUnlockedLevel13") == 1)
			{
				TLockLevel13.SetActive(false);
			}
			else
			{
				TLockLevel13.SetActive(true);
			}
			if (PlayerPrefs.GetInt("TUnlockedLevel14") == 1)
			{
				TLockLevel14.SetActive(false);
			}
			else
			{
				TLockLevel14.SetActive(true);
			}
			if( PlayerPrefs.GetInt("TUnlockedLevel15") == 1)
			{
				TLockLevel15.SetActive(false);
			}
			else
			{
				TLockLevel15.SetActive(true);
			}
			if (PlayerPrefs.GetInt("TUnlockedLevel16")== 1)
			{
				TLockLevel16.SetActive(false);
			}
			else
			{
				TLockLevel16.SetActive(true);
			}
			if (PlayerPrefs.GetInt("TUnlockedLevel17") == 1)
			{
				TLockLevel17.SetActive(false);
			}
			else
			{
				TLockLevel17.SetActive(true);
			}
			if (PlayerPrefs.GetInt("TUnlockedLevel18") == 1)
			{
				TLockLevel18.SetActive(false);
			}
			else
			{
				TLockLevel18.SetActive(true);
			}
			if (PlayerPrefs.GetInt("TUnlockedLevel19") == 1)
			{
				TLockLevel19.SetActive(false);
			}
			else
			{
				TLockLevel19.SetActive(true);
			}
			if (PlayerPrefs.GetInt("TUnlockedLevel20") == 1)
			{
				TLockLevel20.SetActive(false);
			}
			else
			{
				TLockLevel20.SetActive(true);
			}
		}
	}
}
