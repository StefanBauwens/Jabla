using UnityEngine;
using System.Collections;
//using System;

public class WorldDraw : MonoBehaviour {

	//the prefabs you want to draw
	public Transform grassPrefab; //=1
	public Transform dirtPrefab;  //=0

	private Transform tileHolder;
	private Transform prefab;

	//array map
	private int[,] map = new int [,] {
		{0,0,0,0,0,0,0,0,0},
		{0,1,1,1,0,1,1,1,0},
		{0,1,0,0,0,0,1,0,0},
		{0,1,1,1,0,0,1,0,0},
		{0,0,0,1,0,0,1,0,0},
		{0,1,1,1,0,0,1,0,0},
		{0,0,0,0,0,0,0,0,0}
	};


	// Use this for initialization
	void Start () {
		tileHolder = new GameObject ("Tiles").transform; //empty gameobject to hold all the clones so it stays uncluttered
		for (int rows = 0; rows < map.GetLength(0); rows++) { //forloop to draw the map
			for (int colls = 0; colls < map.GetLength(1); colls++) { //colls stands for collumns :P
				switch (map [rows, colls]) { //checks to see which tile it is
				case 0:
					prefab = dirtPrefab;
					break;
				case 1:
					prefab = grassPrefab;
					break;
				}
				//draws it to the screen
				Transform newThing = Instantiate (prefab, new Vector3 (colls, map.GetLength (0) - rows, 0f), Quaternion.identity) as Transform; //Quaternion is for rotation(stays the same here). Instantiate copies an existing prefab.
				newThing.transform.parent = tileHolder; //places the clone as a child from this object.
			}
		}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
