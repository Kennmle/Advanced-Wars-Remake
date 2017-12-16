using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUnit : Unit {

	void Awake() {
		health=100;
		movement=5;
		ammo=5;
		cost=0;
		attack1=10;
		attack2=5;
		defense=1;
		fuel=12;
		range=2;
		direct=true;
		hasActed=false;
		mvmtType=MovementType.Infantry;
		atkType=WeaponType.Infantry;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
