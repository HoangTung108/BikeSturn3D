using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class AuthenticationValues
{
	private CustomAuthenticationType authType = CustomAuthenticationType.None;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string _003CAuthGetParameters_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object _003CAuthPostData_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string _003CToken_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _003CUserId_003Ek__BackingField;

	public CustomAuthenticationType AuthType
	{
		get
		{
			return authType;
		}
		set
		{
			authType = value;
		}
	}

	public string AuthGetParameters
	{
		[CompilerGenerated]
		get
		{
			return _003CAuthGetParameters_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CAuthGetParameters_003Ek__BackingField = value;
		}
	}

	public object AuthPostData
	{
		[CompilerGenerated]
		get
		{
			return _003CAuthPostData_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CAuthPostData_003Ek__BackingField = value;
		}
	}

	public string Token
	{
		[CompilerGenerated]
		get
		{
			return _003CToken_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CToken_003Ek__BackingField = value;
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
		set
		{
			_003CUserId_003Ek__BackingField = value;
		}
	}

	public AuthenticationValues()
	{
	}

	public AuthenticationValues(string userId)
	{
		UserId = userId;
	}

	public virtual void SetAuthPostData(string stringData)
	{
		AuthPostData = ((!string.IsNullOrEmpty(stringData)) ? stringData : null);
	}

	public virtual void SetAuthPostData(byte[] byteData)
	{
		AuthPostData = byteData;
	}

	public virtual void SetAuthPostData(Dictionary<string, object> dictData)
	{
		AuthPostData = dictData;
	}

	public virtual void AddAuthParameter(string key, string value)
	{
		string text = ((!string.IsNullOrEmpty(AuthGetParameters)) ? "&" : string.Empty);
		AuthGetParameters = string.Format("{0}{1}{2}={3}", AuthGetParameters, text, Uri.EscapeDataString(key), Uri.EscapeDataString(value));
	}

	public override string ToString()
	{
		return string.Format("AuthenticationValues UserId: {0}, GetParameters: {1} Token available: {2}", UserId, AuthGetParameters, Token != null);
	}
}
