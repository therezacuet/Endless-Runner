using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float moveSpeed;
	private float moveSpeedStore;
	public float speedMultiplier;

	public float speedIncreaseMilestone;
	public float speedIncreaseMilestoreStore;

	private float speedMilestoneCount;
	private float speedMileStoneCountStore;


	public float jumpForce;

	public float jumpTime;
	public float jumpTimeCounter;

	private bool stopJumping;
	private bool canDoubleJump;

	private Rigidbody2D myRigidBody;


	public bool  grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;

	//private Collider2D myCollider;

	private Animator myAnimator;

	public GameManager theGameManager;

	public AudioSource jumpSound;
	public AudioSource deathSound;


	// Use this for initialization
	void Start () {
		myRigidBody=GetComponent<Rigidbody2D>(); 

		//myCollider =GetComponent<Collider2D>();

		myAnimator = GetComponent<Animator>();

		jumpTimeCounter = jumpTime;

		speedMilestoneCount = speedIncreaseMilestone;

		moveSpeedStore = moveSpeed;
		speedMileStoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoreStore = speedIncreaseMilestone;

		stopJumping = true;

	}
	
	// Update is called once per frame
	void Update () {

		//grounded = Physics2D.IsTouchingLayers(myCollider,whatIsGround);
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);


		if (transform.transform.position.x > speedMilestoneCount) {

			speedMilestoneCount += speedIncreaseMilestone;


			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			moveSpeed = moveSpeed * speedMultiplier;
		}

		myRigidBody.velocity= new Vector2(moveSpeed,myRigidBody.velocity.y);

		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){

			if(grounded){
				myRigidBody.velocity=new Vector2(myRigidBody.velocity.x,jumpForce);
				stopJumping = false;
				jumpSound.Play ();
			}

			if (!grounded && canDoubleJump) {

				myRigidBody.velocity=new Vector2(myRigidBody.velocity.x,jumpForce);
				jumpTimeCounter = jumpTime;
				stopJumping = false;
				canDoubleJump = false;
				jumpSound.Play ();
			}
		}

		if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0)) && !stopJumping) {
			
			if (jumpTimeCounter > 0) {
				myRigidBody.velocity=new Vector2(myRigidBody.velocity.x,jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) {

			jumpTimeCounter = 0;

			stopJumping = true;

		}

		if (grounded) {

			jumpTimeCounter = jumpTime;
			canDoubleJump = true;
		}
		myAnimator.SetFloat ("Speed",myRigidBody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);

	}

	void OnCollisionEnter2D(Collision2D other){

		if(other.gameObject.tag == "killbox"){

			theGameManager.RestartGame ();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMileStoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoreStore;
			deathSound.Play ();
		}
	}
}
