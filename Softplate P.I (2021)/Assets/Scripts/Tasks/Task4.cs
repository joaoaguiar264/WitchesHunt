using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Task4 : MonoBehaviour
{
    public GameObject task;

    public GameObject taskIcon;

    public static bool taskFeita = false;
    public static int contagem;
    public static bool errou = false;
    public static bool ganhou = false;
    public GameObject acabou;

    public void Update()
    {
        if (Witch.Task4Cam == true)
        {
            task.SetActive(true);
        }
        else
        {
            task.SetActive(false);
        }

        if(contagem >= 6)
        {
            ganhou = true;
        }

        if (ganhou == true)
        {
            taskIcon.SetActive(false);
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.right);
            Witch.task4erro = true;
            Witch.Task4Cam = false;
            acabou.SetActive(true);
            contagem = 0;
            Invoke("Close", 1.5f);
            ganhou = false;
            task.SetActive(false);
            taskFeita = true;
        }
    }

    void Close()
    {
        ganhou = false;
        errou = false;
        acabou.SetActive(false);
        this.gameObject.tag = "Untagged";

    }

}
