using UnityEngine;

public class MultiPlyerStart : MonoBehaviour
{
	private void Start()
	{
		PlayerPrefs.SetInt("MultiPlyerGameDB", 1);
	}
}
