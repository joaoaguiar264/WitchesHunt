using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    public Transform LoadingBar;
    public Transform TextIndicator;
    public Transform TextLoading;
    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;

    public static bool reset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(reset == true)
        {
            currentAmount = 0;
            reset = false;
            this.gameObject.SetActive(false);
        }

        if(currentAmount < 100)
        {
            currentAmount += speed * Time.deltaTime;
            TextIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
            TextLoading.gameObject.SetActive(true);
        }
        else
        {
            TextLoading.gameObject.SetActive(false);
            TextIndicator.GetComponent<Text>().text = "Done!";
        }
        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }
}
