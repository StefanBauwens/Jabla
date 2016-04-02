using UnityEngine;
using System.Collections;
using System.Collections.Generic; //for lists
using UnityEngine.UI; //add to access things in UI in Unity 5

public class Shop : MonoBehaviour {

	protected List<BaseItem> itemList; //this will be a list containing all the items in the shop
	public Sprite[] _itemSprites = new Sprite[5]; //with these arrays you can create your own items in unity.
	public string[] _itemNames = new string[5];
	public string[] _itemDescriptions = new string[5];
	public int[] _itemPrices = new int[5];


	protected Image[] _shopIcon = new Image[5];
	protected Text[] _shopName = new Text[5];
	protected Button[] _shopBuyButton = new Button[5];

	protected GameObject emptyObj;
	protected int mOffset = 0;

	public GameObject mShop;
	public GameObject _PlayerObject;

	protected GameObject shopCopy;

	protected Button mUpButton;
	protected Button mDownButton;
	protected Button mCloseButton;
	protected Button mYesButton;
	protected Button mNoButton;

	public Text mPopupText;

	protected Inventory mInventory;
	protected PlayerInfo mPlayerInfo;

	protected GameObject textBox;
	protected GameObject shopBox;

	public string _tooLittleMoneyMessage;
	public string _areYouSureMessage;



	protected int itemNum;
	protected int ii;
	void Start () {
		textBox = new GameObject ();
		shopBox = new GameObject ();
		mInventory = _PlayerObject.GetComponent<Inventory> (); //gets the inventory from the player
		mPlayerInfo = _PlayerObject.GetComponent<PlayerInfo>(); //gets the player info, so we can check it's gold and modify it

		emptyObj = new GameObject();
		emptyObj.AddComponent<BaseItem>();//creates an empty gameobject and adds BaseItem to it

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


		itemList = new List<BaseItem>(); //initialise the list of items
		for (int i = 0; i < _itemSprites.Length; i++) { //will add all the sprites, names and descriptions to a baseitem, and then add that baseitem to the list

			GameObject temp = Instantiate(emptyObj); //clones the emptygameobject with baseitem on it. I have to do it like this because using "new BaseItem" isn't allowed in Unity.
			temp.GetComponent<BaseItem> ().itemSprite = _itemSprites [i];
			temp.GetComponent<BaseItem> ().itemName = _itemNames [i];
			temp.GetComponent<BaseItem> ().itemDescription = _itemDescriptions [i];
			temp.GetComponent<BaseItem> ().itemPrice = _itemPrices [i];

			itemList.Add (temp.GetComponent<BaseItem>());
			Destroy (temp); //gets rid of temp
		}	
		Destroy (emptyObj);//removes emptyobj
	}

	void Update () {
	}

	void DrawItemsShop(int offset) { //this method draws the items in the shop
		for (int i = 0; i < 5; i++) { 
			_shopIcon[i].sprite = itemList[i+offset].itemSprite; 
			_shopName[i].text = itemList[i+offset].itemName;
			_shopBuyButton [i].GetComponentInChildren<Text> ().text = (string)itemList [i + offset].itemPrice.ToString() + "G";
		}
	}

	void OnTriggerEnter2D(Collider2D other) { //checks if you make contact with the shop
		_PlayerObject.GetComponent<PlayerController> ().canMove = false; //when shop activates  you can't move.
		shopCopy.SetActive(true);
		textBox.SetActive (false);//hides the popup
		mInventory.enabled = false; //disables the inventory while the shop is running.
		mOffset = 0;
		DrawItemsShop (0); //draws the items in the shop
	}

	public void PressButtonDown() { //this method is called when you click the down button
		if (mOffset+6<=_itemSprites.Length ) { //checks if the list is longer
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
		_PlayerObject.GetComponent<PlayerController> ().canMove = true; //player can move
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
			mInventory.itemName = itemList [itemNum + mOffset].itemName;
			mInventory.itemDescription = itemList [itemNum + mOffset].itemDescription;
			mInventory.itemSprite = itemList [itemNum + mOffset].itemSprite;
			mInventory.itemPrice = itemList [itemNum + mOffset].itemPrice;
			mPlayerInfo.gold -= itemList [itemNum + mOffset].itemPrice; //takes the money of the player
			textBox.SetActive (false); //disables the textbox after you click yes
			shopBox.SetActive (true); //enables the shop again
		}
	}
	public void PressNoButton() {
		textBox.SetActive (false); //disables the textbox after you click yes
		shopBox.SetActive (true); //enables the shop again
	}
}
