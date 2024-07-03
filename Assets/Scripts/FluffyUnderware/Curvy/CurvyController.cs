using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using FluffyUnderware.Curvy.Utils;
using FluffyUnderware.DevTools;
using FluffyUnderware.DevTools.Extensions;
using UnityEngine;

namespace FluffyUnderware.Curvy
{
	[ExecuteInEditMode]
	public class CurvyController : DTVersionedMonoBehaviour
	{
		public enum MoveModeEnum
		{
			Relative,
			AbsoluteExtrapolate,
			AbsolutePrecise
		}

		public enum OrientationModeEnum
		{
			None,
			Orientation,
			Tangent
		}

		public enum OrientationAxisEnum
		{
			Up,
			Down,
			Forward,
			Backward,
			Left,
			Right
		}

		[Section("General", true, false, 100, Sort = 0, HelpURL = "http://www.fluffyunderware.com/curvy/doclink/200/curvycontroller_general")]
		[Label(Tooltip = "Determines when to update")]
		public CurvyUpdateMethod UpdateIn;

		[SerializeField]
		private Space m_Space;

		[Section("Position", true, false, 100, HelpURL = "http://www.fluffyunderware.com/curvy/doclink/200/curvycontroller_position")]
		[SerializeField]
		private CurvyPositionMode m_PositionMode;

		[SerializeField]
		[RangeEx(0f, "maxPosition", "", "")]
		private float m_InitialPosition;

		[Section("Move", true, false, 100, HelpURL = "http://www.fluffyunderware.com/curvy/doclink/200/curvycontroller_move")]
		[SerializeField]
		private MoveModeEnum m_MoveMode = MoveModeEnum.AbsolutePrecise;

		[SerializeField]
		private float m_Speed;

		[SerializeField]
		private CurvyClamping m_Clamping = CurvyClamping.Loop;

		[SerializeField]
		private bool m_PlayAutomatically = true;

		[SerializeField]
		private bool m_AdaptOnChange = true;

		[SerializeField]
		private bool m_Animate;

		[SerializeField]
		[FieldCondition("m_Animate", true, false, ActionAttribute.ActionEnum.Show, null, ActionAttribute.ActionPositionEnum.Below)]
		private AnimationCurve m_Animation = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		[FieldCondition("m_Animate", true, false, ActionAttribute.ActionEnum.Show, null, ActionAttribute.ActionPositionEnum.Below)]
		[SerializeField]
		private float m_TimeScale = 1f;

		[SerializeField]
		[FieldCondition("m_Animate", true, false, ActionAttribute.ActionEnum.Show, null, ActionAttribute.ActionPositionEnum.Below)]
		private bool m_SingleShot;

		[FieldCondition("m_Animate", true, false, ActionAttribute.ActionEnum.Show, null, ActionAttribute.ActionPositionEnum.Below)]
		[SerializeField]
		private bool m_ResetOnStop;

		[SerializeField]
		[Label("Source", "Source Vector")]
		[Section("Orientation", true, false, 100, HelpURL = "http://www.fluffyunderware.com/curvy/doclink/200/curvycontroller_orientation")]
		private OrientationModeEnum m_OrientationMode = OrientationModeEnum.Orientation;

		[Label("Target", "Target Vector3")]
		[SerializeField]
		private OrientationAxisEnum m_OrientationAxis;

		[Positive]
		[SerializeField]
		private float m_DampingDirection;

		[SerializeField]
		[Positive]
		private float m_DampingUp;

		[SerializeField]
		[Tooltip("Ignore direction when moving backwards?")]
		private bool m_IgnoreDirection;

		private float mTF;

		private int mDirection;

		private float mInitialVirtualPos;

		private bool mIsPlaying;

		private float mShotTime;

		private float mShotStartTF;

		private float mShotStartDistance;

		private GameObject mGameObject;

		private Vector3 mDampingDirVelocity;

		private Vector3 mDampingUpVelocity;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private float _003COrientationDamping_003Ek__BackingField;

		public Space Space
		{
			get
			{
				return m_Space;
			}
			set
			{
				if (m_Space != value)
				{
					m_Space = value;
				}
			}
		}

		public CurvyPositionMode PositionMode
		{
			get
			{
				return m_PositionMode;
			}
			set
			{
				if (m_PositionMode != value)
				{
					m_PositionMode = value;
					if (!Application.isPlaying)
					{
						Prepare();
					}
				}
			}
		}

		public MoveModeEnum MoveMode
		{
			get
			{
				return m_MoveMode;
			}
			set
			{
				if (m_MoveMode != value)
				{
					m_MoveMode = value;
				}
			}
		}

		public bool PlayAutomatically
		{
			get
			{
				return m_PlayAutomatically;
			}
			set
			{
				if (m_PlayAutomatically != value)
				{
					m_PlayAutomatically = value;
				}
			}
		}

		public virtual bool AdaptOnChange
		{
			get
			{
				return m_AdaptOnChange;
			}
			set
			{
				if (m_AdaptOnChange != value)
				{
					m_AdaptOnChange = value;
				}
			}
		}

		public bool Animate
		{
			get
			{
				return m_Animate;
			}
			set
			{
				if (m_Animate != value)
				{
					m_Animate = value;
				}
			}
		}

		public AnimationCurve Animation
		{
			get
			{
				return m_Animation;
			}
			set
			{
				if (m_Animation != value)
				{
					m_Animation = value;
				}
			}
		}

		public float TimeScale
		{
			get
			{
				return m_TimeScale;
			}
			set
			{
				if (m_TimeScale != value)
				{
					m_TimeScale = value;
				}
			}
		}

		public bool SingleShot
		{
			get
			{
				return m_SingleShot;
			}
			set
			{
				if (m_SingleShot != value)
				{
					m_SingleShot = value;
				}
			}
		}

		public bool ResetOnStop
		{
			get
			{
				return m_ResetOnStop;
			}
			set
			{
				if (m_ResetOnStop != value)
				{
					m_ResetOnStop = value;
				}
			}
		}

		public CurvyClamping Clamping
		{
			get
			{
				return m_Clamping;
			}
			set
			{
				if (m_Clamping != value)
				{
					m_Clamping = value;
				}
			}
		}

		public OrientationModeEnum OrientationMode
		{
			get
			{
				return m_OrientationMode;
			}
			set
			{
				if (m_OrientationMode != value)
				{
					m_OrientationMode = value;
				}
			}
		}

		public OrientationAxisEnum OrientationAxis
		{
			get
			{
				return m_OrientationAxis;
			}
			set
			{
				if (m_OrientationAxis != value)
				{
					m_OrientationAxis = value;
				}
			}
		}

		public float DampingDirection
		{
			get
			{
				return m_DampingDirection;
			}
			set
			{
				float num = Mathf.Max(0f, value);
				if (m_DampingDirection != num)
				{
					m_DampingDirection = num;
				}
			}
		}

		public float DampingUp
		{
			get
			{
				return m_DampingUp;
			}
			set
			{
				float num = Mathf.Max(0f, value);
				if (m_DampingUp != num)
				{
					m_DampingUp = num;
				}
			}
		}

		public bool IgnoreDirection
		{
			get
			{
				return m_IgnoreDirection;
			}
			set
			{
				if (m_IgnoreDirection != value)
				{
					m_IgnoreDirection = value;
				}
			}
		}

		public virtual float InitialPosition
		{
			get
			{
				return m_InitialPosition;
			}
			set
			{
				float num = m_InitialPosition;
				switch (PositionMode)
				{
				case CurvyPositionMode.Relative:
					num = CurvyUtility.ClampTF(value, Clamping);
					break;
				case CurvyPositionMode.WorldUnits:
					if (IsInitialized)
					{
						num = CurvyUtility.ClampDistance(value, Clamping, Length);
					}
					break;
				}
				if (m_InitialPosition != num)
				{
					m_InitialPosition = num;
					if (!Application.isPlaying)
					{
						Prepare();
					}
				}
				mInitialVirtualPos = num;
			}
		}

		public float Speed
		{
			get
			{
				return m_Speed;
			}
			set
			{
				if (m_Speed != value)
				{
					m_Speed = value;
				}
				mDirection = (int)Mathf.Sign(m_Speed);
			}
		}

		public float RelativePosition
		{
			get
			{
				return mTF;
			}
			set
			{
				if (mTF != value)
				{
					mTF = CurvyUtility.ClampTF(value, Clamping);
					if (Animate && IsPlaying)
					{
						Stop();
					}
				}
			}
		}

		public float AbsolutePosition
		{
			get
			{
				return RelativeToAbsolute(mTF);
			}
			set
			{
				float num = AbsoluteToRelative(value);
				if (mTF != num)
				{
					mTF = num;
					if (Animate && IsPlaying)
					{
						Stop();
					}
				}
			}
		}

		public float Position
		{
			get
			{
				if (MoveMode == MoveModeEnum.Relative)
				{
					return mTF;
				}
				return RelativeToAbsolute(mTF);
			}
			set
			{
				float num = ((MoveMode != 0) ? AbsoluteToRelative(value) : CurvyUtility.ClampTF(value, Clamping));
				if (mTF != num)
				{
					mTF = num;
					if (Animate && IsPlaying)
					{
						Stop();
					}
				}
			}
		}

		public bool Active
		{
			get
			{
				return mGameObject != null && mGameObject.activeInHierarchy;
			}
		}

		public float DeltaTime
		{
			get
			{
				return DTTime.deltaTime;
			}
		}

		public float AbsSpeed
		{
			get
			{
				return Mathf.Abs(Speed);
			}
		}

		public bool IsPlaying
		{
			get
			{
				return mIsPlaying;
			}
		}

		public int Direction
		{
			get
			{
				return mDirection;
			}
			set
			{
				int num = (int)Mathf.Sign(value);
				if (mDirection != num)
				{
					mDirection = num;
				}
			}
		}

		public virtual bool IsConfigured
		{
			get
			{
				return true;
			}
		}

		public virtual bool IsInitialized
		{
			get
			{
				return IsConfigured && (MoveMode == MoveModeEnum.Relative || Length > 0f);
			}
		}

		public virtual float Length
		{
			get
			{
				return 0f;
			}
		}

		private float maxPosition
		{
			get
			{
				return (PositionMode != 0) ? Length : 1f;
			}
		}

		[Obsolete("Use OrientationVelocity instead!")]
		public float OrientationDamping
		{
			[CompilerGenerated]
			get
			{
				return _003COrientationDamping_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003COrientationDamping_003Ek__BackingField = value;
			}
		}

		protected virtual void OnEnable()
		{
			mGameObject = base.gameObject;
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void Update()
		{
			if (UpdateIn == CurvyUpdateMethod.Update && Application.isPlaying && Speed != 0f)
			{
				Refresh();
			}
		}

		protected virtual void LateUpdate()
		{
			if (UpdateIn == CurvyUpdateMethod.LateUpdate && Speed != 0f)
			{
				Refresh();
			}
		}

		protected virtual void FixedUpdate()
		{
			if (UpdateIn == CurvyUpdateMethod.FixedUpdate && Speed != 0f)
			{
				Refresh();
			}
		}

		protected virtual void OnTransformParentChanged()
		{
			Prepare();
		}

		protected virtual void Reset()
		{
			UpdateIn = CurvyUpdateMethod.Update;
			PositionMode = CurvyPositionMode.Relative;
			InitialPosition = 0f;
			PlayAutomatically = true;
			MoveMode = MoveModeEnum.AbsolutePrecise;
			Speed = 0f;
			Animate = false;
			Animation = AnimationCurve.Linear(0f, 1f, 1f, 1f);
			TimeScale = 1f;
			SingleShot = false;
			ResetOnStop = false;
			Clamping = CurvyClamping.Loop;
			OrientationMode = OrientationModeEnum.Orientation;
			OrientationAxis = OrientationAxisEnum.Up;
			IgnoreDirection = false;
		}

		public virtual void EditorUpdate()
		{
			Refresh();
		}

		public virtual void Prepare()
		{
			if (IsPlaying)
			{
				Stop();
			}
			if (IsConfigured && IsInitialized)
			{
				mDirection = (int)Mathf.Sign(Speed);
				mTF = GetTF(InitialPosition);
				applyPositionAndRotation(mTF);
				UserAfterInit();
				if (PlayAutomatically && Application.isPlaying)
				{
					Play();
				}
			}
		}

		public virtual void Play()
		{
			if (IsInitialized)
			{
				if (IsPlaying)
				{
					Stop();
				}
				mShotStartTF = mTF;
				if (Animate && MoveMode != 0)
				{
					mShotStartDistance = RelativeToAbsolute(mShotStartTF);
				}
				mShotTime = 0f;
				mIsPlaying = true;
			}
		}

		public virtual void Stop()
		{
			mShotTime = 0f;
			mIsPlaying = false;
			if (IsInitialized && Animate)
			{
				if (ResetOnStop)
				{
					mTF = mShotStartTF;
				}
				if (SingleShot)
				{
					applyPositionAndRotation(mTF);
				}
				else
				{
					Play();
				}
			}
		}

		public virtual void Warp(float delta)
		{
			int direction = (int)Mathf.Sign(delta);
			Advance(ref mTF, ref direction, MoveMode, Mathf.Abs(delta), Clamping);
			Vector3 position;
			if (OrientationMode != 0)
			{
				Vector3 tangent;
				Vector3 up;
				GetInterpolatedSourcePosition(mTF, out position, out tangent, out up);
				ApplyTransformRotation(GetRotation(tangent, up));
			}
			else
			{
				position = GetInterpolatedSourcePosition(mTF);
			}
			ApplyTransformPosition(position);
		}

		public virtual void Refresh()
		{
			if (!IsInitialized || !IsPlaying)
			{
				return;
			}
			mShotTime += DeltaTime;
			Vector3 position;
			Vector3 tangent;
			Vector3 up;
			if (Animate)
			{
				mTF = getAnimationTF();
				if (OrientationMode != 0)
				{
					GetInterpolatedSourcePosition(mTF, out position, out tangent, out up);
					ApplyTransformRotation(GetRotation(Vector3.SmoothDamp(base.transform.forward, tangent, ref mDampingDirVelocity, DampingDirection), Vector3.SmoothDamp(base.transform.up, up, ref mDampingUpVelocity, DampingUp)));
				}
				else
				{
					position = GetInterpolatedSourcePosition(mTF);
				}
				ApplyTransformPosition(position);
			}
			else
			{
				Advance(ref mTF, ref mDirection, MoveMode, AbsSpeed * DeltaTime / TimeScale, Clamping);
				if (OrientationMode != 0)
				{
					GetInterpolatedSourcePosition(mTF, out position, out tangent, out up);
					ApplyTransformRotation(GetRotation(Vector3.SmoothDamp(base.transform.forward, tangent, ref mDampingDirVelocity, DampingDirection), Vector3.SmoothDamp(base.transform.up, up, ref mDampingUpVelocity, DampingUp)));
				}
				else
				{
					position = GetInterpolatedSourcePosition(mTF);
				}
				ApplyTransformPosition(position);
			}
			UserAfterUpdate();
			if (Animate && mShotTime >= TimeScale)
			{
				Stop();
			}
		}

		public virtual void BeginPreview()
		{
			mInitialVirtualPos = InitialPosition;
			Play();
		}

		public virtual void EndPreview()
		{
			mIsPlaying = false;
			InitialPosition = mInitialVirtualPos;
			Speed = m_Speed;
			Prepare();
		}

		protected virtual void Advance(ref float tf, ref int direction, MoveModeEnum mode, float absSpeed, CurvyClamping clamping)
		{
		}

		protected virtual void ApplyTransformRotation(Quaternion rotation)
		{
			base.transform.localRotation = rotation;
		}

		protected virtual void ApplyTransformPosition(Vector3 position)
		{
			if (Space == Space.Self)
			{
				base.transform.localPosition = position;
			}
			else
			{
				base.transform.position = position;
			}
		}

		protected virtual float AbsoluteToRelative(float worldUnitDistance)
		{
			return CurvyUtility.ClampTF(worldUnitDistance / Length, Clamping);
		}

		protected virtual float RelativeToAbsolute(float relativeDistance)
		{
			return CurvyUtility.ClampDistance(relativeDistance * Length, Clamping, Length);
		}

		protected float GetTF(float virtualPosition)
		{
			CurvyPositionMode positionMode = PositionMode;
			if (positionMode == CurvyPositionMode.WorldUnits)
			{
				return AbsoluteToRelative(virtualPosition);
			}
			return virtualPosition;
		}

		protected virtual Vector3 GetInterpolatedSourcePosition(float tf)
		{
			return Vector3.zero;
		}

		protected virtual void GetInterpolatedSourcePosition(float tf, out Vector3 position, out Vector3 tangent, out Vector3 up)
		{
			position = Vector3.zero;
			tangent = Vector3.forward;
			up = Vector3.up;
		}

		protected virtual Vector3 GetOrientation(float tf)
		{
			return base.transform.up;
		}

		protected virtual Quaternion GetRotation(Vector3 tangent, Vector3 up)
		{
			if (!IgnoreDirection && mDirection < 0)
			{
				tangent *= -1f;
			}
			if (OrientationMode == OrientationModeEnum.Tangent)
			{
				up = tangent;
				tangent = Vector3.forward;
			}
			switch (OrientationAxis)
			{
			case OrientationAxisEnum.Up:
				return Quaternion.LookRotation(tangent, up);
			case OrientationAxisEnum.Down:
				return Quaternion.LookRotation(tangent, up * -1f);
			case OrientationAxisEnum.Forward:
				return Quaternion.LookRotation(up, tangent * -1f);
			case OrientationAxisEnum.Backward:
				return Quaternion.LookRotation(up, tangent);
			case OrientationAxisEnum.Left:
				return Quaternion.LookRotation(tangent, Vector3.Cross(up, tangent));
			case OrientationAxisEnum.Right:
				return Quaternion.LookRotation(tangent, Vector3.Cross(tangent, up));
			default:
				return Quaternion.identity;
			}
		}

		protected virtual Vector3 GetTangent(float tf)
		{
			return Vector3.forward;
		}

		protected virtual void BindEvents()
		{
		}

		protected virtual void UnbindEvents()
		{
		}

		protected virtual void UserAfterInit()
		{
		}

		protected virtual void UserAfterUpdate()
		{
		}

		public void SetFromString(string fieldAndValue)
		{
			string[] array = fieldAndValue.Split('=');
			if (array.Length != 2)
			{
				return;
			}
			FieldInfo fieldIncludingBaseClasses = TypeExt.GetFieldIncludingBaseClasses(GetType(), array[0], BindingFlags.Instance | BindingFlags.Public);
			if (fieldIncludingBaseClasses != null)
			{
				try
				{
					if (fieldIncludingBaseClasses.FieldType.IsEnum)
					{
						fieldIncludingBaseClasses.SetValue(this, Enum.Parse(fieldIncludingBaseClasses.FieldType, array[1]));
					}
					else
					{
						fieldIncludingBaseClasses.SetValue(this, Convert.ChangeType(array[1], fieldIncludingBaseClasses.FieldType));
					}
				}
				catch (Exception ex)
				{
					UnityEngine.Debug.LogWarning(base.name + ".SetFromString(): " + ex.ToString());
				}
				return;
			}
			PropertyInfo propertyIncludingBaseClasses = TypeExt.GetPropertyIncludingBaseClasses(GetType(), array[0], BindingFlags.Instance | BindingFlags.Public);
			if (propertyIncludingBaseClasses == null)
			{
				return;
			}
			try
			{
				if (propertyIncludingBaseClasses.PropertyType.IsEnum)
				{
					propertyIncludingBaseClasses.SetValue(this, Enum.Parse(propertyIncludingBaseClasses.PropertyType, array[1]), null);
				}
				else
				{
					propertyIncludingBaseClasses.SetValue(this, Convert.ChangeType(array[1], propertyIncludingBaseClasses.PropertyType), null);
				}
			}
			catch (Exception ex2)
			{
				UnityEngine.Debug.LogWarning(base.name + ".SetFromString(): " + ex2.ToString());
			}
		}

		private void applyPositionAndRotation(float tf)
		{
			Vector3 position;
			if (OrientationMode != 0)
			{
				Vector3 tangent;
				Vector3 up;
				GetInterpolatedSourcePosition(tf, out position, out tangent, out up);
				ApplyTransformRotation(GetRotation(tangent, up));
			}
			else
			{
				position = GetInterpolatedSourcePosition(tf);
			}
			ApplyTransformPosition(position);
		}

		private float getAnimationTF()
		{
			float num = AbsSpeed * Animation.Evaluate(Mathf.Clamp01(mShotTime / TimeScale));
			mDirection = (int)Mathf.Sign(num);
			return (MoveMode != 0) ? AbsoluteToRelative(mShotStartDistance + num) : (mShotStartTF + num);
		}
	}
}
