using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map : MonoBehaviour {

	/**Fields**/
	Tile[] tempTiles;
	Tile[,] tiles;
	public Material grassMat;
	public Material waterMat;

	void Awake() {
		tempTiles = this.GetComponentsInChildren<Tile>();
	}
	// Use this for initialization
	void Start () {
		tiles=createMap(tempTiles); //createMap() is defined at the bottom.
	}

	// Update is called once per frame
	void Update () {

	}

	public int getMapWidth() {
		return tiles.GetLength(0);
	}

	public int getMapHeight() {
		return tiles.GetLength(1);
	}

	public Unit findUnit(int x, int y) {
		return tiles[x,y].getUnit();
	}

	public Tile findTile(Unit x) {
		foreach (Tile t in tiles)
			if(t.getUnit()==x)
				return t;
		return null;
	}

	public Tile findTile(int x, int y)
	{
		return tiles[x,y];
	}

	/** Uses 1d array of tiles to create the 2d array. Used in Start() **/
	Tile[,] createMap(Tile[] temp) {

		int x=0;
		int y=0;

		foreach(Tile t in temp) {
			x=Math.Max(x,t.getX());
			y=Math.Max(y,t.getY());
		}

		Tile[,] tileArray= new Tile[x+1,y+1];


		foreach(Tile t in temp) {
			tileArray[t.getX(),t.getY()]=t;
			//Determines TileType

			Material tileMat = t.GetComponent<Renderer>().material;
			if(tileMat==grassMat)
			{
				t.setType(Tile.TileType.Plain);
			}
			if(tileMat==waterMat)
			{
				t.setType(Tile.TileType.Sea);
			}
			//It is important that contaiendBuilding is last, as to overwrite grass/what's underneath (regardless of material)
			if(t.getBuilding())
			{
				t.setType(Tile.TileType.City);
			}
		}

		return tileArray;
	}

	public double distance(Tile a, Tile b) {
		return Math.Sqrt( //It is faster to just multiply instead of using Math.pow
			(a.getX()-b.getX())*(a.getX()-b.getX()) +
			(a.getY()-b.getY())*(a.getY()-b.getY())
			);
	}
}
