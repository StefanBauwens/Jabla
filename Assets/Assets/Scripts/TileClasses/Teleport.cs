using UnityEngine;
using System.Collections;

public class Teleport : Tiles {
	
	public float mNewXCoordinate;
	public float  mNewYCoordinate;
	public float DelayTime =0.9f;
	protected Transform PlayerTrans;
	//protected Rigidbody2D RidgidPlayer;

	void Start()
	{
		PlayerTrans = PlayerObject.GetComponent<Transform> ();
		//RidgidPlayer = PlayerObject.GetComponent<Rigidbody2D>();
	}

	//Constructors
	public Teleport()
	{
		mType = tileType.Teleport;
		mNewXCoordinate = 0f; //eventually change these to Player's current position
		mNewYCoordinate = 0f;
	}

	public Teleport(bool canWalkThrough, float newXCoordinate, float newYCoordinate) : base(canWalkThrough)
	{
		mType = tileType.Teleport;
		mNewXCoordinate = newXCoordinate; 
		mNewYCoordinate = newYCoordinate;
	}

	//properties
	public float NewXCoordinate
	{
		get
		{
			return mNewXCoordinate;
		}
		set
		{
			mNewXCoordinate = value;
		}
	}

	public float NewYCoordinate
	{
		get
		{
			return mNewYCoordinate;
		}
		set
		{
			mNewYCoordinate = value;
		}
	}

	//CHECK if you're on the tile:

	void OnTriggerEnter2D(Collider2D other)  
	{
		if (other.name == PlayerObject.name) { //checks if collider makes contact with the player.
			StartCoroutine(TeleportPlayer()); //Starts teleporter coroutine.
		}
	}

	IEnumerator TeleportPlayer()
	{
		yield return new WaitForSeconds(DelayTime);//Waits for a given time, just so the transition doesn't happen instantly.

		PlayerTrans.position = new Vector3(NewXCoordinate, NewYCoordinate, PlayerTrans.transform.position.z); //moves the player to new position
		Camera.main.transform.position = new Vector3(NewXCoordinate, NewYCoordinate, Camera.main.transform.position.z); //moves the camera as well
	}


}