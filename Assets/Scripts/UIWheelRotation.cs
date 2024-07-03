using UnityEngine;

public class UIWheelRotation : MonoBehaviour
{
	public float speed;

	private void Start()
	{
	}

	private void Update()
	{
		base.transform.Rotate(0f, 0f, speed * Time.deltaTime);
	}
}
