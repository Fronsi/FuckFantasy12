using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour {

    public EnemyAnimatior _enemyAnimator;

	void Start ()
    {
        _enemyAnimator = GetComponent<EnemyAnimatior>();
	}
	
	void Update ()
    {
		
	}

    public void GotHit()
    {
        _enemyAnimator.bGotHit = true;
    }
}
