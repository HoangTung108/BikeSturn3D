using UnityEngine;

public class SetShadowSettt : MonoBehaviour
{
	public Light DirectinlaLighttt;

	private void Awake()
	{
		if (DirectinlaLighttt == null)
		{
			DirectinlaLighttt = Object.FindObjectOfType<Light>();
		}
	}

	private void Start()
	{
		if (SystemInfo.systemMemorySize > 2000)
		{
			if (DirectinlaLighttt != null)
			{
				DirectinlaLighttt.shadows = LightShadows.Hard;
			}
			QualitySettings.SetQualityLevel(2);
		}
		else
		{
			if (DirectinlaLighttt != null)
			{
				DirectinlaLighttt.shadows = LightShadows.None;
			}
			QualitySettings.SetQualityLevel(0);
		}
	}
}
