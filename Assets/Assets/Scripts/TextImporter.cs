using UnityEngine;
using System.Collections;

public class TextImporter : MonoBehaviour {

    public TextAsset textFile;      //text you want to import
    public string[] textLines;      //each string will be taken to array as a seperate object

	// Use this for initialization
	void Start () {
	
        if(textFile != null) //check if there's a text file
        {
            textLines = (textFile.text.Split('\n'));    //split text in parts wherever we see '\n'
        }
	}
	

}
