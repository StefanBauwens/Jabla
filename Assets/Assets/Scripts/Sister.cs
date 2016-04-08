using UnityEngine;
using System.Collections;

public class Sister : BaseCharacters {

	// Update is called once per frame

	public TextBoxManager textBox;
	public GameObject winMenu;

	void OnTriggerEnter2D(Collider2D other){
		
		if(textBox.isActive == false) {
			winMenu.SetActive (true);
		}
	}
}
