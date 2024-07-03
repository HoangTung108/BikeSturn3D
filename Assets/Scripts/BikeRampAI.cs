using UnityEngine;

public class BikeRampAI : MonoBehaviour
{
	public bool rampStop;

	private void OnEnable()
	{
		rampStop = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "rampstop")
		{
			rampStop = true;
			Debug.Log("Stop Trigger");
		}
	}
}
