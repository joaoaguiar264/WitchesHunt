using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    public static bool theBreach;
    public static int credits; 
    public GameObject coins;

    //Location Names
    public GameObject theBreachText;
    public GameObject cityText;
    public GameObject forestText;
   // public GameObject lakeText;
    public GameObject cemeteryText;

    public bool NoRepeat1 = true;
    public bool NoRepeat2 = true;
    public bool NoRepeat3 = true;
    public bool NoRepeat4 = true;
    public bool NoRepeat5 = true;


    public static int witchesAlive = 3;
    public static int witchesnotScape = 3;
    public Text witchesAliveText;

    public Image Fade;

    public GameObject Warn;
    public GameObject templarWarn;
    public GameObject templarCD;
    public GameObject doorWarn;
    public static bool teleport = false;
    public GameObject hideWarn;

    public PhotonView pv;

    public static GameObject mainHud;
    public GameObject medalhao;
    public GameObject eButton;
    public GameObject fButton;
    public GameObject mapa;

    public GameObject blackSquare;

    public GameObject tab;
    public static bool activeTab;
    public static bool noLoopTab;

    public GameObject TemplarHUD;
    public GameObject WitchHUD;
    public GameObject start;

    public GameObject task5;
    public GameObject task7;
    public GameObject task2;

    public Vector3 SpawnPoint1;
    public Quaternion SpawnPoint;

    public GameObject deathCam;
    public GameObject templarWin;
    public GameObject witchesWin;
    public Text deathText;
    public Text HPText;

    public static bool damageflash;
    public Image damageImage;
    private Color flashColor = new Color(1f, 0f, 0f, 0.5f);
    private float flashspeed = 2f;

    public GameObject[] hunters;
    public int huntersNumber;

    public static bool nameFeito = false;

    public static bool bruxa1 = false;
    public static bool bruxa2 = false;
    public static bool bruxa3 = false;

    public static int tasksCompleted = 0;
    public GameObject essenceBar;


    private void Awake()
    {
        if(Lobby.templar == true)
        {
            TemplarHUD.SetActive(true);
            WitchHUD.SetActive(false);
        }
        else
        {
            WitchHUD.SetActive(true);
            TemplarHUD.SetActive(false);
        }
        
        start.SetActive(true);
    }

    private void Start()
    {
        Application.targetFrameRate = 30;
        nameFeito = true;
        Fade.canvasRenderer.SetAlpha(1.0f);
    }

    public void Update()
    {
        if(witchesAlive <= 0)
        {
            templarWin.SetActive(true);
            Cursor.visible = true;
        }

        if(Hunter.ataquePronto == false)
        {
            templarCD.SetActive(true);
        }


        if(Witch.minimapOnOff == true)
        {
            mapa.SetActive(true);
        }
        else
        {
            mapa.SetActive(false);
        }
        if(tasksCompleted == 1)
        {
            essenceBar.transform.localPosition = new Vector3(-164.414f, -9.019592f, 0);
            essenceBar.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(6.5086f, 8.0274f);
            tasksCompleted = 0;
        }
        if (tasksCompleted == 2)
        {
            essenceBar.transform.localPosition = new Vector3(-162.4533f, -9.019592f, 0);
            essenceBar.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(13.48f, 8.0274f);
            tasksCompleted = 0;
        }
        if (tasksCompleted == 3)
        {
            essenceBar.transform.localPosition = new Vector3(-160.7483f, -9.019592f, 0);
            essenceBar.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(19.5421f, 8.0274f);
            tasksCompleted = 0;

        }
        if (tasksCompleted == 4)
        {
            essenceBar.transform.localPosition = new Vector3(-158.907f, -9.019592f, 0);
            essenceBar.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(26.0892f, 8.0274f);
            tasksCompleted = 0;
        }
        if (tasksCompleted == 5)
        {
            essenceBar.transform.localPosition = new Vector3(-157.0997f, -9.019592f, 0);
            essenceBar.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(32.515f, 8.0274f);
            tasksCompleted = 0;
        }
        if (tasksCompleted == 6)
        {
            essenceBar.transform.localPosition = new Vector3(-155.2754f, -9.019592f, 0);
            essenceBar.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(39.0014f, 8.0274f);
            tasksCompleted = 0;
        }
        if (tasksCompleted == 7)
        {
            essenceBar.transform.localPosition = new Vector3(-153.434f, -9.019592f, 0);
            essenceBar.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(45.5485f, 8.0274f);
            tasksCompleted = 0;
        }
        if (tasksCompleted == 8)
        {
            essenceBar.transform.localPosition = new Vector3(-151.4063f, -9.019592f, 0);
            essenceBar.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(52.7582f, 8.0274f);
            tasksCompleted = 0;
        }


        if (Witch.theBreach == true && NoRepeat1 == true)
        {
            NoRepeat1 = false;
            Witch.theBreach = false;
            theBreachText.gameObject.GetComponent<Fade>().enabled = true;
        }

        if (Witch.city == true && NoRepeat2 == true)
        {
            NoRepeat2 = false;
            Witch.city = false;
            cityText.gameObject.GetComponent<Fade>().enabled = true;
        }

        if (Witch.forest == true && NoRepeat3 == true)
        {
            NoRepeat3 = false;
            Witch.forest = false;
            forestText.gameObject.GetComponent<Fade>().enabled = true;
        }
        /*
        if (Witch.lake == true && NoRepeat4 == true)
        {
            NoRepeat4 = false;
            Witch.lake = false;
            lakeText.gameObject.GetComponent<Fade>().enabled = true;
        }*/

        if (Witch.cemetery == true && NoRepeat5 == true)
        {
            NoRepeat5 = false;
            Witch.cemetery = false;
            cemeteryText.gameObject.GetComponent<Fade>().enabled = true;
        }


        if (Witch.healthdisplay == 3)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
        }

        if (Witch.healthdisplay == 2)
        {
            life1.SetActive(false);
            life2.SetActive(true);
            life3.SetActive(true);
        }

        if (Witch.healthdisplay == 1)
        {
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(true);
        }

        if (Witch.healthdisplay <= 0)
        {
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(false);
        }

        witchesAliveText.text = witchesAlive + "/3";
  
        if(Witch.TaskCam == true || Witch.Task2Cam == true || Witch.Task3Cam == true || Witch.Task4Cam == true || Witch.Task5Cam == true || Witch.Task6Cam == true || Witch.Task7Cam == true || Witch.Task8Cam == true)
        {
            WitchHUD.SetActive(false);
        }
        else
        {
            if(Lobby.templar == false)
            {
                WitchHUD.SetActive(true);
            }
            else
            {
                TemplarHUD.SetActive(true);
                WitchHUD.SetActive(false);
            }
        }

        if(Witch.Task2Cam == true)
        {
            task2.gameObject.GetComponent<Task2>().enabled = true;
        }
        else
        {
            task2.gameObject.GetComponent<Task2>().enabled = false;
        }
        if (Witch.Task5Cam == true)
        {
            task5.gameObject.GetComponent<Task5>().enabled = true;
        }
        else
        {
            task5.gameObject.GetComponent<Task5>().enabled = false;
        }
        if (Witch.Task7Cam == true)
        {
            task7.gameObject.GetComponent<Task7>().enabled = true;
        }
        else
        {
            task7.gameObject.GetComponent<Task7>().enabled = false;
        }


        if (teleport == true)
        {
            teleport = false;
            blackSquare.SetActive(true);
            fadeIn();
            Invoke("fadeOut", 0.5f);
            Invoke("BlackSquare", 1f);
        }

        
        hunters = GameObject.FindGameObjectsWithTag("Hunter");
        mainHud = GameObject.FindGameObjectWithTag("MainHud");
        huntersNumber = hunters.Length;


        if (Hunter.medalhao == true)
        {
            eButton.SetActive(false);
            fButton.SetActive(false);
            medalhao.SetActive(true);
            mapa.SetActive(false);
        }


        // AVISOS INTERFACE

        if (Witch.Aviso == true)
        {
            Warn.gameObject.GetComponent<Text>().text = "Press E to interact";
            Warn.SetActive(true);

        }


        if (Witch.churchDoor == true)
        {
            Warn.gameObject.GetComponent<Text>().text = "Press E to enter";
            Warn.SetActive(true);
        }


        if (Witch.churchDoorBack == true)
        {
            Warn.gameObject.GetComponent<Text>().text = "Press E to exit";
            Warn.SetActive(true);
        }

        if (Hunter.churchDoor == true)
        {
            Debug.Log("dadsadsa");
            templarWarn.gameObject.GetComponent<Text>().text = "Press E to enter";
            templarWarn.SetActive(true);
        }


        if (Hunter.churchDoorBack == true)
        {
            templarWarn.gameObject.GetComponent<Text>().text = "Press E to exit";
            templarWarn.SetActive(true);
        }

        if (Witch.hideWarn == true)
        {
            Warn.gameObject.GetComponent<Text>().text = "Press F to hide";
            Warn.SetActive(true);
        }


        if (Witch.Aviso == false && Witch.churchDoor == false && Witch.churchDoorBack == false && Witch.hideWarn == false)
        {
            Warn.SetActive(false);
        }

        if(Hunter.churchDoor == false && Hunter.churchDoorBack == false)
        {
            templarWarn.SetActive(false);
        }



        // oi te amo <3


        // MORTE

        coins.gameObject.GetComponent<Text>().text = credits.ToString();
        if (pv.IsMine)
        {
            if(Witch.Win == true)
            {
                WitchHUD.SetActive(false);
                witchesWin.SetActive(true);
                Cursor.visible = true;
            }

            if (Witch.morreu == true)
            {
                WitchHUD.SetActive(false);
                deathCam.SetActive(true);
                Cursor.visible = true;
            }
            else
            {
                deathCam.SetActive(false);
            }

            coins.gameObject.GetComponent<Text>().text = credits.ToString(); 
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            tab.SetActive(true);
            Cursor.visible = true;
            activeTab = true;
            noLoopTab = true;
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            tab.SetActive(false);
            Cursor.visible = false;
            activeTab = false;
        }

        if (damageflash == true)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashspeed * Time.deltaTime);
        }
        damageflash = false;

    }

    public void BlackSquare()
    {
        blackSquare.SetActive(false);
    }
    void fadeIn()
    {
        Fade.CrossFadeAlpha(15, 2, false);
    }

    void fadeOut()
    {
        Fade.CrossFadeAlpha(0, 1f, false);
    }

    void FadeDisable()
    {
        theBreachText.gameObject.GetComponent<Fade>().enabled = false;
    }

   public void MainMenu()
    {
        PhotonNetwork.LeaveRoom(true);
        PhotonNetwork.LoadLevel("MainMenu");
        Cursor.visible = true;
    }
    
    public void Desconectar()
    {
        medalhao.SetActive(false);
        PhotonNetwork.LeaveRoom(true);
        PhotonNetwork.LoadLevel("Menu");
        Cursor.visible = true;
    }
}

