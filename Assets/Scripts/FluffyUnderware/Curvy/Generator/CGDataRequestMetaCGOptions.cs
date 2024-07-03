namespace FluffyUnderware.Curvy.Generator
{
	public class CGDataRequestMetaCGOptions : CGDataRequestParameter
	{
		public bool CheckHardEdges;

		public bool CheckMaterialID;

		public bool IncludeControlPoints;

		public bool CheckExtendedUV;

		public CGDataRequestMetaCGOptions(bool checkEdges, bool checkMaterials, bool includeCP, bool extendedUV)
		{
			CheckHardEdges = checkEdges;
			CheckMaterialID = checkMaterials;
			IncludeControlPoints = includeCP;
			CheckExtendedUV = extendedUV;
		}

		public override bool Equals(object obj)
		{
			CGDataRequestMetaCGOptions cGDataRequestMetaCGOptions = obj as CGDataRequestMetaCGOptions;
			if (cGDataRequestMetaCGOptions == null)
			{
				return false;
			}
			return CheckHardEdges == cGDataRequestMetaCGOptions.CheckHardEdges && CheckMaterialID == cGDataRequestMetaCGOptions.CheckMaterialID && IncludeControlPoints == cGDataRequestMetaCGOptions.IncludeControlPoints && CheckExtendedUV == cGDataRequestMetaCGOptions.CheckExtendedUV;
		}

		public override int GetHashCode()
		{
			return new _003C_003E__AnonType0<bool, bool, bool, bool>(CheckHardEdges, CheckMaterialID, IncludeControlPoints, CheckExtendedUV).GetHashCode();
		}
	}
}
