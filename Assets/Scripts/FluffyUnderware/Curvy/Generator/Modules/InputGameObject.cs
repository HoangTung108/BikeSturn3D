using System;
using System.Collections.Generic;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[HelpURL("http://www.fluffyunderware.com/curvy/doclink/200/cginputgameobject")]
	[ModuleInfo("Input/Game Objects", ModuleName = "Input GameObjects", Description = "")]
	public class InputGameObject : CGModule
	{
		[OutputSlotInfo(typeof(CGGameObject), Array = true)]
		[HideInInspector]
		public CGModuleOutputSlot OutGameObject = new CGModuleOutputSlot();

		[ArrayEx]
		[SerializeField]
		private List<CGGameObjectProperties> m_GameObjects = new List<CGGameObjectProperties>();

		public List<CGGameObjectProperties> GameObjects
		{
			get
			{
				return m_GameObjects;
			}
		}

		public bool SupportsIPE
		{
			get
			{
				return false;
			}
		}

		public override void Reset()
		{
			base.Reset();
			GameObjects.Clear();
			base.Dirty = true;
		}

		public override void Refresh()
		{
			base.Refresh();
			if (!OutGameObject.IsLinked)
			{
				return;
			}
			CGGameObject[] array = new CGGameObject[GameObjects.Count];
			int newSize = 0;
			for (int i = 0; i < GameObjects.Count; i++)
			{
				if (GameObjects[i] != null)
				{
					array[newSize++] = new CGGameObject(GameObjects[i]);
				}
			}
			Array.Resize(ref array, newSize);
			OutGameObject.SetData(array);
		}

		public override void OnTemplateCreated()
		{
			base.OnTemplateCreated();
			GameObjects.Clear();
		}
	}
}
