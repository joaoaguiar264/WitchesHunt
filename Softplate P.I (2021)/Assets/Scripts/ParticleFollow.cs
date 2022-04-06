using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFollow : MonoBehaviour
{
    public Transform target;

    public float smoothnes = 0.125f;

    public Vector3 offsett;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offsett;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothnes);

        transform.position = SmoothedPosition;


    }
}
