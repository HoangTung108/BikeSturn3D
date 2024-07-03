using UnityEngine;

public class HammerPingPong : MonoBehaviour
{
	public bool HammerRightBool;

	public bool HammerLeftBool;

	public float speed;

	private void Start()
	{
	}

	private void Update()
	{
		if (HammerRightBool)
		{
			base.transform.Rotate(Vector3.up * speed * Time.deltaTime);
			Invoke("LeftCall", 2f);
		}
		else if (HammerLeftBool)
		{
			base.transform.Rotate(Vector3.down * speed * Time.deltaTime);
			Invoke("RightCall", 2f);
		}
	}

	private void RightCall()
	{
		HammerRightBool = true;
		HammerLeftBool = false;
	}

	private void LeftCall()
	{
		HammerLeftBool = true;
		HammerRightBool = false;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			if (HammerRightBool)
			{
				collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.gameObject.transform.up * 25f, ForceMode.VelocityChange);
			}
			else if (HammerLeftBool)
			{
				collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.gameObject.transform.right * 25f, ForceMode.VelocityChange);
			}
		}
	}
}
