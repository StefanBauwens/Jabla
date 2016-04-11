 using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour {

	public string[] text;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;

    public bool destroyWhenActivated;

    public bool requireButtonPress;
    private bool waitForPress;

	// Use this for initialization
	void Start () {
        theTextBox = FindObjectOfType<TextBoxManager>(); //find text box manager
	}
	
	// Update is called once per frame
	void Update () {
		if (waitForPress && Input.GetKeyDown(KeyCode.Return) && !theTextBox.isActive) //this only can run if theTextbox isn't active already
        {
			Input.ResetInputAxes(); //makes sure the enter button is cleared
			StartTextBox();
        }
	}

    void OnTriggerEnter2D(Collider2D other) // trigger text box  -> other is object that collides with this object
    {
        if(other.name == "Player")
        {
            if (requireButtonPress) //don't automatically trigger text box
            {
                waitForPress = true;
                return;
            }
			StartTextBox ();
        }
    }

    void OnTriggerExit2D(Collider2D other) //can't activate text box when player leaves zone
    {
        if (other.name == "Player")
        {
            waitForPress = false;
        }
    }

	void StartTextBox() {
		theTextBox.ReloadScript(text); //theText
		theTextBox.currentLine = startLine;
		theTextBox.endAtLine = endLine;
		theTextBox.EnableTextBox();
		if (destroyWhenActivated) //text box won't appear again after one time
		{
			Destroy(gameObject);
		}
	}
}
