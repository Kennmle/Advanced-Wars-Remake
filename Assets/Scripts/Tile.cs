using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour1 {

	/**Fields**/
	private int x;
	private int y;
	//private Unit containedUnit;
	//private Building containedBuilding;
	//private Map currentMap;
	private TileType type;
	
	/**End of fields**/
	
	void Awake() {
	//	this.setMap(this.GetComponentInParent<Map>());
	
		//Sets x and y based on position on the map, assumes map starts at (0,0)
		setX((int)this.gameObject.transform.position.x);
		setY((int)this.gameObject.transform.position.y);
		
	}
	// Use this for initialization
	void Start () {
		
	}
	//Note: I leave containedBuilding to be set by Building class 
	
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
	
		//returns current unit
	/*
	public Unit getUnit() {
		return containedUnit
	}
	
	public void setUnit(Unit cat) {
		containedUnit = cat;
	}
	
	public Building getBuilding() {
		return containedUnit
	}
	
	public void setBuilding(Building dog) {
		containedBuilding = dog;
	}
	
	public Map getMap() {
		return currentMap;
	}
	
	void setMap(Map m) {
		currentMap = m;
	}
	*/
	
	public Tile.TileType getType() {
		return type;
	}
	
	void setType(Tile.TileType x) {
		type=x;
	}
	
	/**End of setters and getters**/
	
	/**Types of tiles**/
	public enum TileType{
		grass,
		water,
	}
}
