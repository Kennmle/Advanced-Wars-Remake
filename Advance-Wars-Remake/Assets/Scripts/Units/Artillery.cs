using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artillery : Unit {
	void Awake() {
		health=100;
		attack2 = false;
		level = 0;
		minRange = 2;
		maxRange = 3;
		movement=5;
		ammo = 6;
		cost= 6000;
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
