using UnityEngine;

public class SrverCreateSettings : MonoBehaviour
{
	public GameObject SrverPopUPPanel;

	public GameObject SrverEmptyPopUPPanel;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void CreateBtn_Click()
	{
		SrverPopUPPanel.SetActive(true);
	}

	public void CancelBtn_Click()
	{
		SrverPopUPPanel.SetActive(false);
	}

	public void okBtn_Click()
	{
		SrverEmptyPopUPPanel.SetActive(false);
	}
}
