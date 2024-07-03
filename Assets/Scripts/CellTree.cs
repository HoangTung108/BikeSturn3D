using System.Diagnostics;
using System.Runtime.CompilerServices;

public class CellTree
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CellTreeNode _003CRootNode_003Ek__BackingField;

	public CellTreeNode RootNode
	{
		[CompilerGenerated]
		get
		{
			return _003CRootNode_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CRootNode_003Ek__BackingField = value;
		}
	}

	public CellTree()
	{
	}

	public CellTree(CellTreeNode root)
	{
		RootNode = root;
	}
}
