using UnityEngine;

public class GizmoObject : MonoBehaviour
{
	public Color GColor = Color.white;

	public float GSize = 1f;

	private void OnDrawGizmos()
	{
		Gizmos.color = GColor;
		Vector3 direction = base.transform.TransformDirection(Vector3.forward) / 2f;
		Gizmos.DrawRay(base.transform.position, direction);
		Matrix4x4 matrix4x2 = (Gizmos.matrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, Vector3.one * GSize));
		Gizmos.DrawCube(Vector3.zero, Vector3.one * GSize);
	}
}
