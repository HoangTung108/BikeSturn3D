using UnityEngine;

public class WheelRotation : MonoBehaviour
{
	public float speed;

	private void Start()
	{
	}

	private void Update()
	{
		base.transform.Rotate(Vector3.right * speed * Time.deltaTime);
	}
}
