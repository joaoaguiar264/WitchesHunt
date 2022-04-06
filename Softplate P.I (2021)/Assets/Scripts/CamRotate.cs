using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;

    private void Update()
    {
        
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
    }
}
