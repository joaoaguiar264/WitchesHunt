using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChurchTeleport : MonoBehaviour
{
    public bool churchPortalcd = true;

    public PhotonView pv;

    public GameObject Witch1;
    public GameObject Witch2;
    public GameObject Witch3;
    public GameObject Templar;

    public GameObject churchIn;
    public GameObject churchOut;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Witch1 = GameObject.FindGameObjectWithTag("WitchA");
        Witch2 = GameObject.FindGameObjectWithTag("WitchB");
        Witch3 = GameObject.FindGameObjectWithTag("WitchC");
        Templar = GameObject.FindGameObjectWithTag("HunterA");

        if (pv.IsMine)
        {

        
        if (Lobby.witch1 == true)
        {
            if (Witch.churchDoor == true && churchPortalcd == true && Input.GetKeyDown(KeyCode.E))
            {
                Witch.minimapOnOff = false;
                Debug.Log("foi//");
                GameManager.teleport = true;
                churchPortalcd = false;
                Witch.churchDoor = false;
                Invoke("ChurchPortal", 1f);
                this.gameObject.GetPhotonView().RPC("ChurchTP", RpcTarget.All);

            }

            if (Witch.churchDoorBack == true && Input.GetKeyDown(KeyCode.E) && churchPortalcd == true)
            {
                Witch.minimapOnOff = true;
                GameManager.teleport = true;
                churchPortalcd = false;
                Witch.churchDoorBack = false;
                Invoke("ChurchPortal", 1f);
                this.gameObject.GetPhotonView().RPC("ChurchTPOut", RpcTarget.All);
            }
        }

        if (Lobby.witch2 == true)
        {
            if (Witch.churchDoor == true && churchPortalcd == true && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("foi//");
                GameManager.teleport = true;
                churchPortalcd = false;
                Witch.churchDoor = false;
                Invoke("ChurchPortal", 1f);
                this.gameObject.GetPhotonView().RPC("ChurchTP2", RpcTarget.All);

            }

            if (Witch.churchDoorBack == true && Input.GetKeyDown(KeyCode.E) && churchPortalcd == true)
            {
                GameManager.teleport = true;
                churchPortalcd = false;
                Witch.churchDoorBack = false;
                Invoke("ChurchPortal", 1f);
                this.gameObject.GetPhotonView().RPC("ChurchTPOut2", RpcTarget.All);
            }
        }

        if (Lobby.witch3 == true)
        {
            if (Witch.churchDoor == true && churchPortalcd == true && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("foi//");
                GameManager.teleport = true;
                churchPortalcd = false;
                Witch.churchDoor = false;
                Invoke("ChurchPortal", 1f);
                this.gameObject.GetPhotonView().RPC("ChurchTP3", RpcTarget.All);

            }

            if (Witch.churchDoorBack == true && Input.GetKeyDown(KeyCode.E) && churchPortalcd == true)
            {
                GameManager.teleport = true;
                churchPortalcd = false;
                Witch.churchDoorBack = false;
                Invoke("ChurchPortal", 1f);
                this.gameObject.GetPhotonView().RPC("ChurchTPOut3", RpcTarget.All);
            }
        }

        if (Lobby.templar == true)
        {
            if (Hunter.churchDoor == true && churchPortalcd == true && Input.GetKey(KeyCode.E))
            {
                GameManager.teleport = true;
                churchPortalcd = false;
                Hunter.churchDoor = false;
                Invoke("ChurchPortal", 1f);
                this.gameObject.GetPhotonView().RPC("ChurchTP0", RpcTarget.All);
            }

            if (Hunter.churchDoorBack == true && Input.GetKey(KeyCode.E) && churchPortalcd == true)
            {
                GameManager.teleport = true;
                churchPortalcd = false;
                Hunter.churchDoorBack = false;
                Invoke("ChurchPortal", 1f);
                this.gameObject.GetPhotonView().RPC("ChurchTPOut0", RpcTarget.All);
            }
        }
        }
    }
    void ChurchPortal()
    {
        churchPortalcd = true;
    }
    // WITCH 1
    [PunRPC]
    public void ChurchTP()
    {
        Witch1.gameObject.transform.position = churchIn.gameObject.transform.position;
    }

    [PunRPC]
    public void ChurchTPOut()
    {
        Witch1.gameObject.transform.position = churchOut.gameObject.transform.position;
    }

    // WITCH 2
    [PunRPC]
    public void ChurchTP2()
    {
        Witch2.gameObject.transform.position = churchIn.gameObject.transform.position;
    }

    [PunRPC]
    public void ChurchTPOut2()
    {
        Witch2.gameObject.transform.position = churchOut.gameObject.transform.position;
    }

    // WITCH 3
    [PunRPC]
    public void ChurchTP3()
    {
        Witch3.gameObject.transform.position = churchIn.gameObject.transform.position;
    }

    [PunRPC]
    public void ChurchTPOut3()
    {
        Witch3.gameObject.transform.position = churchOut.gameObject.transform.position;
    }

    // TEMPLAR
    [PunRPC]
    public void ChurchTP0()
    {
        Templar.gameObject.transform.position = churchIn.gameObject.transform.position;
    }

    [PunRPC]
    public void ChurchTPOut0()
    {
        Templar.gameObject.transform.position = churchOut.gameObject.transform.position;
    }
}
