using System.Reflection;
using UnityEngine.Events;

namespace FluffyUnderware.Curvy
{
	public class UnityEventEx<T0> : UnityEvent<T0>
	{
		private object mCallerList;

		private PropertyInfo mCallsCount;

		public void AddListenerOnce(UnityAction<T0> call)
		{
			RemoveListener(call);
			AddListener(call);
		}

		public bool HasListeners()
		{
			if (mCallsCount == null)
			{
				FieldInfo field = typeof(UnityEventBase).GetField("m_Calls", BindingFlags.Instance | BindingFlags.NonPublic);
				if (field != null)
				{
					mCallerList = field.GetValue(this);
					if (mCallerList != null)
					{
						mCallsCount = mCallerList.GetType().GetProperty("Count", BindingFlags.Instance | BindingFlags.Public);
					}
				}
			}
			int num = 0;
			if (mCallerList != null && mCallsCount != null)
			{
				num = (int)mCallsCount.GetValue(mCallerList, null);
			}
			num += GetPersistentEventCount();
			return num > 0;
		}
	}
}
