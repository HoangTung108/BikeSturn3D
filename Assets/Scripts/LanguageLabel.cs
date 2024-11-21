using UnityEngine;
using UnityEngine.UI;

public class LanguageLabel : MonoBehaviour
{
	public string EnglishText;

	public string ChineseText;

	public string FrenchText;

	public string GermanText;

	public string SpainishText;

	public string IndianText;

	private void Update()
	{
		if (PlayerPrefs.GetInt("LanguageSet") == 0)
		{
		
			base.gameObject.GetComponent<Text>().text = EnglishText;
		}
		else if (PlayerPrefs.GetInt("LanguageSet") == 1)
		{
			base.gameObject.GetComponent<Text>().text = ChineseText;
		}
		else if (PlayerPrefs.GetInt("LanguageSet") == 2)
		{
			base.gameObject.GetComponent<Text>().text = FrenchText;
		}
		else if (PlayerPrefs.GetInt("LanguageSet") == 3)
		{
			base.gameObject.GetComponent<Text>().text = GermanText;
		}
		else if (PlayerPrefs.GetInt("LanguageSet") == 4)
		{
			base.gameObject.GetComponent<Text>().text = SpainishText;
		}
		else if (PlayerPrefs.GetInt("LanguageSet") == 5)
		{
			base.gameObject.GetComponent<Text>().text = IndianText;
		}
		else
		{
			base.gameObject.GetComponent<Text>().text = EnglishText;
		}
	}
}
