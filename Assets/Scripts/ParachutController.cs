using UnityEngine;

public class ParachutController : MonoBehaviour
{
	private Animator anim;

	public GameObject ParachuteOpen_Btn;

	public GameObject ParachuteLeft_Btn;

	public GameObject ParachuteRight_Btn;

	private bool RightMoveBool;

	private bool LeftMoveBool;

	public GameObject ParachuteObj;

	public Rigidbody ParachuteRigidBody;

	public bool LandingBool;

	public bool LandingFailedBool;

	private void Start()
	{
		anim = GetComponent<Animator>();
		ParachuteOpen_Btn.SetActive(false);
		ParachuteObj.SetActive(false);
		SkyDive_JumpCall();
		Invoke("SkyDive_Call", 1.2f);
		LandingBool = false;
	}

	private void Update()
	{
		base.transform.Translate(Vector3.forward * Time.deltaTime * 2.5f);
		if (RightMoveBool)
		{
			base.transform.Translate(Vector3.right * Time.deltaTime);
			base.transform.Rotate(new Vector3(0f, 1f, 0.2f) * Time.deltaTime * 10f);
		}
		else if (LeftMoveBool)
		{
			base.transform.Translate(Vector3.left * Time.deltaTime);
			base.transform.Rotate(new Vector3(0f, -1f, -0.2f) * Time.deltaTime * 10f);
		}
	}

	private void SkyDive_JumpCall()
	{
		anim.SetInteger("Anim", 0);
	}

	private void SkyDive_Call()
	{
		anim.SetInteger("Anim", 1);
		Invoke("Parachute_OnBtn", 5f);
	}

	private void Parachute_OnBtn()
	{
		ParachuteOpen_Btn.SetActive(true);
	}

	public void Parcahute_Call()
	{
		anim.SetInteger("Anim", 2);
		ParachuteLeft_Btn.SetActive(true);
		ParachuteRight_Btn.SetActive(true);
		ParachuteOpen_Btn.SetActive(false);
		Invoke("ParcahuteIdle_Call", 2f);
		AdsManager.Instance.UpdateBannerPosition(MaxSdkBase.BannerPosition.TopCenter);
	}

	private void ParcahuteIdle_Call()
	{
		anim.SetInteger("Anim", 3);
		Invoke("ParcahuteObj_oPEN", 0.5f);
	}

	private void ParcahuteObj_oPEN()
	{
		ParachuteRigidBody.angularDrag = 4f;
		ParachuteObj.SetActive(true);
	}

	public void Parcahute_RightMove_PoitDown()
	{
		RightMoveBool = true;
	}

	public void Parcahute_RightMove_PoitUP()
	{
		RightMoveBool = false;
	}

	public void Parcahute_LeftMove_PoitDown()
	{
		LeftMoveBool = true;
	}

	public void Parcahute_LeftMove_PoitUP()
	{
		LeftMoveBool = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "complete")
		{
			anim.SetInteger("Anim", 4);
			ParachuteObj.SetActive(false);
			ParachuteRigidBody.angularDrag = 0.05f;
			ParachuteRigidBody.constraints = RigidbodyConstraints.FreezeAll;
			LandingBool = true;
		}
		if (other.gameObject.tag == "failed")
		{
			LandingFailedBool = true;
		}
	}
}
