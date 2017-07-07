using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour1 {
	private Team[] teams;
	private Map currentMap;
	private int current;
	private int income; //amount of money earned for each building
	private Vector3 mousePos; //current Mouse Position
	private Vector3 lastMousePos;
	private GameObject tileHighlighter;
	private List<GameObject> moveHighlighters;
	
	
	void Awake() {
		teams=GetComponentsInChildren<Team>();
		currentMap=GetComponentInChildren<Map>();
		current=0;
		income = 500;//We'll figure out how to change this in a menu later
		tileHighlighter=GameObject.FindWithTag("HighlighterCube");
	}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition); //finds location of mouse
			if(Input.GetMouseButtonUp(0))
			{
				//Checks what to bring up
				Tile selectedTile = currentMap.findTile((int)mousePos.x,(int)mousePos.y);
				Debug.Log((int)mousePos.x+" "+(int)mousePos.y);
				
			}
		checkNewTile();
		lastMousePos=mousePos;	
	}
	
	bool checkNewTile() {
		
		if(Input.GetKeyDown("a")||Input.GetKeyDown("left"))
		{
			if (tileHighlighter.transform.position.x>0)
				tileHighlighter.transform.position -= new Vector3(1f,0f,0f);
			return true;			
		}
		if(Input.GetKeyDown("w")||Input.GetKeyDown("up"))
		{
			if (tileHighlighter.transform.position.y<currentMap.getMapHeight()-1)
				tileHighlighter.transform.position += new Vector3(0f,1f,0f);
			return true;			
		}
		if(Input.GetKeyDown("d")||Input.GetKeyDown("right"))
		{
			if (tileHighlighter.transform.position.x<currentMap.getMapWidth()-1)
				tileHighlighter.transform.position += new Vector3(1f,0f,0f);
			return true;			
		}
		if(Input.GetKeyDown("s")||Input.GetKeyDown("down"))
		{
			if (tileHighlighter.transform.position.y>0)
				tileHighlighter.transform.position -= new Vector3(0f,1f,0f);
			return true;			
		}
		if(mousePos!=lastMousePos&&((int)mousePos.x!=(int)tileHighlighter.transform.position.x||(int)mousePos.y!=(int)tileHighlighter.transform.position.y)) //ie, mouse and highlighters on different tiles
		{
			if(mousePos.x>=0&&mousePos.x<currentMap.getMapWidth()&&mousePos.y>=0&&mousePos.y<currentMap.getMapHeight())
				tileHighlighter.transform.position = new Vector3((int)mousePos.x*1f,(int)mousePos.y*1f,-15f);
			return true;
		}
		return false;
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
}
