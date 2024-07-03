using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BikeRotate : MonoBehaviour
{
	public float rotateSpeed = 10f;

	public Text BikeNameUI;

	public Transform root;

	public GameObject[] bikes;

	private int currentBike;

	private Vector3 position;

	public void Right()
	{
		currentBike--;
		if (currentBike < 0)
		{
			currentBike = bikes.Length - 1;
		}
		ActiveCurrentBike(currentBike);
	}

	public void Left()
	{
		currentBike++;
		if (currentBike > bikes.Length - 1)
		{
			currentBike = 0;
		}
		ActiveCurrentBike(currentBike);
	}

	public void ActiveCurrentBike(int current)
	{
		int num = 0;
		float num2 = 0f;
		GameObject[] array = bikes;
		foreach (GameObject gameObject in array)
		{
			if (currentBike == num)
			{
				BikeNameUI.text = "Motorbike " + (currentBike + 1);
				IEnumerator enumerator = bikes[currentBike].transform.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Transform transform = (Transform)enumerator.Current;
						num2 += (float)transform.GetComponent<MeshFilter>().mesh.triangles.Length / 3f;
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = enumerator as IDisposable) != null)
					{
						disposable.Dispose();
					}
				}
			}
			else
			{
				bikes[num].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
			}
			num++;
		}
	}

	public void Start()
	{
		position = root.position;
	}

	private void Update()
	{
		bikes[currentBike].transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
		root.position = Vector3.Lerp(root.position, position + new Vector3(bikes[currentBike].transform.position.x, 0f, bikes[currentBike].transform.position.z), Time.deltaTime * 10f);
	}
}
