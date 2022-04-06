using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class RoomList : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Text _text2;

    public RoomInfo RoomInfo { get; private set; }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        _text.text =  roomInfo.Name;
        _text2.text = roomInfo.PlayerCount + "/" + roomInfo.MaxPlayers;
    }
   
    public void OnClick_Button()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }
   
}
