using System;
using FluffyUnderware.DevTools;
using FluffyUnderware.DevTools.Data;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[HelpURL("http://www.fluffyunderware.com/curvy/doclink/200/cgdebugvolume")]
	[ModuleInfo("Debug/Volume", ModuleName = "Debug Volume")]
	public class DebugVolume : CGModule
	{
		[InputSlotInfo(new Type[] { typeof(CGVolume) }, Name = "Volume")]
		[HideInInspector]
		public CGModuleInputSlot InData = new CGModuleInputSlot();

		[Tab("General")]
		public bool ShowPathSamples = true;

		public bool ShowCrossSamples = true;

		[FieldCondition("ShowCrossSamples", true, false, ActionAttribute.ActionEnum.Show, null, ActionAttribute.ActionPositionEnum.Below)]
		[IntRegion(RegionIsOptional = true)]
		public IntRegion LimitCross = new IntRegion(0, 0);

		public bool ShowNormals;

		public bool ShowIndex;

		public bool ShowMap;

		public Color PathColor = Color.white;

		public Color VolumeColor = Color.gray;

		public Color NormalColor = Color.yellow;

		[Tab("Interpolate")]
		public bool Interpolate;

		[RangeEx(-1f, 1f, "Path", "")]
		public float InterpolatePathF;

		[RangeEx(-1f, 1f, "Cross", "")]
		public float InterpolateCrossF;
	}
}
