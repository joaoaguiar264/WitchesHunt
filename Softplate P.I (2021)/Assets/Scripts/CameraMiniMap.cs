
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class CameraMiniMap : MonoBehaviour
{
    public GameObject target;

    public float smoothnes = 0.125f;

    public Vector3 offsett;

    public PhotonView pv;


    private void Start()
    {

    }

    void FixedUpdate()
    {
        if (pv.IsMine)
        {
        Vector3 desiredPosition = target.transform.position + offsett;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothnes);
        transform.position = SmoothedPosition;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        
}
}
