using UnityEngine;
using System.Collections;

public class Helper : BaseCharacters {
    
    public int _Gold; //Cash the person gives to the player(to execute a task if its a questgiver)
	public string _MoneySentence = "You got 5G";

	protected int _endLine;
	protected bool _GoldIsGiven;
	protected bool _Collision;
	//Constructors
    public Helper()
    {
        _Gold = 5;
    }

    public Helper(string name, int gold) : base(name)
    {
        _Gold = gold;
    }

	void Start() {
		base.Start (); //runs the base start first
		_endLine = this.gameObject.GetComponent<ActivateTextAtLine> ().endLine+1;
		this.gameObject.GetComponent<ActivateTextAtLine> ().endLine++; //adds a line to the conversation saying you got money
		this.gameObject.GetComponent<ActivateTextAtLine> ().text [this.gameObject.GetComponent<ActivateTextAtLine> ().endLine] =_MoneySentence;
		_GoldIsGiven = false;
	}

	protected void Update(){
		if (_Collision == true) { //checks to see if the player wasn't given gold yet by using the collision so this can only run once
			if (this.gameObject.GetComponent<ActivateTextAtLine> ().theTextBox.currentLine == _endLine) {
				_Player.gold += _Gold; //gives the gold to the player
				_GoldIsGiven=true;
				this.gameObject.GetComponent<ActivateTextAtLine> ().endLine--;
				_Collision = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) //if you're touching the npc
	{
		if (other.name == "Player" && _GoldIsGiven == false) { //checks to see if you already got gold
			_Collision = true;
		}
	}

	protected void Start2() {
		Start ();
	}
}
