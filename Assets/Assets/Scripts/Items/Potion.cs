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
    
    public Potion(string name, string description): base(name, description)
    {
        itemName = name;
        itemDescription = description;
    }


    void Start()
    {
		//Check ();
    }

	void Update() {
		if (this.gameObject == playerObject && alreadyChecked==false) { //check to see if player is carrying the potion
			Check();
			alreadyChecked = true;
		}
	}

	public void Check() 
    {
        /*if (types == potionTypes.Timechanger)
        {
            TimeDecreaser(Timer.changeTime);
        }
        else if (types == potionTypes.Questcompleter)
        {

        }
        else if (types == potionTypes.Speed)
        {

        }*/
		
		switch (types) { //use a switch instead
		case potionTypes.Timechanger:
			Timer.changeTime -= 3;//= TimeDecreaser (Timer.changeTime);
			break;
		case potionTypes.Questcompleter:
			//nothing happens lol
			break;
		case potionTypes.Speed:
			playerObject.GetComponent<PlayerController> ().moveSpeed -= 1;
			break;
		}
        //Debug.Log(Timer.changeTime);
    }

    /*float TimeDecreaser(float time)
    {
        float decreasedTime;
        decreasedTime = time - 3;
        return decreasedTime;
    }*/
}
