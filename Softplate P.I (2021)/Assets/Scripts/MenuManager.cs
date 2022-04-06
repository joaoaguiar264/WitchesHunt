using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private string VersionName = "0.2.16";
    [SerializeField] private GameObject UsernameMenu;
    [SerializeField] private GameObject RoomListing;
    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;

    [SerializeField] private GameObject StartButton;
    public static MenuManager Instance;

    public PhotonView pv;

    public Text _roomName;
    // Start is called before the first frame update
    public void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
        Instance = this;
        PhotonNetwork.GameVersion = VersionName;
    }

    private void Start()
    {
        if(GameManager.nameFeito == false)
        {
            UsernameMenu.SetActive(true); 
        }
        else
        {
            RoomListing.SetActive(true);
        }

    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            this.gameObject.GetPhotonView().RPC("Nickname", RpcTarget.AllBuffered);
            
        }

        if (Input.GetKey(KeyCode.Return) && StartButton.activeSelf == true)
        {
            setUserName();
        }

        if (Input.GetKey(KeyCode.Return) && CreateGameInput != null)
        {
            CreateRoom();
        }

    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }


    public void ChangeUserNameInput()
    {
        if (UsernameInput.text.Length >= 3)
        {
            StartButton.SetActive(true);
        }
        else
        {
            StartButton.SetActive(false);
        }
    }

    public void setUserName()
    {
        UsernameMenu.SetActive(false);
        RoomListing.SetActive(true);
        PlayerPrefs.SetString("username", UsernameInput.text);
        PhotonNetwork.NickName = UsernameInput.text;

    }

    public void CreateRoom()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, TypedLobby.Default);
    }

  

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("MainGame");
       
    }

    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(JoinGameInput.text, roomOptions, TypedLobby.Default);
    }

}