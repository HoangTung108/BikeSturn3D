using UnityEngine;

public class DelayFalseObj : MonoBehaviour
{
	private void OnEnable()
	{
		Invoke("DialogueCall", 2.3f);
	}

	public void DialogueCall()
	{
		base.gameObject.SetActive(false);
	}

	private void OnDisable()
	{
		if (IsInvoking("DialogueCall"))
		{
			CancelInvoke("DialogueCall");
		}
	}
}
