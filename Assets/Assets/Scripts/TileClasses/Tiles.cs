using UnityEngine;
using System.Collections;

public class Tiles : MonoBehaviour {

	public enum tileType
	{
		Normal,
		Teleport,
		DoorTile,
		Dangerous
	}
		
	public tileType mType;
	protected bool mCanWalkThrough;//True if the player can walk through this tile

	//Constructors
	public Tiles()
	{
		mType = tileType.Normal;
		mCanWalkThrough = true;
	}

	public Tiles(bool canWalkThrough)
	{
		mCanWalkThrough = canWalkThrough;
	}

	public Tiles(tileType tileType)
	{
		mType = tileType;
		mCanWalkThrough = false;
	}

	public Tiles(tileType tileType, bool canWalkThrough)
	{
		mType = tileType;
		mCanWalkThrough = canWalkThrough;
	}

	//properties
	public bool CanWalkThrough //use this to check in game if player can walk through tiles
	{
		get
		{
			return mCanWalkThrough;
		}
		set
		{
			mCanWalkThrough = value;
		}
	}

	public tileType TileType
	{
		get
		{
			return mType;
		}
		set
		{
			mType = value;
		}
	}
}