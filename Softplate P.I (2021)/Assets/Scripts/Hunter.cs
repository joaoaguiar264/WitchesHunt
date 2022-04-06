using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using Cinemachine;

public class Hunter : MonoBehaviour
{
    private Animator anim;

    public PhotonView pv;
    public GameObject PlayerCamera;
    public GameObject CameraManager;
    public MeshRenderer sr;
    public Text PlayernameText;

    public AudioSource SFX;

    public static bool churchDoor = false;
    public static bool churchDoorBack = false;

    public static bool ataquePronto = true;
    public int damage = 1;
    public bool range = false;
    public bool range2 = false;
    public bool range3 = false;

    public GameObject bruxa1;
    public GameObject bruxa2;
    public GameObject bruxa3;

    public static bool medalhao = false;

    // TPs
    public GameObject churchInCam;

    // Emotes
    public GameObject Emote1;
    public GameObject Emote2;
    public GameObject Emote3;
    public GameObject Emote4;

    public GameObject audioListener;

    public bool item2Hit;
    public bool item3Hit;
    public bool item4Hit;


    // Start is called before the first frame update
    private void Start()
    {
        SFX = this.gameObject.GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
        if (!pv.IsMine)
        {
            Destroy(audioListener);
            Destroy(PlayerCamera);
            CameraManager.SetActive(false);
            this.enabled = false;
        }
    }

    private void Awake()
    {

        if (pv.IsMine)
        {
            PlayerCamera.SetActive(true);
        }
    }

    void PlayerMaskHide(bool hide_player)
    {
        if (hide_player)
        {
            PlayerCamera.GetComponent<Camera>().cullingMask &= ~(1 << LayerMask.NameToLayer("Player"));
        }
        else
        {
            PlayerCamera.GetComponent<Camera>().cullingMask |= 1 << LayerMask.NameToLayer("Player");
        }
    }


    void Update()
    {
        bruxa1 = GameObject.FindGameObjectWithTag("WitchA");
        bruxa2 = GameObject.FindGameObjectWithTag("WitchB");
        bruxa3 = GameObject.FindGameObjectWithTag("WitchC");

        if (pv.IsMine)
        {
            if(ThirdPersonMovement.inMovement == true)
            {
               
            }
            else
            {

            }
            
            if (Input.GetKeyDown(KeyCode.F) && ataquePronto == true)
            {
                this.gameObject.GetPhotonView().RPC("Hit", RpcTarget.AllBuffered, true);
                Invoke("HitEnd", 0.2f);
                ataquePronto = false;
                Invoke("Recarga", 2f);
            }

            if (MultiplayerManager.item1Ativo == true)
            {
                Debug.Log("DEU CERTO////////");
                PlayerMaskHide(true);
            }
            else
            {
                PlayerMaskHide(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Invoke("EmoteAOn", 0f);
            Invoke("EmoteA", 3f);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Invoke("EmoteBOn", 0f);
            Invoke("EmoteB", 3f);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Invoke("EmoteCOn", 0f);
            Invoke("EmoteC", 3f);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Invoke("EmoteDOn", 0f);
            Invoke("EmoteD", 3f);
        }

    }

    //Emotes
    [PunRPC]
    void EmoteAOn()
    {
        Emote1.SetActive(true);
    }
    [PunRPC]
    void EmoteA()
    {
        Emote1.SetActive(false);
    }
    [PunRPC]
    void EmoteBOn()
    {
        Emote2.SetActive(true);
    }
    [PunRPC]
    void EmoteB()
    {
        Emote2.SetActive(false);
    }
    [PunRPC]
    void EmoteCOn()
    {
        Emote3.SetActive(true);
    }
    [PunRPC]
    void EmoteC()
    {
        Emote3.SetActive(false);
    }
    [PunRPC]
    void EmoteDOn()
    {
        Emote4.SetActive(true);
    }
    [PunRPC]
    void EmoteD()
    {
        Emote4.SetActive(false);
    }

    [PunRPC]
    private void OnTriggerEnter(Collider collision)
    {
        if (pv.IsMine)
        {
            if (collision.gameObject.CompareTag("churchIsOn"))
            {
                CameraManager.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 0f;
                CameraManager.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = 0f;
                CameraManager.GetComponent<CinemachineFreeLook>().m_YAxis.Value = 1f;
                CameraManager.GetComponent<CinemachineFreeLook>().m_XAxis.Value = 0f;
            }

            if(collision.gameObject.tag == "WitchA")
            {
                range = true;
            }
            if (collision.gameObject.tag == "WitchB")
            {
                range2 = true;
            }
            if (collision.gameObject.tag == "WitchC")
            {
                range3 = true;
            }

            if (collision.gameObject.CompareTag("churchPortal"))
            {
                churchDoor = true;
            }

            if (collision.gameObject.CompareTag("churchPortalBack"))
            {
                churchDoorBack = true;
            }

        }
    }

    [PunRPC]
    private void OnTriggerStay(Collider collision)
    {
        if (pv.IsMine)
        {
            if (collision.gameObject.tag == "WitchA" || collision.gameObject.tag == "WitchB" || collision.gameObject.tag == "WitchC")
            {
                if (range == true && Input.GetKeyDown(KeyCode.F) && ataquePronto == true)
                {
                    this.gameObject.GetPhotonView().RPC("Hit", RpcTarget.AllBuffered, true);
                    Invoke("HitEnd", 0.2f);
                    ataquePronto = false;
                    Invoke("Recarga", 2f);
                    collision.gameObject.GetPhotonView().RPC("TakeDamage", RpcTarget.All, damage);
                }

                if (range2 == true && Input.GetKeyDown(KeyCode.F) && ataquePronto == true)
                {
                    this.gameObject.GetPhotonView().RPC("Hit", RpcTarget.AllBuffered, true);
                    Invoke("HitEnd", 0.2f);
                    ataquePronto = false;
                    Invoke("Recarga", 2f);
                    collision.gameObject.GetPhotonView().RPC("TakeDamage2", RpcTarget.All, damage);
                }

                if (range3 == true && Input.GetKeyDown(KeyCode.F) && ataquePronto == true)
                {
                    this.gameObject.GetPhotonView().RPC("Hit", RpcTarget.AllBuffered, true);
                    Invoke("HitEnd", 0.2f);
                    ataquePronto = false;
                    Invoke("Recarga", 2f);
                    collision.gameObject.GetPhotonView().RPC("TakeDamage3", RpcTarget.All, damage);
                }
            }

            if (collision.gameObject.CompareTag("churchIsOn"))
            {
                CameraManager.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 0f;
                CameraManager.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = 0f;
                CameraManager.GetComponent<CinemachineFreeLook>().m_YAxis.Value = 1f;
                CameraManager.GetComponent<CinemachineFreeLook>().m_XAxis.Value = 0f;
            }

            
        }
    }


    void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.tag == "WitchA")
        {
            range = false;
        }
        if (collision.gameObject.tag == "WitchB")
        {
            range2 = false;
        }
        if (collision.gameObject.tag == "WitchC")
        {
            range3 = false;
        }


        if (collision.gameObject.CompareTag("churchPortal"))
        {
            churchDoor = false;
        }

        if (collision.gameObject.CompareTag("churchPortalBack"))
        {
            churchDoorBack = false;
        }
        if (collision.gameObject.CompareTag("churchIsOn"))
        {
            CameraManager.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 100f;
            CameraManager.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = 1f;
        }
    }

    public void Recarga()
    {
        ataquePronto = true;
        Load.reset = true;
    }

    [PunRPC]
    public void Hit(bool isActive)
    {
        anim.SetBool("Hit", isActive);
        if(isActive == true)
        {
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.sword);
        }
        

    }
    
    [PunRPC]
    public void HitEnd()
    {
        this.gameObject.GetPhotonView().RPC("Hit", RpcTarget.AllBuffered, false);
    }
    
    [PunRPC]
    public void TakeDamage(int p_damage)
    {
        bruxa1.gameObject.GetComponent<Witch>().TakeDamage(p_damage);
    }

    [PunRPC]
    public void TakeDamage2(int p_damage)
    {

        bruxa2.gameObject.GetComponent<Witch>().TakeDamage2(p_damage);
    }

    [PunRPC]
    public void TakeDamage3(int p_damage)
    {

        bruxa3.gameObject.GetComponent<Witch>().TakeDamage3(p_damage);
    }


}


