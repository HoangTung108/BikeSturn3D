using UnityEngine;

public class SoundCheckkkss : MonoBehaviour
{
	private void OnEnable()
	{
		if (PlayerPrefs.GetString("Sound Status") == "False")
		{
			base.gameObject.SetActive(false);
		}
	}

	private void LateUpdate()
	{
		if (PlayerPrefs.GetString("Sound Status") == "False")
		{
			base.gameObject.SetActive(false);
		}
	}
}
