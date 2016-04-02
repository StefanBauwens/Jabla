using UnityEngine;
using System.Collections;

public class BaseItem: MonoBehaviour {
	
	public Sprite _itemSprite;
    public string _itemName;
    public string _itemDescription;//description of the item
	public int _itemPrice;

    
    //constructors
    public BaseItem()//default
    {
        _itemName = "Most useless item ever";
        _itemDescription = "Well the name explains it...";
    }

    public BaseItem(string name, string description)
    {
        _itemName = name;
        _itemDescription = description;
    }

	public BaseItem(Sprite sprite, string name, string description)
	{
		_itemSprite = sprite;
		_itemName = name;
		_itemDescription = description;
	}
	//properties

	public Sprite itemSprite {
		get {
			return _itemSprite;
		}
		set {
			_itemSprite = value;
		}
	}
	public string itemName {
		get {
			return _itemName;
		}
		set {
			_itemName = value;
		}
	}
	public string itemDescription {
		get {
			return _itemDescription;
		}
		set {
			_itemDescription = value;
		}
	}
	public int itemPrice {
		get {
			return _itemPrice;
		}
		set {
			_itemPrice = value;
		}
	}

   
}
