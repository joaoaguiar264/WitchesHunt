using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public static Waves instance;

    public float amplitude = 1f;
    public float lenght = 2f;
    public float speed = 1f;
    public float offsett = 0f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        offsett += Time.deltaTime * speed;
    }

    public float GetWaveHeight(float _x)
    {
        return amplitude * Mathf.Sin(_x / lenght + offsett); 
    }
}
