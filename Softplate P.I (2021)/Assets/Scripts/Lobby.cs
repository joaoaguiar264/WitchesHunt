using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Lobby : MonoBehaviourPunCallbacks
{
    public bool characterChoosed;
    public static bool witch1 = false;
    public bool witch1Choosen = false;

    public static bool witch2 = false;
    public bool witch2Choosen = false;

    public static bool witch3 = false;
    public bool witch3Choosen = false;

    public static bool templar = false;
    public bool templarChoosen = false;

    public GameObject witchA;
    public GameObject witchB;
    public GameObject witchC;
    public GameObject hunter;

    public Vector3 SpawnPoint1;
    public Quaternion SpawnPoint;
    public GameObject lobby;
    public int playersReady = 0;
    public Text Ready;

    [SerializeField] public Text roomName;
    [SerializeField] public Text roomPlayers;

    public Text player1;
    public string player1Str;
    public Text player2;
    public string player2Str;
    public Text player3;
    public string player3Str;
    public Text player4;
    public string player4Str;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("playerlist", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(witch1Choosen == true)
        {
            witchA.SetActive(false);
        }
        if(witch2Choosen == true)
        {
            witchB.SetActive(false);
        }
        if(witch3Choosen == true)
        {
            witchC.SetActive(false);
        }
        if(templarChoosen == true)
        {
            hunter.SetActive(false);
        }
        Ready.text = "Players Ready: " + playersReady + "/" + PhotonNetwork.CurrentRoom.MaxPlayers;

        if (Input.GetKey(KeyCode.X))
        {
            this.gameObject.GetPhotonView().RPC("PlayersReady", RpcTarget.AllBuffered, playersReady + 3);
            Debug.Log("contagem ai" + playersReady);
        }

        /*

        _listings.Add(PhotonNetwork.PlayerList.ToStringFull());

        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            player1Str = _listings[0];
            player1.text = player1Str;
        }

        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            player1Str = _listings[0];
            player1.text = player1Str;

            player2Str = _listings[1];
            player2.text = player2Str;
        }

        if (PhotonNetwork.CurrentRoom.PlayerCount == 3)
        {
            player1Str = _listings[0];
            player1.text = player1Str;

            player2Str = _listings[1];
            player2.text = player2Str;

            player3Str = _listings[2];
            player3.text = player3Str;
        }

        if (PhotonNetwork.CurrentRoom.PlayerCount == 4)
        {
            player1Str = _listings[0];
            player1.text = player1Str;

            player2Str = _listings[1];
            player2.text = player2Str;

            player3Str = _listings[2];
            player3.text = player3Str;

            player4Str = _listings[3];
            player4.text = player4Str;
        }
        */
        
       
        roomPlayers.text = "Players: " + PhotonNetwork.CurrentRoom.PlayerCount.ToString() + "/" + PhotonNetwork.CurrentRoom.MaxPlayers.ToString();

        if (playersReady >= 4)
        {

            Cursor.visible = false;
            lobby.SetActive(false);
            SpawnPoint1 = new Vector3(0f, 0f, 0f);

            if (witch1 == true)
            {
                PhotonNetwork.Instantiate("Witch", SpawnPoint1, SpawnPoint, 0);
            }
            if (witch2 == true)
            {
                PhotonNetwork.Instantiate("Witch2", SpawnPoint1, SpawnPoint, 0);
            }
            if (witch3 == true)
            {
                PhotonNetwork.Instantiate("Witch3", SpawnPoint1, SpawnPoint, 0);
            }
            if (templar == true)
            {
                PhotonNetwork.Instantiate("Hunter", SpawnPoint1, SpawnPoint, 0);
            }
        }
    }

    public override void OnJoinedRoom()
    {

    }

    public void StartGame()
    {
        Application.targetFrameRate = 30;
        if (witch1 == true || witch2 == true || witch3 == true || templar == true)
        {
            if(characterChoosed == true)
            {
                characterChoosed = false;
                this.gameObject.GetPhotonView().RPC("PlayersReady", RpcTarget.AllBuffered, playersReady + 1);
                Debug.Log("contagem ai" + playersReady);
            }
        }
    }

    public void Witch1()
    {
         if (witch1Choosen == false && characterChoosed == false)
        {
            characterChoosed = true;
            witch1 = true;
            witch2 = false;
            witch3 = false;
            templar = false;
            this.gameObject.GetPhotonView().RPC("Witch1Choosen", RpcTarget.AllBuffered, true);
        }

        if (witch1Choosen == true)
        {

        }
    }

    public void Witch2()
    {
        
        if (witch2Choosen == false && characterChoosed == false)
        {
            characterChoosed = true;
            witch1 = false;
            witch2 = true;
            witch3 = false;
            templar = false;
            this.gameObject.GetPhotonView().RPC("Witch2Choosen", RpcTarget.AllBuffered, true);
        }
        if (witch2Choosen == true)
        {

        }
    }

    public void Witch3()
    {
        
        if (witch3Choosen == false && characterChoosed == false)
        {
            characterChoosed = true;
            witch1 = false;
            witch2 = false;
            witch3 = true;
            templar = false;
            this.gameObject.GetPhotonView().RPC("Witch3Choosen", RpcTarget.AllBuffered, true);
        }
        if (witch3Choosen == true)
        {

        }
    }

    public void Templar()
    {
        
        if(templarChoosen == false && characterChoosed == false)
        {
            characterChoosed = true;
            witch1 = false;
            witch2 = false;
            witch3 = false;
            templar = true;
            this.gameObject.GetPhotonView().RPC("TemplarChoosen", RpcTarget.AllBuffered, true);
        }
        if (templarChoosen == true)
        {

        }
    }


    [PunRPC]
    public void Witch1Choosen(bool isActive)
    {
        Debug.Log("escolheu");
        witch1Choosen = isActive;
    }

    [PunRPC]
    public void Witch2Choosen(bool isActive)
    {
        witch2Choosen = isActive;
    }

    [PunRPC]
    public void Witch3Choosen(bool isActive)
    {
        witch3Choosen = isActive;
    }

    [PunRPC]
    public void TemplarChoosen(bool isActive)
    {
        templarChoosen = isActive;
    }

    [PunRPC]
    public void PlayersReady(int count)
    {
        playersReady = count;
    }

    [PunRPC]
    public void SetName1()
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
         
        }
    }


    public void playerlist()
    {
        roomName.text = PhotonNetwork.CurrentRoom.Name;
        Debug.Log("ASEEEEEEEEEEESDSADSA");

        /*
        if (player1Filled == false)
        {
            player1.text = PhotonNetwork.NickName;
            this.gameObject.GetPhotonView().RPC("Player1", RpcTarget.AllBuffered, true);
            Debug.LogError("aaaaaaaa");
        }
        else if (player1Filled == true)
        {
            if (player2Filled == false)
            {
                player2.text = PhotonNetwork.NickName;
                this.gameObject.GetPhotonView().RPC("Player2", RpcTarget.AllBuffered, true);
            }
            else
            {
                if (player3Filled == false)
                {
                    player3.text = PhotonNetwork.NickName;
                    this.gameObject.GetPhotonView().RPC("Player3", RpcTarget.AllBuffered, true);
                }
                else
                {
                    if (player4Filled == false)
                    {
                        player4.text = PhotonNetwork.NickName;
                        this.gameObject.GetPhotonView().RPC("Player4", RpcTarget.AllBuffered, true);
                    }
                }
            }
        }*/
    }

}
