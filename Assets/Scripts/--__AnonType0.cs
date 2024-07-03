using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

[CompilerGenerated]
internal sealed class _003C_003E__AnonType0<_003CA_003E__T, _003CB_003E__T, _003CC_003E__T, _003CD_003E__T>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003CA_003E__T _003CA_003E;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003CB_003E__T _003CB_003E;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003CC_003E__T _003CC_003E;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003CD_003E__T _003CD_003E;

	public _003CA_003E__T A
	{
		get
		{
			return _003CA_003E;
		}
	}

	public _003CB_003E__T B
	{
		get
		{
			return _003CB_003E;
		}
	}

	public _003CC_003E__T C
	{
		get
		{
			return _003CC_003E;
		}
	}

	public _003CD_003E__T D
	{
		get
		{
			return _003CD_003E;
		}
	}

	[DebuggerHidden]
	public _003C_003E__AnonType0(_003CA_003E__T A, _003CB_003E__T B, _003CC_003E__T C, _003CD_003E__T D)
	{
		_003CA_003E = A;
		_003CB_003E = B;
		_003CC_003E = C;
		_003CD_003E = D;
	}

	[DebuggerHidden]
	public override bool Equals(object obj)
	{
		_003C_003E__AnonType0<_003CA_003E__T, _003CB_003E__T, _003CC_003E__T, _003CD_003E__T> anon = obj as _003C_003E__AnonType0<_003CA_003E__T, _003CB_003E__T, _003CC_003E__T, _003CD_003E__T>;
		return anon != null && EqualityComparer<_003CA_003E__T>.Default.Equals(_003CA_003E, anon._003CA_003E) && EqualityComparer<_003CB_003E__T>.Default.Equals(_003CB_003E, anon._003CB_003E) && EqualityComparer<_003CC_003E__T>.Default.Equals(_003CC_003E, anon._003CC_003E) && EqualityComparer<_003CD_003E__T>.Default.Equals(_003CD_003E, anon._003CD_003E);
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = (((((((-2128831035 ^ EqualityComparer<_003CA_003E__T>.Default.GetHashCode(_003CA_003E)) * 16777619) ^ EqualityComparer<_003CB_003E__T>.Default.GetHashCode(_003CB_003E)) * 16777619) ^ EqualityComparer<_003CC_003E__T>.Default.GetHashCode(_003CC_003E)) * 16777619) ^ EqualityComparer<_003CD_003E__T>.Default.GetHashCode(_003CD_003E)) * 16777619;
		num += num << 13;
		num ^= num >> 7;
		num += num << 3;
		num ^= num >> 17;
		return num + (num << 5);
	}

	[DebuggerHidden]
	public override string ToString()
	{
		string[] obj = new string[10] { "{", " A = ", null, null, null, null, null, null, null, null };
		string text;
		if (_003CA_003E != null)
		{
			_003CA_003E__T val = _003CA_003E;
			text = val.ToString();
		}
		else
		{
			text = string.Empty;
		}
		obj[2] = text;
		obj[3] = ", B = ";
		string text2;
		if (_003CB_003E != null)
		{
			_003CB_003E__T val2 = _003CB_003E;
			text2 = val2.ToString();
		}
		else
		{
			text2 = string.Empty;
		}
		obj[4] = text2;
		obj[5] = ", C = ";
		string text3;
		if (_003CC_003E != null)
		{
			_003CC_003E__T val3 = _003CC_003E;
			text3 = val3.ToString();
		}
		else
		{
			text3 = string.Empty;
		}
		obj[6] = text3;
		obj[7] = ", D = ";
		string text4;
		if (_003CD_003E != null)
		{
			_003CD_003E__T val4 = _003CD_003E;
			text4 = val4.ToString();
		}
		else
		{
			text4 = string.Empty;
		}
		obj[8] = text4;
		obj[9] = " }";
		return string.Concat(obj);
	}
}
