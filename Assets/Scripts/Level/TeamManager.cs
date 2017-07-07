using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour1 {
	private Team[] teams;
	private Map currentMap;
	private int current;
	private int income; //amount of money earned for each building
	void Awake() {
		teams=GetComponentsInChildren<Team>();
		currentMap=GetComponentInChildren<Map>();
		current=0;
		income = 500;//We'll figure out how to change this in a menu later
	}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
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
