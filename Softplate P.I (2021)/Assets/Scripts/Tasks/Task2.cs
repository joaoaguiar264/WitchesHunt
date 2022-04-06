using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task2 : MonoBehaviour
{

    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    private Transform _selection;

    public GameObject taskIcon;

    public static bool taskFeita = false;
    private Animator anim;

    public GameObject acabou;
    public GameObject task;
    public GameObject img1;
    public GameObject img2;
    public GameObject img3;
    public GameObject img4;

    public static int Herb1;
    public static int Herb2;
    public static int Herb3;
    public int contagem = 0;
    public static bool errou = false;
    public static bool ganhou = false;

    public GameObject Erva1;
    public GameObject Erva2;
    public GameObject Erva3;
    public GameObject Erva4;
    public GameObject Erva5;
    public GameObject Erva6;
    public GameObject Erva7;
    public GameObject Erva8;

    public int randomNumber = -1;
    
    void Update()
    {
        if(Witch.Task2Cam == true)
        {   
            task.SetActive(true);
        }

        if(Witch.Task2Cam == false)
        {
            task.SetActive(false);
            img1.SetActive(false);
            img2.SetActive(false);
            img3.SetActive(false);
            img4.SetActive(false);
            randomNumber = -1;
        }

        if(contagem >= 2)
        {
            ganhou = true;
            contagem = 0;

        } 
     // RANDOM SYSTEM

    if(randomNumber == -1)
        {
            randomNumber = Random.Range(1, 5);
            for (int i = 0; i < 5; i++)
            {
                
            }
            
        }

        if (randomNumber == 1)
        {
            Erva1.gameObject.tag = "Certo";
            Erva2.gameObject.tag = "Errado";
            Erva3.gameObject.tag = "Errado";
            Erva4.gameObject.tag = "Errado";
            Erva5.gameObject.tag = "Certo";
            Erva6.gameObject.tag = "Errado";
            Erva7.gameObject.tag = "Errado";
            Erva8.gameObject.tag = "Errado";
            img1.SetActive(true);
        }

        if (randomNumber == 2)
        {
            Erva1.gameObject.tag = "Errado";
            Erva2.gameObject.tag = "Certo";
            Erva3.gameObject.tag = "Errado";
            Erva4.gameObject.tag = "Errado";
            Erva5.gameObject.tag = "Errado";
            Erva6.gameObject.tag = "Certo";
            Erva7.gameObject.tag = "Errado";
            Erva8.gameObject.tag = "Errado";
            img2.SetActive(true);
        }

        if (randomNumber == 3)
        {
            Erva1.gameObject.tag = "Errado";
            Erva2.gameObject.tag = "Errado";
            Erva3.gameObject.tag = "Certo";
            Erva4.gameObject.tag = "Errado";
            Erva5.gameObject.tag = "Errado";
            Erva6.gameObject.tag = "Errado";
            Erva7.gameObject.tag = "Certo";
            Erva8.gameObject.tag = "Errado";
            img3.SetActive(true);
        }
        if (randomNumber == 4)
        {
            Erva1.gameObject.tag = "Errado";
            Erva2.gameObject.tag = "Errado";
            Erva3.gameObject.tag = "Errado";
            Erva4.gameObject.tag = "Certo";
            Erva5.gameObject.tag = "Errado";
            Erva6.gameObject.tag = "Errado";
            Erva7.gameObject.tag = "Errado";
            Erva8.gameObject.tag = "Certo";
            img4.SetActive(true);
        }

        if (ganhou == true)
        {
            taskIcon.SetActive(false);
            Witch.task2erro = true;
            acabou.SetActive(true);
            contagem = 0;
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.right);
            Invoke("Close", 1.5f);
            ganhou = false;
            task.SetActive(false);
            Erva1.SetActive(true);
            Erva2.SetActive(true);
            Erva3.SetActive(true);
            Erva4.SetActive(true);
            Erva5.SetActive(true);
            Erva6.SetActive(true);
            Erva7.SetActive(true);
            Erva8.SetActive(true);
            Erva1.gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
            Erva2.gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
            Erva3.gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
            Erva4.gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
            taskFeita = true;
        }

        if (errou == true)
        {
            Witch.task2erro = true;
            randomNumber = -1;
            contagem = 0;
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.wrong);
            errou = false;
            task.SetActive(false);
            Erva1.SetActive(true);
            Erva2.SetActive(true);
            Erva3.SetActive(true);
            Erva4.SetActive(true);
            Erva5.SetActive(true);
            Erva6.SetActive(true);
            Erva7.SetActive(true);
            Erva8.SetActive(true);
            Erva1.gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
            Erva2.gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
            Erva3.gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
            Erva4.gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
        } 

        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("Certo"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }
                _selection = selection;
                if (Input.GetMouseButtonDown(0))
                {
                    contagem += 1;
                    hit.collider.gameObject.SetActive(false);
                }
            }

            if (selection.CompareTag("Errado"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }
                _selection = selection;
                if (Input.GetMouseButtonDown(0))
                {
                    errou = true;
                    
                }
            }

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
