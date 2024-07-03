using System;
using System.Collections.Generic;
using FluffyUnderware.Curvy.ThirdParty.poly2tri;
using FluffyUnderware.Curvy.Utils;
using FluffyUnderware.DevTools;
using FluffyUnderware.DevTools.Extensions;
using UnityEngine;
using UnityEngine.Serialization;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[HelpURL("http://www.fluffyunderware.com/curvy/doclink/200/cgbuildvolumecaps")]
	[ModuleInfo("Build/Volume Caps", ModuleName = "Volume Caps", Description = "Build volume caps")]
	public class BuildVolumeCaps : CGModule
	{
		[InputSlotInfo(new Type[] { typeof(CGVolume) })]
		[HideInInspector]
		public CGModuleInputSlot InVolume = new CGModuleInputSlot();

		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGVolume) }, Optional = true, Array = true)]
		public CGModuleInputSlot InVolumeHoles = new CGModuleInputSlot();

		[OutputSlotInfo(typeof(CGVMesh), Array = true)]
		[HideInInspector]
		public CGModuleOutputSlot OutVMesh = new CGModuleOutputSlot();

		[Tab("General")]
		[SerializeField]
		private CGYesNoAuto m_StartCap = CGYesNoAuto.Auto;

		[SerializeField]
		private CGYesNoAuto m_EndCap = CGYesNoAuto.Auto;

		[SerializeField]
		[FormerlySerializedAs("m_ReverseNormals")]
		private bool m_ReverseTriOrder;

		[SerializeField]
		private bool m_GenerateUV = true;

		[Inline]
		[SerializeField]
		[Tab("Start Cap")]
		private CGMaterialSettings m_StartMaterialSettings = new CGMaterialSettings();

		[SerializeField]
		[Label("Material", "")]
		private Material m_StartMaterial;

		[Tab("End Cap")]
		[SerializeField]
		private bool m_CloneStartCap = true;

		[GroupCondition("m_CloneStartCap", false, false)]
		[SerializeField]
		[AsGroup(null, Invisible = true)]
		private CGMaterialSettings m_EndMaterialSettings = new CGMaterialSettings();

		[Label("Material", "")]
		[SerializeField]
		[FieldCondition("m_CloneStartCap", false, false, ActionAttribute.ActionEnum.Show, null, ActionAttribute.ActionPositionEnum.Below)]
		[Group("Default/End Cap")]
		private Material m_EndMaterial;

		public bool GenerateUV
		{
			get
			{
				return m_GenerateUV;
			}
			set
			{
				if (m_GenerateUV != value)
				{
					m_GenerateUV = value;
				}
				base.Dirty = true;
			}
		}

		public bool ReverseTriOrder
		{
			get
			{
				return m_ReverseTriOrder;
			}
			set
			{
				if (m_ReverseTriOrder != value)
				{
					m_ReverseTriOrder = value;
				}
				base.Dirty = true;
			}
		}

		public CGYesNoAuto StartCap
		{
			get
			{
				return m_StartCap;
			}
			set
			{
				if (m_StartCap != value)
				{
					m_StartCap = value;
				}
				base.Dirty = true;
			}
		}

		public Material StartMaterial
		{
			get
			{
				return m_StartMaterial;
			}
			set
			{
				if (m_StartMaterial != value)
				{
					m_StartMaterial = value;
				}
				base.Dirty = true;
			}
		}

		public CGMaterialSettings StartMaterialSettings
		{
			get
			{
				return m_StartMaterialSettings;
			}
		}

		public CGYesNoAuto EndCap
		{
			get
			{
				return m_EndCap;
			}
			set
			{
				if (m_EndCap != value)
				{
					m_EndCap = value;
				}
				base.Dirty = true;
			}
		}

		public bool CloneStartCap
		{
			get
			{
				return m_CloneStartCap;
			}
			set
			{
				if (m_CloneStartCap != value)
				{
					m_CloneStartCap = value;
				}
				base.Dirty = true;
			}
		}

		public CGMaterialSettings EndMaterialSettings
		{
			get
			{
				return m_EndMaterialSettings;
			}
		}

		public Material EndMaterial
		{
			get
			{
				return m_EndMaterial;
			}
			set
			{
				if (m_EndMaterial != value)
				{
					m_EndMaterial = value;
				}
				base.Dirty = true;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			if (StartMaterial == null)
			{
				StartMaterial = CurvyUtility.GetDefaultMaterial();
			}
			if (EndMaterial == null)
			{
				EndMaterial = CurvyUtility.GetDefaultMaterial();
			}
		}

		public override void Reset()
		{
			base.Reset();
			StartCap = CGYesNoAuto.Auto;
			EndCap = CGYesNoAuto.Auto;
			ReverseTriOrder = false;
			GenerateUV = true;
			m_StartMaterialSettings = new CGMaterialSettings();
			m_EndMaterialSettings = new CGMaterialSettings();
		}

		public override void Refresh()
		{
			base.Refresh();
			CGVolume data = InVolume.GetData<CGVolume>(new CGDataRequestParameter[0]);
			List<CGVolume> allData = InVolumeHoles.GetAllData<CGVolume>(new CGDataRequestParameter[0]);
			if (!data)
			{
				return;
			}
			bool flag = StartCap == CGYesNoAuto.Yes || (StartCap == CGYesNoAuto.Auto && !data.Seamless);
			bool flag2 = EndCap == CGYesNoAuto.Yes || (EndCap == CGYesNoAuto.Auto && !data.Seamless);
			if (!flag && !flag2)
			{
				OutVMesh.SetData((CGData[])null);
				return;
			}
			CGVMesh cGVMesh = new CGVMesh();
			Vector3[] vertices = new Vector3[0];
			Vector3[] vertices2 = new Vector3[0];
			cGVMesh.AddSubMesh(new CGVSubMesh((Material)null));
			CGVSubMesh cGVSubMesh = cGVMesh.SubMeshes[0];
			if (flag)
			{
				Vector3[] array = make2DSegment(data, 0);
				if (array.Length < 3)
				{
					OutVMesh.SetData((CGData[])null);
					UIMessages.Add("Cross has <3 Vertices: Can't create Caps!");
					return;
				}
				Polygon polygon = new Polygon(array);
				for (int i = 0; i < allData.Count; i++)
				{
					array = make2DSegment(allData[i], 0);
					if (array.Length < 3)
					{
						OutVMesh.SetData((CGData[])null);
						UIMessages.Add("Hole Cross has <3 Vertices: Can't create Caps!");
						return;
					}
					polygon.AddHole(new Polygon(array));
				}
				try
				{
					P2T.Triangulate(polygon);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					OutVMesh.SetData((CGData[])null);
					return;
				}
				cGVSubMesh.Material = StartMaterial;
				polygon.GetResults(out vertices, out cGVSubMesh.Triangles, ReverseTriOrder);
				cGVMesh.Vertex = applyMat(vertices, getMat(data, 0, true));
				if (GenerateUV)
				{
					cGVMesh.UV = new Vector2[vertices.Length];
					applyUV(vertices, ref cGVMesh.UV, 0, vertices.Length, polygon.Bounds.Bounds, StartMaterialSettings);
				}
			}
			if (flag2)
			{
				Vector3[] array = make2DSegment(data, data.Count - 1);
				if (array.Length < 3)
				{
					OutVMesh.SetData((CGData[])null);
					UIMessages.Add("Cross has <3 Vertices: Can't create Caps!");
					return;
				}
				Polygon polygon = new Polygon(array);
				for (int j = 0; j < allData.Count; j++)
				{
					array = make2DSegment(allData[j], allData[j].Count - 1);
					if (array.Length < 3)
					{
						OutVMesh.SetData((CGData[])null);
						UIMessages.Add("Hole Cross has <3 Vertices: Can't create Caps!");
						return;
					}
					polygon.AddHole(new Polygon(array));
				}
				try
				{
					P2T.Triangulate(polygon);
				}
				catch (Exception exception2)
				{
					Debug.LogException(exception2);
					OutVMesh.SetData((CGData[])null);
					return;
				}
				int[] triangles;
				polygon.GetResults(out vertices2, out triangles, !ReverseTriOrder, vertices.Length);
				cGVMesh.Vertex = ArrayExt.AddRange(cGVMesh.Vertex, applyMat(vertices2, getMat(data, data.Count - 1, true)));
				if (!CloneStartCap && StartMaterial != EndMaterial)
				{
					cGVMesh.AddSubMesh(new CGVSubMesh(triangles, EndMaterial));
				}
				else
				{
					cGVSubMesh.Material = StartMaterial;
					cGVSubMesh.Triangles = ArrayExt.AddRange(cGVSubMesh.Triangles, triangles);
				}
				if (GenerateUV)
				{
					Array.Resize(ref cGVMesh.UV, cGVMesh.UV.Length + vertices2.Length);
					applyUV(vertices2, ref cGVMesh.UV, vertices.Length, vertices2.Length, polygon.Bounds.Bounds, (!CloneStartCap) ? EndMaterialSettings : StartMaterialSettings);
				}
			}
			OutVMesh.SetData(cGVMesh);
		}

		private Vector3[] applyMat(Vector3[] vt, Matrix4x4 mat)
		{
			Vector3[] array = new Vector3[vt.Length];
			for (int i = 0; i < vt.Length; i++)
			{
				array[i] = mat.MultiplyPoint(vt[i]);
			}
			return array;
		}

		private Matrix4x4 getMat(CGVolume vol, int index, bool inverse)
		{
			if (inverse)
			{
				Quaternion q = Quaternion.LookRotation(vol.Direction[index], vol.Normal[index]);
				return Matrix4x4.TRS(vol.Position[index], q, Vector3.one);
			}
			Quaternion quaternion = Quaternion.Inverse(Quaternion.LookRotation(vol.Direction[index], vol.Normal[index]));
			return Matrix4x4.TRS(-(quaternion * vol.Position[index]), quaternion, Vector3.one);
		}

		private Vector3[] make2DSegment(CGVolume vol, int index)
		{
			Matrix4x4 mat = getMat(vol, index, false);
			Vector3[] segmentVertices = vol.GetSegmentVertices(index);
			HashSet<Vector3> hashSet = new HashSet<Vector3>();
			List<Vector3> list = new List<Vector3>(segmentVertices.Length);
			Vector3 vector = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			for (int i = 0; i < segmentVertices.Length; i++)
			{
				Vector3 vector2 = mat.MultiplyPoint(segmentVertices[i]);
				if ((vector2 - vector).sqrMagnitude > 0.001f && hashSet.Add(vector2))
				{
					list.Add(vector2);
				}
				vector = vector2;
			}
			return list.ToArray();
		}

		private void applyUV(Vector3[] vts, ref Vector2[] uvArray, int index, int count, Bounds bounds, CGMaterialSettings mat)
		{
			float x = bounds.size.x;
			float y = bounds.size.y;
			float x2 = bounds.min.x;
			float y2 = bounds.min.y;
			float num = mat.UVScale.x;
			float num2 = mat.UVScale.y;
			switch (mat.KeepAspect)
			{
			case CGKeepAspectMode.ScaleU:
			{
				float num5 = x * mat.UVScale.x;
				float num6 = y * mat.UVScale.y;
				num *= num5 / num6;
				break;
			}
			case CGKeepAspectMode.ScaleV:
			{
				float num3 = x * mat.UVScale.x;
				float num4 = y * mat.UVScale.y;
				num2 *= num4 / num3;
				break;
			}
			}
			if (mat.UVRotation != 0f)
			{
				float f = mat.UVRotation * ((float)Math.PI / 180f);
				float num7 = Mathf.Sin(f);
				float num8 = Mathf.Cos(f);
				float num9 = num * 0.5f;
				float num10 = num2 * 0.5f;
				for (int i = 0; i < count; i++)
				{
					float num11 = (vts[i].x - x2) / x * num;
					float num12 = (vts[i].y - y2) / y * num2;
					float num13 = num11 - num9;
					float num14 = num12 - num10;
					num11 = num8 * num13 - num7 * num14 + num9 + mat.UVOffset.x;
					num12 = num7 * num13 + num8 * num14 + num10 + mat.UVOffset.y;
					uvArray[i + index] = ((!mat.SwapUV) ? new Vector2(num11, num12) : new Vector2(num12, num11));
				}
			}
			else
			{
				for (int j = 0; j < count; j++)
				{
					float num11 = mat.UVOffset.x + (vts[j].x - x2) / x * num;
					float num12 = mat.UVOffset.y + (vts[j].y - y2) / y * num2;
					uvArray[j + index] = ((!mat.SwapUV) ? new Vector2(num11, num12) : new Vector2(num12, num11));
				}
			}
		}
	}
}
