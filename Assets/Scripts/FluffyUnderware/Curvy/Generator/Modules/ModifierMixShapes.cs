using System;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[HelpURL("http://www.fluffyunderware.com/curvy/doclink/200/cgmixshapes")]
	[ModuleInfo("Modifier/Mix Shapes", ModuleName = "Mix Shapes", Description = "Lerps between two shapes")]
	public class ModifierMixShapes : CGModule, IOnRequestPath, IOnRequestProcessing
	{
		[InputSlotInfo(new Type[] { typeof(CGShape) }, Name = "Shape A")]
		[HideInInspector]
		public CGModuleInputSlot InShapeA = new CGModuleInputSlot();

		[InputSlotInfo(new Type[] { typeof(CGShape) }, Name = "Shape B")]
		[HideInInspector]
		public CGModuleInputSlot InShapeB = new CGModuleInputSlot();

		[HideInInspector]
		[OutputSlotInfo(typeof(CGShape))]
		public CGModuleOutputSlot OutShape = new CGModuleOutputSlot();

		[SerializeField]
		[RangeEx(-1f, 1f, "", "", Tooltip = "Mix between the paths")]
		private float m_Mix;

		public float Mix
		{
			get
			{
				return m_Mix;
			}
			set
			{
				if (m_Mix != value)
				{
					m_Mix = value;
				}
				base.Dirty = true;
			}
		}

		public float PathLength
		{
			get
			{
				return (!IsConfigured) ? 0f : Mathf.Max(InShapeA.SourceSlot(0).OnRequestPathModule.PathLength, InShapeB.SourceSlot(0).OnRequestPathModule.PathLength);
			}
		}

		public bool PathIsClosed
		{
			get
			{
				return IsConfigured && InShapeA.SourceSlot(0).OnRequestPathModule.PathIsClosed && InShapeB.SourceSlot(0).OnRequestPathModule.PathIsClosed;
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			Properties.MinWidth = 200f;
			Properties.LabelWidth = 50f;
		}

		public override void Reset()
		{
			base.Reset();
			Mix = 0f;
		}

		public CGData[] OnSlotDataRequest(CGModuleInputSlot requestedBy, CGModuleOutputSlot requestedSlot, params CGDataRequestParameter[] requests)
		{
			CGDataRequestRasterization requestParameter = GetRequestParameter<CGDataRequestRasterization>(ref requests);
			if (!requestParameter)
			{
				return null;
			}
			CGShape data = InShapeA.GetData<CGShape>(requests);
			CGShape data2 = InShapeB.GetData<CGShape>(requests);
			CGPath cGPath = new CGPath();
			CGShape cGShape;
			CGShape cGShape2;
			if (data.Count > data2.Count)
			{
				cGShape = data;
				cGShape2 = data2;
			}
			else
			{
				cGShape = data2;
				cGShape2 = data;
			}
			Vector3[] array = new Vector3[cGShape.Count];
			float t = (Mix + 1f) / 2f;
			for (int i = 0; i < cGShape.Count; i++)
			{
				array[i] = Vector3.Lerp(cGShape.Position[i], cGShape2.InterpolatePosition(cGShape.F[i]), t);
			}
			cGPath.F = cGShape.F;
			cGPath.Position = array;
			return new CGData[1] { cGPath };
		}
	}
}
