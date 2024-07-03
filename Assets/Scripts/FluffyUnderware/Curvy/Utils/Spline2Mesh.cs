using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FluffyUnderware.Curvy.ThirdParty.poly2tri;
using UnityEngine;

namespace FluffyUnderware.Curvy.Utils
{
	public class Spline2Mesh
	{
		public SplinePolyLine Outline;

		public List<SplinePolyLine> Holes = new List<SplinePolyLine>();

		public Vector2 UVTiling = Vector2.one;

		public Vector2 UVOffset = Vector2.zero;

		public bool SuppressUVMapping;

		public bool UV2;

		public string MeshName = string.Empty;

		public bool VertexLineOnly;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _003CError_003Ek__BackingField;

		private bool mUseMeshBounds;

		private Vector2 mNewBounds;

		private Polygon p2t;

		private Mesh mMesh;

		public string Error
		{
			[CompilerGenerated]
			get
			{
				return _003CError_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CError_003Ek__BackingField = value;
			}
		}

		public bool Apply(out Mesh result)
		{
			p2t = null;
			mMesh = null;
			Error = string.Empty;
			if (triangulate() && buildMesh())
			{
				if (!SuppressUVMapping && !VertexLineOnly)
				{
					uvmap();
				}
				result = mMesh;
				return true;
			}
			if ((bool)mMesh)
			{
				mMesh.RecalculateNormals();
			}
			result = mMesh;
			return false;
		}

		public void SetBounds(bool useMeshBounds, Vector2 newSize)
		{
			mUseMeshBounds = useMeshBounds;
			mNewBounds = newSize;
		}

		private bool triangulate()
		{
			if (Outline == null || Outline.Spline == null)
			{
				Error = "Missing Outline Spline";
				return false;
			}
			if (!polyLineIsValid(Outline))
			{
				Error = Outline.Spline.name + ": Angle must be >0";
				return false;
			}
			Vector3[] vertices = Outline.getVertices();
			if (vertices.Length < 3)
			{
				Error = Outline.Spline.name + ": At least 3 Vertices needed!";
				return false;
			}
			p2t = new Polygon(vertices);
			if (VertexLineOnly)
			{
				return true;
			}
			for (int i = 0; i < Holes.Count; i++)
			{
				if (Holes[i].Spline == null)
				{
					Error = "Missing Hole Spline";
					return false;
				}
				if (!polyLineIsValid(Holes[i]))
				{
					Error = Holes[i].Spline.name + ": Angle must be >0";
					return false;
				}
				Vector3[] vertices2 = Holes[i].getVertices();
				if (vertices2.Length < 3)
				{
					Error = Holes[i].Spline.name + ": At least 3 Vertices needed!";
					return false;
				}
				p2t.AddHole(new Polygon(vertices2));
			}
			try
			{
				P2T.Triangulate(p2t);
				return true;
			}
			catch (Exception ex)
			{
				Error = ex.Message;
			}
			return false;
		}

		private bool polyLineIsValid(SplinePolyLine pl)
		{
			return (pl != null && pl.VertexMode == SplinePolyLine.VertexCalculation.ByApproximation) || !Mathf.Approximately(0f, pl.Angle);
		}

		private bool buildMesh()
		{
			mMesh = new Mesh();
			mMesh.name = MeshName;
			if (VertexLineOnly)
			{
				mMesh.vertices = Outline.getVertices();
			}
			else
			{
				List<Vector3> list = new List<Vector3>();
				List<int> list2 = new List<int>();
				for (int i = 0; i < p2t.Triangles.Count; i++)
				{
					DelaunayTriangle delaunayTriangle = p2t.Triangles[i];
					for (int j = 0; j < 3; j++)
					{
						if (!list.Contains(delaunayTriangle.Points[j].V3))
						{
							list.Add(delaunayTriangle.Points[j].V3);
						}
					}
					list2.Add(list.IndexOf(delaunayTriangle.Points[2].V3));
					list2.Add(list.IndexOf(delaunayTriangle.Points[1].V3));
					list2.Add(list.IndexOf(delaunayTriangle.Points[0].V3));
				}
				mMesh.vertices = list.ToArray();
				mMesh.triangles = list2.ToArray();
			}
			mMesh.RecalculateBounds();
			return true;
		}

		private void uvmap()
		{
			Bounds bounds = mMesh.bounds;
			Vector2 vector = bounds.size;
			if (!mUseMeshBounds)
			{
				vector = mNewBounds;
			}
			Vector3[] vertices = mMesh.vertices;
			Vector2[] array = new Vector2[vertices.Length];
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < vertices.Length; i++)
			{
				float num3 = UVOffset.x + (vertices[i].x - bounds.min.x) / vector.x;
				float num4 = UVOffset.y + (vertices[i].y - bounds.min.y) / vector.y;
				num3 *= UVTiling.x;
				num4 *= UVTiling.y;
				num = Mathf.Max(num3, num);
				num2 = Mathf.Max(num4, num2);
				array[i] = new Vector2(num3, num4);
			}
			mMesh.uv = array;
			Vector2[] array2 = new Vector2[0];
			if (UV2)
			{
				array2 = new Vector2[array.Length];
				for (int j = 0; j < vertices.Length; j++)
				{
					array2[j] = new Vector2(array[j].x / num, array[j].y / num2);
				}
			}
			mMesh.uv2 = array2;
			mMesh.RecalculateNormals();
		}
	}
}
