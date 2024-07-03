using UnityEngine;

public class ToggleBehaviourByTrigger : MonoBehaviour
{
	public Behaviour UIElement;

	private void OnTriggerEnter()
	{
		if ((bool)UIElement)
		{
			UIElement.enabled = !UIElement.enabled;
		}
	}
}
