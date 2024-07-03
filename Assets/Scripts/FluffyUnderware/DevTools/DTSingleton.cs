using UnityEngine;

namespace FluffyUnderware.DevTools
{
	public class DTSingleton<T> : MonoBehaviour where T : MonoBehaviour, IDTSingleton
	{
		private static T _instance;

		private static object _lock;

		private static bool applicationIsQuitting;

		private bool isDuplicateInstance;

		public static bool HasInstance
		{
			get
			{
				return (Object)_instance != (Object)null;
			}
		}

		public static T Instance
		{
			get
			{
				if (!Application.isPlaying)
				{
					applicationIsQuitting = false;
				}
				if (applicationIsQuitting)
				{
					return (T)null;
				}
				if (_lock == null)
				{
					_lock = new object();
				}
				lock (_lock)
				{
					if ((Object)_instance == (Object)null)
					{
						_instance = (T)Object.FindObjectOfType(typeof(T));
						if (Object.FindObjectsOfType(typeof(T)).Length > 1)
						{
							Debug.LogError("[DTSingleton] Something went really wrong  - there should never be more than 1 singleton! PLEASE INFORM THE AUTHOR!");
							return _instance;
						}
						if ((Object)_instance == (Object)null)
						{
							GameObject gameObject = new GameObject();
							_instance = gameObject.AddComponent<T>();
						}
					}
					return _instance;
				}
			}
		}

		protected virtual void Awake()
		{
			if ((Object)Instance != (Object)null)
			{
				T instance = Instance;
				if (instance.GetInstanceID() != GetInstanceID())
				{
					Instance.MergeDoubleLoaded((IDTSingleton)this);
					isDuplicateInstance = true;
					Invoke("DestroySelf", 0f);
				}
			}
		}

		protected virtual void OnDestroy()
		{
			if (Application.isPlaying && !isDuplicateInstance)
			{
				applicationIsQuitting = true;
				_instance = (T)null;
			}
		}

		protected virtual void MergeDoubleLoaded(IDTSingleton newInstance)
		{
		}

		private void DestroySelf()
		{
			Object.Destroy(base.gameObject);
		}
	}
}
