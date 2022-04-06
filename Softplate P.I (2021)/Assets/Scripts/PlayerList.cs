using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class PlayerList : MonoBehaviour
{
    [SerializeField] private Text _text;

    public static string Nickname;

    public Player Player{ get; private set; }

    public RoomInfo RoomInfo { get; private set; }

    public void SetPlayerInfo(Player player)
    {
       Player = player;
        _text.text = player.NickName;
        Nickname = player.NickName;
    }


}
