using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D myRigidbody;
	public float playerSpeed;
	private bool facingRight;

	public Animator myAnimator;

	private bool attack;

	// Use this for initialization
	void Start () {
		facingRight = true;
		
	}

	void Update(){
		HandInput();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis("Horizontal");
		MovePlayer(horizontal);
		Attack();
		Flip(horizontal);	
		reset();
	}

	private void MovePlayer(float horizontal){
		if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")){
		myRigidbody.velocity = new Vector2(horizontal * playerSpeed, myRigidbody.velocity.y);
	}
		myAnimator.SetFloat("speed",Mathf.Abs(horizontal));
	}

	private void Attack(){
		if (attack && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")){
			myAnimator.SetTrigger("attack");
			myRigidbody.velocity = Vector2.zero;
		}
	}

	private void HandInput(){

		if (Input.GetKeyDown(KeyCode.LeftShift)){
			attack = true;
		}
	}

	private void Flip(float horizontal){
		if (horizontal>0 && !facingRight || horizontal < 0 && facingRight ){
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *=-1;
			transform.localScale = theScale;
		}
	}

	private void reset(){
		attack =false;
	}
}
