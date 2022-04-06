using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using Photon.Pun;

public class Menu : MonoBehaviourPunCallbacks
{
    public GameObject options;
    public GameObject howToPlay;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Application.targetFrameRate = 75;
        Debug.Log("Connected");
    }

    public void Jogar()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Opcoes()
    {
        options.SetActive(true);
        howToPlay.SetActive(false);
    }
    public void ComoJogar()
    {
        howToPlay.SetActive(true);
        options.SetActive(false);
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void OpcoesVoltar()
    {
        options.SetActive(false);
    }
    public void ComoJogarVoltar()
    {
        howToPlay.SetActive(false);
    }
}
