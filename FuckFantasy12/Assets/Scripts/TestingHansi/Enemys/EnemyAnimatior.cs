using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatior : MonoBehaviour
{

    public Animator _enemyAnimator;
    public float fIdleTimer = 0.0f;

    void Start()
    {
        _enemyAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        if (_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if (_enemyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                fIdleTimer = 0;
                _enemyAnimator.SetFloat("IdleTimer", fIdleTimer);
            }
        }
        else
        {
            _enemyAnimator.SetFloat("IdleTimer", fIdleTimer);
            fIdleTimer += Time.deltaTime;
        }
    }
}
