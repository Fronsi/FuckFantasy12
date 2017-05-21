using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animation _playerAnimation;
    private PlayerCharController _playerCharController;

    void Start()
    {
        _playerAnimation = GetComponent<Animation>();
        _playerCharController = GetComponent<PlayerCharController>();
    }

    void Update()
    {
        if (_playerCharController.moveDirection.z == 0.0f)
        {
            _playerAnimation.CrossFade("idle");
        }
        else if (_playerCharController.moveDirection.z < 0.0f && _playerCharController.moveDirection.z >= -2.0f
                || _playerCharController.moveDirection.z > 0.0f && _playerCharController.moveDirection.z <= 2.0f)
        {
            _playerAnimation.CrossFade("Walk");
        }
        else if (_playerCharController.moveDirection.z < -2.0f || _playerCharController.moveDirection.z > 2.0f)
        {
            _playerAnimation.CrossFade("Run");
        }
    }
}
