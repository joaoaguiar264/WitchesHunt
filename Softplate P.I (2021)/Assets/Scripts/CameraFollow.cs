
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothnes = 0.125f;

    public Vector3 offsett;


    private void Start()
    {

    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offsett;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothnes);

        transform.position = SmoothedPosition;


    }
}
