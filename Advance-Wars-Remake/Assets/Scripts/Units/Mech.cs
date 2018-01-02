using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : Unit {
	void Awake() {
		health=100;
		attack2 = true;
		level = 0;
		minRange = 1;
		maxRange = 1;
		movement=2;
		ammo = 3;
		cost= 3000;
		fuel=70;
		direct=true;
		hasActed=false;
		mvmtType=MovementType.Mech;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
