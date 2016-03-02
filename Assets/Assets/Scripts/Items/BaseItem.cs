using UnityEngine;
using System.Collections;

public class BaseItem {

    protected string _itemName;
    protected string _itemDescription;//description of the item
    public enum itemTypes
    {
        KEY,
        BOOK,
        POTION
    };

    protected itemTypes _itemType;

    
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

    //properties --> allows you to access information in base class (set the value or read it)
    public string itemName
    {
        get { return _itemName; }
        set { _itemName = value; }
    }

    public string itemDescription
    {
        get { return _itemDescription; }
        set { _itemDescription = value; }
    }
    public itemTypes itemType
    {
        get { return _itemType; }
        set { _itemType = value; }
    }

}
