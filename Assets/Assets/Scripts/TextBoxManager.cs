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

    public PlayerController player; //disable the player from being able to move

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
    }

    void Update()
    {
        theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Return)) //get next line in dialog box by pressing 'Enter'(Return)
        {
            currentLine += 1;
        }

        if(currentLine > endAtLine) //texbox will go away after last line
        {
            textBox.SetActive(false);
        }
    }


}
