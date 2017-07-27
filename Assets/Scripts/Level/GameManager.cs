using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour1 {
	private Team[] teams;
	private Map currentMap;
	private int current; //index of active team (for the current team, use teams[current])
	private int income; //amount of money earned for each building
	private Vector3 mousePos; //current Mouse Position
	private Vector3 lastMousePos;
	private GameObject tileHighlighter;
	private Vector3 hlPos; //highlighter Position
	private List<GameObject> moveHighlighters;
	private GameObject sampleMoveHL;
	private List<Tile> possibleMoves;
	private Tile selectedTile;
	private int gameState; // 0=Normal, 1=Move/attack highlighter open, 2=menus
	
	private Dictionary<Tile.TileType, int> movementCost; //To be defined by each movement type
	
	private Vector3 tempPos; //used in update()
	
	
	void Awake() {
		teams=GetComponentsInChildren<Team>();
		gameState=0;
		currentMap=GetComponentInChildren<Map>();
		current=0;
		income = 500;//We'll figure out how to change this in a menu later
		tileHighlighter=GameObject.FindWithTag("HighlighterCube");
		sampleMoveHL=GameObject.FindWithTag("MovementHighlighter");
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	/** The following are shortcuts (keyboard) used for tile selection **/
	
	bool aPress() {
		return Input.GetMouseButtonUp(0)||Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Return);
	}
	
	bool bPress() {
		return Input.GetKeyDown(KeyCode.Backspace)||Input.GetKeyDown("b");
	}
	
	bool left() {
		return Input.GetKeyDown("a")||Input.GetKeyDown("left");
	}
	
	bool right() {
		return Input.GetKeyDown("d")||Input.GetKeyDown("right");
	}
	
	bool up() {
		return Input.GetKeyDown("w")||Input.GetKeyDown("up");
	}
	
	bool down() {
		return Input.GetKeyDown("s")||Input.GetKeyDown("down");
	}
	/** End of shortcuts **/
	
	// Update is called once per frame
	void Update () {
		hlPos=tileHighlighter.transform.position;
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition); //finds location of mouse
		tempPos=hlPos;
		
		if(left())
			tempPos -= new Vector3(1f,0f,0f);		
		if(up())
			tempPos += new Vector3(0f,1f,0f);
		if(right())
			tempPos += new Vector3(1f,0f,0f);
		if(down())
			tempPos -= new Vector3(0f,1f,0f);
		if(mousePos!=lastMousePos&&((int)mousePos.x!=(int)tileHighlighter.transform.position.x||(int)mousePos.y!=(int)tileHighlighter.transform.position.y)) //ie, mouse and highlighters on different tiles
		{
			tempPos = new Vector3((int)mousePos.x*1f,(int)mousePos.y*1f,0f);
		}
		
		if(tempPos.x<0)
			tempPos.x=0;
		if(tempPos.x>=currentMap.getMapWidth())
			tempPos.x=currentMap.getMapWidth()-1;
		if(tempPos.y<0)
			tempPos.y=0;
		if(tempPos.y>=currentMap.getMapHeight())
			tempPos.y=currentMap.getMapHeight()-1;
		
		tileHighlighter.transform.position=tempPos;
		
			if(aPress())
			{
				//only doing basic attack/movement stuff rn, will implement rigs, flares, etc. later on
				//Checks what to bring up
				selectedTile = currentMap.findTile((int)hlPos.x,(int)hlPos.y);
				Debug.Log((int)hlPos.x+" "+(int)hlPos.y);
				if(selectedTile.containsUnit())
				{
					Unit u = selectedTile.getUnit();
					if(teams[current].contains(u)) //this is not combined with the other if-statement on purpose
					{
						movementCost=setCurrentMovement(u);
						possibleMoves= new List<Tile>();
						moveHighlighters = new List<GameObject>();
						
						addPossibleMoves(selectedTile,movementCost,u.getMovement(),possibleMoves);
						foreach(Tile t in possibleMoves)
						{
							moveHighlighters.Add(UnityEngine.Object.Instantiate(sampleMoveHL,t.transform.position,Quaternion.identity));
						}
					}
				}
				
			}
		lastMousePos=mousePos;	
	}
	
	void addPossibleMoves(Tile currentTile, Dictionary<Tile.TileType, int> d, int moves, List<Tile> moveList) {
		moveList.Add(currentTile);
		if(currentTile.getX()>0&&d[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()]<moves&&d[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()]>0) //check if leftmost
			if(!currentMap.findTile(currentTile.getX()-1,currentTile.getY()).containsUnit()||!teams[current].contains(currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getUnit()))
				addPossibleMoves(currentMap.findTile(currentTile.getX()-1,currentTile.getY()),d,moves-d[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()],moveList);
		if(currentTile.getX()<currentMap.getMapWidth()-1&&d[currentMap.findTile(currentTile.getX()+1,currentTile.getY()).getType()]<moves&&d[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()]>0) //check rightmost
			if(currentMap.findTile(currentTile.getX()+1,currentTile.getY()).containsUnit()||!teams[current].contains(currentMap.findTile(currentTile.getX()+1,currentTile.getY()).getUnit()))
				addPossibleMoves(currentMap.findTile(currentTile.getX()+1,currentTile.getY()),d,moves-d[currentMap.findTile(currentTile.getX()+1,currentTile.getY()).getType()],moveList);
		if(currentTile.getY()>0&&d[currentMap.findTile(currentTile.getX(),currentTile.getY()-1).getType()]<moves&&d[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()]>0) //check if bottom
			if(currentMap.findTile(currentTile.getX(),currentTile.getY()-1).containsUnit()||!teams[current].contains(currentMap.findTile(currentTile.getX(),currentTile.getY()-1).getUnit()))
				addPossibleMoves(currentMap.findTile(currentTile.getX(),currentTile.getY()-1),d,moves-d[currentMap.findTile(currentTile.getX(),currentTile.getY()-1).getType()],moveList);
		if(currentTile.getY()<currentMap.getMapHeight()-1&&d[currentMap.findTile(currentTile.getX()+1,currentTile.getY()).getType()]<moves&&d[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()]>0) //check top
			if(currentMap.findTile(currentTile.getX(),currentTile.getY()+1).containsUnit()||!teams[current].contains(currentMap.findTile(currentTile.getX(),currentTile.getY()+1).getUnit()))
				addPossibleMoves(currentMap.findTile(currentTile.getX(),currentTile.getY()+1),d,moves-d[currentMap.findTile(currentTile.getX(),currentTile.getY()+1).getType()],moveList);
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
	
	Dictionary<Tile.TileType, int> setCurrentMovement(Unit u) {
		Dictionary<Tile.TileType, int> movementCosts=new Dictionary<Tile.TileType, int>();
		if(u.getMovementType()==Unit.MovementType.Infantry) {
			movementCosts.Add(Tile.TileType.HQ,1);
			movementCosts.Add(Tile.TileType.City,1);
			movementCosts.Add(Tile.TileType.Factory,1);
			movementCosts.Add(Tile.TileType.Airport,1);
			movementCosts.Add(Tile.TileType.Seaport,1);
			movementCosts.Add(Tile.TileType.TempAir,1);
			movementCosts.Add(Tile.TileType.TempSea,1);
			movementCosts.Add(Tile.TileType.Plain,1);
			movementCosts.Add(Tile.TileType.River,2);
			movementCosts.Add(Tile.TileType.Road,1);
			movementCosts.Add(Tile.TileType.Wood,1);
			movementCosts.Add(Tile.TileType.Wasteland,1);
			movementCosts.Add(Tile.TileType.Ruins,1);
			movementCosts.Add(Tile.TileType.Mountain,2);
			movementCosts.Add(Tile.TileType.Beach,1);
			movementCosts.Add(Tile.TileType.Bridge,1);
			movementCosts.Add(Tile.TileType.Sea,0);
			movementCosts.Add(Tile.TileType.Reef,0);
			movementCosts.Add(Tile.TileType.RoughSea,0);
			movementCosts.Add(Tile.TileType.Mist,0);
		}
		
		if(u.getMovementType()==Unit.MovementType.Mech) {
			movementCosts.Add(Tile.TileType.HQ,1);
			movementCosts.Add(Tile.TileType.City,1);
			movementCosts.Add(Tile.TileType.Factory,1);
			movementCosts.Add(Tile.TileType.Airport,1);
			movementCosts.Add(Tile.TileType.Seaport,1);
			movementCosts.Add(Tile.TileType.TempAir,1);
			movementCosts.Add(Tile.TileType.TempSea,1);
			movementCosts.Add(Tile.TileType.Plain,1);
			movementCosts.Add(Tile.TileType.River,1);
			movementCosts.Add(Tile.TileType.Road,1);
			movementCosts.Add(Tile.TileType.Wood,1);
			movementCosts.Add(Tile.TileType.Wasteland,1);
			movementCosts.Add(Tile.TileType.Ruins,1);
			movementCosts.Add(Tile.TileType.Mountain,1);
			movementCosts.Add(Tile.TileType.Beach,1);
			movementCosts.Add(Tile.TileType.Bridge,1);
			movementCosts.Add(Tile.TileType.Sea,0);
			movementCosts.Add(Tile.TileType.Reef,0);
			movementCosts.Add(Tile.TileType.RoughSea,0);
			movementCosts.Add(Tile.TileType.Mist,0);
		}
		
		if(u.getMovementType()==Unit.MovementType.TireA) {
			movementCosts.Add(Tile.TileType.HQ,1);
			movementCosts.Add(Tile.TileType.City,1);
			movementCosts.Add(Tile.TileType.Factory,1);
			movementCosts.Add(Tile.TileType.Airport,1);
			movementCosts.Add(Tile.TileType.Seaport,1);
			movementCosts.Add(Tile.TileType.TempAir,1);
			movementCosts.Add(Tile.TileType.TempSea,1);
			movementCosts.Add(Tile.TileType.Plain,2);
			movementCosts.Add(Tile.TileType.River,0);
			movementCosts.Add(Tile.TileType.Road,1);
			movementCosts.Add(Tile.TileType.Wood,3);
			movementCosts.Add(Tile.TileType.Wasteland,3);
			movementCosts.Add(Tile.TileType.Ruins,2);
			movementCosts.Add(Tile.TileType.Mountain,0);
			movementCosts.Add(Tile.TileType.Beach,2);
			movementCosts.Add(Tile.TileType.Bridge,1);
			movementCosts.Add(Tile.TileType.Sea,0);
			movementCosts.Add(Tile.TileType.Reef,0);
			movementCosts.Add(Tile.TileType.RoughSea,0);
			movementCosts.Add(Tile.TileType.Mist,0);
		}
		
		if(u.getMovementType()==Unit.MovementType.TireB) {
			movementCosts.Add(Tile.TileType.HQ,1);
			movementCosts.Add(Tile.TileType.City,1);
			movementCosts.Add(Tile.TileType.Factory,1);
			movementCosts.Add(Tile.TileType.Airport,1);
			movementCosts.Add(Tile.TileType.Seaport,1);
			movementCosts.Add(Tile.TileType.TempAir,1);
			movementCosts.Add(Tile.TileType.TempSea,1);
			movementCosts.Add(Tile.TileType.Plain,1);
			movementCosts.Add(Tile.TileType.River,0);
			movementCosts.Add(Tile.TileType.Road,1);
			movementCosts.Add(Tile.TileType.Wood,3);
			movementCosts.Add(Tile.TileType.Wasteland,3);
			movementCosts.Add(Tile.TileType.Ruins,1);
			movementCosts.Add(Tile.TileType.Mountain,0);
			movementCosts.Add(Tile.TileType.Beach,2);
			movementCosts.Add(Tile.TileType.Bridge,1);
			movementCosts.Add(Tile.TileType.Sea,0);
			movementCosts.Add(Tile.TileType.Reef,0);
			movementCosts.Add(Tile.TileType.RoughSea,0);
			movementCosts.Add(Tile.TileType.Mist,0);
		}
		
		if(u.getMovementType()==Unit.MovementType.Tank) {
			movementCosts.Add(Tile.TileType.HQ,1);
			movementCosts.Add(Tile.TileType.City,1);
			movementCosts.Add(Tile.TileType.Factory,1);
			movementCosts.Add(Tile.TileType.Airport,1);
			movementCosts.Add(Tile.TileType.Seaport,1);
			movementCosts.Add(Tile.TileType.TempAir,1);
			movementCosts.Add(Tile.TileType.TempSea,1);
			movementCosts.Add(Tile.TileType.Plain,1);
			movementCosts.Add(Tile.TileType.River,0);
			movementCosts.Add(Tile.TileType.Road,1);
			movementCosts.Add(Tile.TileType.Wood,2);
			movementCosts.Add(Tile.TileType.Wasteland,2);
			movementCosts.Add(Tile.TileType.Ruins,1);
			movementCosts.Add(Tile.TileType.Mountain,0);
			movementCosts.Add(Tile.TileType.Beach,1);
			movementCosts.Add(Tile.TileType.Bridge,1);
			movementCosts.Add(Tile.TileType.Sea,0);
			movementCosts.Add(Tile.TileType.Reef,0);
			movementCosts.Add(Tile.TileType.RoughSea,0);
			movementCosts.Add(Tile.TileType.Mist,0);
		}
		
		if(u.getMovementType()==Unit.MovementType.Air) {
			movementCosts.Add(Tile.TileType.HQ,1);
			movementCosts.Add(Tile.TileType.City,1);
			movementCosts.Add(Tile.TileType.Factory,1);
			movementCosts.Add(Tile.TileType.Airport,1);
			movementCosts.Add(Tile.TileType.Seaport,1);
			movementCosts.Add(Tile.TileType.TempAir,1);
			movementCosts.Add(Tile.TileType.TempSea,1);
			movementCosts.Add(Tile.TileType.Plain,1);
			movementCosts.Add(Tile.TileType.River,1);
			movementCosts.Add(Tile.TileType.Road,1);
			movementCosts.Add(Tile.TileType.Wood,1);
			movementCosts.Add(Tile.TileType.Wasteland,1);
			movementCosts.Add(Tile.TileType.Ruins,1);
			movementCosts.Add(Tile.TileType.Mountain,1);
			movementCosts.Add(Tile.TileType.Beach,1);
			movementCosts.Add(Tile.TileType.Bridge,1);
			movementCosts.Add(Tile.TileType.Sea,1);
			movementCosts.Add(Tile.TileType.Reef,1);
			movementCosts.Add(Tile.TileType.RoughSea,1);
			movementCosts.Add(Tile.TileType.Mist,1);
		}
		
		if(u.getMovementType()==Unit.MovementType.Ship) {
			movementCosts.Add(Tile.TileType.HQ,0);
			movementCosts.Add(Tile.TileType.City,0);
			movementCosts.Add(Tile.TileType.Factory,0);
			movementCosts.Add(Tile.TileType.Airport,0);
			movementCosts.Add(Tile.TileType.Seaport,1);
			movementCosts.Add(Tile.TileType.TempAir,0);
			movementCosts.Add(Tile.TileType.TempSea,1);
			movementCosts.Add(Tile.TileType.Plain,0);
			movementCosts.Add(Tile.TileType.River,0);
			movementCosts.Add(Tile.TileType.Road,0);
			movementCosts.Add(Tile.TileType.Wood,0);
			movementCosts.Add(Tile.TileType.Wasteland,0);
			movementCosts.Add(Tile.TileType.Ruins,0);
			movementCosts.Add(Tile.TileType.Mountain,0);
			movementCosts.Add(Tile.TileType.Beach,0);
			movementCosts.Add(Tile.TileType.Bridge,1);
			movementCosts.Add(Tile.TileType.Sea,1);
			movementCosts.Add(Tile.TileType.Reef,2);
			movementCosts.Add(Tile.TileType.RoughSea,2);
			movementCosts.Add(Tile.TileType.Mist,1);
		}
		
		if(u.getMovementType()==Unit.MovementType.Transport) {
			movementCosts.Add(Tile.TileType.HQ,0);
			movementCosts.Add(Tile.TileType.City,0);
			movementCosts.Add(Tile.TileType.Factory,0);
			movementCosts.Add(Tile.TileType.Airport,0);
			movementCosts.Add(Tile.TileType.Seaport,1);
			movementCosts.Add(Tile.TileType.TempAir,0);
			movementCosts.Add(Tile.TileType.TempSea,1);
			movementCosts.Add(Tile.TileType.Plain,0);
			movementCosts.Add(Tile.TileType.River,0);
			movementCosts.Add(Tile.TileType.Road,0);
			movementCosts.Add(Tile.TileType.Wood,0);
			movementCosts.Add(Tile.TileType.Wasteland,0);
			movementCosts.Add(Tile.TileType.Ruins,0);
			movementCosts.Add(Tile.TileType.Mountain,0);
			movementCosts.Add(Tile.TileType.Beach,1);
			movementCosts.Add(Tile.TileType.Bridge,1);
			movementCosts.Add(Tile.TileType.Sea,1);
			movementCosts.Add(Tile.TileType.Reef,2);
			movementCosts.Add(Tile.TileType.RoughSea,2);
			movementCosts.Add(Tile.TileType.Mist,1);
		}
		
		return movementCosts;
	}
}
