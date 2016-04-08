using UnityEngine;
using System.Collections;

public class DoorTile : Tiles { //e.G: doors that need a key
	public bool haveKey;
	public string[] mInfo = new string[1];//Information about what the "door" needs to be opened
	public Sprite unlockedSprite;
	public string mKeyNumber; //the number of the key that needs to be used to open this door
	public TextBoxManager theTextBox;

	//Constructors
	public DoorTile() //Since this default constructor we're probably never going to use I guess I'll delete it later :P
	{
		//mType = tileType.DoorTile;
		//mCanWalkThrough = false;
		mInfo[0] = "This door needs a key to be opened";
	}

	public DoorTile(string info)
	{
		//mType = tileType.DoorTile;
		//mCanWalkThrough = false;
		mInfo[0] = info;
	}

	//Methods

	public void CheckForKey()
	{
		if (PlayerObject.GetComponent<Key>() !=null) { //checks if the player is carrying a key
			if (PlayerObject.GetComponent<Key>().keyNumber == mKeyNumber) {
				haveKey = true;
			}
		}

		if (haveKey) { //if player has key change sprite to unlocked-door-sprite and make that you can walk through it.
			GetComponent<SpriteRenderer> ().sprite = unlockedSprite;
			GetComponent<PolygonCollider2D> ().enabled = false;
		} else {
			theTextBox.ReloadScript(mInfo); //what happens when you die.
			theTextBox.currentLine =0;
			theTextBox.endAtLine = 0;
			theTextBox.EnableTextBox();
		}
	}

	void OnTriggerEnter2D(Collider2D other) //Only checks if you have key when you make contact with the door
	{
		if (other.name == PlayerObject.name) { //checks if collider makes contact with the player.
			CheckForKey();
		}
	}

}