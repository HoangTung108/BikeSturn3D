using System;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[ModuleInfo("Modifier/TRS Shape", ModuleName = "TRS Shape", Description = "Transform,Rotate,Scale a Shape")]
	[HelpURL("http://www.fluffyunderware.com/curvy/doclink/200/cgtrsshape")]
	public class ModifierTRSShape : TRSModuleBase, IOnRequestPath, IOnRequestProcessing
	{
		[InputSlotInfo(new Type[] { typeof(CGShape) }, Name = "Shape A", ModifiesData = true)]
		[HideInInspector]
		public CGModuleInputSlot InShape = new CGModuleInputSlot();

		[OutputSlotInfo(typeof(CGShape))]
		[HideInInspector]
		public CGModuleOutputSlot OutShape = new CGModuleOutputSlot();

		public float PathLength
		{
			get
			{
				return (!IsConfigured) ? 0f : InShape.SourceSlot(0).OnRequestPathModule.PathLength;
			}
		}

		public bool PathIsClosed
		{
			get
			{
				return IsConfigured && InShape.SourceSlot(0).OnRequestPathModule.PathIsClosed;
			}
		}

		public CGData[] OnSlotDataRequest(CGModuleInputSlot requestedBy, CGModuleOutputSlot requestedSlot, params CGDataRequestParameter[] requests)
		{
			if (requestedSlot == OutShape)
			{
				CGShape data = InShape.GetData<CGShape>(requests);
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
