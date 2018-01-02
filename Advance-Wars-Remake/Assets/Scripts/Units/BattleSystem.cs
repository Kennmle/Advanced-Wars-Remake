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
	private void dictInfantry() {
		Dictionary<Type, int> dict = new Dictionary<Type, int>();
		dict.Add(typeof(TestUnit), 69);
	}
}
