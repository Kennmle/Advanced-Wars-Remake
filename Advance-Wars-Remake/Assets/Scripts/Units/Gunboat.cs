using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBoat : Unit {
	void Awake() {
		health=100;
		attack2 = false;
		level = 0;
		minRange = 1;
		maxRange = 1;
		movement=7;
		ammo = 1;
		cost= 6000;
		fuel=99;
		direct=true;
		hasActed=false;
		mvmtType=MovementType.Transport;
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
