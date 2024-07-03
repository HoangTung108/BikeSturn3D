using UnityEngine;
using UnityEngine.UI;

public class DScript : MonoBehaviour
{
	public GameObject RankObject;

	public Text DTextObject;

	private void Start()
	{
	}

	private void Update()
	{
		if (RankObject.activeInHierarchy)
		{
			DTextObject.text = "RankObjectActive";
		}
		else
		{
			DTextObject.text = "RankObjectDisable";
		}
	}
}
