using UnityEngine;

public class SelectTut : MonoBehaviour
{
	public Animator PlayAnimBtn;

	private void OnEnable()
	{
		if (PlayerPrefs.GetInt("SelTutDB") == 0)
		{
			PlayAnimBtn.enabled = true;
			return;
		}
		base.transform.localScale = new Vector3(1f, 1f, 1f);
		PlayAnimBtn.enabled = false;
	}
}