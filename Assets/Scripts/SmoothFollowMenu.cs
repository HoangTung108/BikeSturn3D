using UnityEngine;

public class SmoothFollowMenu : MonoBehaviour
{
	public Transform target;

	[SerializeField]
	public float distance = 10f;

	[SerializeField]
	public float height = 5f;

	public float rotationDamping;

	public float heightDamping;

	private float wantedRotationAngle;

	private float wantedHeight;


	private void Start()
	{
	}

	private void FixedUpdate()
	{
		wantedRotationAngle = target.eulerAngles.y;
		wantedHeight = target.position.y + height;
	}

	private void LateUpdate()
	{
		if ((bool)target)
		{
			float y = base.transform.eulerAngles.y;
			float y2 = base.transform.position.y;
			y = Mathf.LerpAngle(y, wantedRotationAngle, rotationDamping * Time.deltaTime);
			y2 = Mathf.Lerp(y2, wantedHeight, heightDamping * Time.deltaTime);
			Quaternion quaternion = Quaternion.Euler(0f, y, 0f);
			base.transform.position = target.position;
			base.transform.position -= quaternion * Vector3.forward * distance;
			base.transform.position = new Vector3(base.transform.position.x, y2, base.transform.position.z);
			base.transform.LookAt(target);
		
		}
	}
}
