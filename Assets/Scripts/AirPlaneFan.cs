using UnityEngine;

public class AirPlaneFan : MonoBehaviour
{
	public float speed;

	private void Start()
	{
	}

	private void Update()
	{
		base.transform.Rotate(0f, speed * Time.deltaTime, 0f, Space.Self);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.gameObject.transform.up * 40f, ForceMode.VelocityChange);
		}
	}
}
