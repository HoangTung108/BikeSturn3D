using UnityEngine;

public class OnJoinedInstantiate : MonoBehaviour
{
	public Transform SpawnPosition;

	public float PositionOffset = 2f;

	public GameObject[] PrefabsToInstantiate;

	public void OnJoinedRoom()
	{
		if (PrefabsToInstantiate == null)
		{
			return;
		}
		GameObject[] prefabsToInstantiate = PrefabsToInstantiate;
		foreach (GameObject gameObject in prefabsToInstantiate)
		{
			Debug.Log("Instantiating: " + gameObject.name);
			Vector3 vector = Vector3.up;
			if (SpawnPosition != null)
			{
				vector = SpawnPosition.position;
			}
			Vector3 vector2 = Random.insideUnitSphere;
			vector2.y = 0f;
			vector2 = vector2.normalized;
			Vector3 position = vector + PositionOffset * vector2;
			//PhotonNetwork.Instantiate(gameObject.name, position, Quaternion.identity, 0);
		}
	}
}
