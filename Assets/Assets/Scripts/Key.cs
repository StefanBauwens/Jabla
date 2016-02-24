using UnityEngine;
using System.Collections;

public class Key : Items {
    //key to open certain doors
    public string _KeyNumber; //should have the same name as the door so that we can check if it's the right key

    public Key()
    {
        _KeyNumber = "Name of the door this key can open";
    }
    public Key(string name, string description, string keynumber): base(name, description)
    {
        _KeyNumber = keynumber;
    }
}
