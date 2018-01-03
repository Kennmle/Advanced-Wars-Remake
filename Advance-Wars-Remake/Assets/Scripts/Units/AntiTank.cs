using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiTank : Unit {
	void Awake() {
		health=100;
		attack2 = false;
		level = 0;
		minRange = 1;
		maxRange = 3;
		movement=4;
		ammo = 6;
		cost= 11000;
		fuel=50;
		direct=false;
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
