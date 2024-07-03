using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

//[Extension]
public static class Extensions
{
	public static Dictionary<MethodInfo, ParameterInfo[]> ParametersOfMethods = new Dictionary<MethodInfo, ParameterInfo[]>();

	//[Extension]
	public static ParameterInfo[] GetCachedParemeters(MethodInfo mo)
	{
		ParameterInfo[] value;
		if (!ParametersOfMethods.TryGetValue(mo, out value))
		{
			value = mo.GetParameters();
			ParametersOfMethods[mo] = value;
		}
		return value;
	}

	//[Extension]
	//public static PhotonView[] GetPhotonViewsInChildren(GameObject go)
	//{
	//	return go.GetComponentsInChildren<PhotonView>(true);
	//}

	////[Extension]
	//public static PhotonView GetPhotonView(GameObject go)
	//{
	//	return go.GetComponent<PhotonView>();
	//}

	//[Extension]
	public static bool AlmostEquals(Vector3 target, Vector3 second, float sqrMagnitudePrecision)
	{
		return (target - second).sqrMagnitude < sqrMagnitudePrecision;
	}

	//[Extension]
	public static bool AlmostEquals(Vector2 target, Vector2 second, float sqrMagnitudePrecision)
	{
		return (target - second).sqrMagnitude < sqrMagnitudePrecision;
	}

	//[Extension]
	public static bool AlmostEquals(Quaternion target, Quaternion second, float maxAngle)
	{
		return Quaternion.Angle(target, second) < maxAngle;
	}

	//[Extension]
	public static bool AlmostEquals(float target, float second, float floatDiff)
	{
		return Mathf.Abs(target - second) < floatDiff;
	}

	//[Extension]
	public static void Merge(IDictionary target, IDictionary addHash)
	{
		if (addHash == null || target.Equals(addHash))
		{
			return;
		}
		IEnumerator enumerator = addHash.Keys.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				target[current] = addHash[current];
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

	//[Extension]
	public static void MergeStringKeys(IDictionary target, IDictionary addHash)
	{
		if (addHash == null || target.Equals(addHash))
		{
			return;
		}
		IEnumerator enumerator = addHash.Keys.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (current is string)
				{
					target[current] = addHash[current];
				}
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

	//[Extension]
	public static string ToStringFull(IDictionary origin)
	{
		//return SupportClass.DictionaryToString(origin, false);
		return string.Empty;
	}

	//[Extension]
	public static string ToStringFull(object[] data)
	{
		if (data == null)
		{
			return "null";
		}
		string[] array = new string[data.Length];
		for (int i = 0; i < data.Length; i++)
		{
			object obj = data[i];
			array[i] = ((obj == null) ? "null" : obj.ToString());
		}
		return string.Join(", ", array);
	}

	//[Extension]
	//public static ExitGames.Client.Photon.Hashtable StripToStringKeys(IDictionary original)
	//{
	//	ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
	//	if (original != null)
	//	{
	//		IEnumerator enumerator = original.Keys.GetEnumerator();
	//		try
	//		{
	//			while (enumerator.MoveNext())
	//			{
	//				object current = enumerator.Current;
	//				if (current is string)
	//				{
	//					hashtable[current] = original[current];
	//				}
	//			}
	//			return hashtable;
	//		}
	//		finally
	//		{
	//			IDisposable disposable;
	//			if ((disposable = enumerator as IDisposable) != null)
	//			{
	//				disposable.Dispose();
	//			}
	//		}
	//	}
	//	return hashtable;
	//}

	//[Extension]
	public static void StripKeysWithNullValues(IDictionary original)
	{
		object[] array = new object[original.Count];
		int num = 0;
		IEnumerator enumerator = original.Keys.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				array[num++] = current;
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
		foreach (object key in array)
		{
			if (original[key] == null)
			{
				original.Remove(key);
			}
		}
	}

	//[Extension]
	public static bool Contains(int[] target, int nr)
	{
		if (target == null)
		{
			return false;
		}
		for (int i = 0; i < target.Length; i++)
		{
			if (target[i] == nr)
			{
				return true;
			}
		}
		return false;
	}
}
