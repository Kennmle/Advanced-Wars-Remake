using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map : MonoBehaviour1 {

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
	
	public Tile getTile(int x, int y)
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
			t.DetermineTileType();
		}
		
		return tileArray;
	}
}
