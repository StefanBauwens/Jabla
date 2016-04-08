using UnityEngine;
using System.Collections;
using System.Collections.Generic; //for lists
using UnityEngine.UI; //add to access things in UI in Unity 5
using System.Reflection; //using this to be able to use getfields

public class Shop2 : Tiles{

	public List<BaseItem> itemList; //this will be a list containing all the items in the shop

	protected Image[] _shopIcon = new Image[5];
	protected Text[] _shopName = new Text[5];
	protected Button[] _shopBuyButton = new Button[5];

	protected int mOffset = 0;

	public GameObject mShop;
	//public GameObject _PlayerObject;

	protected GameObject shopCopy;

	protected Button mUpButton;
	protected Button mDownButton;
	protected Button mCloseButton;
	protected Button mYesButton;
	protected Button mNoButton;

	protected Text mPopupText;

	protected Inventory2 mInventory;
	protected PlayerInfo mPlayerInfo;

	protected GameObject textBox;
	protected GameObject shopBox;

	public string _tooLittleMoneyMessage;
	public string _areYouSureMessage;



	protected int itemNum;
	protected int ii;
	public void Start () {
		textBox = new GameObject ();
		shopBox = new GameObject ();
		mInventory = PlayerObject.GetComponent<Inventory2> (); //gets the inventory from the player
		mPlayerInfo = PlayerObject.GetComponent<PlayerInfo>(); //gets the player info, so we can check it's gold and modify it


		shopCopy = Instantiate (mShop); //creates a clone of the shop
		ii = 0;
		foreach (var item in shopCopy.GetComponentsInChildren<Image> ()) { //fetches the references of the itemimages of the shopclone
			if (item.tag == "shopSprites") {
				_shopIcon [ii] = item;
				ii++;
			}
		}
		ii = 0;
		foreach (var item in shopCopy.GetComponentsInChildren<Text> ()) { //fetches the references of the itemnames of the shopclones
			if (item.tag == "shopNames") {
				_shopName [ii] = item;
				ii++;
			}
			if (item.tag == "popupText") { //fetches the text from the confirmation popup
				mPopupText = item;
			}
		}
		ii = 0;
		foreach (var item in shopCopy.GetComponentsInChildren<Button> ()) { //fetches the references of the itembuy button of the shopclone.
			if (item.tag == "buyButton") {
				_shopBuyButton [ii] = item;
				ii++;
			}
		}

		foreach (var item in shopCopy.GetComponentsInChildren<Button> ()) { //fetches the up-down-close buttons
			if (item.tag == "upButton") {
				mUpButton = item;
			}
			if (item.tag == "downButton") {
				mDownButton = item;
			}
			if (item.tag == "closeButton") {
				mCloseButton = item;
			}
			//gets the yes no buttons from the confirmation popup:
			if (item.tag == "yesButton") {
				mYesButton = item;
			}
			if (item.tag == "noButton") {
				mNoButton = item;
			}
		}


		textBox = mNoButton.gameObject.transform.parent.gameObject;//gets the textbox so we can toggle it
		shopBox = mUpButton.gameObject.transform.parent.gameObject;//gets the "shopbox" so we can toggle it

		shopCopy.SetActive (false);
		mShop.SetActive (false);

		mUpButton.onClick.AddListener(() => PressButtonUp()); //tells the buttons which functions to call when pressed.
		mDownButton.onClick.AddListener(() => PressButtonDown());
		mCloseButton.onClick.AddListener(() => ClosedButton());
		mYesButton.onClick.AddListener (() => PressYesButton ());
		mNoButton.onClick.AddListener (() => PressNoButton ());

		_shopBuyButton [0].onClick.AddListener (() => BuyItem(0)); //tells the buybuttons which function to call
		_shopBuyButton [1].onClick.AddListener (() => BuyItem(1));
		_shopBuyButton [2].onClick.AddListener (() => BuyItem(2));
		_shopBuyButton [3].onClick.AddListener (() => BuyItem(3));
		_shopBuyButton [4].onClick.AddListener (() => BuyItem(4));

		foreach (var item in this.GetComponents<BaseItem>()) { //gets all the baseitems and adds them to the shop
			itemList.Add (item);
		}
		DrawItemsShop (0);
		 
	}

	void Update () {
	}

	virtual protected void DrawItemsShop(int offset) { //this method draws the items in the shop
		for (int i = 0; i < 5; i++) { 
			_shopIcon[i].sprite = itemList[i+offset].itemSprite; 
			_shopName[i].text = itemList[i+offset].itemName;
			_shopBuyButton [i].GetComponentInChildren<Text> ().text = (string)itemList [i + offset].itemPrice.ToString() + "G";
		}
	}

	void OnTriggerEnter2D(Collider2D other) { //checks if you make contact with the shop
		PlayerObject.GetComponent<PlayerController> ().canMove = false; //when shop activates  you can't move.
		shopCopy.SetActive(true);
		textBox.SetActive (false);//hides the popup
		mInventory.enabled = false; //disables the inventory while the shop is running.
		mOffset = 0;
		DrawItemsShop (0); //draws the items in the shop
	}

	public void PressButtonDown() { //this method is called when you click the down button
		if (mOffset+6<=itemList.Count) { //checks if the list is longer
			mOffset++;
			DrawItemsShop (mOffset); //redraws the shop
		}
	}

	public void PressButtonUp() { //this method is called when you click the up button
		if (mOffset>0 ) { //checks if you're not already at the top of the list
			mOffset--;
			DrawItemsShop (mOffset); //redraws the shop
		}
	}

	public void ClosedButton() { //if the closed button is pressed close the shop
		shopCopy.SetActive(false);
		mInventory.enabled = true; //enables inventory again
		PlayerObject.GetComponent<PlayerController> ().canMove = true; //player can move
	}

	public void BuyItem(int nr) { //when one of the buybuttons is pressed
		itemNum = nr;
		shopBox.SetActive(false);
		if (mPlayerInfo.gold >= itemList [nr + mOffset].itemPrice) { //checks if you can afford the item and changes the textbox accordingly
			mPopupText.text = _areYouSureMessage;
			mYesButton.gameObject.SetActive (true); //shows the yes button
			mNoButton.gameObject.GetComponentInChildren<Text>().text = "No"; //changes the no button back in case it was set to cancel
		} else {
			mPopupText.text = _tooLittleMoneyMessage;
			mYesButton.gameObject.SetActive (false); //hides the yes button
			mNoButton.gameObject.GetComponentInChildren<Text>().text = "Cancel"; //changes the no button to cancel
		}
		textBox.SetActive (true);
	}

	public void PressYesButton() { // the inventory is updated with new values.
		if (mPlayerInfo.gold >= itemList [itemNum + mOffset].itemPrice) {
			Destroy (PlayerObject.GetComponent<BaseItem> ());//removes whats currently in the inventory
			CopyComponent(itemList[itemNum+mOffset], PlayerObject);//adds the new bought componennt
			mPlayerInfo.gold -= itemList [itemNum + mOffset].itemPrice; //takes the money of the player
			textBox.SetActive (false); //disables the textbox after you click yes
			shopBox.SetActive (true); //enables the shop again
		}
	}
	public void PressNoButton() {
		textBox.SetActive (false); //disables the textbox after you click yes
		shopBox.SetActive (true); //enables the shop again
	}
	
	static public void CopyComponent(Component original, GameObject destination) //method to copy a component to another component //static so we can use it elsewhere
	{
		Component copy = destination.AddComponent(original.GetType());
		FieldInfo[] fields = original.GetType().GetFields();  //gets the public fields from the original component
		foreach (FieldInfo field in fields)
		{
			field.SetValue(copy, field.GetValue(original)); //places the fields on the new component
		}
	}
}
