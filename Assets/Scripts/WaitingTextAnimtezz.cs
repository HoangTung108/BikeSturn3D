using UnityEngine;
using UnityEngine.UI;

public class WaitingTextAnimtezz : MonoBehaviour
{
	public Text WaitingTxt;

	private int n;

	private void a()
	{
		n++;
		switch (n)
		{
		case 3:
			WaitingTxt.text = "Waiting . .  ";
			break;
		case 6:
			WaitingTxt.text = "Waiting . . .";
			break;
		case 9:
			WaitingTxt.text = "Waiting .    ";
			n = 0;
			break;
		}
	}

	private void OnEnable()
	{
		InvokeRepeating("a", 0f, 0.07f);
	}
}
