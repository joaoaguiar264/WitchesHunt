using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MultiplayerManager : MonoBehaviour
{
    public static bool item1Ativo;
    public bool item1NoLoop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Item1.activeItem == true && item1NoLoop == true)
        {
            StartCoroutine(Item());
            item1NoLoop = false;
        }
    }

    [PunRPC]
    public void ActiveItem(bool active)
    {
        item1Ativo = active;
        Item1.activeItem = active;
        Debug.LogError("UAI PORRA");
        
    }
    public void Finish()
    {
        Item1.activeItem = false;
        
    }
    IEnumerator Item()
    {
        this.gameObject.GetPhotonView().RPC("ActiveItem", RpcTarget.AllBuffered, true);
        yield return new WaitForSeconds(2.5f);
        this.gameObject.GetPhotonView().RPC("ActiveItem", RpcTarget.AllBuffered, false);
        
    }
}
