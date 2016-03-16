using UnityEngine;
using System.Collections;

public class Key : BaseItem {
    //key to open certain doors
    public string keyNumber; //should have the same name as the door so that we can check if it's the right key
    public string itemName;
    public string itemDescription;

    //constructors
    public Key()    //default constructor
    {
        keyNumber = "Name of the door this key can open";
    }
    public Key(string name, string description, string keynr) : base(name, description)
    {
        keyNumber = keynr;
        itemName = name;
        itemDescription = description;
    }
    
}
