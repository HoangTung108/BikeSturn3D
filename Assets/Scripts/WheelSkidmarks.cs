using UnityEngine;

public class WheelSkidmarks : MonoBehaviour
{
	public GameObject skidCaller;

	public float startSlipValue = 0.4f;

	private Skidmarks skidmarks;

	private int lastSkidmark = -1;

	private WheelCollider wheel_col;

	private void Start()
	{
		skidCaller = base.transform.root.gameObject;
		wheel_col = GetComponent<WheelCollider>();
		if ((bool)Object.FindObjectOfType(typeof(Skidmarks)))
		{
			skidmarks = Object.FindObjectOfType(typeof(Skidmarks)) as Skidmarks;
		}
		else
		{
			Debug.Log("No skidmarks object found. Skidmarks will not be drawn");
		}
	}

	private void FixedUpdate()
	{
		WheelHit hit;
		wheel_col.GetGroundHit(out hit);
		float num = Mathf.Abs(hit.sidewaysSlip);
		if (num > startSlipValue)
		{
			Vector3 pos = hit.point + 2f * skidCaller.GetComponent<Rigidbody>().velocity * Time.deltaTime;
			lastSkidmark = skidmarks.AddSkidMark(pos, hit.normal, num / 2f, lastSkidmark);
		}
		else
		{
			lastSkidmark = -1;
		}
	}
}
