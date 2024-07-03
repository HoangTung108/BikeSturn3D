using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LobbyScript : MonoBehaviour
{
	[Header("UI Panels")]
	public GameObject LobbyMenuPanel;

	public GameObject CreateRoomPanel;

	public GameObject JoinPrivateRoomPanel;

	public GameObject JoinAvailableRoomPanel;

	public GameObject LevelSelectionPanel;

	private bool checklistonce = true;

	public Button[] ServerButtonRef;

	public Button ServerListButtonsprefab;

	public Transform ButtonInsPanel;

	[Header("ERRORS Panels")]
	public GameObject RoomCreateEmptyNameMsg;

	public GameObject JoinRoomEmptyNameMsg;

	public GameObject RoomNameAlreadyExistError;

	public GameObject JoinRoomFullError;

	public GameObject RandomJoinRoomAvailableError;

	public GameObject WaitForOtherPlayerMsg;

	public GameObject NoUserFoundMsg;

	public Text TimeShow;

	public float timer;

	private bool WaitBool;

	public GameObject LoadingPanel;

	private string roomName = "myRoom";

	private bool connectFailed;

	public static readonly string SceneNameMenu = "PhotonLobby";

	public static string SceneNameGame;

	private string errorDialog;

	private double timeToClearDialog;

	[Header("Create Room Input Fields")]
	public InputField CreateRoom_EnterPlyerName;

	public InputField CreateRoom_EnterRoomName;

	[Header("Join Private Room Input Fields")]
	public InputField PrivateRoom_EnterPlyerName;

	public InputField PrivateRoom_EnterRoomName;

	[Header("Join Available Room Input Fields")]
	public InputField JoinAvailableRoom_EnterPlyerName;

	[Header("Level Selection")]
	private int counter;

	public GameObject RightBtn;

	public GameObject LeftBtn;

	[Header("Level Images")]
	public GameObject[] Image1;

	[Header("Level Texts")]
	public GameObject[] ImageText1;

	[Header("ScenesLevel Names")]
	public string Level1Name = "MultiplayerBikeStuntLevel_1_Net";

	public string Level2Name = "MultiplayerBikeStuntLevel_2_Net";

	public string Level3Name = "MultiplayerBikeStuntLevel_3_Net";

	public string Level4Name = "MultiplayerBikeStuntLevel_4_Net";

	public string Level5Name = "MultiplayerBikeStuntLevel_5_Net";

	public string Level6Name = "MultiplayerBikeStuntLevel_6_Net";

	public string Level7Name = "MultiplayerBikeStuntLevel_7_Net";

	public string Level8Name = "MultiplayerBikeStuntLevel_8_Net";

	public string Level9Name = "MultiplayerBikeStuntLevel_9_Net";

	public AudioClip btn_click;

	public string ErrorDialog
	{
		get
		{
			return errorDialog;
		}
		private set
		{
			errorDialog = value;
			if (!string.IsNullOrEmpty(value))
			{
				timeToClearDialog = Time.time + 4f;
			}
		}
	}

	public void Awake()
	{
		PlayerPrefs.SetInt("MultiPlyerGameDB", 1);
		LoadingPanel.SetActive(true);
		//PhotonNetwork.automaticallySyncScene = true;
		//if (PhotonNetwork.connectionStateDetailed == ClientState.PeerCreated)
		//{
		//	PhotonNetwork.ConnectUsingSettings("0.9");
		//}
	}

	private void Start()
	{
		Invoke("LoadingDisable", 0.5f);
	}

	private void LoadingDisable()
	{
		LoadingPanel.SetActive(false);
		timer = 30f;
	}

	private void Update()
	{
		if (WaitBool)
		{
			timer -= Time.deltaTime;
			int num = Mathf.RoundToInt(timer);
			TimeShow.text = num.ToString();
			if (timer <= 0f)
			{
				WaitBool = false;
				WaitForOtherPlayerMsg.SetActive(false);
				NoUserFoundMsg.SetActive(true);
				timer = 0f;
			}
		}
		//if (PhotonNetwork.playerList.Length == 2)
		//{
		//	WaitBool = false;
		//	timer = 30f;
		//	WaitForOtherPlayerMsg.SetActive(false);
		//	NoUserFoundMsg.SetActive(false);
		//	LoadingPanel.SetActive(true);
		//	PhotonNetwork.LoadLevel(SceneNameGame);
		//}
		switch (counter)
		{
		case 0:
		{
			for (int num3 = 0; num3 <= 8; num3++)
			{
				if (num3 == counter)
				{
					Image1[num3].SetActive(true);
					ImageText1[num3].SetActive(true);
				}
				else
				{
					Image1[num3].SetActive(false);
					ImageText1[num3].SetActive(false);
				}
			}
			SceneNameGame = Level1Name;
			break;
		}
		case 1:
		{
			for (int m = 0; m <= 8; m++)
			{
				if (m == counter)
				{
					Image1[m].SetActive(true);
					ImageText1[m].SetActive(true);
				}
				else
				{
					Image1[m].SetActive(false);
					ImageText1[m].SetActive(false);
				}
			}
			SceneNameGame = Level2Name;
			break;
		}
		case 2:
		{
			for (int num4 = 0; num4 <= 8; num4++)
			{
				if (num4 == counter)
				{
					Image1[num4].SetActive(true);
					ImageText1[num4].SetActive(true);
				}
				else
				{
					Image1[num4].SetActive(false);
					ImageText1[num4].SetActive(false);
				}
			}
			SceneNameGame = Level3Name;
			break;
		}
		case 3:
		{
			for (int k = 0; k <= 8; k++)
			{
				if (k == counter)
				{
					Image1[k].SetActive(true);
					ImageText1[k].SetActive(true);
				}
				else
				{
					Image1[k].SetActive(false);
					ImageText1[k].SetActive(false);
				}
			}
			SceneNameGame = Level4Name;
			break;
		}
		case 4:
		{
			for (int n = 0; n <= 8; n++)
			{
				if (n == counter)
				{
					Image1[n].SetActive(true);
					ImageText1[n].SetActive(true);
				}
				else
				{
					Image1[n].SetActive(false);
					ImageText1[n].SetActive(false);
				}
			}
			SceneNameGame = Level5Name;
			break;
		}
		case 5:
		{
			for (int j = 0; j <= 8; j++)
			{
				if (j == counter)
				{
					Image1[j].SetActive(true);
					ImageText1[j].SetActive(true);
				}
				else
				{
					Image1[j].SetActive(false);
					ImageText1[j].SetActive(false);
				}
			}
			SceneNameGame = Level6Name;
			break;
		}
		case 6:
		{
			for (int num2 = 0; num2 <= 8; num2++)
			{
				if (num2 == counter)
				{
					Image1[num2].SetActive(true);
					ImageText1[num2].SetActive(true);
				}
				else
				{
					Image1[num2].SetActive(false);
					ImageText1[num2].SetActive(false);
				}
			}
			SceneNameGame = Level7Name;
			break;
		}
		case 7:
		{
			for (int l = 0; l <= 8; l++)
			{
				if (l == counter)
				{
					Image1[l].SetActive(true);
					ImageText1[l].SetActive(true);
				}
				else
				{
					Image1[l].SetActive(false);
					ImageText1[l].SetActive(false);
				}
			}
			SceneNameGame = Level8Name;
			break;
		}
		case 8:
		{
			for (int i = 0; i <= 8; i++)
			{
				if (i == counter)
				{
					Image1[i].SetActive(true);
					ImageText1[i].SetActive(true);
				}
				else
				{
					Image1[i].SetActive(false);
					ImageText1[i].SetActive(false);
				}
			}
			SceneNameGame = Level9Name;
			break;
		}
		}
	}

	public void RoomCreateEmptyNameMSg_Ok_Button_Click()
	{
		RoomCreateEmptyNameMsg.SetActive(false);
	}

	public void PrivateRoomEmptyNameMSg_Ok_Button_Click()
	{
		JoinRoomEmptyNameMsg.SetActive(false);
	}

	public void RoomNameAlreadyExistErrorNameMSg_Ok_Button_Click()
	{
		RoomNameAlreadyExistError.SetActive(false);
	}

	public void JoinRoomFullErrorNameMSg_Ok_Button_Click()
	{
		JoinRoomFullError.SetActive(false);
	}

	public void RandomJoinRoomAvailableErrorNameMSg_Ok_Button_Click()
	{
		RandomJoinRoomAvailableError.SetActive(false);
	}

	public void CreateRoom_Click()
	{
		if (CreateRoom_EnterRoomName.text == string.Empty)
		{
			RoomCreateEmptyNameMsg.SetActive(true);
		}
		else
		{
			if (CreateRoom_EnterPlyerName.text == string.Empty)
			{
				PlayerPrefs.SetString("PlayerNameDB", "Guest" + UnityEngine.Random.Range(1, 9999));
				//PhotonNetwork.playerName = PlayerPrefs.GetString("PlayerNameDB");
			}
			else
			{
				PlayerPrefs.SetString("PlayerNameDB", CreateRoom_EnterPlyerName.text);
				//PhotonNetwork.playerName = PlayerPrefs.GetString("PlayerNameDB");
			}
			WaitForOtherPlayerMsg.SetActive(true);
			WaitBool = true;
			PlayerPrefs.SetString("RoomNameDB", CreateRoom_EnterRoomName.text);
			roomName = PlayerPrefs.GetString("RoomNameDB");
			string text = roomName;
			//RoomOptions roomOptions = new RoomOptions();
			//roomOptions.MaxPlayers = 2;
			//PhotonNetwork.CreateRoom(text, roomOptions, null);
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void JoinRoom_Click()
	{
		if (PrivateRoom_EnterRoomName.text == string.Empty)
		{
			JoinRoomEmptyNameMsg.SetActive(true);
		}
		else
		{
			if (PrivateRoom_EnterPlyerName.text == string.Empty)
			{
				PlayerPrefs.SetString("PlayerNameDB", "Guest" + UnityEngine.Random.Range(1, 9999));
				//PhotonNetwork.playerName = PlayerPrefs.GetString("PlayerNameDB");
			}
			else
			{
				PlayerPrefs.SetString("PlayerNameDB", PrivateRoom_EnterPlyerName.text);
				//PhotonNetwork.playerName = PlayerPrefs.GetString("PlayerNameDB");
			}
			//PhotonNetwork.JoinRoom(PrivateRoom_EnterRoomName.text);
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void JoinServerFromList()
	{
		if (JoinAvailableRoom_EnterPlyerName.text == string.Empty)
		{
			PlayerPrefs.SetString("PlayerNameDB", "Guest" + UnityEngine.Random.Range(1, 9999));
			//PhotonNetwork.playerName = PlayerPrefs.GetString("PlayerNameDB");
		}
		else
		{
			PlayerPrefs.SetString("PlayerNameDB", JoinAvailableRoom_EnterPlyerName.text);
			//PhotonNetwork.playerName = PlayerPrefs.GetString("PlayerNameDB");
		}
		//RoomInfo[] roomList = PhotonNetwork.GetRoomList();
		//foreach (RoomInfo roomInfo in roomList)
		//{
		//	PhotonNetwork.JoinRoom(roomInfo.Name);
		//}
		LoadingPanel.SetActive(true);
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void OnJoinedRoom()
	{
		Debug.Log("OnJoinedRoom");
	}

	public void OnPhotonCreateRoomFailed()
	{
		RoomNameAlreadyExistError.SetActive(true);
		ErrorDialog = "Error: Can't create room (room name maybe already used).";
		Debug.Log("OnPhotonCreateRoomFailed got called. This can happen if the room exists (even if not visible). Try another room name.");
	}

	public void OnPhotonJoinRoomFailed(object[] cause)
	{
		JoinRoomFullError.SetActive(true);
		ErrorDialog = "Error: Can't join room (full or unknown room name). " + cause[1];
		Debug.Log("OnPhotonJoinRoomFailed got called. This can happen if the room is not existing or full or closed.");
	}

	public void OnPhotonRandomJoinFailed()
	{
		RandomJoinRoomAvailableError.SetActive(true);
		ErrorDialog = "Error: Can't join random room (none found).";
		Debug.Log("OnPhotonRandomJoinFailed got called. Happens if no room is available (or all full or invisible or closed). JoinrRandom filter-options can limit available rooms.");
	}

	public void OnCreatedRoom()
	{
		Debug.Log("OnCreatedRoom");
	}

	public void OnDisconnectedFromPhoton()
	{
		Debug.Log("Disconnected from Photon.");
	}

	public void OnFailedToConnectToPhoton(object parameters)
	{
		connectFailed = true;
		//Debug.Log(string.Concat("OnFailedToConnectToPhoton. StatusCode: ", parameters, " ServerAddress: ", PhotonNetwork.ServerAddress));
	}

	public void OnConnectedToMaster()
	{
		Debug.Log("As OnConnectedToMaster() got called, the PhotonServerSetting.AutoJoinLobby must be off. Joining lobby by calling PhotonNetwork.JoinLobby().");
		//PhotonNetwork.JoinLobby();
	}

	public void CreateRoomBtn_Click()
	{
		LobbyMenuPanel.SetActive(false);
		CreateRoomPanel.SetActive(false);
		JoinPrivateRoomPanel.SetActive(false);
		JoinAvailableRoomPanel.SetActive(false);
		LevelSelectionPanel.SetActive(true);
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void CreateRoom_Back_Btn_Click()
	{
		LobbyMenuPanel.SetActive(false);
		CreateRoomPanel.SetActive(false);
		JoinPrivateRoomPanel.SetActive(false);
		JoinAvailableRoomPanel.SetActive(false);
		LevelSelectionPanel.SetActive(true);
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelSelection_StartBtn_Click()
	{
		LobbyMenuPanel.SetActive(false);
		CreateRoomPanel.SetActive(true);
		JoinPrivateRoomPanel.SetActive(false);
		JoinAvailableRoomPanel.SetActive(false);
		LevelSelectionPanel.SetActive(false);
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LevelSelection_BackBtn_Click()
	{
		LobbyMenuPanel.SetActive(true);
		CreateRoomPanel.SetActive(false);
		JoinPrivateRoomPanel.SetActive(false);
		JoinAvailableRoomPanel.SetActive(false);
		LevelSelectionPanel.SetActive(false);
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void JoinPrivateRoomBtn_Click()
	{
		LobbyMenuPanel.SetActive(false);
		CreateRoomPanel.SetActive(false);
		JoinPrivateRoomPanel.SetActive(true);
		JoinAvailableRoomPanel.SetActive(false);
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void JoinPrivateRoom_Back_Btn_Click()
	{
		LobbyMenuPanel.SetActive(true);
		CreateRoomPanel.SetActive(false);
		JoinPrivateRoomPanel.SetActive(false);
		JoinAvailableRoomPanel.SetActive(false);
	}

	public void JoinRandomRoomBtn_Click()
	{
		RandomJoinRoomAvailableError.SetActive(true);
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void JoinAvailbleRoomBtn_Click()
	{
		LobbyMenuPanel.SetActive(false);
		CreateRoomPanel.SetActive(false);
		JoinPrivateRoomPanel.SetActive(false);
		JoinAvailableRoomPanel.SetActive(true);
		//ServerButtonRef = new Button[PhotonNetwork.countOfRooms];
		//if (PhotonNetwork.insideLobby && checklistonce)
		//{
		//	int num = 0;
		//	RoomInfo[] roomList = PhotonNetwork.GetRoomList();
		//	foreach (RoomInfo roomInfo in roomList)
		//	{
		//		ServerButtonRef[num] = UnityEngine.Object.Instantiate(ServerListButtonsprefab);
		//		ServerButtonRef[num].gameObject.transform.SetParent(ButtonInsPanel);
		//		ServerButtonRef[num].transform.localScale = new Vector3(1f, 1f, 1f);
		//		ServerButtonRef[num].transform.name = roomInfo.name;
		//		ServerButtonRef[num].onClick.AddListener(JoinServerFromList);
		//		GameObject.Find(roomInfo.name.ToString() + "/ServerNameText").GetComponent<Text>().text = roomInfo.name;
		//		GameObject.Find(roomInfo.name.ToString() + "/PlayerText").GetComponent<Text>().text = roomInfo.PlayerCount + "/2";
		//		if (roomInfo.PlayerCount >= roomInfo.MaxPlayers)
		//		{
		//			ServerButtonRef[num].interactable = false;
		//		}
		//		num++;
		//	}
		//	checklistonce = false;
		//}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void RefreshBtn_Click()
	{
		StartCoroutine(RefreshList());
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	private IEnumerator RefreshList()
	{
		for (int j = 0; j < ServerButtonRef.Length; j++)
		{
			if (ServerButtonRef[j] != null)
			{
				UnityEngine.Object.Destroy(ServerButtonRef[j].gameObject);
			}
		}
		Array.Clear(ServerButtonRef, 0, ServerButtonRef.Length);
		ServerButtonRef = new Button[0];
		checklistonce = true;
		//ServerButtonRef = new Button[PhotonNetwork.countOfRooms];
		//if (!PhotonNetwork.insideLobby || !checklistonce || ServerButtonRef.Length <= 0)
		//{
		//	yield break;
		//}
		//int i = 0;
		//RoomInfo[] roomList = PhotonNetwork.GetRoomList();
		//foreach (RoomInfo game in roomList)
		//{
		//	ServerButtonRef[i] = UnityEngine.Object.Instantiate(ServerListButtonsprefab);
		//	ServerButtonRef[i].gameObject.transform.SetParent(ButtonInsPanel);
		//	ServerButtonRef[i].transform.localScale = new Vector3(1f, 1f, 1f);
		//	ServerButtonRef[i].transform.name = game.name;
		//	ServerButtonRef[i].onClick.AddListener(JoinServerFromList);
		//	yield return new WaitForSeconds(0.5f);
		//	GameObject.Find(game.name.ToString() + "/ServerNameText").GetComponent<Text>().text = game.name;
		//	GameObject.Find(game.name.ToString() + "/PlayerText").GetComponent<Text>().text = game.PlayerCount + "/2";
		//	if (game.PlayerCount >= game.MaxPlayers)
		//	{
		//		ServerButtonRef[i].interactable = false;
		//	}
		//	i++;
		//}
		checklistonce = false;
		//add 
		yield break;
	}

	public void JoinAvailbleRoom_Back_Btn_Click()
	{
		LobbyMenuPanel.SetActive(true);
		CreateRoomPanel.SetActive(false);
		JoinPrivateRoomPanel.SetActive(false);
		JoinAvailableRoomPanel.SetActive(false);
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void Menu_Back_Click()
	{
		LoadingPanel.SetActive(true);
		Application.LoadLevel(1);
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void RightClick_Btn()
	{
		if (counter >= 8)
		{
			RightBtn.SetActive(false);
			LeftBtn.SetActive(true);
			counter = 8;
		}
		else
		{
			RightBtn.SetActive(true);
			LeftBtn.SetActive(true);
			counter++;
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void LeftClick_Btn()
	{
		if (counter <= 0)
		{
			LeftBtn.SetActive(false);
			RightBtn.SetActive(true);
			counter = 0;
		}
		else
		{
			LeftBtn.SetActive(true);
			RightBtn.SetActive(true);
			counter--;
		}
		if (PlayerPrefs.GetString("Sound Status") == "True")
		{
			GetComponent<AudioSource>().PlayOneShot(btn_click, 1f);
		}
	}

	public void RetryBtn_Click()
	{
		LoadingPanel.SetActive(true);
		Application.LoadLevel(Application.loadedLevel);
	}
}
