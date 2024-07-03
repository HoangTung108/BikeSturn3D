using UnityEngine;

public class RandomSkyScript : MonoBehaviour
{
	public Material SkyboxObj1;

	public Material SkyboxObj2;

	public Material SkyboxObj3;

	public Material SkyboxObj4;

	public int counter;

	private void Start()
	{
		counter = Random.Range(0, 5);
		if (counter == 0)
		{
			RenderSettings.skybox = SkyboxObj1;
		}
		else if (counter == 1)
		{
			RenderSettings.skybox = SkyboxObj1;
		}
		else if (counter == 2)
		{
			RenderSettings.skybox = SkyboxObj2;
		}
		else if (counter == 3)
		{
			RenderSettings.skybox = SkyboxObj3;
		}
		else if (counter == 4)
		{
			RenderSettings.skybox = SkyboxObj4;
		}
		else
		{
			RenderSettings.skybox = SkyboxObj3;
		}
	}
}
