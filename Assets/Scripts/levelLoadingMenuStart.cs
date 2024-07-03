using UnityEngine;
using UnityEngine.UI;

public class levelLoadingMenuStart : MonoBehaviour
{
	public Text loadingTxt;

	private int n;

	private void a()
	{
		n++;
		switch (n)
		{
		case 3:
			loadingTxt.text = "Loading . .  ";
			break;
		case 6:
			loadingTxt.text = "Loading . . .";
			break;
		case 9:
			loadingTxt.text = "Loading .    ";
			n = 0;
			break;
		}
	}

	private void OnEnable()
	{
		InvokeRepeating("a", 0f, 0.07f);
	}
}
