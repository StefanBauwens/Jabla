using UnityEngine;
using System.Collections;
using UnityEngine.UI; //add to access things in UI in Unity 5

public class Inventory2 : MonoBehaviour{
	public Text mItemName; 
	public Text mItemDescription;
	public Image mItemIcon;
	public bool _InventoryActive;
	public GameObject _InventoryObject;
	public Text mGold;
	protected BaseItem inventoryItem; //the item the player is carrying;

	// Use this for initialization
	public void Start () { //run this everytime the inventory is updated
		BaseItem inventoryItem = this.gameObject.GetComponent<BaseItem>(); //gets the item that is attached to the player
		mItemName.text = inventoryItem._itemName; //changes the name, description and icon in the inventory.
		mItemDescription.text = inventoryItem._itemDescription;
		mItemIcon.sprite = inventoryItem._itemSprite;  
		mGold.text = "Gold: " + this.gameObject.GetComponent<PlayerInfo> ().gold.ToString () + "G"; //gets the gold from the player and shows it in the inventory
		if (_InventoryActive == false) {
			_InventoryObject.SetActive (false);//Sets the inventory off if the bool is false.
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.I)) { //checks if the user presses I. If so, toggles the inventory screen.
			if (_InventoryActive == false) {
				Start ();
				_InventoryObject.SetActive (true);//turns inventory on
				_InventoryActive = true;
			} else {
				_InventoryActive = false;
				_InventoryObject.SetActive (false);//turns inventory off
			}
		}
	}
}
