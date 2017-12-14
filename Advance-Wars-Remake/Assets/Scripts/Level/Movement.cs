using System.Collections;
using System.Collections.Generic;
using System;

public class Movement{
	//class is static, will be used by game.cs
	private static List<Tile> moveList;
	private static Unit currentUnit;
	private static Path currentPath;
	private static Dictionary<Tile.TileType, int> movementCosts;

	public static void updatePath(Tile t, Map m) {
			if(moveList.Contains(t)) {
				bool inside=false;
				for(int i = 0; i<currentPath.length(); ++i)
					if(t==currentPath.at(i).getValue()) {
						currentPath=currentPath.getUpTo(i);
						inside=true;
					}
				if(!inside) {
					if(UserMath.About(m.distance(t,currentPath.at(currentPath.length()-1).getValue()),1)&&currentPath.getCost()+movementCosts[t.getType()]<currentUnit.getMovement())
						currentPath.insertTail(t,movementCosts[t.getType()]);
					else {
					/*
						try generating shortest path using a variation of Dijkstra's algorithm
						if such a path doesn't exist, try it for the 2nd most recent
							(base will work since t is in movelist)
							Notes: break as soon as the node is found (1 pair),
							we can't really afford athe full runtime (I think)
					*/
						Path newPath,oldPath;
						for(int i = currentPath.length()-1; i>=0 ;++i) {
							//Note that since t is in moveList, that currentPath will be set at some point
							oldPath=currentPath.getUpTo(i);
							newPath = shortestPath(currentPath.at(i).getValue(),t);
							if(newPath.getCost()+oldPath.getCost()<=currentUnit.getMovement()) {
								currentPath=oldPath.merge(newPath);
								i=-1; //equivalent to break;
							}
						}
					}
				}
				//UI.updatePath(currentPath.getTiles());
			}
	}

	private static Path shortestPath(Tile a, Tile b) {
		//To impelement; high runtimes might result in reworking this algorithm
		return null;
	}

	public static void debugMoveList() {
		//Debug.Log("Current list size is"+moveList.Count); //JFC why is this a public field? I know it is read-only, but still
	}

	public static void addPossibleMoves(Tile currentTile, Unit u, Map currentMap, Team current) {
		setCurrentMovement(u);
		currentUnit = u;
		addPossibleMoves(currentTile, u.getMovement(), currentMap, current);
		UI.highlightMoves(moveList);
	}

	private static void addPossibleMoves(Tile currentTile, int moves, Map currentMap, Team current) {
		moveList.Add(currentTile);
		if(currentTile.getX()>0&&movementCosts[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()]<moves&&movementCosts[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()]>0) //check if leftmost
			if(!currentMap.findTile(currentTile.getX()-1,currentTile.getY()).containsUnit()||!current.contains(currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getUnit()))
				addPossibleMoves(currentMap.findTile(currentTile.getX()-1,currentTile.getY()),moves-movementCosts[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()], currentMap, current);
		if(currentTile.getX()<currentMap.getMapWidth()-1&&movementCosts[currentMap.findTile(currentTile.getX()+1,currentTile.getY()).getType()]<moves&&movementCosts[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()]>0) //check rightmost
			if(currentMap.findTile(currentTile.getX()+1,currentTile.getY()).containsUnit()||!current.contains(currentMap.findTile(currentTile.getX()+1,currentTile.getY()).getUnit()))
				addPossibleMoves(currentMap.findTile(currentTile.getX()+1,currentTile.getY()),moves-movementCosts[currentMap.findTile(currentTile.getX()+1,currentTile.getY()).getType()], currentMap, current);
		if(currentTile.getY()>0&&movementCosts[currentMap.findTile(currentTile.getX(),currentTile.getY()-1).getType()]<moves&&movementCosts[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()]>0) //check if bottom
			if(currentMap.findTile(currentTile.getX(),currentTile.getY()-1).containsUnit()||!current.contains(currentMap.findTile(currentTile.getX(),currentTile.getY()-1).getUnit()))
				addPossibleMoves(currentMap.findTile(currentTile.getX(),currentTile.getY()-1),moves-movementCosts[currentMap.findTile(currentTile.getX(),currentTile.getY()-1).getType()], currentMap, current);
		if(currentTile.getY()<currentMap.getMapHeight()-1&&movementCosts[currentMap.findTile(currentTile.getX()+1,currentTile.getY()).getType()]<moves&&movementCosts[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()]>0) //check top
			if(currentMap.findTile(currentTile.getX(),currentTile.getY()+1).containsUnit()||!current.contains(currentMap.findTile(currentTile.getX(),currentTile.getY()+1).getUnit()))
				addPossibleMoves(currentMap.findTile(currentTile.getX(),currentTile.getY()+1),moves-movementCosts[currentMap.findTile(currentTile.getX(),currentTile.getY()+1).getType()], currentMap, current);
	}

	public static void dehighlight() {
		moveList.Clear();
		UI.dehighlightMoves();
	}

	private static void setCurrentMovement(Unit u) {
		movementCosts=new Dictionary<Tile.TileType, int>();
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
	}
}
