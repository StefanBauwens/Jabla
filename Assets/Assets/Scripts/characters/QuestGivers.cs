﻿using UnityEngine;
using System.Collections;

public class QuestGivers : Helper {

    //Fields
    
    public string _ItemRequested; //The item the player must return;
    
    public int _Reward; //the award the player gets for returning the requested item
	public BaseItem _RewardItem; //give item as reward.
	public BaseItem _EmptyItem; //give item as reward.
	public string _RewardSentence; //what he says when you bring the requested item
	public string _ReturnWithNothing; //what he says when you don't bring the requested item.
	public string _ReturnSentence; //What he says when he already gave you your reward.
	protected int _TimesVisited =0;

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

    
	void Start() {
		base.Start2(); //runs the start from Helperclass
	}


    void Update()
    {
		base.Update (); //runs the update from Helperclass
    }

	void OnTriggerEnter2D(Collider2D other) //if you're touching the npc
	{
		if (other.name == "Player" && _GoldIsGiven == false) { //checks to see if you already got gold
			_Collision = true;
		}
		if (_TimesVisited == 0) {
			_TimesVisited = 1; //checks if you already came
		} else {
			if (_TimesVisited ==1) {
				this.gameObject.GetComponent<ActivateTextAtLine> ().endLine = 0; //changes the talk of the npc to only one line
				if (_Player.gameObject.GetComponent<BaseItem> ()._itemName == _ItemRequested) { //checks if you brought the item
					this.gameObject.GetComponent<ActivateTextAtLine> ().text [0] = _RewardSentence; //puts the rewardsentence in the activatetextatline script 
					Destroy (_Player.gameObject.GetComponent<BaseItem> ());//removes whats currently in the inventory
					if (_RewardItem != null) { //null means empty field
						Shop2.CopyComponent (_RewardItem, _Player.gameObject);//adds the reward item
					} else {
						Shop2.CopyComponent (_EmptyItem, _Player.gameObject); //if you don't get a rewarditem, you get an empty item instead.
					}
					_Player.gold += _Reward; //gives the player his reward
					_TimesVisited = 2;
				} else {
					this.gameObject.GetComponent<ActivateTextAtLine> ().text[0] = _ReturnWithNothing; //if you didn't return with the item
				}
			}
			else { //if timesvisited ==2
				this.gameObject.GetComponent<ActivateTextAtLine> ().text [0] = _ReturnSentence; //if you already got your reward.
			}

		}
	}

}
