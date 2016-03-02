using UnityEngine;
using System.Collections;

public class Teleport : Tiles {
	
	public float mNewXCoordinate;
	public float  mNewYCoordinate;
	public GameObject PlayerObject;
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

	void OnTriggerEnter2D(Collider2D other)  
	{
		if (other.name == PlayerObject.name) { //checks if collider makes contact with the player.
			//RidgidPlayer.velocity = new Vector2(NewXCoordinate, NewYCoordinate);
			StartCoroutine(TeleportPlayer());
			//PlayerTrans.position = new Vector3(NewXCoordinate, NewYCoordinate, PlayerTrans.transform.position.z);
			//Camera.main.transform.position = new Vector3(NewXCoordinate, NewYCoordinate, Camera.main.transform.position.z);
		}
	}

	IEnumerator TeleportPlayer()
	{
		yield return new WaitForSeconds(DelayTime);

		PlayerTrans.position = new Vector3(NewXCoordinate, NewYCoordinate, PlayerTrans.transform.position.z);
		Camera.main.transform.position = new Vector3(NewXCoordinate, NewYCoordinate, Camera.main.transform.position.z);
	}


}