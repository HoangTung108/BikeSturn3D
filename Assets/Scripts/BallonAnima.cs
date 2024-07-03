using UnityEngine;

public class BallonAnima : MonoBehaviour
{
	public Transform Target1;

	public Transform Target2;

	public float speed;

	private int counter;

	private void Start()
	{
		counter = 1;
	}

	private void Update()
	{
		if (counter == 1)
		{
			float maxDistanceDelta = speed * Time.deltaTime;
			base.transform.position = Vector3.MoveTowards(base.transform.position, Target1.position, maxDistanceDelta);
		}
		if (base.transform.position == Target1.position)
		{
			counter = 2;
		}
		if (counter == 2)
		{
			float maxDistanceDelta2 = speed * Time.deltaTime;
			base.transform.position = Vector3.MoveTowards(base.transform.position, Target2.position, maxDistanceDelta2);
		}
		if (base.transform.position == Target2.position)
		{
			counter = 1;
		}
	}
}
