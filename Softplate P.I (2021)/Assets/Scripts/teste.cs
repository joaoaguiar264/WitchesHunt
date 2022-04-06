using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teste : MonoBehaviour
{
    public Image Fade;
    // Start is called before the first frame update
    void Start()
    {
        Fade.canvasRenderer.SetAlpha(1.0f);
        fadeOut();
    }

    // Update is called once per frame
    void Update()
    {
   

    }

    void fadeOut()
    {
        Fade.CrossFadeAlpha(0, 1f, false);
    }
}
