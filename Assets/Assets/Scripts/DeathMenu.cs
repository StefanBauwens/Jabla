using UnityEngine;
using System.Collections;

public class DeathMenu : MonoBehaviour {

    public string startGame; // variable to put the game scene in
    public GameObject deathMenuCanvas; // death menu screen
    public bool isDead;


    public void PlayerDead()
    {
        if(isDead)
        {
            deathMenuCanvas.SetActive(true); // show death menu
        }
        else
        {
            deathMenuCanvas.SetActive(false); 
        }
    }

    public void RestartGame()
    {
        Application.LoadLevel(startGame);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
