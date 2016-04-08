using UnityEngine;
using System.Collections;
using System.Collections.Generic; //using list


public class BaseCharacters : MonoBehaviour {

    //fields
	public PlayerInfo _Player;
    public string _Name;
    //public TextAsset _Text;

	protected string _PersonTalking;
	protected List<string> _Conversation; 

    //Constructors
    public BaseCharacters() //base constructor
    {
        _Name = "John Smith";
        
    }

    public BaseCharacters(string name)
    {
        _Name = name;
        
    }

	protected void Start() {
		_Conversation = new List<string>();
		_PersonTalking = _Name;
		for (int i = 0; i < GetComponent<ActivateTextAtLine> ().text.Length; i++) { //checks for a space in the text to know when the other person needs to talk
			if (GetComponent<ActivateTextAtLine> ().text [i] == "") {
				if (_PersonTalking == _Name) {
					_PersonTalking = _Player.playerName;
				} else {
					_PersonTalking = _Name;
				}
				i++;
			}
			_Conversation.Add (_PersonTalking + ": " + GetComponent<ActivateTextAtLine> ().text [i]); //puts the conversation with names and without spaces in new list
			//Debug.Log("test");
		}
		for (int i = 0; i < _Conversation.Count; i++) { //puts list back into array
			GetComponent<ActivateTextAtLine> ().text [i] = _Conversation [i];
		}
		GetComponent<ActivateTextAtLine> ().endLine = _Conversation.Count - 1; //tell it when to stop reading text.


	}

}
