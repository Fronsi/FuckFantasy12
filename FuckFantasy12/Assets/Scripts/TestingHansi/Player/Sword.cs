using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public PlayerAttack _playerAttack;

    void Start ()
    {

	}
	
	void Update ()
    {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (_playerAttack.bIsAttacking)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.SendMessage("GotHit");
                Debug.Log("Send");
            }
        }
    }
}
