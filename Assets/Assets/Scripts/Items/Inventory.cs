using UnityEngine;
using System.Collections;
using UnityEngine.UI; //add to access things in UI in Unity 5

public class Inventory : BaseItem {
	public Text mItemName; 
	public Text mItemDescription;
	public Image mItemIcon;
	public bool _InventoryActive;
	public GameObject _InventoryObject;

	// Use this for initialization
	void Start () {
		mItemName.text = _itemName; //changes the name, description and icon in the inventory.
		mItemDescription.text = _itemDescription;
		mItemIcon.sprite = _itemSprite;  
		if (_InventoryActive == false) {
			_InventoryObject.SetActive (false);//Sets the inventory off if the bool is false.
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.I)) { //checks if the user presses I. If so, toggles the inventory screen.
			if (_InventoryActive == false) {
				_InventoryObject.SetActive (true);//turns inventory on
				_InventoryActive = true;
			} else {
				_InventoryActive = false;
				_InventoryObject.SetActive (false);//turns inventory off
			}
		}
	}
}
