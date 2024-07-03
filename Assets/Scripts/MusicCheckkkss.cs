using UnityEngine;

public class MusicCheckkkss : MonoBehaviour
{
	private void OnEnable()
	{
		if (PlayerPrefs.GetString("Music Status") == "False")
		{
			base.gameObject.SetActive(false);
		}
	}

	private void LateUpdate()
	{
		if (PlayerPrefs.GetString("Music Status") == "False")
		{
			base.gameObject.SetActive(false);
		}
	}
}
