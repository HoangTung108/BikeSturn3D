using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FluffyUnderware.DevTools;
using FluffyUnderware.DevTools.Data;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[HelpURL("http://www.fluffyunderware.com/curvy/doclink/200/cgbuildshapeextrusion")]
	[ModuleInfo("Build/Shape Extrusion", ModuleName = "Shape Extrusion", Description = "Simple Shape Extrusion")]
	public class BuildShapeExtrusion : CGModule
	{
		public enum ScaleModeEnum
		{
			Simple,
			Advanced
		}

		public enum CrossShiftModeEnum
		{
			None,
			ByOrientation,
			Custom
		}

		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGPath) }, RequestDataOnly = true)]
		public CGModuleInputSlot InPath = new CGModuleInputSlot();

		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGShape) }, RequestDataOnly = true)]
		public CGModuleInputSlot InCross = new CGModuleInputSlot();

		[OutputSlotInfo(typeof(CGVolume))]
		[HideInInspector]
		public CGModuleOutputSlot OutVolume = new CGModuleOutputSlot();

		[OutputSlotInfo(typeof(CGVolume))]
		[HideInInspector]
		public CGModuleOutputSlot OutVolumeHollow = new CGModuleOutputSlot();

		[Tab("Path")]
		[FloatRegion(UseSlider = true, RegionOptionsPropertyName = "RangeOptions", Precision = 4)]
		[SerializeField]
		private FloatRegion m_Range = FloatRegion.ZeroOne;

		[SerializeField]
		[RangeEx(0f, 100f, "", "", Tooltip = "Vertex distance")]
		private int m_Resolution = 50;

		[SerializeField]
		private bool m_Optimize = true;

		[FieldCondition("m_Optimize", true, false, ActionAttribute.ActionEnum.Show, null, ActionAttribute.ActionPositionEnum.Below)]
		[SerializeField]
		[RangeEx(0.1f, 120f, "", "", Tooltip = "Max angle")]
		private float m_AngleThreshold = 10f;

		[FloatRegion(UseSlider = true, RegionOptionsPropertyName = "CrossRangeOptions", Precision = 4)]
		[SerializeField]
		[Tab("Cross")]
		[FieldAction("CBEditCrossButton", ActionAttribute.ActionEnum.Callback, Position = ActionAttribute.ActionPositionEnum.Above)]
		private FloatRegion m_CrossRange = FloatRegion.ZeroOne;

		[RangeEx(0f, 100f, "Resolution", "", Tooltip = "Vertex distance")]
		[SerializeField]
		private int m_CrossResolution = 50;

		[Label("Optimize", "")]
		[SerializeField]
		private bool m_CrossOptimize = true;

		[RangeEx(0.1f, 120f, "Angle Threshold", "", Tooltip = "Max angle")]
		[SerializeField]
		[FieldCondition("m_CrossOptimize", true, false, ActionAttribute.ActionEnum.Show, null, ActionAttribute.ActionPositionEnum.Below)]
		private float m_CrossAngleThreshold = 10f;

		[Label("Include CP", "")]
		[SerializeField]
		private bool m_CrossIncludeControlpoints;

		[SerializeField]
		[Label("Hard Edges", "")]
		private bool m_CrossHardEdges;

		[Label("Materials", "")]
		[SerializeField]
		private bool m_CrossMaterials;

		[Label("Extended UV", "")]
		[SerializeField]
		private bool m_CrossExtendedUV;

		[SerializeField]
		[Label("Shift", "", Tooltip = "Shift Cross Start")]
		private CrossShiftModeEnum m_CrossShiftMode = CrossShiftModeEnum.ByOrientation;

		[FieldCondition("m_CrossShiftMode", CrossShiftModeEnum.Custom, false, ActionAttribute.ActionEnum.Show, null, ActionAttribute.ActionPositionEnum.Below)]
		[RangeEx(0f, 1f, "Value", "Shift By", Slider = true)]
		[SerializeField]
		private float m_CrossShiftValue;

		[SerializeField]
		[Label("Reverse Normal", "Reverse Vertex Normals?")]
		private bool m_CrossReverseNormals;

		[SerializeField]
		[Label("Mode", "")]
		[Tab("Scale")]
		private ScaleModeEnum m_ScaleMode;

		[FieldCondition("m_ScaleMode", ScaleModeEnum.Advanced, false, ActionAttribute.ActionEnum.Show, null, ActionAttribute.ActionPositionEnum.Below)]
		[SerializeField]
		[Label("Reference", "")]
		private CGReferenceMode m_ScaleReference = CGReferenceMode.Self;

		[SerializeField]
		[Label("Offset", "")]
		[FieldCondition("m_ScaleMode", ScaleModeEnum.Advanced, false, ActionAttribute.ActionEnum.Show, null, ActionAttribute.ActionPositionEnum.Below)]
		private float m_ScaleOffset;

		[Label("Uniform", "", Tooltip = "Use a single curve")]
		[SerializeField]
		private bool m_ScaleUniform = true;

		[SerializeField]
		private float m_ScaleX = 1f;

		[SerializeField]
		[FieldCondition("m_ScaleUniform", false, false, ActionAttribute.ActionEnum.Show, null, ActionAttribute.ActionPositionEnum.Below)]
		private float m_ScaleY = 1f;

		[AnimationCurveEx("Multiplier X", "")]
		[FieldCondition("m_ScaleMode", ScaleModeEnum.Advanced, false, ActionAttribute.ActionEnum.Show, null, ActionAttribute.ActionPositionEnum.Below)]
		[SerializeField]
		private AnimationCurve m_ScaleCurveX = AnimationCurve.Linear(0f, 1f, 1f, 1f);

		[AnimationCurveEx("Multiplier Y", "")]
		[FieldCondition("m_ScaleUniform", false, false, FluffyUnderware.DevTools.ConditionalAttribute.OperatorEnum.AND, "m_ScaleMode", ScaleModeEnum.Advanced, false)]
		[SerializeField]
		private AnimationCurve m_ScaleCurveY = AnimationCurve.Linear(0f, 1f, 1f, 1f);

		[SerializeField]
		[RangeEx(0f, 1f, "", "", Slider = true, Label = "Inset")]
		[Tab("Hollow")]
		private float m_HollowInset;

		[Label("Reverse Normal", "Reverse Vertex Normals?")]
		[SerializeField]
		private bool m_HollowReverseNormals;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int _003CPathSamples_003Ek__BackingField;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int _003CCrossSamples_003Ek__BackingField;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _003CCrossGroups_003Ek__BackingField;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Vector3 _003CCrossPosition_003Ek__BackingField;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Quaternion _003CCrossRotation_003Ek__BackingField;

		public float From
		{
			get
			{
				return m_Range.From;
			}
			set
			{
				float num = Mathf.Repeat(value, 1f);
				if (m_Range.From != num)
				{
					m_Range.From = num;
				}
				base.Dirty = true;
			}
		}

		public float To
		{
			get
			{
				return m_Range.To;
			}
			set
			{
				float num = Mathf.Max(From, value);
				if (ClampPath)
				{
					num = DTMath.Repeat(value, 1f);
				}
				if (m_Range.To != num)
				{
					m_Range.To = num;
				}
				base.Dirty = true;
			}
		}

		public float Length
		{
			get
			{
				return (!ClampPath) ? m_Range.To : (m_Range.To - m_Range.From);
			}
			set
			{
				float num = ((!ClampPath) ? value : (value - m_Range.To));
				if (m_Range.To != num)
				{
					m_Range.To = num;
				}
				base.Dirty = true;
			}
		}

		public int Resolution
		{
			get
			{
				return m_Resolution;
			}
			set
			{
				int num = Mathf.Clamp(value, 0, 100);
				if (m_Resolution != num)
				{
					m_Resolution = num;
				}
				base.Dirty = true;
			}
		}

		public bool Optimize
		{
			get
			{
				return m_Optimize;
			}
			set
			{
				if (m_Optimize != value)
				{
					m_Optimize = value;
				}
				base.Dirty = true;
			}
		}

		public float AngleThreshold
		{
			get
			{
				return m_AngleThreshold;
			}
			set
			{
				float num = Mathf.Clamp(value, 0.1f, 120f);
				if (m_AngleThreshold != num)
				{
					m_AngleThreshold = num;
				}
				base.Dirty = true;
			}
		}

		public float CrossFrom
		{
			get
			{
				return m_CrossRange.From;
			}
			set
			{
				float num = Mathf.Repeat(value, 1f);
				if (m_CrossRange.From != num)
				{
					m_CrossRange.From = num;
				}
				base.Dirty = true;
			}
		}

		public float CrossTo
		{
			get
			{
				return m_CrossRange.To;
			}
			set
			{
				float num = Mathf.Max(CrossFrom, value);
				if (ClampCross)
				{
					num = DTMath.Repeat(value, 1f);
				}
				if (m_CrossRange.To != num)
				{
					m_CrossRange.To = num;
				}
				base.Dirty = true;
			}
		}

		public float CrossLength
		{
			get
			{
				return (!ClampCross) ? m_CrossRange.To : (m_CrossRange.To - m_CrossRange.From);
			}
			set
			{
				float num = ((!ClampCross) ? value : (value - m_CrossRange.To));
				if (m_CrossRange.To != num)
				{
					m_CrossRange.To = num;
				}
				base.Dirty = true;
			}
		}

		public int CrossResolution
		{
			get
			{
				return m_CrossResolution;
			}
			set
			{
				int num = Mathf.Clamp(value, 0, 100);
				if (m_CrossResolution != num)
				{
					m_CrossResolution = num;
				}
				base.Dirty = true;
			}
		}

		public bool CrossOptimize
		{
			get
			{
				return m_CrossOptimize;
			}
			set
			{
				if (m_CrossOptimize != value)
				{
					m_CrossOptimize = value;
				}
				base.Dirty = true;
			}
		}

		public float CrossAngleThreshold
		{
			get
			{
				return m_CrossAngleThreshold;
			}
			set
			{
				float num = Mathf.Clamp(value, 0.1f, 120f);
				if (m_CrossAngleThreshold != num)
				{
					m_CrossAngleThreshold = num;
				}
				base.Dirty = true;
			}
		}

		public bool CrossIncludeControlPoints
		{
			get
			{
				return m_CrossIncludeControlpoints;
			}
			set
			{
				if (m_CrossIncludeControlpoints != value)
				{
					m_CrossIncludeControlpoints = value;
				}
				base.Dirty = true;
			}
		}

		public bool CrossHardEdges
		{
			get
			{
				return m_CrossHardEdges;
			}
			set
			{
				if (m_CrossHardEdges != value)
				{
					m_CrossHardEdges = value;
				}
				base.Dirty = true;
			}
		}

		public bool CrossMaterials
		{
			get
			{
				return m_CrossMaterials;
			}
			set
			{
				if (m_CrossMaterials != value)
				{
					m_CrossMaterials = value;
				}
				base.Dirty = true;
			}
		}

		public bool CrossExtendedUV
		{
			get
			{
				return m_CrossExtendedUV;
			}
			set
			{
				if (m_CrossExtendedUV != value)
				{
					m_CrossExtendedUV = value;
				}
				base.Dirty = true;
			}
		}

		public CrossShiftModeEnum CrossShiftMode
		{
			get
			{
				return m_CrossShiftMode;
			}
			set
			{
				if (m_CrossShiftMode != value)
				{
					m_CrossShiftMode = value;
				}
				base.Dirty = true;
			}
		}

		public float CrossShiftValue
		{
			get
			{
				return m_CrossShiftValue;
			}
			set
			{
				float num = Mathf.Repeat(m_CrossShiftValue, 1f);
				if (m_CrossShiftValue != num)
				{
					m_CrossShiftValue = num;
				}
				base.Dirty = true;
			}
		}

		private bool CrossReverseNormals
		{
			get
			{
				return m_CrossReverseNormals;
			}
			set
			{
				if (m_CrossReverseNormals != value)
				{
					m_CrossReverseNormals = value;
				}
				base.Dirty = true;
			}
		}

		public ScaleModeEnum ScaleMode
		{
			get
			{
				return m_ScaleMode;
			}
			set
			{
				if (m_ScaleMode != value)
				{
					m_ScaleMode = value;
				}
				base.Dirty = true;
			}
		}

		public CGReferenceMode ScaleReference
		{
			get
			{
				return m_ScaleReference;
			}
			set
			{
				if (m_ScaleReference != value)
				{
					m_ScaleReference = value;
				}
				base.Dirty = true;
			}
		}

		public bool ScaleUniform
		{
			get
			{
				return m_ScaleUniform;
			}
			set
			{
				if (m_ScaleUniform != value)
				{
					m_ScaleUniform = value;
				}
				base.Dirty = true;
			}
		}

		public float ScaleOffset
		{
			get
			{
				return m_ScaleOffset;
			}
			set
			{
				if (m_ScaleOffset != value)
				{
					m_ScaleOffset = value;
				}
				base.Dirty = true;
			}
		}

		public float ScaleX
		{
			get
			{
				return m_ScaleX;
			}
			set
			{
				if (m_ScaleX != value)
				{
					m_ScaleX = value;
				}
				base.Dirty = true;
			}
		}

		public float ScaleY
		{
			get
			{
				return m_ScaleY;
			}
			set
			{
				if (m_ScaleY != value)
				{
					m_ScaleY = value;
				}
				base.Dirty = true;
			}
		}

		private float HollowInset
		{
			get
			{
				return m_HollowInset;
			}
			set
			{
				float num = Mathf.Clamp01(value);
				if (m_HollowInset != num)
				{
					m_HollowInset = num;
				}
				base.Dirty = true;
			}
		}

		private bool HollowReverseNormals
		{
			get
			{
				return m_HollowReverseNormals;
			}
			set
			{
				if (m_HollowReverseNormals != value)
				{
					m_HollowReverseNormals = value;
				}
				base.Dirty = true;
			}
		}

		public int PathSamples
		{
			[CompilerGenerated]
			get
			{
				return _003CPathSamples_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CPathSamples_003Ek__BackingField = value;
			}
		}

		public int CrossSamples
		{
			[CompilerGenerated]
			get
			{
				return _003CCrossSamples_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CCrossSamples_003Ek__BackingField = value;
			}
		}

		public int CrossGroups
		{
			[CompilerGenerated]
			get
			{
				return _003CCrossGroups_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CCrossGroups_003Ek__BackingField = value;
			}
		}

		public IExternalInput Cross
		{
			get
			{
				return (!IsConfigured) ? null : InCross.SourceSlot(0).ExternalInput;
			}
		}

		public Vector3 CrossPosition
		{
			[CompilerGenerated]
			get
			{
				return _003CCrossPosition_003Ek__BackingField;
			}
			[CompilerGenerated]
			protected set
			{
				_003CCrossPosition_003Ek__BackingField = value;
			}
		}

		public Quaternion CrossRotation
		{
			[CompilerGenerated]
			get
			{
				return _003CCrossRotation_003Ek__BackingField;
			}
			[CompilerGenerated]
			protected set
			{
				_003CCrossRotation_003Ek__BackingField = value;
			}
		}

		private bool ClampPath
		{
			get
			{
				return !InPath.IsLinked || !InPath.SourceSlot(0).OnRequestPathModule.PathIsClosed;
			}
		}

		private bool ClampCross
		{
			get
			{
				return !InCross.IsLinked || !InCross.SourceSlot(0).OnRequestPathModule.PathIsClosed;
			}
		}

		private RegionOptions<float> RangeOptions
		{
			get
			{
				if (ClampPath)
				{
					return RegionOptions<float>.MinMax(0f, 1f);
				}
				RegionOptions<float> result = default(RegionOptions<float>);
				result.LabelFrom = "Start";
				result.ClampFrom = DTValueClamping.Min;
				result.FromMin = 0f;
				result.LabelTo = "Length";
				result.ClampTo = DTValueClamping.Range;
				result.ToMin = 0f;
				result.ToMax = 1f;
				return result;
			}
		}

		private RegionOptions<float> CrossRangeOptions
		{
			get
			{
				if (ClampCross)
				{
					return RegionOptions<float>.MinMax(0f, 1f);
				}
				RegionOptions<float> result = default(RegionOptions<float>);
				result.LabelFrom = "Start";
				result.ClampFrom = DTValueClamping.Min;
				result.FromMin = 0f;
				result.LabelTo = "Length";
				result.ClampTo = DTValueClamping.Range;
				result.ToMin = 0f;
				result.ToMax = 1f;
				return result;
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			Properties.MinWidth = 270f;
			Properties.LabelWidth = 100f;
		}

		public override void Reset()
		{
			base.Reset();
			From = 0f;
			To = 1f;
			Resolution = 50;
			AngleThreshold = 10f;
			Optimize = true;
			CrossFrom = 0f;
			CrossTo = 1f;
			CrossResolution = 50;
			CrossAngleThreshold = 10f;
			CrossOptimize = true;
			CrossIncludeControlPoints = false;
			CrossHardEdges = false;
			CrossMaterials = false;
			CrossShiftMode = CrossShiftModeEnum.ByOrientation;
			ScaleMode = ScaleModeEnum.Simple;
			ScaleUniform = true;
			ScaleX = 1f;
			ScaleY = 1f;
			HollowInset = 0f;
		}

		public override void Refresh()
		{
			base.Refresh();
			if (Length == 0f)
			{
				Reset();
				return;
			}
			List<CGDataRequestParameter> list = new List<CGDataRequestParameter>();
			list.Add(new CGDataRequestRasterization(From, Length, CGUtility.CalculateSamplePointsCacheSize(Resolution, InPath.SourceSlot(0).OnRequestPathModule.PathLength * Length), AngleThreshold, Optimize ? CGDataRequestRasterization.ModeEnum.Optimized : CGDataRequestRasterization.ModeEnum.Even));
			CGPath data = InPath.GetData<CGPath>(list.ToArray());
			list.Clear();
			list.Add(new CGDataRequestRasterization(CrossFrom, CrossLength, CGUtility.CalculateSamplePointsCacheSize(CrossResolution, InCross.SourceSlot(0).OnRequestPathModule.PathLength * CrossLength), CrossAngleThreshold, CrossOptimize ? CGDataRequestRasterization.ModeEnum.Optimized : CGDataRequestRasterization.ModeEnum.Even));
			if (CrossIncludeControlPoints || CrossHardEdges || CrossMaterials)
			{
				list.Add(new CGDataRequestMetaCGOptions(CrossHardEdges, CrossMaterials, CrossIncludeControlPoints, CrossExtendedUV));
			}
			CGShape data2 = InCross.GetData<CGShape>(list.ToArray());
			if (!data || !data2 || data.Count == 0 || data2.Count == 0)
			{
				OutVolume.ClearData();
				OutVolumeHollow.ClearData();
				return;
			}
			CGVolume cGVolume = CGVolume.Get(OutVolume.GetData<CGVolume>(), data, data2);
			CGVolume cGVolume2 = ((!OutVolumeHollow.IsLinked) ? null : CGVolume.Get(OutVolumeHollow.GetData<CGVolume>(), data, data2));
			PathSamples = data.Count;
			CrossSamples = data2.Count;
			CrossGroups = data2.MaterialGroups.Count;
			CrossPosition = cGVolume.Position[0];
			CrossRotation = Quaternion.LookRotation(cGVolume.Direction[0], cGVolume.Normal[0]);
			Vector3 vector = ((!ScaleUniform) ? new Vector3(ScaleX, ScaleY, 1f) : new Vector3(ScaleX, ScaleX, 1f));
			Vector3 scale = vector;
			int num = 0;
			float[] array = ((ScaleReference != 0) ? data.F : data.SourceF);
			int num2 = ((!CrossReverseNormals) ? 1 : (-1));
			int num3 = ((!HollowReverseNormals) ? 1 : (-1));
			for (int i = 0; i < data.Count; i++)
			{
				Quaternion quaternion = Quaternion.LookRotation(data.Direction[i], data.Normal[i]);
				getScaleInternal(array[i], vector, ref scale);
				Matrix4x4 matrix4x = Matrix4x4.TRS(data.Position[i], quaternion, scale);
				if (cGVolume2 == null)
				{
					for (int j = 0; j < data2.Count; j++)
					{
						cGVolume.Vertex[num] = matrix4x.MultiplyPoint(data2.Position[j]);
						cGVolume.VertexNormal[num++] = quaternion * data2.Normal[j] * num2;
					}
					continue;
				}
				Matrix4x4 matrix4x2 = Matrix4x4.TRS(data.Position[i], quaternion, scale * (1f - HollowInset));
				for (int k = 0; k < data2.Count; k++)
				{
					cGVolume.Vertex[num] = matrix4x.MultiplyPoint(data2.Position[k]);
					cGVolume.VertexNormal[num] = quaternion * data2.Normal[k];
					cGVolume2.Vertex[num] = matrix4x2.MultiplyPoint(data2.Position[k]);
					cGVolume2.VertexNormal[num] = cGVolume.VertexNormal[num++] * num3;
				}
			}
			switch (CrossShiftMode)
			{
			case CrossShiftModeEnum.ByOrientation:
			{
				Vector2 hit;
				float frag;
				for (int l = 0; l < data2.Count - 1; l++)
				{
					if (DTMath.RayLineSegmentIntersection(cGVolume.Position[0], cGVolume.VertexNormal[0], cGVolume.Vertex[l], cGVolume.Vertex[l + 1], out hit, out frag))
					{
						cGVolume.CrossFShift = DTMath.SnapPrecision(cGVolume.CrossF[l] + (cGVolume.CrossF[l + 1] - cGVolume.CrossF[l]) * frag, 2);
						break;
					}
				}
				if (cGVolume.CrossClosed && DTMath.RayLineSegmentIntersection(cGVolume.Position[0], cGVolume.VertexNormal[0], cGVolume.Vertex[data2.Count - 1], cGVolume.Vertex[0], out hit, out frag))
				{
					cGVolume.CrossFShift = DTMath.SnapPrecision(cGVolume.CrossF[data2.Count - 1] + (cGVolume.CrossF[0] - cGVolume.CrossF[data2.Count - 1]) * frag, 2);
				}
				break;
			}
			case CrossShiftModeEnum.Custom:
				cGVolume.CrossFShift = CrossShiftValue;
				break;
			default:
				cGVolume.CrossFShift = 0f;
				break;
			}
			if (cGVolume2 != null)
			{
				cGVolume2.CrossFShift = cGVolume.CrossFShift;
			}
			OutVolume.SetData(cGVolume);
			OutVolumeHollow.SetData(cGVolume2);
		}

		public Vector3 GetScale(float f)
		{
			Vector3 baseScale = ((!ScaleUniform) ? new Vector3(ScaleX, ScaleY, 1f) : new Vector3(ScaleX, ScaleX, 1f));
			Vector3 scale = Vector3.zero;
			getScaleInternal(f, baseScale, ref scale);
			return scale;
		}

		private void getScaleInternal(float f, Vector3 baseScale, ref Vector3 scale)
		{
			if (ScaleMode == ScaleModeEnum.Advanced)
			{
				float time = DTMath.Repeat(f - ScaleOffset, 1f);
				float num = baseScale.x * m_ScaleCurveX.Evaluate(time);
				scale.Set(num, (!m_ScaleUniform) ? (baseScale.y * m_ScaleCurveY.Evaluate(time)) : num, 1f);
			}
			else
			{
				scale = baseScale;
			}
		}
	}
}
