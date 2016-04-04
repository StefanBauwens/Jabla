using UnityEngine;
using System.Collections;

public class Key : BaseItem {
    //key to open certain doors
    public string keyNumber; //should have the same name as the door so that we can check if it's the right key. This way we can two keys with the same name but still different

    //constructors
    public Key()    //default constructor
    {
        keyNumber = "keyid";
    }
    public Key(string name, string description, string keynr) : base(name, description)
    {
        keyNumber = keynr;
        itemName = name;
        itemDescription = description;
    }
    
}
