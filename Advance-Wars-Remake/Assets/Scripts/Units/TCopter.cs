using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCopter : Unit {
	void Awake() {
		health=100;
		attack2 = false;
		level = 0;
		minRange = 1;
		maxRange = 1;
		movement=6;
		ammo = 0;
		cost= 5000;
		fuel=99;
		direct=true;
		hasActed=false;
		mvmtType=MovementType.Air;
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
