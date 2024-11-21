using UnityEngine;

public class TrainPanelDisable : MonoBehaviour
{
	private void OnEnable()
	{
		Invoke("ObjecDisable", 2f);
	}

	private void ObjecDisable()
	{
		base.gameObject.SetActive(false);
	}

	private void OnDisable()
	{
		if (IsInvoking("ObjecDisable"))
		{
			CancelInvoke("ObjecDisable");
		}
	}
}
