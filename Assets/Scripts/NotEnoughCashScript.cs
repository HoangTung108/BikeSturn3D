using UnityEngine;

public class NotEnoughCashScript : MonoBehaviour
{
	private void OnEnable()
	{
	}

	public void DialogueCall()
	{
		base.gameObject.SetActive(false);
	}
}
