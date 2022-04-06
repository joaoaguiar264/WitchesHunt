using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using Cinemachine;

public class Witch : MonoBehaviourPunCallbacks, IPunObservable 
{
    public static bool Win;
    public static bool esconder = false;

    public bool startZoom;
    public bool startZoomOut;

    public GameObject particulas;

    // Spawnpoints
    public Vector3 spawnpoint1;
   // public Vector3 spawnpoint2;
   // public Vector3 spawnpoint3;

    // Tasks Errors
    public static bool taskerro = false;
    public static bool task2erro = false;
    public static bool task3erro = false;
    public static bool task4erro = false;
    public static bool task5erro = false;
    public static bool task6erro = false;
    public static bool task7erro = false;
    public static bool task8erro = false;

    public GameObject Witchh;

    //Location Active
    public static bool theBreach = false;
    public static bool city = false;
    public static bool forest = false;
    public static bool FadeOut = false;
    public static bool lake = false;
    public static bool cemetery = false;

    // Items
    public bool shopOn;
    public bool item1;
    public bool item2;
    public bool item3;
    public bool item4;

    // Tasks Range
    public bool range = false;
    public bool range2 = false;
    public bool range3 = false;
    public bool range4 = false;
    public bool range5 = false;
    public bool range6 = false;
    public bool range7 = false;
    public bool range8 = false;

    public static bool Aviso = false;
    public static bool Warn = false;
    public static bool hideWarn = false;

    // Tasks Cams
    public static bool TaskCam = false;
    public static bool Task2Cam = false;
    public static bool Task3Cam = false;
    public static bool Task4Cam = false;
    public static bool Task5Cam = false;
    public static bool Task6Cam = false;
    public static bool Task7Cam = false;
    public static bool Task8Cam = false;

    public static bool churchDoor = false;
    public static bool churchDoorBack = false;

    public bool task1Ativa = false;

    public static bool morreu = false;

    public bool TESTE = false;

    public bool task1Done;
    public bool task2Done;
    public bool task3Done;
    public bool task4Done;
    public bool task5Done;
    public bool task6Done;
    public bool task7Done;
    public bool task8Done;

    public static bool minimapOnOff = true;

    public GameObject minimap;
    public GameObject audioListener;

    public Quaternion CameraQDefault;
    // TPs
    public GameObject churchInCam;

    // Task1 Cam
    public Quaternion CameraQ1;
    public GameObject task1pos;


    // Task2 Cam
    public Quaternion CameraQ2;
    public GameObject task2pos;

    // Task3 Cam
    public Quaternion CameraQ3;
    public GameObject task3pos;

    // Task4 Cam
    public Quaternion CameraQ4;

    // Task5 Cam
    public Quaternion CameraQ5;
    public GameObject task5pos;

    // Task6 Cam
    public Quaternion CameraQ6;
    public GameObject task6pos;

    // Task7 Cam
    public Quaternion CameraQ7;
    public GameObject task7pos;

    // Task8 Cam
    public Quaternion CameraQ8;
    public GameObject task8pos;


    public PhotonView pv;
    public GameObject PlayerCamera;
    public GameObject CameraManager;
    public MeshRenderer sr;
    public Text PlayernameText;
    public int health;
    public static int healthdisplay;
    public int maxHealth = 3;

    public Transform MyPlayer;
    // Emotes
    public GameObject Emote1;
    public GameObject Emote2;
    public GameObject Emote3;
    public GameObject Emote4;

    private GameObject bruxa1;
    private GameObject bruxa2;
    private GameObject bruxa3;

    private static int oldMask;

    // Start is called before the first frame update
    private void Start()
    {
        health = maxHealth;
        GameManager.credits += 300;

        if (pv.IsMine)
        {
            
            if(this.gameObject.tag == "WitchA")
            {
                spawnpoint1 = new Vector3(-92.95f, 8.3f, -241.16f);
                this.gameObject.transform.position = spawnpoint1;
            }

            if (this.gameObject.tag == "WitchB")
            {
                spawnpoint1 = new Vector3(-95.72f, 1, -286.27f);
                this.gameObject.transform.position = spawnpoint1;
            }

            if (this.gameObject.tag == "WitchC")
            {
                spawnpoint1 = new Vector3(-1.68f, 13f, -149.07f);
                this.gameObject.transform.position = spawnpoint1;
            }
            particulas.SetActive(true);
        }

        if(!pv.IsMine)
        {
            Destroy(audioListener);
            PlayerCamera.SetActive(false);
            CameraManager.SetActive(false);
            this.enabled = false;
        }

    }

    private void Awake()
    {
        oldMask = PlayerCamera.GetComponent<Camera>().cullingMask;    
    }

    void PlayerMaskHide(bool hide_player)
    {
        if(hide_player)
        {
            PlayerCamera.GetComponent<Camera>().cullingMask &= ~(1 << LayerMask.NameToLayer("Player"));
        }
        else
        {
            PlayerCamera.GetComponent<Camera>().cullingMask |= 1 << LayerMask.NameToLayer("Player");
        }
    }


    IEnumerator EmotesA()
    {
        this.gameObject.GetPhotonView().RPC("EmoteA", RpcTarget.AllBuffered, true);
        yield return new WaitForSeconds(2.5f);
        this.gameObject.GetPhotonView().RPC("EmoteA", RpcTarget.AllBuffered, false);
    }

    IEnumerator EmotesB()
    {
        this.gameObject.GetPhotonView().RPC("EmoteB", RpcTarget.AllBuffered, true);
        yield return new WaitForSeconds(2.5f);
        this.gameObject.GetPhotonView().RPC("EmoteB", RpcTarget.AllBuffered, false);
    }

    IEnumerator EmotesC()
    {
        this.gameObject.GetPhotonView().RPC("EmoteC", RpcTarget.AllBuffered, true);
        yield return new WaitForSeconds(2.5f);
        this.gameObject.GetPhotonView().RPC("EmoteC", RpcTarget.AllBuffered, false);
    }

    IEnumerator EmotesD()
    {
        this.gameObject.GetPhotonView().RPC("EmoteD", RpcTarget.AllBuffered, true);
        yield return new WaitForSeconds(2.5f);
        this.gameObject.GetPhotonView().RPC("EmoteD", RpcTarget.AllBuffered, false);
    }


    // Update is called once per frame
    void Update()
    {
        bruxa1 = GameObject.FindGameObjectWithTag("WitchA");
        bruxa2 = GameObject.FindGameObjectWithTag("WitchB");
        bruxa3 = GameObject.FindGameObjectWithTag("WitchC");

        healthdisplay = health;
        if(startZoom == true)
        {
            CameraManager.gameObject.GetComponent<CinemachineFreeLook>().m_Orbits[0].m_Height += 6f * Time.deltaTime; //26
            CameraManager.gameObject.GetComponent<CinemachineFreeLook>().m_Orbits[1].m_Height += 6f * Time.deltaTime; //20
            CameraManager.gameObject.GetComponent<CinemachineFreeLook>().m_Orbits[2].m_Height += 6f * Time.deltaTime; //18.1


            CameraManager.gameObject.GetComponent<CinemachineFreeLook>().m_Orbits[0].m_Radius += 6f * Time.deltaTime; //20
            CameraManager.gameObject.GetComponent<CinemachineFreeLook>().m_Orbits[1].m_Radius += 6f * Time.deltaTime; //26
            CameraManager.gameObject.GetComponent<CinemachineFreeLook>().m_Orbits[2].m_Radius += 6f * Time.deltaTime; //20

            if(CameraManager.gameObject.GetComponent<CinemachineFreeLook>().m_Orbits[0].m_Radius >= 20)
            {
                startZoom = false;
            }
            
        }

        if(startZoomOut == true)
        {
            CameraManager.gameObject.GetComponent<CinemachineFreeLook>().m_Orbits[0].m_Height -= 6f * Time.deltaTime; //26;
            CameraManager.gameObject.GetComponent<CinemachineFreeLook>().m_Orbits[1].m_Height -= 6f * Time.deltaTime; //20;
            CameraManager.gameObject.GetComponent<CinemachineFreeLook>().m_Orbits[2].m_Height -= 6f * Time.deltaTime; //18.1f;


            CameraManager.gameObject.GetComponent<CinemachineFreeLook>().m_Orbits[0].m_Radius -= 6f * Time.deltaTime; //20;
            CameraManager.gameObject.GetComponent<CinemachineFreeLook>().m_Orbits[1].m_Radius -= 6f * Time.deltaTime; //26;
            CameraManager.gameObject.GetComponent<CinemachineFreeLook>().m_Orbits[2].m_Radius -= 6f * Time.deltaTime; //20;

            if (CameraManager.gameObject.GetComponent<CinemachineFreeLook>().m_Orbits[0].m_Radius <= 10)
            {
                startZoomOut = false;
            }
        }

        if (pv.IsMine)
        {
            if(minimapOnOff == true)
            {
                minimap.SetActive(true);
            }
            else
            {
                minimap.SetActive(false);
            }


            //Open Shop
            if (shopOn == true && Input.GetKeyDown(KeyCode.F))
            {
                Shop.shop = true;
            }

            //Open PlayerList
            if(GameManager.activeTab == true)
            {
                CameraManager.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 0f;
                CameraManager.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = 0f;
            }
            else if( GameManager.activeTab == false && GameManager.noLoopTab == true)
            {
                CameraManager.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 100f;
                CameraManager.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = 1f;
                GameManager.noLoopTab = false;
            }

            if(Shop.item1 == true)
            {
                this.gameObject.AddComponent<Item1>();
                Shop.item1 = false;
            }
            if (Shop.item2 == true)
            {
                this.gameObject.AddComponent<Item2>();
                Shop.item2 = false;
            }
            if (Shop.item3 == true)
            {
                this.gameObject.AddComponent<Item3>();
                Shop.item3 = false;
            }
            if (Shop.item4 == true)
            {
                this.gameObject.AddComponent<Item4>();
                Shop.item4 = false;
            }
            
           

            if (health <= 0)
            {
                this.gameObject.GetPhotonView().RPC("Dead", RpcTarget.AllBuffered, true);
                this.gameObject.GetPhotonView().RPC("WitchesAlive", RpcTarget.All, GameManager.witchesAlive - 1);
            }

            // Task 1

            if (Task1.taskFeita == true)
            {
                task1Done = true;
                range = false;
                GameManager.tasksCompleted += 1;
            }

            if (Task2.taskFeita == true)
            {
                task2Done = true;
                range2 = false;
                GameManager.tasksCompleted += 1;
            }

            if (Task3.taskFeita == true)
            {
                task3Done = true;
                range3 = false;
                GameManager.tasksCompleted += 2;
            }
            if (Task4.taskFeita == true)
            {
                task4Done = true;
                range4 = false;
                GameManager.tasksCompleted += 1;
            }
            if (Task5.taskFeita == true)
            {
                task5Done = true;
                range5 = false;
                GameManager.tasksCompleted += 2;
            }
            /*
            if (Task6.taskFeita == true)
            {
                task6Done = true;
                range6 = false;
                GameManager.tasksCompleted += 2;
            }
            */
            if (Task7.taskFeita == true)
            {
                task7Done = true;
                range7 = false;
                GameManager.tasksCompleted += 1;
            }

            // WIN CONDITION
            if (task1Done == true && task2Done == true && task3Done == true && task4Done == true && task5Done == true && task7Done == true)
            {
                GameManager.theBreach = true;

            }

            if (TESTE == true)
            {
                TaskCam = true;
                Debug.Log("Fiz essa merda");
            }

            // Task Cam

            if (TaskCam == true)
            {
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = false;
                PlayerCamera.gameObject.transform.position = task1pos.gameObject.transform.position;
                PlayerCamera.gameObject.transform.rotation = CameraQ1;
                PlayerMaskHide(true);

            }
            else
            {

            }
            

            if (Task2Cam == true)
            {
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = false;
                PlayerCamera.gameObject.transform.position = task2pos.gameObject.transform.position;
                PlayerCamera.gameObject.transform.rotation = CameraQ2;
                PlayerMaskHide(true);
                Cursor.visible = true;
            }
            
            else
            {
                
            }
            

            if (Task3Cam == true)
            {
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = false;
                PlayerCamera.gameObject.transform.position = task3pos.gameObject.transform.position;
                PlayerCamera.gameObject.transform.rotation = CameraQ3;
                PlayerMaskHide(true);
                Cursor.visible = true;
            }
            
            else
            {
                
            }
            
            if (Task4Cam == true)
            {
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = false;
                PlayerCamera.gameObject.transform.rotation = CameraQ4;
                PlayerMaskHide(true);
                Cursor.visible = true;
            }
            else
            {
                
            }

            if (Task5Cam == true)
            {
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = false;
                PlayerCamera.gameObject.transform.position = task5pos.gameObject.transform.position;
                PlayerCamera.gameObject.transform.rotation = CameraQ5;
                PlayerMaskHide(true);
                Cursor.visible = true;
            }
            else
            {

            }

            if (Task6Cam == true)
            {
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = false;
                PlayerCamera.gameObject.transform.position = task6pos.gameObject.transform.position;
                PlayerCamera.gameObject.transform.rotation = CameraQ6;
                PlayerMaskHide(true);
                Cursor.visible = true;
            }
            else
            {

            }

            if (Task7Cam == true)
            {
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = false;
                PlayerCamera.gameObject.transform.position = task7pos.gameObject.transform.position;
                PlayerCamera.gameObject.transform.rotation = CameraQ7;
                PlayerMaskHide(true);
                Cursor.visible = true;
            }
            else
            {

            }

            if (Task8Cam == true)
            {
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = false;
                PlayerCamera.gameObject.transform.position = task8pos.gameObject.transform.position;
                PlayerCamera.gameObject.transform.rotation = CameraQ8;
                PlayerMaskHide(true);
                Cursor.visible = true;
            }
            else
            {

            }

            //maria linda <3

            if (range == true && Input.GetKey(KeyCode.E) && Task1.taskFeita == false)
            {
                Aviso = false;
                TaskCam = true;
            }

            if (range2 == true && Input.GetKey(KeyCode.E) && Task2.taskFeita == false)
            {
                Aviso = false;
                Task2Cam = true;
            }
            else
            {
                Task2Cam = false;
            }
            if (range3 == true && Input.GetKey(KeyCode.E) && Task3.taskFeita == false)
            {
                Aviso = false;
                Task3Cam = true;
            }

            if (range4 == true && Input.GetKey(KeyCode.E) && Task4.taskFeita == false)
            {
                Aviso = false;
                Task4Cam = true;
            }

            if (range5 == true && Input.GetKey(KeyCode.E) && Task5.taskFeita == false)
            {
                Aviso = false;
                Task5Cam = true;
            }
            
            if (range6 == true && Input.GetKey(KeyCode.E) && Task6.taskFeita == false)
            {
                Aviso = false;
                Task6Cam = true;
            }
            
            if (range7 == true && Input.GetKey(KeyCode.E) && Task7.taskFeita == false)
            {
                Aviso = false;
                Task7Cam = true;
            }
            /*
            if (range8 == true && Input.GetKey(KeyCode.E) && Task8.taskFeita == false)
            {
                Aviso = false;
                Task8Cam = true;
            }
            */

            if (taskerro == true)
            {
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = true;
                PlayerCamera.gameObject.transform.rotation = CameraQDefault;
                PlayerMaskHide(false);
                TaskCam = false;
                taskerro = false;
            }

            if (task2erro == true)
            {
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = true;
                PlayerCamera.gameObject.transform.rotation = CameraQDefault;
                PlayerMaskHide(false);
                Task2Cam = false;
                task2erro = false;
                Cursor.visible = false;
            }

            if (task3erro == true)
            {
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = true;
                PlayerCamera.gameObject.transform.rotation = CameraQDefault;
                PlayerMaskHide(false);
                Task3Cam = false;
                task3erro = false;
                Cursor.visible = false;
            }

            if (task4erro == true)
            {
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = true;
                PlayerCamera.gameObject.transform.rotation = CameraQDefault;
                PlayerMaskHide(false);
                Task4Cam = false;
                task4erro = false;
                Cursor.visible = false;
            }

            if (task5erro == true)
            {
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = true;
                PlayerCamera.gameObject.transform.rotation = CameraQDefault;
                PlayerMaskHide(false);
                Task5Cam = false;
                task5erro = false;
                Cursor.visible = false;
            }

            if (task6erro == true)
            {
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = true;
                PlayerCamera.gameObject.transform.rotation = CameraQDefault;
                PlayerMaskHide(false);
                Task6Cam = false;
                task6erro = false;
                Cursor.visible = false;
            }

            if (task7erro == true)
            {
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = true;
                PlayerCamera.gameObject.transform.rotation = CameraQDefault;
                PlayerMaskHide(false);
                Task7Cam = false;
                task7erro = false;
                Cursor.visible = false;
            }

            if (task8erro == true)
            {
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = true;
                PlayerCamera.gameObject.transform.rotation = CameraQDefault;
                PlayerMaskHide(false);
                Task8Cam = false;
                task8erro = false;
                Cursor.visible = false;
            }

        }
        

        // Emotes
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(EmotesA());
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(EmotesB());
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(EmotesC());
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(EmotesD());
        }

    }

    [PunRPC]
    private void OnTriggerEnter(Collider collider)
    {
        if (pv.IsMine)
        {
            if (collider.gameObject.CompareTag("PortalArea"))
            {
                startZoom = true;
                startZoomOut = false;
                theBreach = true;
                Fade.noReplay = true;
            }

            if (collider.gameObject.CompareTag("CityArea"))
            {
                city = true;
                Fade.noReplay = true;
            }

            if (collider.gameObject.CompareTag("ForestArea"))
            {
                forest = true;
                Fade.noReplay = true;
            }
            if (collider.gameObject.CompareTag("LakeArea"))
            {
                lake = true;
                Fade.noReplay = true;
            }
            if (collider.gameObject.CompareTag("CemeteryArea"))
            {
                cemetery = true;
                Fade.noReplay = true;
            }


            if (collider.gameObject.CompareTag("Shop"))
            {
                shopOn = true;
            }

            if (collider.gameObject.CompareTag("Barril") && Input.GetKeyDown(KeyCode.F))
            {
             this.gameObject.GetPhotonView().RPC("Hide", RpcTarget.AllBuffered, false);
             Invoke("Esconder", 0.5f);
            }

            if (collider.gameObject.CompareTag("TheBreach") && GameManager.theBreach == true)
            {
                minimapOnOff = false;
                Destroy(this.gameObject);
                Win = true;
                
            }

            // Tasks Collider

            if (collider.gameObject.CompareTag("Task1"))
            {
             range = true;
             Aviso = true;
            }

            if (collider.gameObject.CompareTag("Task2"))
            {
             range2 = true;
             Aviso = true;
            }

            if (collider.gameObject.CompareTag("Task3"))
             {
             range3 = true;
             Aviso = true;
             }

            if (collider.gameObject.CompareTag("Task4"))
            {
                range4 = true;
                Aviso = true;
            }

            if (collider.gameObject.CompareTag("Task5"))
            {
                range5 = true;
                Aviso = true;
            }

            if (collider.gameObject.CompareTag("Task6"))
            {
                range6 = true;
                Aviso = true;
            }

            if (collider.gameObject.CompareTag("Task7"))
            {
                range7 = true;
                Aviso = true;
            }

            if (collider.gameObject.CompareTag("Task8"))
            {
                range8 = true;
                Aviso = true;
            }



            if (collider.gameObject.CompareTag("Barril"))
             {
                 hideWarn = true;
             }
            if (collider.gameObject.CompareTag("Water"))
            {
                health = 0;
            }

            if (collider.gameObject.CompareTag("churchPortal"))
            {
                churchDoor = true;
            }

            if (collider.gameObject.CompareTag("churchPortalBack"))
            {
                churchDoorBack = true;
            }

        }
    }

    [PunRPC]
    void OnTriggerStay(Collider collision)
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
            else
            {
                CameraManager.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 100f;
                CameraManager.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = 1f;
            }

            if (collision.gameObject.CompareTag("Task2"))
            {
                range2 = true;
                Aviso = true;
            }

            // HIDE MECHANIC

            if (collision.gameObject.CompareTag("Barril") && Input.GetKeyDown(KeyCode.F))
            {
                GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.hide);
                this.gameObject.GetPhotonView().RPC("Hide", RpcTarget.AllBuffered, false);
                Invoke("Esconder", 0.5f);

            }

     }

    }

    void OnTriggerExit(Collider collision)
    {
        if (pv.IsMine)
        {
            if (collision.gameObject.CompareTag("PortalArea"))
            {
                startZoom = false;
                startZoomOut = true;
                FadeOut = true;
                theBreach = false; 
            }

            if (collision.gameObject.CompareTag("CityArea"))
            {
                city = false;
            }

            if (collision.gameObject.CompareTag("ForestArea"))
            {
                forest = false;
            }

            if (collision.gameObject.CompareTag("LakeArea"))
            {
                lake = false;
            }

            if (collision.gameObject.CompareTag("CemeteryArea"))
            {
                cemetery = false;
            }


            if (collision.gameObject.CompareTag("churchIsOn"))
            {
                CameraManager.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 100f;
                CameraManager.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = 1f;
            }

            if (collision.gameObject.CompareTag("Shop"))
            {
                shopOn = false;
                Cursor.visible = false;
            }

            if (collision.gameObject.tag == "Task1")
            {
                range = false;
                Aviso = false;
                TaskCam = false;
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = true;
                PlayerCamera.gameObject.transform.rotation = CameraQDefault;
                PlayerMaskHide(false);
            }

            if (collision.gameObject.tag == "Task2")
            {
                Aviso = false;
                range2 = false;
                Task2Cam = false;
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = true;
                PlayerCamera.gameObject.transform.rotation = CameraQDefault;
                PlayerMaskHide(false);
            }

            if (collision.gameObject.tag == "Task3")
            {
                Aviso = false;
                range3 = false;
                Task3Cam = false;
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = true;
                PlayerCamera.gameObject.transform.rotation = CameraQDefault;
                PlayerMaskHide(false);
            }

            if (collision.gameObject.tag == "Task4")
            {
                Aviso = false;
                range4 = false;
                Task4Cam = false;
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = true;
                PlayerCamera.gameObject.transform.rotation = CameraQDefault;
                PlayerMaskHide(false);
            }

            if (collision.gameObject.tag == "Task5")
            {
                Aviso = false;
                range5 = false;
                Task5Cam = false;
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = true;
                PlayerCamera.gameObject.transform.rotation = CameraQDefault;
                PlayerMaskHide(false);
            }

            if (collision.gameObject.tag == "Task6")
            {
                Aviso = false;
                range6 = false;
                Task6Cam = false;
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = true;
                PlayerCamera.gameObject.transform.rotation = CameraQDefault;
                PlayerMaskHide(false);
            }

            if (collision.gameObject.tag == "Task7")
            {
                Aviso = false;
                range7 = false;
                Task7Cam = false;
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = true;
                PlayerCamera.gameObject.transform.rotation = CameraQDefault;
                PlayerMaskHide(false);
            }

            if (collision.gameObject.tag == "Task8")
            {
                Aviso = false;
                range8 = false;
                Task8Cam = false;
                PlayerCamera.GetComponent<CinemachineBrain>().enabled = true;
                PlayerCamera.gameObject.transform.rotation = CameraQDefault;
                PlayerMaskHide(false);
            }


            if (collision.gameObject.CompareTag("Barril"))
            {
                hideWarn = false;
            }


            if (collision.gameObject.CompareTag("churchPortal"))
            {
                churchDoor = false;
            }

            if (collision.gameObject.CompareTag("churchPortalBack"))
            {
                churchDoorBack = false;
            }

        } 
    }

    //Emotes

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

    void Esconder()
    {
        esconder = true;
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(health); 
           
        }
        else
        {
           health = (int)stream.ReceiveNext();

        }
    }
        
    

    [PunRPC]
    public void TakeDamage(int p_damage)
    {
        bruxa1.gameObject.GetComponent<Witch>().health -= p_damage;
            GameManager.damageflash = true;
            Debug.Log(health);
        
    }

    [PunRPC]
    public void TakeDamage2(int p_damage)
    {
        bruxa2.gameObject.GetComponent<Witch>().health -= p_damage;
        GameManager.damageflash = true;
        Debug.Log(health);

    }

    [PunRPC]
    public void TakeDamage3(int p_damage)
    {
        bruxa3.gameObject.GetComponent<Witch>().health -= p_damage;
        GameManager.damageflash = true;
        Debug.Log(health);

    }

    [PunRPC]
    public void Dead(bool isdead)
    {
        if (pv.IsMine)
        {
            morreu = true;
        }
        this.gameObject.SetActive(false);
        
    }

    [PunRPC]
    public void WitchesAlive(int value)
    {
        GameManager.witchesAlive = value;
        Debug.Log("numero ae" + GameManager.witchesAlive);
    }


    [PunRPC]
    public void Hide(bool setActive)
    {
        this.gameObject.SetActive(setActive);  
    }

    [PunRPC]
    public void EmoteA(bool setActive)
    {
        Emote1.gameObject.SetActive(setActive);
    }

    [PunRPC]
    public void EmoteB(bool setActive)
    {

        Emote2.gameObject.SetActive(setActive);
    }

    [PunRPC]
    public void EmoteC(bool setActive)
    {

        Emote3.gameObject.SetActive(setActive);
    }

    [PunRPC]
    public void EmoteD(bool setActive)
    {

        Emote4.gameObject.SetActive(setActive); 
    }

    
}



