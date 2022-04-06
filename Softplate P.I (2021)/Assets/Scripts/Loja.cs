using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loja : MonoBehaviour
{
    public int preço1 = 300;
    public int preço2 = 600;
    public int preço3 = 900;
    public int preço4 = 1200;

    public static bool item1;
    public static bool item2;
    public static bool item3;
    public static bool item4;

    public GameObject bloq;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Item1()
    {
        if(GameManager.credits >= preço1)
        {
            item1 = true;
            GameManager.credits = GameManager.credits - preço1;
            Debug.Log("FOI CARALHO");
        }
        else
        {
            bloq.SetActive(true);
            Invoke("fechar", 1f);
        }
    }
    public void Item2()
    {
        if (GameManager.credits >= preço2)
        {
            item2 = true;
            GameManager.credits = GameManager.credits - preço2;
        }
        else
        {
            bloq.SetActive(true);
            Invoke("fechar", 1f);
        }
    }
    public void Item3()
    {
        if (GameManager.credits >= preço3)
        {
            item3 = true;
            GameManager.credits = GameManager.credits - preço3;
        }
        else
        {
            bloq.SetActive(true);
            Invoke("fechar", 1f);
        }
    }
    public void Item4()
    {
        if (GameManager.credits >= preço4)
        {
            item4 = true;
            GameManager.credits = GameManager.credits - preço4;
        }
        else
        {
            bloq.SetActive(true);
            Invoke("fechar", 1f);
        }
    }

    public void fechar()
    {
        bloq.SetActive(false);
    }
}
