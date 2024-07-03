using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;

public class RankShow
	//: NetworkBehaviour
{
	//[SyncVar]
	public float P1_CurrentDis;

	//[SyncVar]
	public float P2_CurrentDis;

	public PScoreN PScoreN1Script1;

	public PScoreN PScoreN1Script2;

	private bool startbool;

	private static int kCmdCmdClientPos;

	public float NetworkP1_CurrentDis
	{
		get
		{
			return P1_CurrentDis;
		}
		[param: In]
		set
		{
			//SetSyncVar(value, ref P1_CurrentDis, 1u);
		}
	}

	public float NetworkP2_CurrentDis
	{
		get
		{
			return P2_CurrentDis;
		}
		[param: In]
		set
		{
			//SetSyncVar(value, ref P2_CurrentDis, 2u);
		}
	}

	private void OnEnable()
	{
		PScoreN1Script1 = GameObject.FindGameObjectWithTag("P1").GetComponentInChildren<PScoreN>();
		PScoreN1Script2 = GameObject.FindGameObjectWithTag("P2").GetComponentInChildren<PScoreN>();
		startbool = true;
	}

	private void Update()
	{
		if (startbool)
		{
		}
		//CallCmdClientPos();
		ClientPos();
	}

	//[Command]
	private void CmdClientPos()
	{
		if (startbool)
		{
			NetworkP1_CurrentDis = PScoreN1Script1.currentDis;
			NetworkP2_CurrentDis = PScoreN1Script2.currentDis;
			if (P1_CurrentDis < P2_CurrentDis)
			{
				PScoreN1Script1.ScoreText.text = "1st";
				PScoreN1Script2.ScoreText.text = "2nd";
			}
			else if (P1_CurrentDis > P2_CurrentDis)
			{
				PScoreN1Script1.ScoreText.text = "2nd";
				PScoreN1Script2.ScoreText.text = "1st";
			}
			else
			{
				PScoreN1Script1.ScoreText.text = "Tie";
				PScoreN1Script2.ScoreText.text = "Tie";
			}
		}
	}

	//[Client]
	private void ClientPos()
	{
		//if (!NetworkClient.active)
		//{
		//	Debug.LogWarning("[Client] function 'System.Void RankShow::ClientPos()' called on server");
		//}
		//else 
		if (startbool)
		{
			NetworkP1_CurrentDis = PScoreN1Script1.currentDis;
			NetworkP2_CurrentDis = PScoreN1Script2.currentDis;
			if (P1_CurrentDis < P2_CurrentDis)
			{
				PScoreN1Script1.ScoreText.text = "1st";
				PScoreN1Script2.ScoreText.text = "2nd";
			}
			else if (P1_CurrentDis > P2_CurrentDis)
			{
				PScoreN1Script1.ScoreText.text = "2nd";
				PScoreN1Script2.ScoreText.text = "1st";
			}
			else
			{
				PScoreN1Script1.ScoreText.text = "Tie";
				PScoreN1Script2.ScoreText.text = "Tie";
			}
		}
	}

	private void UNetVersion()
	{
	}

	//protected static void InvokeCmdCmdClientPos(NetworkBehaviour obj, NetworkReader reader)
	//{
	//	if (!NetworkServer.active)
	//	{
	//		Debug.LogError("Command CmdClientPos called on client.");
	//	}
	//	else
	//	{
	//		((RankShow)obj).CmdClientPos();
	//	}
	//}

	//public void CallCmdClientPos()
	//{
	//	if (!NetworkClient.active)
	//	{
	//		Debug.LogError("Command function CmdClientPos called on server.");
	//		return;
	//	}
	//	if (base.isServer)
	//	{
	//		CmdClientPos();
	//		return;
	//	}
	//	NetworkWriter networkWriter = new NetworkWriter();
	//	networkWriter.Write((short)0);
	//	networkWriter.Write((short)5);
	//	networkWriter.WritePackedUInt32((uint)kCmdCmdClientPos);
	//	networkWriter.Write(GetComponent<NetworkIdentity>().netId);
	//	SendCommandInternal(networkWriter, 0, "CmdClientPos");
	//}

	//static RankShow()
	//{
	//	kCmdCmdClientPos = 1563823840;
	//	NetworkBehaviour.RegisterCommandDelegate(typeof(RankShow), kCmdCmdClientPos, InvokeCmdCmdClientPos);
	//	NetworkCRC.RegisterBehaviour("RankShow", 0);
	//}

	//public override bool OnSerialize(NetworkWriter writer, bool forceAll)
	//{
	//	if (forceAll)
	//	{
	//		writer.Write(P1_CurrentDis);
	//		writer.Write(P2_CurrentDis);
	//		return true;
	//	}
	//	bool flag = false;
	//	if ((base.syncVarDirtyBits & (true ? 1u : 0u)) != 0)
	//	{
	//		if (!flag)
	//		{
	//			writer.WritePackedUInt32(base.syncVarDirtyBits);
	//			flag = true;
	//		}
	//		writer.Write(P1_CurrentDis);
	//	}
	//	if ((base.syncVarDirtyBits & 2u) != 0)
	//	{
	//		if (!flag)
	//		{
	//			writer.WritePackedUInt32(base.syncVarDirtyBits);
	//			flag = true;
	//		}
	//		writer.Write(P2_CurrentDis);
	//	}
	//	if (!flag)
	//	{
	//		writer.WritePackedUInt32(base.syncVarDirtyBits);
	//	}
	//	return flag;
	//}

	//public override void OnDeserialize(NetworkReader reader, bool initialState)
	//{
	//	if (initialState)
	//	{
	//		P1_CurrentDis = reader.ReadSingle();
	//		P2_CurrentDis = reader.ReadSingle();
	//		return;
	//	}
	//	int num = (int)reader.ReadPackedUInt32();
	//	if (((uint)num & (true ? 1u : 0u)) != 0)
	//	{
	//		P1_CurrentDis = reader.ReadSingle();
	//	}
	//	if (((uint)num & 2u) != 0)
	//	{
	//		P2_CurrentDis = reader.ReadSingle();
	//	}
	//}
}
