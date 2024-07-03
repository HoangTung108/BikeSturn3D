using UnityEngine;

public class ParcahuteScaleAdjust : MonoBehaviour
{
	private float TargetScale;

	private void Start()
	{
	}

	private void Update()
	{
		if (TargetScale < 1.2f)
		{
			TargetScale += Time.deltaTime * 0.6f;
			base.transform.localScale = new Vector3(TargetScale, TargetScale, TargetScale);
		}
		else
		{
			base.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
		}
	}
}
