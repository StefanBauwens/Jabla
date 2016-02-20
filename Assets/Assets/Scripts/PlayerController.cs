using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed; // set movement speed in Unity (public)

	private Animator anim;
	private Rigidbody2D myRigidbody;

	private bool playerMoving;
	private Vector2 lastMove; // to set the direction of the face when not moving

    public bool canMove;

	// Use this for initialization
	void Start () {    
                                  
		anim = GetComponent<Animator>();         // make changes to the Animator
		myRigidbody = GetComponent<Rigidbody2D>(); //control Player by adding force --> won't bounce against objects
	}

	// Update is called once per frame                                                                                       //GetAxisRaw --> methode in Class Input | GetAxisRaw = a key that gets pressed
	void Update ()                                                                                                           //right > 0.5f, left < -0.5f en 0 = idle (stilstaan) 
	{
		/*if (!canMove) //player won't move when there's a dialogue, code won't run under this code
		{
			//myRigidbody.isKinematic = true;
			// i still don't know how to stop the Animator (legs and arms moving)
			//return;
		}*/

		if (canMove) { //Edit by stefan: changed it like this so animation stops as well.
			playerMoving = false;
			if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {                                 //moving horizontal (left & right) --> on the x-axis            
				//transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));           //Translate --> lets the player move
				myRigidbody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * moveSpeed, myRigidbody.velocity.y);          // velocity = whatever force is acting on the Rigidbody at the moment
				playerMoving = true;                                                                                             //Vector3( x, y, z) | Time.deltaTime = time between every upate | * Time.deltaTime --> will take care of distance difference between different fps
				lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
			}

			if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {                                     //up > 0.5f en down < -0.5f//moving vertical (up & down) --> on the y-axis
				//transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, Input.GetAxisRaw ("Vertical") * moveSpeed);
				playerMoving = true;
				lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));          
			}

		} else {
			playerMoving = false;
			anim.SetBool ("PlayerMoving", playerMoving);
		}
			//Player keeps going in one direction so...

			if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) { // if Player is not moving
				myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
			}

			if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);
			}
			anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));      // give a number to MoveX
			anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));        // give a number to MoveY
			anim.SetBool ("PlayerMoving", playerMoving);
			anim.SetFloat ("LastMoveX", lastMove.x);                      // x coordinate from variable lastMove
			anim.SetFloat ("LastMoveY", lastMove.y);                      // y coordinate from variable lastMove
	}
}
