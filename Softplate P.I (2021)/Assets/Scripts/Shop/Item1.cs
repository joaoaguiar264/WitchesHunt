using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Item1 : MonoBehaviour
{
    public static bool activeItem;
    public bool cd = true;
    public float duration;
    public PhotonView pv;
    public Material InviMaterial;
    public Material defaultMaterial;

    // Start is called before the first frame update
    void Start()
    {
        duration = 2.5f;
        pv = this.gameObject.GetComponent<PhotonView>();
        InviMaterial = Resources.Load<Material>("WitchInviMat");
        defaultMaterial = Resources.Load<Material>("WitchMat");


    }

    // Update is called once per frame
    void Update()
    {
        if (pv.IsMine)
        {
            if (Input.GetKey(KeyCode.Alpha1) && cd == true)
            {
                activeItem = true;
                cd = false;
                Invoke("coldown", 60f);
                Invoke("Finish", 2.5f);
            }

            if(activeItem == true)
            {
                this.gameObject.GetComponent<MeshRenderer>().material = InviMaterial;
                Debug.Log("INSIVIVEL CARALHOOOOO");
            }
            else
            {
                this.gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
            }
        }
        
        
    }
    public void Finish()
    {
       activeItem = false;
    }

    public void coldown()
    {
        cd = true;
    }

}
