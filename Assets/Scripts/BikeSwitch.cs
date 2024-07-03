using UnityEngine;

public class BikeSwitch : MonoBehaviour
{
	public Transform[] Bikes;

	public Transform MyCamera;

	public void CurrentBikeActive(int current)
	{
		int num = 0;
		Transform[] bikes = Bikes;
		foreach (Transform transform in bikes)
		{
			if (current == num)
			{
				MyCamera.GetComponent<BikeCamera>().target = transform;
				MyCamera.GetComponent<BikeCamera>().Switch = 0;
				MyCamera.GetComponent<BikeCamera>().cameraSwitchView = transform.GetComponent<BikeControl>().bikeSetting.cameraSwitchView;
				MyCamera.GetComponent<BikeCamera>().BikerMan = transform.GetComponent<BikeControl>().bikeSetting.bikerMan;
				transform.GetComponent<BikeControl>().activeControl = true;
			}
			else
			{
				transform.GetComponent<BikeControl>().activeControl = false;
			}
			num++;
		}
	}
}
