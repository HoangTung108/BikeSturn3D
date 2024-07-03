using System;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyUnderware.Curvy.Utils
{
	[Serializable]
	public class SplinePolyLine
	{
		public enum VertexCalculation
		{
			ByApproximation,
			ByAngle
		}

		public CurvySplineBase Spline;

		public VertexCalculation VertexMode;

		public float Angle;

		public float Distance;

		public Space Space;

		public bool IsClosed
		{
			get
			{
				return (bool)Spline && Spline.IsClosed;
			}
		}

		public bool IsContinuous
		{
			get
			{
				return (bool)Spline && Spline.IsContinuous;
			}
		}

		public SplinePolyLine(CurvySplineBase spline)
			: this(spline, VertexCalculation.ByApproximation, 0f, 0f)
		{
		}

		public SplinePolyLine(CurvySplineBase spline, float angle, float distance)
			: this(spline, VertexCalculation.ByAngle, angle, distance)
		{
		}

		private SplinePolyLine(CurvySplineBase spline, VertexCalculation vertexMode, float angle, float distance, Space space = Space.World)
		{
			Spline = spline;
			VertexMode = vertexMode;
			Angle = angle;
			Distance = distance;
			Space = space;
		}

		public Vector3[] getVertices()
		{
			Vector3[] array = new Vector3[0];
			VertexCalculation vertexMode = VertexMode;
			List<float> vertexTF;
			List<Vector3> vertexTangents;
			array = ((vertexMode != VertexCalculation.ByAngle) ? Spline.GetApproximation(Space.Self) : Spline.GetPolygon(0f, 1f, Angle, Distance, -1f, out vertexTF, out vertexTangents, false));
			if (Space == Space.World)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = Spline.transform.TransformPoint(array[i]);
				}
			}
			return array;
		}
	}
}
