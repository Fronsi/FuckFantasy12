using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour {

    public EnemyAnimatior _enemyAnimator;
    public float fLife = 100.0f;
    public bool bGotHit = false;

	void Start ()
    {
        _enemyAnimator = GetComponent<EnemyAnimatior>();
	}
	
	void Update ()
    {
        if (fLife <= 0.0f)
        {
            GetComponent<Collider>().enabled = false;
        }
	}

    public void GotHit(float dmg)
    {
        fLife -= dmg;
        bGotHit = true;
    }
}
