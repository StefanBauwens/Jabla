using UnityEngine;
using System.Collections;
using UnityEngine.UI; //add to access things in UI in Unity 5

public class Chest : Shop2 { //inherits from the shop
	public string _ChestName;


	// Use this for initialization
	void Start () {
		base.Start (); //runs the base start from shop2
		foreach (var item in shopCopy.GetComponentsInChildren<Text>()) { //gets the shop title name so we can change it to chestname
			if (item.tag=="shopTitle") {
				item.text = _ChestName;
			}
		}
	}
		
	override protected void DrawItemsShop(int offset) { //overriding this method so we can remove prices and just place "get" as a chest has only free items.
		for (int i = 0; i < 5; i++) { 
			_shopIcon[i].sprite = itemList[i+offset].itemSprite; 
			_shopName[i].text = itemList[i+offset].itemName;
			_shopBuyButton [i].GetComponentInChildren<Text> ().text = "GET";
		}
	}
}
