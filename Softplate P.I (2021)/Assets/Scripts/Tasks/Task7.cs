using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task7 : MonoBehaviour
{
    public GameObject task;

    public static bool taskFeita = false;
    public static int contagem;
    public static bool errou = false;
    public static bool ganhou = false;
    public GameObject acabou;

    public GameObject taskIcon;

    public float holdDownStartTime;
    public GameObject timer;

    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material defaultMaterial2;
    [SerializeField] private Material defaultMaterial3;

    private Transform _selection;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         if (Witch.Task7Cam == true)
         {
             task.SetActive(true);
            this.gameObject.GetComponent<Task7>().enabled = true;
         }
         else
         {
             task.SetActive(false);
            this.gameObject.GetComponent<Task7>().enabled = false;
        } 

        if (contagem >= 3)
        {
            ganhou = true;
        }

        if (ganhou == true)
        {
            taskIcon.SetActive(false);
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.right);
            Witch.task7erro = true;
            Witch.Task7Cam = false;
            acabou.SetActive(true);
            contagem = 0;
            Invoke("Close", 1.5f);
            ganhou = false;
            //   task.SetActive(false);
            taskFeita = true;
        }

        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            if (selectionRenderer.CompareTag("Artefact1"))
            {
                selectionRenderer.material = defaultMaterial;
            }
            if (selectionRenderer.CompareTag("Artefact2"))
            {
                selectionRenderer.material = defaultMaterial2;
            }
            if (selectionRenderer.CompareTag("Artefact3"))
            {
                selectionRenderer.material = defaultMaterial3;
            }

            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("Artefact1"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }
                _selection = selection;

                if (Input.GetMouseButton(0))
                {
                    timer.gameObject.transform.position = Input.mousePosition;
                    timer.gameObject.SetActive(true);
                    holdDownStartTime += Time.deltaTime;
                    if (holdDownStartTime >= 1.5f)
                    {
                        contagem += 1;
                        hit.collider.gameObject.SetActive(false);
                        holdDownStartTime = 0;
                        Load.reset = true;
                    }

                }
                if (Input.GetMouseButtonUp(0))
                {
                    Load.reset = true;
                    holdDownStartTime = 0;


                }
            }
            if (selection.CompareTag("Artefact2"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }
                _selection = selection;

                if (Input.GetMouseButton(0))
                {
                    timer.gameObject.transform.position = Input.mousePosition;
                    timer.gameObject.SetActive(true);
                    holdDownStartTime += Time.deltaTime;
                    if (holdDownStartTime >= 1.5f)
                    {
                        contagem += 1;
                        hit.collider.gameObject.SetActive(false);
                        holdDownStartTime = 0;
                        Load.reset = true;
                    }

                }
                if (Input.GetMouseButtonUp(0))
                {
                    Load.reset = true;
                    holdDownStartTime = 0;


                }
            }
            if (selection.CompareTag("Artefact3"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }
                _selection = selection;

                if (Input.GetMouseButton(0))
                {
                    timer.gameObject.transform.position = Input.mousePosition;
                    timer.gameObject.SetActive(true);
                    holdDownStartTime += Time.deltaTime;
                    if (holdDownStartTime >= 1.5f)
                    {
                        contagem += 1;
                        hit.collider.gameObject.SetActive(false);
                        holdDownStartTime = 0;
                        Load.reset = true;
                    }

                }
                if (Input.GetMouseButtonUp(0))
                {
                    Load.reset = true;
                    holdDownStartTime = 0;


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
