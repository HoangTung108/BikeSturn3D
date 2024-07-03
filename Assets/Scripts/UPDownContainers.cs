using UnityEngine;

public class UPDownContainers : MonoBehaviour
{
	public int Speed;

	public int Degree;

	private float xPos;

	private float yPos;

	private float zPos;

	private void Start()
	{
		xPos = base.transform.position.x;
		yPos = base.transform.position.y;
		zPos = base.transform.position.z;
	}

	private void Update()
	{
		base.transform.position = new Vector3(xPos, yPos + Mathf.Sin(Time.time * (float)Speed) * (float)Degree, zPos);
	}
}
