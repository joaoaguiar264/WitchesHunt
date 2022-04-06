using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Reativar : MonoBehaviour
{
    public GameObject bruxa;
    public bool desesconder = false;


    public PhotonView pv;


    [PunRPC]
    public void UnHide()
    {
        if (pv.IsMine)
        {
        Witch.esconder = false;
        }
        bruxa.gameObject.SetActive(true);
        desesconder = false;
    }

    void Start()
    {
    }

    void Update()
    {
        if (pv.IsMine)
        { 

        if (Witch.esconder == true && Input.GetKeyDown(KeyCode.F))
        {
                Debug.Log("vagabunda");
            desesconder = true;
        }

        if (desesconder == true)
        {
                GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.hide);
                gameObject.GetPhotonView().RPC("UnHide", RpcTarget.All);
        }
    }
}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Primeiro"))
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
