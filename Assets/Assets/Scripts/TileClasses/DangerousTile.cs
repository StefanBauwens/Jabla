using UnityEngine;
using System.Collections;
using UnityEngine.UI; //add to access things in UI in Unity 5

public class DangerousTile : Tiles { //bv. lava, water, put

	public string mDeathMessage;
    public DeathMenu deadScreen;

	protected Text dieText;
    

	//Constructors
	public DangerousTile()
	{
		mDeathMessage = "You died!";
	}

	public DangerousTile(string deathMessage)
	{
		mDeathMessage = deathMessage;
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
		}
	}


		
}