using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

    public int gold;
    public string playerName;
	public string Inventory;

    public PlayerInfo()
    {
        gold = 0;
        playerName = "John Smith";
		Inventory = "EMPTY";
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
