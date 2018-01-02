using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : Unit {
	void Awake() {
		health=100;
		attack2 = false;
		level = 0;
		minRange = 1;
		maxRange = 1;
		movement=5;
		ammo = 999;
		cost= 2500;
		fuel=70;
		direct=true;
		hasActed=false;
		mvmtType=MovementType.TireB;
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
