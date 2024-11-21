using UnityEngine;

public class LandSquare : MonoBehaviour
{
	public GameObject SquareObect;

	private bool squareBool = true;

	private void Start()
	{
		SquareObect = GameObject.Find("Sphere");
	}

	private void Update()
	{
		if (squareBool)
		{
			SquareObect.SetActive(true);
			Invoke("Object_DisableCall", 0.5f);
		}
		else
		{
			SquareObect.SetActive(false);
			Invoke("Object_EnableCall", 0.5f);
		}
	}

	private void Object_EnableCall()
	{
		squareBool = true;
	}

	private void Object_DisableCall()
	{
		squareBool = false;
	}

	private void OnDisable()
	{
		if (IsInvoking("Object_DisableCall"))
		{
			CancelInvoke("Object_DisableCall");
		}
		if (IsInvoking("Object_EnableCall"))
		{
			CancelInvoke("Object_EnableCall");
		}
	}
}
