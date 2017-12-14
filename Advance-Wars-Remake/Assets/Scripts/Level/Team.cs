using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour {
	private UnitVector units;
	//private List<Building> buildings;
	private Commander co;
	private int funds; //Bank (income is handled in TeamManager)
	
	void Awake () {
		units = new UnitVector();
		//addUnitsToList(units,GetComponentsInChildren<Unit>()); Used for preset units
		//buildings = new List<Building>();
		//addBuildingsToList(buildings,GetComponentsInChildren<Building>());
		co=GetComponentInChildren<Commander>();
		//Note: Work is currently halted. Do we want commander class to control all else (ie, function as a class to control the entire team)
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*
	public UnitVector getUnits() {
		return units;
	}
	
	public List<Building> getBuildings() {
		return buildings;
	}
	*/
	public bool contains(Unit u) {
		return units.contains(u);
	}
	/*
	public bool contains(Building b) {
		return buildings.Contains(b);
	}
	
	public int getFunds()
	{
		return funds;
	}
	*/
	public void addFunds(int x) {
		funds+=x;
	}
	/*
	public void decreaseFunds(int x) {
		funds-=x;
	}
	
	public bool canPurchase(int x) {
		return funds>x;
	}
	*/
	void addUnitsToList (UnitVector l1,Unit[] l2)
	{
		foreach(Unit o in l2)
		{
			l1.add(o);
		}
	}
	/*
	void addBuildingsToList (List<Building> l1,Building[] l2)
	{
		foreach(Building o in l2)
		{
			l1.Add(o);
		}
	}
	*/
}
