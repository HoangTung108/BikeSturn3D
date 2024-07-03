using System.Runtime.CompilerServices;
using UnityEngine;

namespace DG.Tweening
{
	//[Extension]
	public static class DOTweenAnimationExtensions
	{
		//[Extension]
		public static bool IsSameOrSubclassOf<T>(Component t)
		{
			return t is T;
		}
	}
}
