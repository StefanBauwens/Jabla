using UnityEngine;
using System.Collections;

public class DangerousTile : Tiles { //bv. lava, water, put

	public string[] mDeathMessage = new string[5]; //Message that is given when you die on this specific tile
	public TextBoxManager theTextBox;
	public int startLine;
	public int endLine;
    public DeathMenu deadScreen;

    

	//Constructors
	public DangerousTile()
	{
		mType = tileType.Dangerous; //default text
		mDeathMessage[0] = "You died!";
		startLine =0;
		endLine = 1;
	}

	public DangerousTile(string deathMessage)
	{
		mType = tileType.Dangerous;
		mDeathMessage[0] = deathMessage;
		startLine =0;
		endLine = 1;
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


	void OnTriggerEnter2D(Collider2D other)  
	{
		if (other.name == PlayerObject.name) { //checks if collider makes contact with the player.
            deadScreen.isDead = true; // player is dead
            deadScreen.PlayerDead(); // calls method PLayerDead from class DeathMenu
            theTextBox.ReloadScript(mDeathMessage); //what happens when you die.
			theTextBox.currentLine =startLine;
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox();
            
			//Application.Quit(); //won't work in editor.
		}
	}

	void Start()
	{
        theTextBox = (TextBoxManager)GameObject.FindWithTag ("textbox").GetComponent ("TextBoxManager"); //gets Textboxmanager type automatically
		PlayerObject = GameObject.FindWithTag ("Player"); //fills Player automatically in
	}
		
}