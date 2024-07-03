using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Image))]
public class ForcedReset : MonoBehaviour
{
	private void Update()
	{
		if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
		{
			Application.LoadLevelAsync(Application.loadedLevelName);
		}
	}
}
