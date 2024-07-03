using UnityEngine;

public class MenuTut : MonoBehaviour
{
	public Animator PlayAnimBtn;

	private void OnEnable()
	{
		if (PlayerPrefs.GetInt("MenuTutDB") == 0)
		{
			PlayAnimBtn.enabled = true;
			return;
		}
		base.transform.localScale = new Vector3(1f, 1f, 1f);
		PlayAnimBtn.enabled = false;
	}
}
