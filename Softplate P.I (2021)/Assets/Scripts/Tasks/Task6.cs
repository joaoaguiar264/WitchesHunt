using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task6 : MonoBehaviour
{
    //  public GameObject task;

    public GameObject task;
    public static bool taskFeita = false;
    public static int contagem;
    public static bool errou = false;
    public static bool ganhou = false;
    public GameObject acabou;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Witch.Task6Cam == true)
        {
            task.SetActive(true);
            Cursor.visible = true;
        }
        else
        {
            task.SetActive(false);
            
        } 

        if (contagem >= 5)
        {
            ganhou = true;
        }

        if (ganhou == true)
        {
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.right);
            Witch.task6erro = true;
            Witch.Task6Cam = false;
            acabou.SetActive(true);
            contagem = 0;
            Invoke("Close", 1.5f);
            ganhou = false;
         //   task.SetActive(false);
            taskFeita = true;
        }
    }
}
