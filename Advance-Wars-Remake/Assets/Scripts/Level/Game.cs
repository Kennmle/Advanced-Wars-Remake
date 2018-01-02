using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Game: MonoBehaviour {
	private Team[] team;
	private Map map;
	private int turn; //index of active team (for the turn team, use team[turn])
	private int income; //amount of money earned for each building


	private Tile selectedTile;
	private int gameState;
	/* 0=Normal (unit/building selection)
	* 1=Move/attack highlighter open,
	* 2=movement confirmation
	* 3=building menu (buying units)
	* 4=option menu
	*/

	void Awake() {
		team=new Team[2]; //no idea how this is gonna work
		gameState=0;
		map=GetComponentInChildren<Map>();
		turn=0;
		income = 500;//We'll figure out how to change this in a menu later
	}

	// Use this for initialization
	void Start () {
		/* Testing movement */
		Commander co = new TestCommander();
		team[0]= new Team(co);
		map.findTile(0,0).setUnit(team[0].generateTestTeam(GetComponentInChildren<TestUnit>().gameObject));
		UI.setMap(map);
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
		//Maybe move these into switch statement later on?
		if(gameState==0||gameState==1) {
			UI.updateHighlight();
			selectedTile = map.findTile(UI.x(),UI.y());
		}
		/* Game state represents what's going on in-game right now.
		* 0 = nothing selected, default state
		* 1 = unit selected, so displaying movement options and choosing move
		* 2 = building selected, so menu to buy stuff (if appropriate)
		*/
		switch(gameState) {
					case(0):
						if(aPress()) {
						//only doing basic attack/movement stuff rn, will implement rigs, flares, etc. later on
						//Checks what to bring up
							if(selectedTile.containsUnit())	{
								Unit u = selectedTile.getUnit();
								if(u==null)
									Debug.Log("UnitNullException");
								if(team[turn].contains(u)) {//this is not combined with the other if-statement on purpose
									setGameState(1);
									Movement.addPossibleMoves(selectedTile,u,map, team[turn]);
								}
							}
								else if(selectedTile.containsBuilding()) {
									//if(team[turn] has this building)
									setGameState(2);
									//Have menu open only
								}
						} //End of A-press
						if(bPress()) {
							UI.debug('B', map);
						}//End of B-press
					break;
					case(1):
						Movement.updatePath(selectedTile,map);
						if(aPress()) {//ignoring confirmation step for now
							if(selectedTile==Movement.getEndTile()) {
								Menu.movementReset();
								Menu.movementSelect(true);//placeholder for now
								Menu.switchToMovement();
								gameState=2;
							}
						}
					break;
					case(2):
						switch(Menu.getMovementState()) {
							case(1):
								Movement.moveUnit();
								Menu.switchFromMovement();
								gameState=0;
								break;
							case(2): //attack
								Movement.moveUnit();
								Menu.switchFromMovement();
								gameState=0;
								//Placeholder
								break;
						}
					break;
				}//End of switch statement


		UI.updateMousePos();
	}

	public void nextTurn() { //To be used by button
		turn=(turn+1)%team.Length;
		/*
		Note: Alternatively, the following bit can be implemented w/ clicking on units

		foreach(Team t in team)
		{
			foreach(Unit u in t)
			{
				u.disable(); //Make it so that units cannot attack/move (perform any action)
			}
		}
		foreach(Unit u in team[turn])
		{
			u.refresh(); //Placeholder name, idea is to reallow movement, reduce gas, supply, etc. Either make in Unit or this class
		}
		*/
		//team[turn].addFunds(income*team[turn].getBuildings().Count);
	}

	int getGameState()	{
		return gameState;
	}

	void setGameState(int x)	{
		gameState=x;
	}
}
