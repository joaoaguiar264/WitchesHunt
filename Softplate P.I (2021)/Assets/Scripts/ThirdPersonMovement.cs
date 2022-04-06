using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ThirdPersonMovement : MonoBehaviour
{
    private Animator anim;

    public PhotonView pv;

    public CharacterController controller;

    public static bool inMovement = false;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    public Transform cam;

    Vector3 velocity;

    public float gravity = -0.5f;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if (pv.IsMine)
        {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

            // usa o float aq em cima

            if (horizontal != 0 || vertical != 0)
            {
                inMovement = true;
                this.gameObject.GetPhotonView().RPC("SpeedUp", RpcTarget.AllBuffered);

            }
            else
            {
                inMovement = false;
                this.gameObject.GetPhotonView().RPC("SpeedDown", RpcTarget.AllBuffered);
            }

            velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        }
    }

    [PunRPC]
    public void SpeedUp()
    {
        anim.SetFloat("Speed", 0.5f);
    }
    [PunRPC]
    public void SpeedDown()
    {
        anim.SetFloat("Speed", 0);
    }
}
