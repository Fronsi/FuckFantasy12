using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animation _playerAnimation;
    private PlayerCharController _playerCharController;
    private PlayerAttack _playerAttack;

    void Start()
    {
        _playerAnimation = GetComponent<Animation>();
        _playerCharController = GetComponent<PlayerCharController>();
        _playerAttack = GetComponent<PlayerAttack>();
    }

    void Update()
    {
        if (_playerCharController.moveDirection.z == 0.0f)
        {
            _playerAnimation.CrossFade("idle");
        }
        else if (!_playerCharController.bIsRunning)
        {
            _playerAnimation.CrossFade("Walk");
        }
        else if (_playerCharController.bIsRunning)
        {
            _playerAnimation.CrossFade("Run");
        }

        if (_playerAttack.bIsAttacking)
        {
            _playerAnimation.CrossFade("Attack");
            if (_playerAnimation["Attack"].normalizedTime >= 0.5f)
            {
                _playerAttack.bIsAttacking = false;
            }
        }
    }
}
