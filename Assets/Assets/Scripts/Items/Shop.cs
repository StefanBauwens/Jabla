using UnityEngine;
using System.Collections;
using System.Collections.Generic; //for lists
using UnityEngine.UI; //add to access things in UI in Unity 5

public class Shop : MonoBehaviour {

	protected List<BaseItem> itemList; //this will be a list containing all the items in the shop
	public Sprite[] _itemSprites = new Sprite[5]; //with these arrays you can create your own items in unity.
	public string[] _itemNames = new string[5];
	public string[] _itemDescriptions = new string[5];

	public Image[] _shopIcon = new Image[5]; //references to the items in the shop so the code knows which images and text to change
	public Text[] _shopName = new Text[5];
	public Button[] _shopBuyButton = new Button[5];

	protected GameObject emptyObj;
	protected int mOffset = 0;
	public GameObject mShop;

	void Start () {
		emptyObj = new GameObject();
		emptyObj.AddComponent<BaseItem>();//creates an empty gameobject and adds BaseItem to it

		itemList = new List<BaseItem>(); //initialise the list of items
		for (int i = 0; i < _itemSprites.Length; i++) { //will add all the sprites, names and descriptions to a baseitem, and then add that baseitem to the list

			GameObject temp = Instantiate(emptyObj); //clones the emptygameobject with baseitem on it. I have to do it like this because using "new BaseItem" isn't allowed in Unity.
			temp.GetComponent<BaseItem> ().itemSprite = _itemSprites [i];
			temp.GetComponent<BaseItem> ().itemName = _itemNames [i];
			temp.GetComponent<BaseItem> ().itemDescription = _itemDescriptions [i];

			itemList.Add (temp.GetComponent<BaseItem>());
		}	

		DrawItemsShop (0); //draws the items in the shop
	}

	void Update () {
	}

	void DrawItemsShop(int offset) { //this method draws the items in the shop
		for (int i = 0; i < 5; i++) { 
			_shopIcon[i].sprite = itemList[i+offset].itemSprite; 
			_shopName[i].text = itemList[i+offset].itemName;
		}
	}

	void OnTriggerEnter2D(Collider2D other) { //checks if you make contact with the shop
		mShop.SetActive(true);
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
		mShop.SetActive(false);
	}

}
