using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public bool bIsAttacking = false;
    public Sword _sword;

	void Start ()
    {
        _sword = GetComponent<Sword>();
	}
	
	void Update ()
    {
        if (bIsAttacking)
        {
           
        }
	}
}
