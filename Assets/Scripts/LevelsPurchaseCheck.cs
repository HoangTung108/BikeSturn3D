using UnityEngine;

public class LevelsPurchaseCheck : MonoBehaviour
{
	private void OnEnable()
	{
		if (Application.internetReachability != 0)
		{
			if (PlayerPrefs.GetInt("UnlockALLLevelsDB") == 1 || PlayerPrefs.GetInt("UnlockTimeModeDB") ==1)
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
