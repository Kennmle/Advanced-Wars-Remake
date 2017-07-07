using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour1 {

	/**Fields**/
	private int x;
	private int y;
	private Building containedBuilding;
	private TileType type;
	
	/**End of fields**/
	
	void Awake() {
	
		//Sets x and y based on position on the map, assumes map starts at (0,0)
		setX((int)this.gameObject.transform.position.x);
		setY((int)this.gameObject.transform.position.y);
		containedBuilding=GetComponentInChildren<Building>();
		
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnClick() {
		//Selects unit or building, with unit priority
		/*
		if (containedUnit)
			containedUnit.OnClick();
		else if (containedBuilding)
			containedBuilding.OnClick();
		*/
	}
	
	/**Setters and getters**/
	
		//returns x and y coordinates
	public int getX() {
		return x;
	}
	
	public int getY() {
		return y;
	}
		//setters for x and y not made public, since they shouldn't be changed.
	void setX(int x1) {
		x = x1;
	}
	
	void setY(int y1) {
		y = y1;
	}
	
	public Building getBuilding() {
		return containedBuilding;
	}
	
	public void setBuilding(Building dog) {
		containedBuilding = dog;
	}
	
	
	public Tile.TileType getType() {
		return type;
	}
	
	public void setType(Tile.TileType x) {
		type=x;
	}
	
	/**End of setters and getters**/
	
	/**Types of tiles**/
	public enum TileType{
		HQ,	City,	Factory,	Airport,	Seaport,	TempAir,	TempSea,
		Plain,	River,	Road,	Wood,	Wasteland,	Ruins,	Mountain,
		Beach,	Bridge,	Sea,	Reef,	RoughSea,	Mist,
	}
}
