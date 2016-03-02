using UnityEngine;
using System.Collections;

public class Key : BaseItem {
    //key to open certain doors
    protected string _keyNumber; //should have the same name as the door so that we can check if it's the right key

    //constructors
    public Key()
    {
        _keyNumber = "Name of the door this key can open";
    }
    public Key(string name, string description, string keynumber): base(name, description)
    {
        _keyNumber = keynumber;
    }
    //properties
    public string keyNumber
    {
        get { return _keyNumber; }
        set { _keyNumber = value; }
    }
}
