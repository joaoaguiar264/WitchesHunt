using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task1 : MonoBehaviour
{
    public GameObject Task;
    public GameObject acabou;
    public GameObject Q;
    public GameObject E;
    public Color ativo;
    public Color desativo;

    public GameObject taskIcon;

    public bool NoRepeat = true;
    public static bool taskFeita = false;
    public static bool ganhou = false;

    public static bool Vitoria;

    private Animator anim;

    public bool freeE = false;
    public bool freeQ = false;
    public int contagem;

    private void Start()
    {
        ativo = new Color(255, 255, 255, 255);
        desativo = new Color(255, 255, 255, -255);
       anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(Witch.TaskCam == true && NoRepeat == true)
        {
            Task.SetActive(true);
            freeQ = true;
            Q.gameObject.GetComponent<RawImage>().color = ativo;
            NoRepeat = false;
        }
        else if(Witch.TaskCam == false)
        {
            NoRepeat = true;
            E.gameObject.GetComponent<RawImage>().color = desativo;
            Q.gameObject.GetComponent<RawImage>().color = desativo;
        }

        if(Witch.taskerro == true)
        {
            anim.SetInteger("Ativo", 0);
            contagem = 0;
        }

        if (ganhou == true)
        {
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.right);
            taskIcon.SetActive(false);
            contagem = 0;
            ganhou = false;
            E.gameObject.GetComponent<RawImage>().color = desativo;
            Q.gameObject.GetComponent<RawImage>().color = desativo;
            freeE = false;
            freeQ = false;
            Witch.taskerro = true;
            Witch.TaskCam = false; 
            acabou.SetActive(true);
            anim.SetInteger("Ativo", 0); 
            Invoke("Close", 1.5f);
            taskFeita = true;
        }

        anim.SetInteger("Ativo", contagem);

        if (contagem == 15 && taskFeita == false)
        {
            ganhou = true;
        }

        

        if (Input.GetKeyDown(KeyCode.E) && freeE == true)
        {
            E.gameObject.GetComponent<RawImage>().color = desativo;
            Q.gameObject.GetComponent<RawImage>().color = ativo;
            freeQ = true;
            freeE = false;
            contagem++;
        }
        if(Input.GetKeyDown(KeyCode.Q) && freeQ == true)
        {
            Q.gameObject.GetComponent<RawImage>().color = desativo;
            E.gameObject.GetComponent<RawImage>().color = ativo;
            freeE = true;
            freeQ = false;
            contagem++;
        }
    }
    void Close()
    {
        ganhou = false;
        Witch.taskerro = false;
        acabou.SetActive(false);
        this.gameObject.tag = "Untagged";
        Task.SetActive(false);
    }

}
