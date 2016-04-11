using UnityEngine;
using System.Collections;

public class DeathMenu : MainMenu {

    public GameObject deathMenuCanvas; // death menu screen
    public bool isDead;

	void Start() {
		deathMenuCanvas.GetComponentInChildren<Canvas> ().gameObject.SetActive (false);
	}


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

	void Update() {
		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.C)) {
			Start ();
		}
	}
    
}
