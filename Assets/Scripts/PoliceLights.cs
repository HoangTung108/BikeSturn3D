using UnityEngine;

public class PoliceLights : MonoBehaviour
{
	public bool activeLight = true;

	public float time = 20f;

	public AudioSource policeAudioSource;

	public AudioClip[] policeAudioClips;

	public Light[] RedLights;

	public Light[] BlueLights;

	private float timer;

	private int lightNum;

	private void Awake()
	{
		if (policeAudioClips.Length > 0)
		{
			policeAudioSource.clip = policeAudioClips[Random.Range(0, policeAudioClips.Length)];
			policeAudioSource.Play();
		}
	}

	private void Update()
	{
		if (!activeLight)
		{
			if (!policeAudioSource.mute)
			{
				policeAudioSource.clip = policeAudioClips[Random.Range(0, policeAudioClips.Length)];
				policeAudioSource.mute = true;
			}
			Light[] redLights = RedLights;
			foreach (Light light in redLights)
			{
				light.enabled = false;
			}
			Light[] blueLights = BlueLights;
			foreach (Light light2 in blueLights)
			{
				light2.enabled = false;
			}
			return;
		}
		timer = Mathf.MoveTowards(timer, 0f, Time.deltaTime * time);
		if (timer == 0f)
		{
			lightNum++;
			if (lightNum > 12)
			{
				lightNum = 1;
			}
			timer = 1f;
		}
		if ((bool)policeAudioSource)
		{
			policeAudioSource.mute = false;
			if (!policeAudioSource.isPlaying)
			{
				policeAudioSource.Play();
			}
		}
		if (lightNum == 1 || lightNum == 3)
		{
			Light[] redLights2 = RedLights;
			foreach (Light light3 in redLights2)
			{
				light3.enabled = true;
			}
			Light[] blueLights2 = BlueLights;
			foreach (Light light4 in blueLights2)
			{
				light4.enabled = false;
			}
		}
		if (lightNum == 5 || lightNum == 7)
		{
			Light[] blueLights3 = BlueLights;
			foreach (Light light5 in blueLights3)
			{
				light5.enabled = true;
			}
			Light[] redLights3 = RedLights;
			foreach (Light light6 in redLights3)
			{
				light6.enabled = false;
			}
		}
		if (lightNum == 2 || lightNum == 4 || lightNum == 6 || lightNum == 8)
		{
			Light[] blueLights4 = BlueLights;
			foreach (Light light7 in blueLights4)
			{
				light7.enabled = false;
			}
			Light[] redLights4 = RedLights;
			foreach (Light light8 in redLights4)
			{
				light8.enabled = false;
			}
		}
	}
}
