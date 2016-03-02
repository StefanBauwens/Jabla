using UnityEngine;
using System.Collections;

public class Dangerous : Tiles { //bv. lava, water, put

	public string[] mDeathMessage; //Message that is given when you die on this specific tile
	public TextBoxManager theTextBox;


	//Constructors
	public Dangerous()
	{
		mType = tileType.Dangerous;
		mDeathMessage[0] = "You died!";
	}

	public Dangerous(string deathMessage)
	{
		mType = tileType.Dangerous;
		mDeathMessage[0] = deathMessage;
	} 

	//property
	public string DeathMessage
	{
		get
		{
			return mDeathMessage[0];
		}
		set
		{
			mDeathMessage[0] = value;
		}
	}

	//working on this:

	/*void OnTriggerEnter2D(Collider2D other)  
	{
		if (other.name == PlayerObject.name) { //checks if collider makes contact with the player.
			
			theTextBox.ReloadScript((TextAsset)mDeathMessage);
			theTextBox.EnableTextBox();
		}
	}*/
		
}