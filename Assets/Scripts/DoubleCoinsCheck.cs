using UnityEngine;

public class DoubleCoinsCheck : MonoBehaviour
{
	private void OnEnable()
	{
		if (Application.internetReachability != 0)
		{
			if (PlayerPrefs.GetInt("DoubleCoinsPurcahsed") == 1)
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
