using System;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[HelpURL("http://www.fluffyunderware.com/curvy/doclink/200/cgdebugvmesh")]
	[ModuleInfo("Debug/VMesh", ModuleName = "Debug VMesh")]
	public class DebugVMesh : CGModule
	{
		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGVMesh) }, Name = "VMesh")]
		public CGModuleInputSlot InData = new CGModuleInputSlot();

		[Tab("General")]
		public bool ShowVertices;

		public bool ShowVertexID;

		public bool ShowUV;
	}
}
