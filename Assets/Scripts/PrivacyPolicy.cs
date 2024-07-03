using UnityEngine;

public class PrivacyPolicy : MonoBehaviour
{
	public GameObject privacyPolicyDialogue;

	private void Start()
	{
		if (PlayerPrefs.GetInt("PolicyCheckDB") == 1)
		{
			privacyPolicyDialogue.SetActive(false);
		}
		else
		{
			privacyPolicyDialogue.SetActive(true);
		}
	}

	public void AgreeBtnClicked()
	{
		privacyPolicyDialogue.SetActive(false);
		PlayerPrefs.SetInt("PolicyCheckDB", 1);
	}

	public void ShowPrivacyClicked()
	{
		Application.OpenURL("http://monstergamesproductions.com.au/PrivacyPolicy.html");
	}
}
