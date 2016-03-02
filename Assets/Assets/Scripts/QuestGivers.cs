using UnityEngine;
using System.Collections;

public class QuestGivers : Helper {

    //Fields
    
    public string _ItemRequested; //The item the player must return;
    
    public int _Reward; //the award the player gets for returning the requested item;

    //Constructors
    public QuestGivers()
    {
        _Reward = 0;
        _Gold = 10;
        _ItemRequested = "Cake";
    }

    public QuestGivers(string name, int gold, string itemRequested, int reward) : base(name, gold)
    {
        _ItemRequested = itemRequested;
        _Reward = reward;
    }

    //Methods

    //Check if player returned item
    public string CheckForItem()
    {
        //check-code here
        return "Thank you";
        //give-reward-code here
    }

    void Update()
    {
        //Debug.Log("This NPC's name is " + _Name + ", has " + _Gold + " gold, wants " + _ItemRequested + " and gives " + _Reward + " as a reward");
    }

}
