using System;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[HelpURL("http://www.fluffyunderware.com/curvy/doclink/200/cgtrspath")]
	[ModuleInfo("Modifier/TRS Path", ModuleName = "TRS Path", Description = "Transform,Rotate,Scale a Path")]
	public class ModifierTRSPath : TRSModuleBase, IOnRequestPath, IOnRequestProcessing
	{
		[InputSlotInfo(new Type[] { typeof(CGPath) }, Name = "Path A", ModifiesData = true)]
		[HideInInspector]
		public CGModuleInputSlot InPath = new CGModuleInputSlot();

		[OutputSlotInfo(typeof(CGPath))]
		[HideInInspector]
		public CGModuleOutputSlot OutPath = new CGModuleOutputSlot();

		public float PathLength
		{
			get
			{
				return (!IsConfigured) ? 0f : InPath.SourceSlot(0).OnRequestPathModule.PathLength;
			}
		}

		public bool PathIsClosed
		{
			get
			{
				return IsConfigured && InPath.SourceSlot(0).OnRequestPathModule.PathIsClosed;
			}
		}

		public CGData[] OnSlotDataRequest(CGModuleInputSlot requestedBy, CGModuleOutputSlot requestedSlot, params CGDataRequestParameter[] requests)
		{
			if (requestedSlot == OutPath)
			{
				CGPath data = InPath.GetData<CGPath>(requests);
				Matrix4x4 matrix = base.Matrix;
				for (int i = 0; i < data.Count; i++)
				{
					data.Position[i] = matrix.MultiplyPoint3x4(data.Position[i]);
				}
				data.Recalculate();
				return new CGData[1] { data };
			}
			return null;
		}
	}
}
