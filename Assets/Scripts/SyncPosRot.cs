using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;

public class SyncPosRot 
	//: NetworkBehaviour
{
	//[SyncVar]
	private Vector3 syncPos;

	//[SyncVar]
	private float syncYRot;

	private Vector3 lastPos;

	private Quaternion lastRot;

	private Transform myTransform;

	[SerializeField]
	private float lerpRate = 10f;

	[SerializeField]
	private float posThreshold = 0.5f;

	[SerializeField]
	private float rotThreshold = 5f;

	private static int kCmdCmd_ProvidePositionToServer;

	public Vector3 NetworksyncPos
	{
		get
		{
			return syncPos;
		}
		[param: In]
		set
		{
			//SetSyncVar(value, ref syncPos, 1u);
		}
	}

	public float NetworksyncYRot
	{
		get
		{
			return syncYRot;
		}
		[param: In]
		set
		{
			//SetSyncVar(value, ref syncYRot, 2u);
		}
	}

	private void Start()
	{
		//myTransform = base.transform;
	}

	private void FixedUpdate()
	{
		TransmitMotion();
		LerpMotion();
	}

	//[Command]
	private void Cmd_ProvidePositionToServer(Vector3 pos, float rot)
	{
		NetworksyncPos = pos;
		NetworksyncYRot = rot;
	}

	//[ClientCallback]
	private void TransmitMotion()
	{
		//if (NetworkClient.active && base.hasAuthority && (Vector3.Distance(myTransform.position, lastPos) > posThreshold || Quaternion.Angle(myTransform.rotation, lastRot) > rotThreshold))
		//{
		//	CallCmd_ProvidePositionToServer(myTransform.position, myTransform.localEulerAngles.y);
		//	lastPos = myTransform.position;
		//	lastRot = myTransform.rotation;
		//}
	}

	private void LerpMotion()
	{
		//if (!base.hasAuthority)
		//{
		//	myTransform.position = Vector3.Lerp(myTransform.transform.position, syncPos, Time.deltaTime * lerpRate);
		//	Vector3 euler = new Vector3(0f, syncYRot, 0f);
		//	myTransform.rotation = Quaternion.Lerp(myTransform.rotation, Quaternion.Euler(euler), Time.deltaTime * lerpRate);
		//}
	}

	private void UNetVersion()
	{
	}

	//protected static void InvokeCmdCmd_ProvidePositionToServer(NetworkBehaviour obj, NetworkReader reader)
	//{
	//	if (!NetworkServer.active)
	//	{
	//		Debug.LogError("Command Cmd_ProvidePositionToServer called on client.");
	//	}
	//	else
	//	{
	//		((SyncPosRot)obj).Cmd_ProvidePositionToServer(reader.ReadVector3(), reader.ReadSingle());
	//	}
	//}

	public void CallCmd_ProvidePositionToServer(Vector3 pos, float rot)
	{
		//if (!NetworkClient.active)
		//{
		//	Debug.LogError("Command function Cmd_ProvidePositionToServer called on server.");
		//	return;
		//}
		//if (base.isServer)
		//{
		//	Cmd_ProvidePositionToServer(pos, rot);
		//	return;
		//}
		//NetworkWriter networkWriter = new NetworkWriter();
		//networkWriter.Write((short)0);
		//networkWriter.Write((short)5);
		//networkWriter.WritePackedUInt32((uint)kCmdCmd_ProvidePositionToServer);
		//networkWriter.Write(GetComponent<NetworkIdentity>().netId);
		//networkWriter.Write(pos);
		//networkWriter.Write(rot);
		//SendCommandInternal(networkWriter, 0, "Cmd_ProvidePositionToServer");
	}

	static SyncPosRot()
	{
		kCmdCmd_ProvidePositionToServer = -1200522745;
		//NetworkBehaviour.RegisterCommandDelegate(typeof(SyncPosRot), kCmdCmd_ProvidePositionToServer, InvokeCmdCmd_ProvidePositionToServer);
		//NetworkCRC.RegisterBehaviour("SyncPosRot", 0);
	}

	//public override bool OnSerialize(NetworkWriter writer, bool forceAll)
	//{
	//	if (forceAll)
	//	{
	//		writer.Write(syncPos);
	//		writer.Write(syncYRot);
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
	//		writer.Write(syncPos);
	//	}
	//	if ((base.syncVarDirtyBits & 2u) != 0)
	//	{
	//		if (!flag)
	//		{
	//			writer.WritePackedUInt32(base.syncVarDirtyBits);
	//			flag = true;
	//		}
	//		writer.Write(syncYRot);
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
	//		syncPos = reader.ReadVector3();
	//		syncYRot = reader.ReadSingle();
	//		return;
	//	}
	//	int num = (int)reader.ReadPackedUInt32();
	//	if (((uint)num & (true ? 1u : 0u)) != 0)
	//	{
	//		syncPos = reader.ReadVector3();
	//	}
	//	if (((uint)num & 2u) != 0)
	//	{
	//		syncYRot = reader.ReadSingle();
	//	}
	//}
}
