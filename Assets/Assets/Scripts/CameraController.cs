using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    //camera won't directly follow player, but follows certain amount of time behind player --> gives a smoother image

    public GameObject followTarget;                                       // make camera follow a specific object, not just the player
    private Vector3 targetPos;                                            // position for object to aim towards 
    public float moveSpeed;                                               // how fast camera will chase after player

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z); // z gets default value because it can't have same value as the camera --> z from camera = -10 so the value of this z can't be -10 or else the game world would go on top of the camera
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);                        // Vector3.Lerp( current position of camera, where the player is, movement that camera can have in every update) 
    }
}
