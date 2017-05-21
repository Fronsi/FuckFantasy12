using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharController : MonoBehaviour
{

    public float fGravity = -10.0f;
    public float fMovementSpeed = 2.0f;
    public float fRunSpeed = 5.0f;
    public float fJumpforce = 5.0f;
    public Vector3 moveDirection = Vector3.zero;
    public CharacterController charController;

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //add gravity
        moveDirection.y += fGravity * Time.deltaTime;

        charController.Move(moveDirection * Time.deltaTime);
    }

    public void setMoveDirection(float x, float z, bool bRun)
    {
        moveDirection = new Vector3(x, 0, z);
        //transform from local to world space
        moveDirection = transform.TransformDirection(moveDirection);
        if (bRun)
        {
            moveDirection *= fRunSpeed;
        }
        else
        {
            moveDirection *= fMovementSpeed;
        }
    }

    public void jump()
    {
        moveDirection.y = fJumpforce;
    }
}
