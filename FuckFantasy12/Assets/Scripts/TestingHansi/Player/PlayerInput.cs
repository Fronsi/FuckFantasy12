﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private PlayerCharController _playerCharController;

    void Start()
    {
        _playerCharController = GetComponent<PlayerCharController>();
    }

    void Update()
    {
        //Movement if player is grounded
        if (_playerCharController.charController.isGrounded)
        {
            if (Input.GetButtonDown("Horizontal"))
            {
                _playerCharController.setMoveDirection(Input.GetAxis("Horizontal"), 0, false);
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
            {
                _playerCharController.setMoveDirection(Input.GetAxis("Horizontal"), 0, false);
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                _playerCharController.setMoveDirection(0, Input.GetAxis("Vertical"), false);
            }
            else if (!Input.GetKeyUp(KeyCode.W) || !Input.GetKeyUp(KeyCode.S) || !Input.GetKeyUp(KeyCode.A) || !Input.GetKeyUp(KeyCode.D))
            {
                _playerCharController.setMoveDirection(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), false);
            }
            if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKeyUp(KeyCode.W)
                    || !Input.GetKeyUp(KeyCode.S) && Input.GetKey(KeyCode.LeftShift)
                    || !Input.GetKeyUp(KeyCode.A) && Input.GetKey(KeyCode.LeftShift)
                    || !Input.GetKeyUp(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
            {
                _playerCharController.setMoveDirection(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), true);
            }


            if (Input.GetButton("Jump"))
            {
                _playerCharController.jump();
            }
        }
    }
}