using UnityEngine;

public class ParachutePlayerCloth : MonoBehaviour
{
	public Material Bike1BodyMat;

	public Material Bike1HelmetMat;

	public Material Bike2BodyMat;

	public Material Bike2HelmetMat;

	public Material Bike3BodyMat;

	public Material Bike3HelmetMat;

	public Material Bike4BodyMat;

	public Material Bike4HelmetMat;

	private Material[] Mats;

	private void OnEnable()
	{
		Mats = GetComponent<Renderer>().materials;
		if (PlayerPrefs.GetInt("BikeSelDB") == 1)
		{
			Mats[0] = Bike1HelmetMat;
			Mats[1] = Bike1BodyMat;
			base.gameObject.GetComponent<Renderer>().materials = Mats;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 2 || PlayerPrefs.GetInt("BikeSelDB") == 3 || PlayerPrefs.GetInt("BikeSelDB") == 8 || PlayerPrefs.GetInt("BikeSelDB") == 9 || PlayerPrefs.GetInt("BikeSelDB") == 10 || PlayerPrefs.GetInt("BikeSelDB") == 11)
		{
			Mats[0] = Bike2HelmetMat;
			Mats[1] = Bike2BodyMat;
			base.gameObject.GetComponent<Renderer>().materials = Mats;
		}
		else if (PlayerPrefs.GetInt("BikeSelDB") == 4 || PlayerPrefs.GetInt("BikeSelDB") == 5 || PlayerPrefs.GetInt("BikeSelDB") == 6 || PlayerPrefs.GetInt("BikeSelDB") == 7)
		{
			Mats[0] = Bike4HelmetMat;
			Mats[1] = Bike4BodyMat;
			base.gameObject.GetComponent<Renderer>().materials = Mats;
		}
	}
}
