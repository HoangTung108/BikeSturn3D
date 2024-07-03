using System;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy
{
	[ExecuteInEditMode]
	[Obsolete]
	public class CurvyComponent : MonoBehaviour
	{
		public delegate void CurvyComponentEvent(CurvyComponent sender);

		[Label(Tooltip = "Determines when to update")]
		public CurvyUpdateMethod UpdateIn;

		public bool DoMove = true;

		public bool DoOrientate = true;

		private Transform mTransform;

		public Transform Transform
		{
			get
			{
				if (!mTransform)
				{
					mTransform = base.transform;
				}
				return mTransform;
			}
		}

		public float DeltaTime
		{
			get
			{
				return DTTime.deltaTime;
			}
		}

		private void Update()
		{
			if (UpdateIn == CurvyUpdateMethod.Update && Application.isPlaying)
			{
				Refresh();
			}
		}

		private void LateUpdate()
		{
			if (UpdateIn == CurvyUpdateMethod.LateUpdate)
			{
				Refresh();
			}
		}

		private void FixedUpdate()
		{
			if (UpdateIn == CurvyUpdateMethod.FixedUpdate)
			{
				Refresh();
			}
		}

		public virtual void EditorUpdate()
		{
			DTTime.UpdateEditorTime();
		}

		public virtual bool Initialize()
		{
			return false;
		}

		public virtual void Refresh()
		{
		}
	}
}
