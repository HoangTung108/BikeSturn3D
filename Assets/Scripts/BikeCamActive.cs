using UnityEngine;

public class BikeCamActive : MonoBehaviour
{
	private void Start()
	{
		Invoke("DelayActive", 2f);
	}

	private void DelayActive()
	{
	}
}
