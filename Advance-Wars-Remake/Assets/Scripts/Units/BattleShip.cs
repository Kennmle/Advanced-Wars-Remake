using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battleship : Unit {
	void Awake() {
		health=100;
		attack2 = false;
		level = 0;
		minRange = 1;
		maxRange = 5;
		movement=5;
		ammo = 6;
		cost= 25000;
		fuel=99;
		direct=false;
		hasActed=false;
		mvmtType=MovementType.Ship;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
