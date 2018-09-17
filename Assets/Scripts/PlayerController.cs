﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D myRigidbody;
	public float playerSpeed;
	private bool facingRight;

	public Animator myAnimator;


	// Use this for initialization
	void Start () {
		facingRight = true;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis("Horizontal");
		MovePlayer(horizontal);
		Flip(horizontal);	
	}

	private void MovePlayer(float horizontal){
		myRigidbody.velocity = new Vector2(horizontal * playerSpeed, myRigidbody.velocity.y);
		myAnimator.SetFloat("speed",Mathf.Abs(horizontal));
	}

	private void Flip(float horizontal){
		if (horizontal>0 && !facingRight || horizontal < 0 && facingRight ){
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *=-1;
			transform.localScale = theScale;
		}
	}
}
