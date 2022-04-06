using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task3 : MonoBehaviour
{
    public GameObject Task;
    public GameObject acabou;
    public GameObject timeOver;

    public GameObject taskIcon;

    public static bool taskFeita = false;
    public static bool ganhou = false;
    public static bool errou = false;
    public bool firstTime = true;
    public int timer = 0;

    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject seven;
    public GameObject eight;
    public GameObject nine;
    public GameObject ten;

    public bool number1 = true;
    public bool number2 = false;
    public bool number3 = false;
    public bool number4 = false;
    public bool number5 = false;
    public bool number6 = false;
    public bool number7 = false;
    public bool number8 = false;
    public bool number9 = false;
    public bool number10 = false;

    public int contagem = 0;

    private Animator anim;


    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(Witch.Task3Cam == true)
        {
            Task.SetActive(true);
        }
        if (Witch.Task3Cam == true && firstTime == true)
        {
            firstTime = false;

        }

        if (Witch.Task3Cam == false)
        {
            Task.SetActive(false);
        }


        if(contagem >= 10)
        {
            ganhou = true;
        }

        if (ganhou == true)
        {
            taskIcon.SetActive(false);
            Witch.task3erro = true;
            acabou.SetActive(true);
            contagem = 0;
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.right);
            Invoke("Close", 1.5f);
            ganhou = false;
            Task.SetActive(false);
            taskFeita = true;
        }

        if (errou == true)
        {
            Witch.task3erro = true;
            contagem = 0;
            errou = false;
            Task.SetActive(false);
            firstTime = true;
            one.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            two.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            three.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            four.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            five.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            six.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            seven.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            eight.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            nine.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            ten.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }


    }
    void Close()
    {
        ganhou = false;
        Witch.task3erro = false;
        Task.SetActive(false);
        acabou.SetActive(false);
        timeOver.SetActive(false);
        this.gameObject.tag = "Untagged";
    }

    void Time()
    {
        errou = true;
        timeOver.SetActive(true);
    }

    public void N1()
    {
        if (number1)
        {
            one.gameObject.GetComponent<Image>().color = new Color(0, 255, 0, 255);
            contagem += 1;
            number2 = true;
        }
        else
        {
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.wrong);
            Invoke("Errou", 0.2f);
            one.gameObject.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
    }

    public void N2()
    {
        if (number2)
        {
            two.gameObject.GetComponent<Image>().color = new Color(0, 255, 0, 255);
            contagem += 1;
            number3 = true;
        }
        else
        {
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.wrong);
            Invoke("Errou", 0.2f);
            two.gameObject.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
    }

    public void N3()
    {
        if (number3)
        {
            three.gameObject.GetComponent<Image>().color = new Color(0, 255, 0, 255);
            contagem += 1;
            number4 = true;
        }
        else
        {
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.wrong);
            Invoke("Errou", 0.2f);
            three.gameObject.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
    }

    public void N4()
    {
        if (number4)
        {
            four.gameObject.GetComponent<Image>().color = new Color(0, 255, 0, 255);
            contagem += 1;
            number5 = true;
        }
        else
        {
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.wrong);
            Invoke("Errou", 0.2f);
            four.gameObject.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
    }

    public void N5()
    {
        if (number5)
        {
            five.gameObject.GetComponent<Image>().color = new Color(0, 255, 0, 255);
            contagem += 1;
            number6 = true;
        }
        else
        {
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.wrong);
            Invoke("Errou", 0.2f);
            five.gameObject.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
    }

    public void N6()
    {
        if (number6)
        {
            six.gameObject.GetComponent<Image>().color = new Color(0, 255, 0, 255);
            contagem += 1;
            number7 = true;
        }
        else
        {
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.wrong);
            Invoke("Errou", 0.2f);
            six.gameObject.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
    }

    public void N7()
    {
        if (number7)
        {
            seven.gameObject.GetComponent<Image>().color = new Color(0, 255, 0, 255);
            contagem += 1;
            number8 = true;
        }
        else
        {
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.wrong);
            Invoke("Errou", 0.2f);
            seven.gameObject.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
    }

    public void N8()
    {
        if (number8)
        {
            eight.gameObject.GetComponent<Image>().color = new Color(0, 255, 0, 255);
            contagem += 1;
            number9 = true;
        }
        else
        {
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.wrong);
            Invoke("Errou", 0.2f);
            eight.gameObject.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
    }

    public void N9()
    {
        if (number9)
        {
            nine.gameObject.GetComponent<Image>().color = new Color(0, 255, 0, 255);
            contagem += 1;
            number10 = true;
        }
        else
        {
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.wrong);
            Invoke("Errou", 0.2f);
            nine.gameObject.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
    }

    public void N10()
    {
        if (number10)
        {
            ten.gameObject.GetComponent<Image>().color = new Color(0, 255, 0, 255);
            contagem += 1;
        }
        else
        {
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.wrong);
            Invoke("Errou", 0.2f);
            ten.gameObject.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
    }

    public void Errou()
    {
        errou = true;
    }

}
