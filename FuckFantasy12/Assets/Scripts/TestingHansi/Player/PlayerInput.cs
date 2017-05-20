using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private PlayerCharController _playerCharController;

	void Start ()
    {
        _playerCharController = GetComponent<PlayerCharController>();
	}
	
	void Update ()
    {
        //Movement if player is grounded
        if (_playerCharController.charController.isGrounded)
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
            {
                _playerCharController.setMoveDirection(Input.GetAxis("Horizontal"), 0);
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                _playerCharController.setMoveDirection(0, Input.GetAxis("Vertical"));
            }
            else if (!Input.GetKeyUp(KeyCode.W) || !Input.GetKeyUp(KeyCode.S) || !Input.GetKeyUp(KeyCode.A) || !Input.GetKeyUp(KeyCode.D))
            {
                _playerCharController.setMoveDirection(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }

            if (Input.GetButton("Jump"))
            {
                _playerCharController.jump();
            }
        }


	}
}
