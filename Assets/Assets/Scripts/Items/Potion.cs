using UnityEngine;
using System.Collections;

public class Potion : BaseItem {

    public potionTypes types;
	public GameObject playerObject;

	protected bool alreadyChecked= false;

	public enum potionTypes
    {
        Timechanger, // instead of getting more time, you'll get less
        Questcompleter, // you'll get nothing out of it
        Speed //decrease your movement speed
    }
    
	//constructor
    public Potion(string name, string description): base(name, description)
    {
        itemName = name;
        itemDescription = description;
    }


	void Update() {
		if (this.gameObject == playerObject && alreadyChecked==false) { //check to see if player is carrying the potion
			Check();
			alreadyChecked = true; //only check once else the potions keeps effecting over and over. it only needs to do its damage once.
		}
	}

	public void Check() 
    {
		switch (types) { //use a switch instead
		case potionTypes.Timechanger:
			Timer.changeTime -= 3;//changes the time to go faster
			break;
		case potionTypes.Questcompleter:
			//nothing happens lol
			break;
		case potionTypes.Speed:
			playerObject.GetComponent<PlayerController> ().moveSpeed -= 1; //slows you down
			break;
		}
    }
}
