using System.Collections;
using FluffyUnderware.Curvy.Controllers;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	public class VolumeControllerInput : MonoBehaviour
	{
		public float AngularVelocity = 0.2f;

		public ParticleSystem explosionEmitter;

		public VolumeController volumeController;

		public Transform rotatedTransform;

		public Rigidbody rigidbodyComponent;

		public float maxSpeed = 40f;

		public float accelerationForward = 20f;

		public float accelerationBackward = 40f;

		public float speedBleed = 10f;

		private bool mGameOver;

		private void Awake()
		{
			if (!volumeController)
			{
				volumeController = GetComponent<VolumeController>();
			}
		}

		private IEnumerator Start()
		{
			if ((bool)volumeController)
			{
				while (!volumeController.IsInitialized)
				{
					yield return 0;
				}
			}
		}

		private void Update()
		{
			if ((bool)volumeController && !mGameOver)
			{
				if (!volumeController.IsPlaying)
				{
					volumeController.Play();
				}
				float axis = Input.GetAxis("Vertical");
				float axis2 = Input.GetAxis("Horizontal");
				float num = Mathf.Abs(axis2);
				float value = volumeController.Speed + axis * Time.deltaTime * Mathf.Lerp(accelerationBackward, accelerationForward, (axis + 1f) / 2f) - num * accelerationBackward * Time.deltaTime * 0.25f - speedBleed * Time.deltaTime;
				volumeController.Speed = Mathf.Clamp(value, 0f, maxSpeed);
				volumeController.CrossPosition += AngularVelocity * Mathf.Clamp(volumeController.Speed / 10f, 0.2f, 1f) * axis2 * Time.deltaTime;
				if ((bool)rotatedTransform)
				{
					float y = Mathf.Lerp(-90f, 90f, (axis2 + 1f) / 2f);
					rotatedTransform.localRotation = Quaternion.Euler(0f, y, 0f);
				}
			}
		}

		public void OnCollisionEnter(Collision collision)
		{
		}

		public void OnTriggerEnter(Collider other)
		{
			explosionEmitter.Emit(200);
			volumeController.Stop();
			mGameOver = true;
			Invoke("StartOver", 1f);
		}

		private void StartOver()
		{
			volumeController.Speed = 0f;
			volumeController.RelativePosition = 0f;
			volumeController.CrossPosition = 0f;
			mGameOver = false;
		}
	}
}
