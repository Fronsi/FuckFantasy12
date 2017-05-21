using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatior : MonoBehaviour
{

    public Animator _enemyAnimator;
    public Skeleton _skeleton;
    //Timer used for IdleTimer condition in Animator
    public float fIdleTimer = 0.0f;
    public bool bGotHit = false;

    void Start()
    {
        _enemyAnimator = GetComponent<Animator>();
        _skeleton = GetComponent<Skeleton>();
        _enemyAnimator.SetFloat("Life", _skeleton.fLife);
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

        if (_skeleton.bGotHit)
        {
            if (_skeleton.fLife > 0.0f)
            {
                _enemyAnimator.SetBool("GotHit", _skeleton.bGotHit);
                if (_enemyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                {
                    _skeleton.bGotHit = false;
                    fIdleTimer = 0;
                    _enemyAnimator.SetBool("GotHit", _skeleton.bGotHit);
                }
            }
            else
            {
                _enemyAnimator.SetFloat("Life", _skeleton.fLife);
            }
        }
    }

}
