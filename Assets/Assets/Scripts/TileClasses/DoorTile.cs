using UnityEngine;
using System.Collections;

public class DoorTile : Tiles { //e.G: doors that need a key
	public bool haveKey;
	public string mInfo;//Information about what the "door" needs to be opened
	public GameObject unlockedDoor;

	//Constructors
	public DoorTile() //Since this default constructor we're probably never going to use I guess I'll delete it later :P
	{
		mType = tileType.DoorTile;
		mCanWalkThrough = false;
		mInfo = "This door needs a key to be opened";
	}

	public DoorTile(string info)
	{
		mType = tileType.DoorTile;
		mCanWalkThrough = false;
		mInfo = info;
	}

	//Methods

	public void CheckForKey()
	{
		//insert code to check if player has key. If so door changes that the player can walk through it.
	}

	void OnTriggerEnter2D(Collider2D other)  
	{
		if (other.name == PlayerObject.name) { //checks if collider makes contact with the player.
			unlockedDoor.SetActive(false);
			//unlockedDoor.GetComponent<BoxCollider2D>().enabled = false;
		}
	}

}