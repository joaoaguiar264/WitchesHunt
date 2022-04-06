using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Shop : MonoBehaviour
{
    public static bool shop;
    public GameObject Loja;
    public GameObject noMoney;
    public static bool item1;
    public bool item1Active;
    public static bool item2;
    public bool item2Active;
    public static bool item3;
    public bool item3Active;
    public static bool item4;
    public bool item4Active;
    public PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shop == true)
        {
            Cursor.visible = true;
            Loja.SetActive(true);
        }
        else
        {
            Loja.SetActive(false);
        }
    }
    public void Voltar()
    {
        shop = false;
        Loja.SetActive(false);
        Cursor.visible = false;
    }

    public void Warn()
    {
        noMoney.SetActive(false);
    }

    public void Item1()
    {
        if (pv.IsMine)
        {
            if(GameManager.credits >= 200)
            {
                if (item1Active == false)
                {
                    item1 = true;
                    item1Active = true;
                    GameManager.credits = GameManager.credits - 200;
                }
                else
                {

                }
            }
            else
            {
                noMoney.SetActive(true);
                Invoke("Warn", 1f);
            }

            
        }
    }

    public void Item2()
    {
        if (pv.IsMine)
        {
            if (GameManager.credits >= 400)
            {
                if (item2Active == false)
                {
                    item2 = true;
                    item2Active = true;
                }
                else
                {

                }
            }
            else
            {
                noMoney.SetActive(true);
                Invoke("Warn", 1f);
            }

        }
    }

    public void Item3()
    {
        if (pv.IsMine)
        {
            if (GameManager.credits >= 600)
            {

           
                if (item3Active == false)
                {
                item3 = true;
                item3Active = true;
                }
            else
            {

            }
            }
            else
            {
                noMoney.SetActive(true);
                Invoke("Warn", 1f);
            }
        }
    }

    public void Item4()
    {
        if (pv.IsMine)
        {
            if (GameManager.credits >= 800) 
            { 
                if (item4Active == false)
                {
                item4 = true;
                item4Active = true;
                }
            else
            {

            }
            }
            else
            {
                noMoney.SetActive(true);
                Invoke("Warn", 1f);
            }
        }
    }
}
