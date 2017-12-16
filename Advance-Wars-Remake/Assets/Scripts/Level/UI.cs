using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UI : MonoBehaviour {
	private static Vector3 mousePos; //current Mouse Position
	private static Vector3 lastMousePos;
	private static GameObject tileHighlighter;
	private static Vector3 hlPos; //highlighter Position
	private static List<GameObject> moveHighlighters;
	private static GameObject sampleMoveHL;
	private static Vector3 tempPos; //used in update()
	private static Material blue;
	private static Material green;
	private static Material red;

	void Awake() {
		tileHighlighter=GameObject.FindWithTag("HighlighterCube");
		if(tileHighlighter==null) {
			Debug.Log("Uh Oh Spagetti-Ohs!");
			while(true)
				tileHighlighter=null;
		}
		sampleMoveHL=GameObject.FindWithTag("MovementHighlighter");
		blue=sampleMoveHL.GetComponent<Renderer>().material;
		green = GameObject.Instantiate(blue);
		red = GameObject.Instantiate(blue);
		blue.color = new Color(0f,0f,2f,.1f);
		green.color = new Color(0f,2f,0f,.1f);
		red.color = new Color(7f,0f,0f,.1f);

	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public static void updateHighlight(int width, int height) {
		hlPos=tileHighlighter.transform.position;
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition); //finds location of mouse
		tempPos=hlPos;

		if(Game.left())
			tempPos -= new Vector3(1f,0f,0f);
		if(Game.up())
			tempPos += new Vector3(0f,1f,0f);
		if(Game.right())
			tempPos += new Vector3(1f,0f,0f);
		if(Game.down())
			tempPos -= new Vector3(0f,1f,0f);
		if(mousePos!=lastMousePos&&((int)mousePos.x!=(int)tileHighlighter.transform.position.x||(int)mousePos.y!=(int)tileHighlighter.transform.position.y)) //ie, mouse and highlighters on different tiles
		{
			tempPos = new Vector3((int)mousePos.x*1f,(int)mousePos.y*1f,0f);
		}

		if(tempPos.x<0)
			tempPos.x=0;
		if(tempPos.x>=width)
			tempPos.x=width-1;
		if(tempPos.y<0)
			tempPos.y=0;
		if(tempPos.y>=height)
			tempPos.y=height-1;

		tileHighlighter.transform.position=tempPos;
	}
	public static void updateMousePos() {
		lastMousePos=mousePos;
	}

	public static void highlightMoves(List<Tile> moves) {
		Vector3 offset=new Vector3 (0f,0f,sampleMoveHL.transform.position.z); //As of writing, this is -10
		moveHighlighters=new List<GameObject>();
		foreach(Tile t in moves) {
			GameObject o = Instantiate(sampleMoveHL,t.transform.position+offset,Quaternion.identity);
			moveHighlighters.Add(o);
		}
	}

	public static void highlightPath(List<int> path) {
		for(int i = 0; i<moveHighlighters.Count;i++) {
			if(path.Contains(i))
				moveHighlighters[i].GetComponent<Renderer>().material=green;
			else
				moveHighlighters[i].GetComponent<Renderer>().material=blue;
		}
	}

	public static void dehighlightMoves() {
		if(moveHighlighters!=null)
			foreach(GameObject o in moveHighlighters) {
				Destroy(o);
			}
	}

	public static void debug(char x, Map m) {
		switch(x) {
			case('A'):
				Debug.Log((int)hlPos.x+" "+(int)hlPos.y);
				//TESTING highlighters
				/*
				if((int)hlPos.x==1&&(int)hlPos.y==1)
					testHighlightMoves(m);
				if((int)hlPos.x==2&&(int)hlPos.y==2)
					testHighlightPath(0);
				if((int)hlPos.x==3&&(int)hlPos.y==3)
					testHighlightPath(1);
					*/
				break;
			case('B'):
				Debug.Log("Press B when nothing selected");
				break;
		}
	}

	public static int x() {
		return (int)hlPos.x;
	}

	public static int y() {
		return (int)hlPos.y;
	}

	//Testing methods
	public static void testHighlightMoves(Map m) {
	List<Tile> ret=new List<Tile>();
		for(int i =0; i<3; i++)
			for(int j=0; j<3; j++)
				ret.Add(m.findTile(i,j));
		dehighlightMoves();
		highlightMoves(ret);
	}

	public static void print(string s) {
			Debug.Log(s);
	}

	private static void testHighlightPath(int x) {
	List<int> ret=new List<int>();
		for(int i =0; i<4; i++)
				ret.Add(i);
				switch(x) {
					case(0):
					highlightPath(ret);
					break;
					case(1):
					highlightRed(ret);
					break;
				}
	}

	private static void highlightRed(List<int> x) {
		Material temp = GameObject.Instantiate(green);
		green=red;
		highlightPath(x);
		green=temp;
	}
}
