using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public Image Fade;

    private void Start()
    {
        Fade.canvasRenderer.SetAlpha(0.0f);
        fadeIn();

    }

    void fadeIn()
    {
        Fade.CrossFadeAlpha(1, 2, false);
    }

    void fadeOut()
    {
        Fade.CrossFadeAlpha(0, 2, false);
    }
}
