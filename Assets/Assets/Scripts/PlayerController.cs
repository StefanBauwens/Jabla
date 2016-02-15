using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed; // set movement speed in Unity (public)

    private Animator anim;

    private bool playerMoving;
    private Vector2 lastMove; // to set the direction of the face when not moving

	// Use this for initialization
	void Start () {                                            
        anim = GetComponent<Animator>();         // it will search for Animator object
	}

    // Update is called once per frame                                                                                       //GetAxisRaw --> methode in Class Input | GetAxisRaw = a key that gets pressed
    void Update ()                                                                                                           //right > 0.5f, left < -0.5f en 0 = idle (stilstaan) 
    {
        playerMoving = false;
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)                                 //moving horizontal (left & right) --> on the x-axis            
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));           //Translate --> lets the player move
            playerMoving = true;                                                                                             //Vector3( x, y, z) | Time.deltaTime = time between every upate | * Time.deltaTime --> will take care of distance difference between different fps
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)                                     //up > 0.5f en down < -0.5f
        {                                                                                                                    //moving vertical (up & down) --> on the y-axis
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));          
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));      // give a number to MoveX
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));        // give a number to MoveY
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);                      // x coordinate from variable lastMove
        anim.SetFloat("LastMoveY", lastMove.y);                      // y coordinate from variable lastMove
    }
}
