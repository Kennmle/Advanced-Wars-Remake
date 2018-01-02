using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleSystem : MonoBehaviour {

	private static Dictionary<Type, Dictionary<Type, int>> battle;

	// Use this for initialization
	void Start () {
		battle = new Dictionary<Type, Dictionary<Type, int>>();
	}

	// Update is called once per frame
	void Update () {
	}

	public static void attackable(Unit unit1, Unit unit2) {
		if (unit1.GetType().Name == "TestUnit") {
			unit1.getFuel();
		}
	}
	private void dictInit() {
		Dictionary dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),55);
		dict.Add(typeof(Mech),45);
		dict.Add(typeof(Bike),45);
		dict.Add(typeof(Recon),12);
		dict.Add(typeof(Flare),10);
		dict.Add(typeof(AntiAir),3);
		dict.Add(typeof(Tank),5);
		dict.Add(typeof(MediumTank),5);
		dict.Add(typeof(WarTank),1);
		dict.Add(typeof(Artillery),10);
		dict.Add(typeof(AntiTank),30);
		dict.Add(typeof(Rocket),20);
		dict.Add(typeof(Missile),20);
		dict.Add(typeof(Rig),14);
		dict.Add(typeof(Battleship),0);
		dict.Add(typeof(Carrier),0);
		dict.Add(typeof(Submarine),0);
		dict.Add(typeof(Cruiser),0);
		dict.Add(typeof(GunBoat),0);
		dict.Add(typeof(Lander),0);
		dict.Add(typeof(Duster),0);
		dict.Add(typeof(Bomber),0);
		dict.Add(typeof(Fighter),0);
		dict.Add(typeof(BCopter),8);
		dict.Add(typeof(TCopter),30);
		dict.Add(typeof(SeaPlane),0);
		battle.Add(typeof(Infantry),dict);

		dict = new Dictionary<Type, int>();
		dict.Add(typeof(Infantry),65);
		dict.Add(typeof(Mech),55);
		dict.Add(typeof(Bike),55);
		dict.Add(typeof(Recon),85);
		dict.Add(typeof(Flare),80);
		dict.Add(typeof(AntiAir),55);
		dict.Add(typeof(Tank),55);
		dict.Add(typeof(MediumTank),25);
		dict.Add(typeof(WarTank),15);
		dict.Add(typeof(Artillery),70);
		dict.Add(typeof(AntiTank),55);
		dict.Add(typeof(Rocket),85);
		dict.Add(typeof(Missile),85);
		dict.Add(typeof(Rig),75);
		dict.Add(typeof(Battleship),0);
		dict.Add(typeof(Carrier),0);
		dict.Add(typeof(Submarine),0);
		dict.Add(typeof(Cruiser),0);
		dict.Add(typeof(GunBoat),0);
		dict.Add(typeof(Lander),0);
		dict.Add(typeof(Duster),0);
		dict.Add(typeof(Bomber),0);
		dict.Add(typeof(Fighter),0);
		dict.Add(typeof(BCopter),12);
		dict.Add(typeof(TCopter),35);
		dict.Add(typeof(SeaPlane),0);
		battle.Add(typeof(Mech),dict);
	}
}
