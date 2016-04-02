using UnityEngine;
using System.Collections;
using System.Collections.Generic; //using list


public class BaseCharacters : MonoBehaviour {

    //fields
	public PlayerInfo _Player;
    public string _Name;
    //public TextAsset _Text;

	protected string _PersonTalking;
	protected List<string> _Conversation = new List<string>();

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
		_PersonTalking = _Name;
		for (int i = 0; i < this.gameObject.GetComponent<ActivateTextAtLine> ().text.Length; i++) { //checks for a space in the text to know when the other person needs to talk
			if (this.gameObject.GetComponent<ActivateTextAtLine> ().text [i] == "") {
				if (_PersonTalking == _Name) {
					_PersonTalking = _Player.playerName;
				} else {
					_PersonTalking = _Name;
				}
				i++;
			}
			_Conversation.Add (_PersonTalking + ": " + this.gameObject.GetComponent<ActivateTextAtLine> ().text [i]); //puts the conversation with names and without spaces in new list

		}
		for (int i = 0; i < _Conversation.Count; i++) { //puts list back into array
			this.gameObject.GetComponent<ActivateTextAtLine> ().text [i] = _Conversation [i];
		}
		this.gameObject.GetComponent<ActivateTextAtLine> ().endLine = _Conversation.Count - 1; //tell it when to stop reading text.

	}

}
