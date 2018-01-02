using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recon : Unit {
	void Awake() {
		health=100;
		attack2 = false;
		level = 0;
		minRange = 1;
		maxRange = 1;
		movement=8;
		ammo = 999;
		cost= 4000;
		fuel=80;
		direct=true;
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
