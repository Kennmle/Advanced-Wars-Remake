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
	
	void Awake() {
		tileHighlighter=GameObject.FindWithTag("HighlighterCube");
		sampleMoveHL=GameObject.FindWithTag("MovementHighlighter");
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
		foreach(Tile t in moves) {
			GameObject o = Instantiate(sampleMoveHL,t.transform.position+offset,Quaternion.identity);			
			moveHighlighters.Add(o);
		}
	}
	
	public static void dehighlightMoves() {
		foreach(GameObject o in moveHighlighters) {
			Destroy(o);
		}
	}
	
	public static void debug(char x) {
		switch(x) {
			case('A'):
				Debug.Log((int)hlPos.x+" "+(int)hlPos.y);
				break;
		}
	}
	
	public static int x() {
		return (int)hlPos.x;
	}
	
	public static int y() {
		return (int)hlPos.y;
	}
}
