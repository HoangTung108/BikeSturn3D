using UnityEngine;

public class NetBikeUIActive : MonoBehaviour
{
	public BikeUIControllerN BikeUIControllerNScript;

	private void Start()
	{
		Invoke("ScriptActivez", 2.5f);
	}

	private void ScriptActivez()
	{
		BikeUIControllerNScript.enabled = true;
	}
}
