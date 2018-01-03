using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Unit {
	void Awake() {
		health=100;
		attack2 = false;
		level = 0;
		minRange = 3;
		maxRange = 5;
		movement=5;
		ammo = 5;
		cost= 15000;
		fuel=50;
		direct=false;
		hasActed=false;
		mvmtType=MovementType.TireA;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
