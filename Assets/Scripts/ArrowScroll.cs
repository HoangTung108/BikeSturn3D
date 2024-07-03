using UnityEngine;

public class ArrowScroll : MonoBehaviour
{
	public float horizontalScrollSpeed = 0.25f;

	public float verticalScrollSpeed = 0.25f;

	private bool scroll = true;

	public void FixedUpdate()
	{
		if (scroll)
		{
			float y = Time.time * verticalScrollSpeed;
			float x = Time.time * horizontalScrollSpeed;
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2(x, y);
		}
	}

	public void DoActivateTrigger()
	{
		scroll = !scroll;
	}
}
