using UnityEngine;

public class CamLookAtScript : MonoBehaviour
{
	private Transform target;

	public Transform Bike1;

	public Transform Bike2;

	public Transform Bike3;

	public Transform Bike4;

	public Transform Bike5;

	public Transform Bike6;

	public Transform Bike7;

	public Transform Bike8;

	public Transform Bike9;

	public Transform Bike10;

	public Transform Bike11;

	private void OnEnable()
	{
		if (PlayerPrefs.GetInt("BikeSelDB") == 1)
		{
			target = Bike1;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 2)
		{
			target = Bike2;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 3)
		{
			target = Bike3;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 4)
		{
			target = Bike4;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 5)
		{
			target = Bike5;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 6)
		{
			target = Bike6;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 7)
		{
			target = Bike7;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 8)
		{
			target = Bike8;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 9)
		{
			target = Bike9;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 10)
		{
			target = Bike10;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 11)
		{
			target = Bike11;
		}
	}

	private void Update()
	{
		base.transform.LookAt(target);
	}
}
