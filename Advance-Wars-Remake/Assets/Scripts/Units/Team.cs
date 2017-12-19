using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team {
	private UnitVector units;
	//private List<Building> buildings;
	private Commander co;
	private int coBar;
	private int funds; //Bank (income is handled in TeamManager)

	public Team(Commander co) {
		units = new UnitVector();
		this.co=co;
		coBar=0;
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

	void addUnitsToList (UnitVector l1,Unit[] l2)
	{
		foreach(Unit o in l2)
		{
			l1.add(o);
		}
	}

	void addBuildingsToList (List<Building> l1,Building[] l2)
	{
		foreach(Building o in l2)
		{
			l1.Add(o);
		}
	}
	*/

	public Unit generateTestTeam(GameObject x) {
		GameObject temp = GameObject.Instantiate(x);
		//TestUnit tempU = new TestUnit();
		temp.AddComponent<TestUnit>();
		temp.transform.position += new Vector3(1f,1f,0f);
		units.add(temp.GetComponent<TestUnit>());
		return temp.GetComponent<TestUnit>();
	}
}
