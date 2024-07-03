using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class FriendInfo
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _003CUserId_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _003CIsOnline_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string _003CRoom_003Ek__BackingField;

	[Obsolete("Use UserId.")]
	public string Name
	{
		get
		{
			return UserId;
		}
	}

	public string UserId
	{
		[CompilerGenerated]
		get
		{
			return _003CUserId_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected internal set
		{
			_003CUserId_003Ek__BackingField = value;
		}
	}

	public bool IsOnline
	{
		[CompilerGenerated]
		get
		{
			return _003CIsOnline_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected internal set
		{
			_003CIsOnline_003Ek__BackingField = value;
		}
	}

	public string Room
	{
		[CompilerGenerated]
		get
		{
			return _003CRoom_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected internal set
		{
			_003CRoom_003Ek__BackingField = value;
		}
	}

	public bool IsInRoom
	{
		get
		{
			return IsOnline && !string.IsNullOrEmpty(Room);
		}
	}

	public override string ToString()
	{
		return string.Format("{0}\t is: {1}", UserId, (!IsOnline) ? "offline" : ((!IsInRoom) ? "on master" : "playing"));
	}
}
