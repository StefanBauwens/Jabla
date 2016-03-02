using UnityEngine;
using System.Collections;

public class Teleport : Tiles {
	
	public int mNewXCoordinate;
	public int mNewYCoordinate;

	//Constructors
	public Teleport()
	{
		mType = tileType.Teleport;
		mNewXCoordinate = 0; //eventually change these to Player's current position
		mNewYCoordinate = 0;
	}

	public Teleport(bool canWalkThrough, int newXCoordinate, int newYCoordinate) : base(canWalkThrough)
	{
		mType = tileType.Teleport;
		mNewXCoordinate = newXCoordinate; 
		mNewYCoordinate = newYCoordinate;
	}

	//properties
	public int NewXCoordinate
	{
		get
		{
			return mNewXCoordinate;
		}
		set
		{
			mNewXCoordinate = value;
		}
	}

	public int NewYCoordinate
	{
		get
		{
			return mNewYCoordinate;
		}
		set
		{
			mNewYCoordinate = value;
		}
	}
}