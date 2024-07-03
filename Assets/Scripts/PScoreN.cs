using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PScoreN : MonoBehaviour
{
	public float currentDis;

	public Transform Distarget;

	public Transform Distarget1;

	public Transform Distarget2;

	[SerializeField]
	public Text ScoreText;

	public Text NameText;

	public GameObject NameObj;

	private bool InintBool;

	[SerializeField]
	public string PName;

	//[SerializeField]
	//public PhotonView m_PhotonView;

	private Scene CurrentScene;

	private void OnEnable()
	{
		Invoke("initCall", 0.5f);
	}

	private void initCall()
	{
		Distarget = GameObject.FindGameObjectWithTag("TargetDis").transform;
		InintBool = true;
		CurrentScene = SceneManager.GetActiveScene();
		if (CurrentScene.name == "MultiplayerBikeStuntLevel_2_Net")
		{
			Distarget1 = GameObject.FindGameObjectWithTag("TargetDis1").transform;
			Distarget2 = GameObject.FindGameObjectWithTag("TargetDis2").transform;
		}
		else if (CurrentScene.name == "MultiplayerBikeStuntLevel_4_Net")
		{
			Distarget1 = GameObject.FindGameObjectWithTag("TargetDis1").transform;
		}
		else if (CurrentScene.name == "MultiplayerBikeStuntLevel_5_Net")
		{
			Distarget1 = GameObject.FindGameObjectWithTag("TargetDis1").transform;
		}
		else if (CurrentScene.name == "MultiplayerBikeStuntLevel_6_Net")
		{
			Distarget1 = GameObject.FindGameObjectWithTag("TargetDis1").transform;
			Distarget2 = GameObject.FindGameObjectWithTag("TargetDis2").transform;
		}
		else if (CurrentScene.name == "MultiplayerBikeStuntLevel_9_Net")
		{
			Distarget1 = GameObject.FindGameObjectWithTag("TargetDis1").transform;
		}
	}

	private void Update()
	{
		if (!InintBool)
		{
			return;
		}
		//PName = m_PhotonView.owner.NickName;
		if (CurrentScene.name == "MultiplayerBikeStuntLevel_2_Net")
		{
			if (BikeControlN.CheckDistanceCounter == 0)
			{
				currentDis = Vector3.Distance(Distarget1.position, base.transform.position);
			}
			else if (BikeControlN.CheckDistanceCounter == 1)
			{
				currentDis = Vector3.Distance(Distarget2.position, base.transform.position);
			}
			else
			{
				currentDis = Vector3.Distance(Distarget.position, base.transform.position);
			}
		}
		else if (CurrentScene.name == "MultiplayerBikeStuntLevel_4_Net")
		{
			if (BikeControlN.CheckDistanceCounter == 0)
			{
				currentDis = Vector3.Distance(Distarget1.position, base.transform.position);
			}
			else
			{
				currentDis = Vector3.Distance(Distarget.position, base.transform.position);
			}
		}
		else if (CurrentScene.name == "MultiplayerBikeStuntLevel_5_Net")
		{
			if (BikeControlN.CheckDistanceCounter == 0)
			{
				currentDis = Vector3.Distance(Distarget1.position, base.transform.position);
			}
			else
			{
				currentDis = Vector3.Distance(Distarget.position, base.transform.position);
			}
		}
		else if (CurrentScene.name == "MultiplayerBikeStuntLevel_6_Net")
		{
			if (BikeControlN.CheckDistanceCounter == 0)
			{
				currentDis = Vector3.Distance(Distarget1.position, base.transform.position);
			}
			else if (BikeControlN.CheckDistanceCounter == 1)
			{
				currentDis = Vector3.Distance(Distarget2.position, base.transform.position);
			}
			else
			{
				currentDis = Vector3.Distance(Distarget.position, base.transform.position);
			}
		}
		else if (CurrentScene.name == "MultiplayerBikeStuntLevel_9_Net")
		{
			if (BikeControlN.CheckDistanceCounter == 0)
			{
				currentDis = Vector3.Distance(Distarget1.position, base.transform.position);
			}
			else
			{
				currentDis = Vector3.Distance(Distarget.position, base.transform.position);
			}
		}
		else
		{
			currentDis = Vector3.Distance(Distarget.position, base.transform.position);
		}
	}
}
