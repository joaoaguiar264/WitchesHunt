using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task5 : MonoBehaviour
{
    public float holdDownStartTime;
    public GameObject timer;

    public GameObject task;

    public static bool taskFeita = false;
    public static int contagem;
    public static bool errou = false;
    public static bool ganhou = false;
    public GameObject acabou;

    public GameObject taskIcon;

    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    private Transform _selection;

    public GameObject Flower1;
    public GameObject Flower2;
    public GameObject Flower3;
    public GameObject Flower4;
    public GameObject Flower5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Witch.Task5Cam == true)
        {
            task.SetActive(true);
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
            taskIcon.SetActive(false);
            GameManagerSFX.AudioSFX.PlayOneShot(GameManagerSFX.right);
            Witch.task5erro = true;
            Witch.Task5Cam = false;
            acabou.SetActive(true);
            contagem = 0;
            Invoke("Close", 1.5f);
            ganhou = false;
            task.SetActive(false);
            taskFeita = true;
        }



        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("Flowers"))
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
    void Timer()
    {
        Load.reset = true;
        
    }
    void Close()
    {
        ganhou = false;
        errou = false;
        acabou.SetActive(false);
        this.gameObject.tag = "Untagged";

    }
}
