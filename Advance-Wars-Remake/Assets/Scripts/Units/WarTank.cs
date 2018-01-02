using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarTank : Unit {
	void Awake() {
		health=100;
		attack2 = true;
		level = 0;
		minRange = 1;
		maxRange = 1;
		movement=4;
		ammo = 5;
		cost= 7000;
		fuel=50;
		direct=true;
		hasActed=false;
		mvmtType=MovementType.Tank;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
