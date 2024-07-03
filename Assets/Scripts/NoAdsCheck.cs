using UnityEngine;

public class NoAdsCheck : MonoBehaviour
{
	private void OnEnable()
	{
		if (Application.internetReachability != 0)
		{
			if (PlayerPrefs.GetInt("NoAdsPurchase") == 1)
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
