using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    public float fGravity = -10.0f;
    public float fMovementSpeed = 5.0f;
    public float fJumpforce = 5.0f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController charController;

    // Use this for initialization
    void Start ()
    {
        charController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (charController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= fMovementSpeed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = fJumpforce;
            }
        }
        else
        {
            moveDirection.y += fGravity * Time.deltaTime;
        }
        charController.Move(moveDirection * Time.deltaTime);
	}
}
