using UnityEngine;

public class PauseSoundScript : MonoBehaviour
{
	public GameObject SondOffBtn;

	public GameObject SondONBtn;

	public GameObject MUSICOffBtn;

	public GameObject MUSICONBtn;

	private void Start()
	{
	}

	private void Update()
	{
		if (PlayerPrefs.GetString("Sound Status") == "False")
		{
			SondOffBtn.SetActive(true);
			SondONBtn.SetActive(false);
			PlayerPrefs.SetString("Sound Status", "False");
			PlayerPrefs.Save();
		}
		else
		{
			SondOffBtn.SetActive(false);
			SondONBtn.SetActive(true);
			PlayerPrefs.SetString("Sound Status", "True");
			PlayerPrefs.Save();
		}
		if (PlayerPrefs.GetString("Music Status") == "False")
		{
			MUSICOffBtn.SetActive(true);
			MUSICONBtn.SetActive(false);
			PlayerPrefs.SetString("Music Status", "False");
			PlayerPrefs.Save();
		}
		else
		{
			MUSICOffBtn.SetActive(false);
			MUSICONBtn.SetActive(true);
			PlayerPrefs.SetString("Music Status", "True");
			PlayerPrefs.Save();
		}
	}

	public void SoundBtn_Click()
	{
		if (PlayerPrefs.GetString("Sound Status") == "False")
		{
			SondOffBtn.SetActive(true);
			SondONBtn.SetActive(false);
			PlayerPrefs.SetString("Sound Status", "True");
			PlayerPrefs.Save();
		}
		else if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			SondOffBtn.SetActive(false);
			SondONBtn.SetActive(true);
			PlayerPrefs.SetString("Sound Status", "False");
			PlayerPrefs.Save();
		}
	}

	public void MusicBtn_Click()
	{
		if (PlayerPrefs.GetString("Music Status") == "False")
		{
			MUSICOffBtn.SetActive(true);
			MUSICONBtn.SetActive(false);
			PlayerPrefs.SetString("Music Status", "True");
			PlayerPrefs.Save();
		}
		else if (PlayerPrefs.GetString("Music Status") == "True")
		{
			MUSICOffBtn.SetActive(false);
			MUSICONBtn.SetActive(true);
			PlayerPrefs.SetString("Music Status", "False");
			PlayerPrefs.Save();
		}
	}
}
