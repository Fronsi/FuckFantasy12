using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    public Animator _playerAnimator;

	void Start ()
    {
        
	}
	
	void Update ()
    {
        float move = Input.GetAxis("Vertical");
        _playerAnimator.SetFloat("Speed", move);
    }
}
