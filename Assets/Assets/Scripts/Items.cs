using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour {

    public string _Name;
    public string _Description;//description of the item

    //constructors
    public Items()//default
    {
        _Name = "Most useless item ever";
        _Description = "Well the name explains it...";
    }

    public Items(string name, string description)
    {
        _Name = name;
        _Description = description;
    }


}
