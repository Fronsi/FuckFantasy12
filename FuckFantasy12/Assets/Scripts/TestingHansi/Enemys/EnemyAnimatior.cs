using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatior : MonoBehaviour
{

    public Animator _enemyAnimator;
    //Timer used for IdleTimer condition in Animator
    public float fIdleTimer = 0.0f;
    public bool bGotHit = false;

    void Start()
    {
        _enemyAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        _enemyAnimator.SetFloat("IdleTimer", fIdleTimer);
        //Idle Animation can only be activated if in "stand" animation
        //
        //If in stand animation check IdleTimer condition with fIdleTimer and count up timer
        if (_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
        {
            _enemyAnimator.SetFloat("IdleTimer", fIdleTimer);
            fIdleTimer += Time.deltaTime;
        }
        //If Idle Condition is true and animation changed to idle
        //Check if animation is finished (normalizedTime = 1.0 means animation finished once (2.0 e.g would mean animation played twice))
        //Set idleTimer back to 0 and check condition
        else if (_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if (_enemyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                fIdleTimer = 0;
                _enemyAnimator.SetFloat("IdleTimer", fIdleTimer);
            }
        }

        if (bGotHit)
        {
            _enemyAnimator.SetBool("GotHit", bGotHit);
            if (_enemyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                bGotHit = false;
                fIdleTimer = 0;
                _enemyAnimator.SetBool("GotHit", bGotHit);
            }
        }
    }

}
