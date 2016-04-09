 using UnityEngine;
using System.Collections;

public class Sister : BaseCharacters {

	// Update is called once per frame

	public TextBoxManager textBox;
	public GameObject winMenu;
	protected bool isTouching=false;

	void Update() {
		if(isTouching == true && textBox.isActive == false) {
			winMenu.SetActive (true);
		}
	}

	void OnTriggerEnter2D(Collider2D other){		
		isTouching = true;
	}
}
