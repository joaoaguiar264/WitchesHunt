using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskListing : MonoBehaviour
{
    //Tasks List
    public GameObject task1;
    public GameObject task2;
    public GameObject task3;
    public GameObject task4;
    public GameObject task5;
    public GameObject task6;
    public GameObject task7;
    public GameObject task8;


    public Color Feita = new Color(255f, 186f, 0f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Task1.taskFeita == true)
        {
            task1.gameObject.GetComponent<Text>().color = Feita;
        }

        if (Task2.taskFeita == true)
        {
            task2.gameObject.GetComponent<Text>().color = Feita;
        }

        if (Task3.taskFeita == true)
        {
            task3.gameObject.GetComponent<Text>().color = Feita;
        }
        if (Task4.taskFeita == true)
        {
            task4.gameObject.GetComponent<Text>().color = Feita;
        }
        if (Task5.taskFeita == true)
        {
            task5.gameObject.GetComponent<Text>().color = Feita;
        }
        /* if (Task6.taskFeita == true)
         {
             task6.gameObject.GetComponent<Text>().color = Feita;
         }*/
        if (Task7.taskFeita == true)
          {
            task7.gameObject.GetComponent<Text>().color = Feita;
          }
         /* if (Task8.taskFeita == true)
          {
             task8.gameObject.GetComponent<Text>().color = Feita;
          }*/
    }
}
