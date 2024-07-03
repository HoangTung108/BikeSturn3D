using System.Runtime.CompilerServices;
using UnityEngine;

//[Extension]
public static class GameObjectExtensions
{
	//[Extension]
	public static bool GetActive(GameObject target)
	{
		return target.activeInHierarchy;
	}
}
