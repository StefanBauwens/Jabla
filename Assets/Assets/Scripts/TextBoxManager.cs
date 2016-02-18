using UnityEngine;
using System.Collections;
using UnityEngine.UI; //add to access things in UI in Unity 5

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;

    public Text theText;

    public TextAsset textFile;      //text you want to import
    public string[] textLines;      //each string will be taken to array as a seperate object

    public int currentLine;
    public int endAtLine;

    public PlayerController player;

    public bool isActive;

    public bool stopPlayerMovement; //disable the player from being able to move during dialogue

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>(); //find player in scene

        if (textFile != null) //check if there's a text file
        {
            textLines = (textFile.text.Split('\n'));    //split text in parts wherever we see '\n'
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1; //array starts at 0
        }

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

        theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Return)) //get next line in dialog box by pressing 'Enter'(Return)
        {
            currentLine += 1;
        }

        if(currentLine > endAtLine) //texbox will go away after last line
        {
            DisableTextBox();
        }
    }

    public void EnableTextBox() //enable text box outside script
    {
        textBox.SetActive(true);
        isActive = true;

        if (stopPlayerMovement)
        {
            player.canMove = false;
        }
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;

        player.canMove = true;
        
    }

    public void ReloadScript(TextAsset theText) //allow us to use multiple text files
    {
        if(theText != null) //check if there's a text file
        {
            textLines = new string[1]; //replace old text file with new one
            textLines = (theText.text.Split('\n'));
        }
    }
}
