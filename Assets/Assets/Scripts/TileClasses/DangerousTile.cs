using UnityEngine;
using System.Collections;
using UnityEngine.UI; //add to access things in UI in Unity 5

public class DangerousTile : Tiles { //bv. lava, water, put

	//public string[] mDeathMessage = new string[5]; //Message that is given when you die on this specific tile
	//public TextBoxManager theTextBox;
	//public int startLine;
	//public int endLine;
	public string mDeathMessage;
    public DeathMenu deadScreen;

	protected Text dieText;
    

	//Constructors
	public DangerousTile()
	{
		//mType = tileType.Dangerous; //default text
		mDeathMessage = "You died!";
		//startLine =0;
		//endLine = 1;
	}

	public DangerousTile(string deathMessage)
	{
		//mType = tileType.Dangerous;
		mDeathMessage = deathMessage;
		//startLine =0;
		//endLine = 1;
	} 

	//property
	public string DeathMessage
	{
		get
		{
			return mDeathMessage;
		}
		set
		{
			mDeathMessage = value;
		}
	}
	void Awake()
	{
		//theTextBox = (TextBoxManager)GameObject.FindWithTag ("textbox").GetComponent ("TextBoxManager"); //gets Textboxmanager type automatically
		PlayerObject = GameObject.FindWithTag ("Player"); //fills Player automatically in

		foreach (var item in deadScreen.GetComponentsInChildren<Text>()) {
			if (item.tag=="dietext") {
				dieText = item;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)  
	{
		if (other.name == PlayerObject.name) { //checks if collider makes contact with the player.
			dieText.text = mDeathMessage;
            deadScreen.isDead = true; // player is dead
            deadScreen.PlayerDead(); // calls method PLayerDead from class DeathMenu
            /*theTextBox.ReloadScript(mDeathMessage); //what happens when you die.
			theTextBox.currentLine =startLine;
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox();*/
            
			//Application.Quit(); //won't work in editor.
		}
	}


		
}