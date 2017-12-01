using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Game: MonoBehaviour {
	private Team[] teams;
	private Map currentMap;
	private int current; //index of active team (for the current team, use teams[current])
	private int income; //amount of money earned for each building
	
	
	private Tile selectedTile;
	private int gameState; // 0=Normal, 1=Move/attack highlighter open, 2=menus
	private readonly int GAMESTATEMAX = 2;
	
	private Dictionary<Tile.TileType, int> movementCost; //To be defined by each movement type
	
	
	
	void Awake() {
		teams=GetComponentsInChildren<Team>();
		gameState=0;
		currentMap=GetComponentInChildren<Map>();
		current=0;
		income = 500;//We'll figure out how to change this in a menu later
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	/** The following are shortcuts (keyboard) used for tile selection **/
	
	public static bool aPress() {
		return Input.GetMouseButtonUp(0)||Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Return);
	}
	
	public static bool bPress() {
		return Input.GetKeyDown(KeyCode.Backspace)||Input.GetKeyDown("b");
	}
	
	public static bool left() {
		return Input.GetKeyDown("a")||Input.GetKeyDown("left");
	}
	
	public static bool right() {
		return Input.GetKeyDown("d")||Input.GetKeyDown("right");
	}
	
	public static bool up() {
		return Input.GetKeyDown("w")||Input.GetKeyDown("up");
	}
	
	public static bool down() {
		return Input.GetKeyDown("s")||Input.GetKeyDown("down");
	}
	/** End of shortcuts **/
	
	// Update is called once per frame
	void Update () {
		UI.updateHighlight(currentMap.getMapWidth(), currentMap.getMapHeight());
		
			if(aPress()) {
				selectedTile = currentMap.findTile(UI.x(),UI.y());
				//only doing basic attack/movement stuff rn, will implement rigs, flares, etc. later on
				//Checks what to bring up
				UI.debug('A');
				if(selectedTile.containsUnit())	{
					Unit u = selectedTile.getUnit();
					if(teams[current].contains(u)) {//this is not combined with the other if-statement on purpose
						setGameState(1);					
						movementCost=Movement.setCurrentMovement(u);
						
						Movement.addPossibleMoves(selectedTile,movementCost,u.getMovement(),currentMap, teams[current]);
						Movement.highlight();
						
						
					}
				}
				
				else if(selectedTile.containsBuilding()) {
					setGameState(2);
				}
				
			}
			
			if(bPress()) {
				
			}
		UI.updateMousePos();
	}
	
	public void nextTurn() { //To be used by button
		current=(current+1)%teams.Length;
		/*
		Note: Alternatively, the following bit can be implemented w/ clicking on units
		
		foreach(Team t in teams)
		{
			foreach(Unit u in t)
			{
				u.disable(); //Make it so that units cannot attack/move (perform any action)
			}
		}
		foreach(Unit u in teams[current])
		{
			u.refresh(); //Placeholder name, idea is to reallow movement, reduce gas, supply, etc. Either make in Unit or this class
		}
		*/
		teams[current].addFunds(income*teams[current].getBuildings().Count);
	}
	
	int getGameState()
	{
		return gameState;
	}
	
	bool setGameState(int x)
	{
		if(0<=x&&x<=GAMESTATEMAX) {
			gameState=x;
			return true;
		}
		else {
			return false;
		}
	}
	
	
}
