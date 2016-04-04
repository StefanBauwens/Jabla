using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public bool isPaused; 
    public GameObject pauseMenuCanvas; // pause menu screen
    public PlayerController player;
    public bool stopPlayerMovement; //disable the player from being able to move during pause menu

    void Start ()
    {
        player = FindObjectOfType<PlayerController>(); //find player in scene
    }

    void Update ()
    {
        if(isPaused) // game is paused
        {
            pauseMenuCanvas.SetActive(true); // will show menu
            player.canMove = false; // player can't walk during pause menu
        }
        else
        {
            pauseMenuCanvas.SetActive(false); // won't show menu
            player.canMove = true; // player can walk again
        }

        if(Input.GetKeyDown(KeyCode.Escape)) // when escape button is pressed
        {
            isPaused = !isPaused; // game will pause when not paused and vice versa
        }
    }

    public void ResumeGame()
    {
        isPaused = false; // pause menu will go away
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    
}
