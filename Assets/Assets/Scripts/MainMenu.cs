using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public string startGame; // variable to put the game scene in


    public void StartGame()
    {
        Application.LoadLevel(startGame);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
	
}
