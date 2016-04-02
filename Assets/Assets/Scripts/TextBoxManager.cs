using UnityEngine;
using System.Collections;
using UnityEngine.UI; //add to access things in UI in Unity 5

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;

    public Text theText;

    //public TextAsset textFile;      //text you want to import
    public string[] textLines;      //each string will be taken to array as a seperate object

    public int currentLine;
    public int endAtLine;

    public PlayerController player;

    public bool isActive;

    public bool stopPlayerMovement; //disable the player from being able to move during dialogue

    private bool isTyping = false; //text scrolling on screen 
	private bool cancelTyping = false;

    public float typeSpeed;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>(); //find player in scene

        /*if (textFile != null) //check if there's a text file
        {
            textLines = (textFile.text.Split('\n'));    //split text in parts wherever we see '\n'
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1; //array starts at 0
        }*/

        if (isActive) //text box will appear when you check box in Unity
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
    }

    void Update()
    {
        if (!isActive) //won't run code after this code when text box is not active
        {
            return;
        }

        //theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Return)) //get next line in dialog box by pressing 'Enter'(Return)
		{
			if (!isTyping)//if text is not typing out
	        {
	            currentLine += 1;

	            if (currentLine > endAtLine) //texbox will go away after last line
	            {
	                DisableTextBox();
	            }
	            else
	            {
	                StartCoroutine(TextScroll(textLines[currentLine])); //start scrolling through text
	            }
	        }
	        else if(isTyping && !cancelTyping)//if text is typing out and you haven't cancelled it
	        {
	            cancelTyping = true;
	        }
        }
			    
    }

    private IEnumerator TextScroll (string lineOfText) //how the text scrolling works
    {
        int letter = 0;//keep track of what letter we are on within string
        theText.text = "";//display nothing in box
        isTyping = true;
        cancelTyping = false;
		while(isTyping && !cancelTyping && (letter < lineOfText.Length - 1))//make letters appear on screen
        {
            theText.text += lineOfText[letter];//we are at another letter
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);//wait for time we have set at typeSpeed
        }
        theText.text = lineOfText;
        isTyping = false; //no more text
        cancelTyping = false;
    }

    public void EnableTextBox() //enable text box outside script
    {
        textBox.SetActive(true);
        isActive = true;

        if (stopPlayerMovement)
        {
            player.canMove = false;
        }

        StartCoroutine(TextScroll(textLines[currentLine]));
    }
	
	public void DisableTextBox()
	{
		StartCoroutine (DisableTextBoxx()); 
	}

	private IEnumerator DisableTextBoxx ()
	{
		yield return new WaitForEndOfFrame (); //I use an IEnumerator instead of just a method so i could make sure i wait for the end of the frame and by doing so reset input.
		textBox.SetActive(false);
		isActive = false;
		player.canMove = true;
	}

    //public void ReloadScript(TextAsset theText) //allow us to use multiple text files
	public void ReloadScript(string[] theText)
	{
        /*if(theText != null) //check if there's a text file
        {
            textLines = new string[1]; //replace old text file with new one
            textLines = (theText.text.Split('\n'));
        }*/
		textLines = theText;
    }
}
