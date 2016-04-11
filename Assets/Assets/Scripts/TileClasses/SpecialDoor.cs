using UnityEngine;
using System.Collections;

public class SpecialDoor : Tiles {
	
	public TextBoxManager theTextBox;
	public GameObject Timer;
	public Sprite unlockedSprite;
	public string[] mInfo = new string[1]; //the info about why the door is locked.

	
	// Update is called once per frame
	void Update () {
		if (Timer.GetComponent<Timer>().minutes == 0 && Timer.GetComponent<Timer>().seconds == 20) { //if twenty seconds are left, the door goes open from itself.
			GetComponent<SpriteRenderer> ().sprite = unlockedSprite;
			GetComponent<CircleCollider2D> ().enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other) //Only checks if you have key when you make contact with the door
	{
		if (other.name == PlayerObject.name && GetComponent<CircleCollider2D>().enabled ==true ) { //checks if collider makes contact with the player.
			theTextBox.ReloadScript(mInfo); 
			theTextBox.currentLine =0;
			theTextBox.endAtLine = mInfo.Length-1;
			theTextBox.EnableTextBox();
		}
	}
}
