using System;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[HelpURL("http://www.fluffyunderware.com/curvy/doclink/200/cgtrsmesh")]
	[ModuleInfo("Modifier/TRS Mesh", ModuleName = "TRS Mesh", Description = "Transform,Rotate,Scale a VMesh")]
	public class ModifierTRSMesh : TRSModuleBase
	{
		[InputSlotInfo(new Type[] { typeof(CGVMesh) }, Array = true, ModifiesData = true)]
		[HideInInspector]
		public CGModuleInputSlot InVMesh = new CGModuleInputSlot();

		[OutputSlotInfo(typeof(CGVMesh), Array = true)]
		[HideInInspector]
		public CGModuleOutputSlot OutVMesh = new CGModuleOutputSlot();

		public override void Refresh()
		{
			base.Refresh();
			if (OutVMesh.IsLinked)
			{
				List<CGVMesh> allData = InVMesh.GetAllData<CGVMesh>(new CGDataRequestParameter[0]);
				Matrix4x4 matrix = base.Matrix;
				for (int i = 0; i < allData.Count; i++)
				{
					allData[i].TRS(matrix);
				}
				OutVMesh.SetData(allData);
			}
		}
	}
}
