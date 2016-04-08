using UnityEngine;
using System.Collections;

public class WinMenu : MainMenu {

    public GameObject winMenuCanvas; // win menu screen
    public bool playerWon;



    public void PlayerWinGame()
    {
        if (playerWon)
        {
            winMenuCanvas.SetActive(true); // show win menu
        }
        else
        {
            winMenuCanvas.SetActive(false);
        }
    }

}
