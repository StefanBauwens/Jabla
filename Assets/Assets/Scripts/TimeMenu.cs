using UnityEngine;
using System.Collections;

public class TimeMenu : MainMenu {

    public GameObject timeMenuCanvas; // time menu screen
    public bool timeUp;

    public void TimeUp()
    {
        if (timeUp)
        {
            timeMenuCanvas.SetActive(true); // show Time menu
        }
        else
        {
            timeMenuCanvas.SetActive(false);
        }
    }
}
