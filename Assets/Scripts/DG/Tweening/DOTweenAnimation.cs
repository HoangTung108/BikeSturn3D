using System;
using System.Collections.Generic;
using DG.Tweening.Core;
using UnityEngine;
using UnityEngine.UI;

namespace DG.Tweening
{
	[AddComponentMenu("DOTween/DOTween Animation")]
	public class DOTweenAnimation : ABSAnimationComponent
	{
		public float delay;

		public float duration = 1f;

		public Ease easeType = Ease.OutQuad;

		public AnimationCurve easeCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		public LoopType loopType;

		public int loops = 1;

		public string id = string.Empty;

		public bool isRelative;

		public bool isFrom;

		public bool isIndependentUpdate;

		public bool autoKill = true;

		public bool isActive = true;

		public bool isValid;

		public Component target;

		public DOTweenAnimationType animationType;

		public TargetType targetType;

		public TargetType forcedTargetType;

		public bool autoPlay = true;

		public bool useTargetAsV3;

		public float endValueFloat;

		public Vector3 endValueV3;

		public Vector2 endValueV2;

		public Color endValueColor = new Color(1f, 1f, 1f, 1f);

		public string endValueString = string.Empty;

		public Rect endValueRect = new Rect(0f, 0f, 0f, 0f);

		public Transform endValueTransform;

		public bool optionalBool0;

		public float optionalFloat0;

		public int optionalInt0;

		public RotateMode optionalRotationMode;

		public ScrambleMode optionalScrambleMode;

		public string optionalString;

		private bool _tweenCreated;

		private int _playCount = -1;

		private void Awake()
		{
			if (isActive && isValid && (animationType != DOTweenAnimationType.Move || !useTargetAsV3))
			{
				CreateTween();
				_tweenCreated = true;
			}
		}

		private void Start()
		{
			if (!_tweenCreated && isActive && isValid)
			{
				CreateTween();
				_tweenCreated = true;
			}
		}

		private void OnDestroy()
		{
			if (tween != null && TweenExtensions.IsActive(tween))
			{
				TweenExtensions.Kill(tween);
			}
			tween = null;
		}

		public void CreateTween()
		{
			if (target == null)
			{
				Debug.LogWarning(string.Format("{0} :: This tween's target is NULL, because the animation was created with a DOTween Pro version older than 0.9.255. To fix this, exit Play mode then simply select this object, and it will update automatically", base.gameObject.name), base.gameObject);
				return;
			}
			if (forcedTargetType != 0)
			{
				this.targetType = forcedTargetType;
			}
			if (this.targetType == TargetType.Unset)
			{
				this.targetType = TypeToDOTargetType(target.GetType());
			}
			switch (animationType)
			{
			case DOTweenAnimationType.Move:
				if (useTargetAsV3)
				{
					isRelative = false;
					if (endValueTransform == null)
					{
						Debug.LogWarning(string.Format("{0} :: This tween's TO target is NULL, a Vector3 of (0,0,0) will be used instead", base.gameObject.name), base.gameObject);
						endValueV3 = Vector3.zero;
					}
					else if (this.targetType == TargetType.RectTransform)
					{
						RectTransform rectTransform = endValueTransform as RectTransform;
						if (rectTransform == null)
						{
							Debug.LogWarning(string.Format("{0} :: This tween's TO target should be a RectTransform, a Vector3 of (0,0,0) will be used instead", base.gameObject.name), base.gameObject);
							endValueV3 = Vector3.zero;
						}
						else
						{
							RectTransform rectTransform2 = target as RectTransform;
							if (rectTransform2 == null)
							{
								Debug.LogWarning(string.Format("{0} :: This tween's target and TO target are not of the same type. Please reassign the values", base.gameObject.name), base.gameObject);
							}
							else
							{
								endValueV3 = DOTweenUtils46.SwitchToRectTransform(rectTransform, rectTransform2);
							}
						}
					}
					else
					{
						endValueV3 = endValueTransform.position;
					}
				}
				switch (this.targetType)
				{
				case TargetType.RectTransform:
					tween = ShortcutExtensions46.DOAnchorPos3D((RectTransform)target, endValueV3, duration, optionalBool0);
					break;
				case TargetType.Transform:
					tween = ShortcutExtensions.DOMove((Transform)target, endValueV3, duration, optionalBool0);
					break;
				case TargetType.Rigidbody2D:
					tween = ShortcutExtensions43.DOMove((Rigidbody2D)target, endValueV3, duration, optionalBool0);
					break;
				case TargetType.Rigidbody:
					tween = ShortcutExtensions.DOMove((Rigidbody)target, endValueV3, duration, optionalBool0);
					break;
				}
				break;
			case DOTweenAnimationType.LocalMove:
				tween = ShortcutExtensions.DOLocalMove(base.transform, endValueV3, duration, optionalBool0);
				break;
			case DOTweenAnimationType.Rotate:
				switch (this.targetType)
				{
				case TargetType.Transform:
					tween = ShortcutExtensions.DORotate((Transform)target, endValueV3, duration, optionalRotationMode);
					break;
				case TargetType.Rigidbody2D:
					tween = ShortcutExtensions43.DORotate((Rigidbody2D)target, endValueFloat, duration);
					break;
				case TargetType.Rigidbody:
					tween = ShortcutExtensions.DORotate((Rigidbody)target, endValueV3, duration, optionalRotationMode);
					break;
				}
				break;
			case DOTweenAnimationType.LocalRotate:
				tween = ShortcutExtensions.DOLocalRotate(base.transform, endValueV3, duration, optionalRotationMode);
				break;
			case DOTweenAnimationType.Scale:
				tween = ShortcutExtensions.DOScale(base.transform, (!optionalBool0) ? endValueV3 : new Vector3(endValueFloat, endValueFloat, endValueFloat), duration);
				break;
			case DOTweenAnimationType.UIWidthHeight:
				tween = ShortcutExtensions46.DOSizeDelta((RectTransform)target, (!optionalBool0) ? endValueV2 : new Vector2(endValueFloat, endValueFloat), duration);
				break;
			case DOTweenAnimationType.Color:
				isRelative = false;
				switch (this.targetType)
				{
				case TargetType.SpriteRenderer:
					tween = ShortcutExtensions43.DOColor((SpriteRenderer)target, endValueColor, duration);
					break;
				case TargetType.Renderer:
					tween = ShortcutExtensions.DOColor(((Renderer)target).material, endValueColor, duration);
					break;
				case TargetType.Image:
					tween = ShortcutExtensions46.DOColor((Image)target, endValueColor, duration);
					break;
				case TargetType.Text:
					tween = ShortcutExtensions46.DOColor((Text)target, endValueColor, duration);
					break;
				case TargetType.Light:
					tween = ShortcutExtensions.DOColor((Light)target, endValueColor, duration);
					break;
				}
				break;
			case DOTweenAnimationType.Fade:
				isRelative = false;
				switch (this.targetType)
				{
				case TargetType.SpriteRenderer:
					tween = ShortcutExtensions43.DOFade((SpriteRenderer)target, endValueFloat, duration);
					break;
				case TargetType.Renderer:
					tween = ShortcutExtensions.DOFade(((Renderer)target).material, endValueFloat, duration);
					break;
				case TargetType.Image:
					tween = ShortcutExtensions46.DOFade((Image)target, endValueFloat, duration);
					break;
				case TargetType.Text:
					tween = ShortcutExtensions46.DOFade((Text)target, endValueFloat, duration);
					break;
				case TargetType.Light:
					tween = ShortcutExtensions.DOIntensity((Light)target, endValueFloat, duration);
					break;
				case TargetType.CanvasGroup:
					tween = ShortcutExtensions46.DOFade((CanvasGroup)target, endValueFloat, duration);
					break;
				}
				break;
			case DOTweenAnimationType.Text:
			{
				TargetType targetType = this.targetType;
				if (targetType == TargetType.Text)
				{
					tween = ShortcutExtensions46.DOText((Text)target, endValueString, duration, optionalBool0, optionalScrambleMode, optionalString);
				}
				break;
			}
			case DOTweenAnimationType.PunchPosition:
				switch (this.targetType)
				{
				case TargetType.RectTransform:
					tween = ShortcutExtensions46.DOPunchAnchorPos((RectTransform)target, endValueV3, duration, optionalInt0, optionalFloat0, optionalBool0);
					break;
				case TargetType.Transform:
					tween = ShortcutExtensions.DOPunchPosition((Transform)target, endValueV3, duration, optionalInt0, optionalFloat0, optionalBool0);
					break;
				}
				break;
			case DOTweenAnimationType.PunchScale:
				tween = ShortcutExtensions.DOPunchScale(base.transform, endValueV3, duration, optionalInt0, optionalFloat0);
				break;
			case DOTweenAnimationType.PunchRotation:
				tween = ShortcutExtensions.DOPunchRotation(base.transform, endValueV3, duration, optionalInt0, optionalFloat0);
				break;
			case DOTweenAnimationType.ShakePosition:
				switch (this.targetType)
				{
				case TargetType.RectTransform:
					tween = ShortcutExtensions46.DOShakeAnchorPos((RectTransform)target, duration, endValueV3, optionalInt0, optionalFloat0, optionalBool0);
					break;
				case TargetType.Transform:
					tween = ShortcutExtensions.DOShakePosition((Transform)target, duration, endValueV3, optionalInt0, optionalFloat0, optionalBool0);
					break;
				}
				break;
			case DOTweenAnimationType.ShakeScale:
				tween = ShortcutExtensions.DOShakeScale(base.transform, duration, endValueV3, optionalInt0, optionalFloat0);
				break;
			case DOTweenAnimationType.ShakeRotation:
				tween = ShortcutExtensions.DOShakeRotation(base.transform, duration, endValueV3, optionalInt0, optionalFloat0);
				break;
			case DOTweenAnimationType.CameraAspect:
				tween = ShortcutExtensions.DOAspect((Camera)target, endValueFloat, duration);
				break;
			case DOTweenAnimationType.CameraBackgroundColor:
				tween = ShortcutExtensions.DOColor((Camera)target, endValueColor, duration);
				break;
			case DOTweenAnimationType.CameraFieldOfView:
				tween = ShortcutExtensions.DOFieldOfView((Camera)target, endValueFloat, duration);
				break;
			case DOTweenAnimationType.CameraOrthoSize:
				tween = ShortcutExtensions.DOOrthoSize((Camera)target, endValueFloat, duration);
				break;
			case DOTweenAnimationType.CameraPixelRect:
				tween = ShortcutExtensions.DOPixelRect((Camera)target, endValueRect, duration);
				break;
			case DOTweenAnimationType.CameraRect:
				tween = ShortcutExtensions.DORect((Camera)target, endValueRect, duration);
				break;
			}
			if (tween == null)
			{
				return;
			}
			if (isFrom)
			{
				TweenSettingsExtensions.From((Tweener)tween, isRelative);
			}
			else
			{
				TweenSettingsExtensions.SetRelative(tween, isRelative);
			}
			TweenSettingsExtensions.OnKill(TweenSettingsExtensions.SetAutoKill(TweenSettingsExtensions.SetLoops(TweenSettingsExtensions.SetDelay(TweenSettingsExtensions.SetTarget(tween, base.gameObject), delay), loops, loopType), autoKill), delegate
			{
				tween = null;
			});
			if (isSpeedBased)
			{
				TweenSettingsExtensions.SetSpeedBased(tween);
			}
			if (easeType == Ease.INTERNAL_Custom)
			{
				TweenSettingsExtensions.SetEase(tween, easeCurve);
			}
			else
			{
				TweenSettingsExtensions.SetEase(tween, easeType);
			}
			if (!string.IsNullOrEmpty(id))
			{
				TweenSettingsExtensions.SetId(tween, id);
			}
			TweenSettingsExtensions.SetUpdate(tween, isIndependentUpdate);
			if (hasOnStart)
			{
				if (onStart != null)
				{
					TweenSettingsExtensions.OnStart(tween, onStart.Invoke);
				}
			}
			else
			{
				onStart = null;
			}
			if (hasOnPlay)
			{
				if (onPlay != null)
				{
					TweenSettingsExtensions.OnPlay(tween, onPlay.Invoke);
				}
			}
			else
			{
				onPlay = null;
			}
			if (hasOnUpdate)
			{
				if (onUpdate != null)
				{
					TweenSettingsExtensions.OnUpdate(tween, onUpdate.Invoke);
				}
			}
			else
			{
				onUpdate = null;
			}
			if (hasOnStepComplete)
			{
				if (onStepComplete != null)
				{
					TweenSettingsExtensions.OnStepComplete(tween, onStepComplete.Invoke);
				}
			}
			else
			{
				onStepComplete = null;
			}
			if (hasOnComplete)
			{
				if (onComplete != null)
				{
					TweenSettingsExtensions.OnComplete(tween, onComplete.Invoke);
				}
			}
			else
			{
				onComplete = null;
			}
			if (hasOnRewind)
			{
				if (onRewind != null)
				{
					TweenSettingsExtensions.OnRewind(tween, onRewind.Invoke);
				}
			}
			else
			{
				onRewind = null;
			}
			if (autoPlay)
			{
				TweenExtensions.Play(tween);
			}
			else
			{
				TweenExtensions.Pause(tween);
			}
			if (hasOnTweenCreated && onTweenCreated != null)
			{
				onTweenCreated.Invoke();
			}
		}

		public override void DOPlay()
		{
			DOTween.Play(base.gameObject);
		}

		public override void DOPlayBackwards()
		{
			DOTween.PlayBackwards(base.gameObject);
		}

		public override void DOPlayForward()
		{
			DOTween.PlayForward(base.gameObject);
		}

		public override void DOPause()
		{
			DOTween.Pause(base.gameObject);
		}

		public override void DOTogglePause()
		{
			DOTween.TogglePause(base.gameObject);
		}

		public override void DORewind()
		{
			_playCount = -1;
			DOTweenAnimation[] components = base.gameObject.GetComponents<DOTweenAnimation>();
			for (int num = components.Length - 1; num > -1; num--)
			{
				Tween tween = components[num].tween;
				if (tween != null && TweenExtensions.IsInitialized(tween))
				{
					TweenExtensions.Rewind(components[num].tween);
				}
			}
		}

		public override void DORestart(bool fromHere = false)
		{
			_playCount = -1;
			if (tween == null)
			{
				if (Debugger.logPriority > 1)
				{
					Debugger.LogNullTween(tween);
				}
				return;
			}
			if (fromHere && isRelative)
			{
				ReEvaluateRelativeTween();
			}
			DOTween.Restart(base.gameObject);
		}

		public override void DOComplete()
		{
			DOTween.Complete(base.gameObject);
		}

		public override void DOKill()
		{
			DOTween.Kill(base.gameObject);
			tween = null;
		}

		public void DOPlayById(string id)
		{
			DOTween.Play(base.gameObject, id);
		}

		public void DOPlayAllById(string id)
		{
			DOTween.Play(id);
		}

		public void DOPauseAllById(string id)
		{
			DOTween.Pause(id);
		}

		public void DOPlayBackwardsById(string id)
		{
			DOTween.PlayBackwards(base.gameObject, id);
		}

		public void DOPlayBackwardsAllById(string id)
		{
			DOTween.PlayBackwards(id);
		}

		public void DOPlayForwardById(string id)
		{
			DOTween.PlayForward(base.gameObject, id);
		}

		public void DOPlayForwardAllById(string id)
		{
			DOTween.PlayForward(id);
		}

		public void DOPlayNext()
		{
			DOTweenAnimation[] components = GetComponents<DOTweenAnimation>();
			while (_playCount < components.Length - 1)
			{
				_playCount++;
				DOTweenAnimation dOTweenAnimation = components[_playCount];
				if (dOTweenAnimation != null && dOTweenAnimation.tween != null && !TweenExtensions.IsPlaying(dOTweenAnimation.tween) && !TweenExtensions.IsComplete(dOTweenAnimation.tween))
				{
					TweenExtensions.Play(dOTweenAnimation.tween);
					break;
				}
			}
		}

		public void DORewindAndPlayNext()
		{
			_playCount = -1;
			DOTween.Rewind(base.gameObject);
			DOPlayNext();
		}

		public void DORestartById(string id)
		{
			_playCount = -1;
			DOTween.Restart(base.gameObject, id);
		}

		public void DORestartAllById(string id)
		{
			_playCount = -1;
			DOTween.Restart(id);
		}

		public List<Tween> GetTweens()
		{
			List<Tween> list = new List<Tween>();
			DOTweenAnimation[] components = GetComponents<DOTweenAnimation>();
			DOTweenAnimation[] array = components;
			foreach (DOTweenAnimation dOTweenAnimation in array)
			{
				list.Add(dOTweenAnimation.tween);
			}
			return list;
		}

		public static TargetType TypeToDOTargetType(Type t)
		{
			string text = t.ToString();
			int num = text.LastIndexOf(".");
			if (num != -1)
			{
				text = text.Substring(num + 1);
			}
			if (text.IndexOf("Renderer") != -1 && text != "SpriteRenderer")
			{
				text = "Renderer";
			}
			return (TargetType)Enum.Parse(typeof(TargetType), text);
		}

		private void ReEvaluateRelativeTween()
		{
			if (animationType == DOTweenAnimationType.Move)
			{
				((Tweener)tween).ChangeEndValue(base.transform.position + endValueV3, true);
			}
			else if (animationType == DOTweenAnimationType.LocalMove)
			{
				((Tweener)tween).ChangeEndValue(base.transform.localPosition + endValueV3, true);
			}
		}
	}
}
