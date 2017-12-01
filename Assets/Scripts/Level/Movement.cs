using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour {
	//class is static, will be used by game.cs
	private static List<Tile> moveList;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public static void debugMoveList() {
		Debug.Log("Current list size is"+moveList.Count); //JFC why is this a public field? I know it is read-only, but still
	}
	public static void addPossibleMoves(Tile currentTile, Dictionary<Tile.TileType, int> d, int moves, Map currentMap, Team current) {
		moveList.Add(currentTile);
		if(currentTile.getX()>0&&d[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()]<moves&&d[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()]>0) //check if leftmost
			if(!currentMap.findTile(currentTile.getX()-1,currentTile.getY()).containsUnit()||!current.contains(currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getUnit()))
				addPossibleMoves(currentMap.findTile(currentTile.getX()-1,currentTile.getY()),d,moves-d[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()], currentMap, current);
		if(currentTile.getX()<currentMap.getMapWidth()-1&&d[currentMap.findTile(currentTile.getX()+1,currentTile.getY()).getType()]<moves&&d[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()]>0) //check rightmost
			if(currentMap.findTile(currentTile.getX()+1,currentTile.getY()).containsUnit()||!current.contains(currentMap.findTile(currentTile.getX()+1,currentTile.getY()).getUnit()))
				addPossibleMoves(currentMap.findTile(currentTile.getX()+1,currentTile.getY()),d,moves-d[currentMap.findTile(currentTile.getX()+1,currentTile.getY()).getType()], currentMap, current);
		if(currentTile.getY()>0&&d[currentMap.findTile(currentTile.getX(),currentTile.getY()-1).getType()]<moves&&d[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()]>0) //check if bottom
			if(currentMap.findTile(currentTile.getX(),currentTile.getY()-1).containsUnit()||!current.contains(currentMap.findTile(currentTile.getX(),currentTile.getY()-1).getUnit()))
				addPossibleMoves(currentMap.findTile(currentTile.getX(),currentTile.getY()-1),d,moves-d[currentMap.findTile(currentTile.getX(),currentTile.getY()-1).getType()], currentMap, current);
		if(currentTile.getY()<currentMap.getMapHeight()-1&&d[currentMap.findTile(currentTile.getX()+1,currentTile.getY()).getType()]<moves&&d[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()]>0) //check top
			if(currentMap.findTile(currentTile.getX(),currentTile.getY()+1).containsUnit()||!current.contains(currentMap.findTile(currentTile.getX(),currentTile.getY()+1).getUnit()))
				addPossibleMoves(currentMap.findTile(currentTile.getX(),currentTile.getY()+1),d,moves-d[currentMap.findTile(currentTile.getX(),currentTile.getY()+1).getType()], currentMap, current);
	}
	
	public static void highlight() {
		UI.highlightMoves(moveList);
	}
	
	public static void dehighlight() {
		moveList.Clear();
		UI.dehighlightMoves();
	}
	
	public static Dictionary<Tile.TileType, int> setCurrentMovement(Unit u) {
		Dictionary<Tile.TileType, int> movementCosts=new Dictionary<Tile.TileType, int>();
		
		switch(u.getMovementType()) {
			case(Unit.MovementType.Infantry):
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
				break;
		
		
			case(Unit.MovementType.Mech):
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
				break;
		
			case(Unit.MovementType.TireA):
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
				break;
			
			case(Unit.MovementType.TireB):
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
				break;
			
			case(Unit.MovementType.Tank):
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
				break;
			
			case(Unit.MovementType.Air):
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
				break;
					
			case(Unit.MovementType.Ship):
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
				break;
			
			case(Unit.MovementType.Transport):
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
				break;
		}
		return movementCosts;
	}
}
