﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    private int health; //go to hellth
    private int movement; //you best move your ass out of the way
    private int ammo; //I'll use this ammo to bust your cap
    private int cost; //This is gonna cost you pal
    private int attack1; //Attack on titan gives me cancer
    private int attack2;
    private int defense; //Dee-fuck you
    private int fuel; //You have too much gas
    private int range; //y: (0, 6) U (7, 90]
	private bool hasActed; //reflects whether the unit has acted (movcd and/or attacked+) this turn. To be reset each turn
	//WHO THE FUCK????
	
	private MovementType mvmtType;
	private WeaponType atkType;
	
	void Awake()
	{
		
	}
	
    // Use this for initialization
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setHealth(int x)
    {
        health = x;
    }
    public int getHealth()
    {
        return health;
    }
    public void setMove(int x)
    {
        movement = x;
    }
    public int getMovement()
    {
        return movement;
    }
    public void setAmmo(int x)
    {
        ammo = x;
    }
    public int getAmmo()
    {
        return ammo;
    }
    public void setCost(int x)
    {
       cost = x;
    }
    public int getCost()
    {
        return cost;
    }
    public void setAttack1(int x)
    {
        attack1 = x;
    }
    public int getAttack1()
    {
        return attack1;
    }
    public void setAttack2(int x)
    {
        attack2 = x;
    }
    public int getAttack2()
    {
        return attack2;
    }
    public void setDefense(int x)
    {
        defense = x;
    }
    public int getDefense()
    {
        return defense;
    }
    public void setFuel(int x)
    {
        fuel = x;
    }
    public int getFuel()
    {
        return fuel;
    }
    public void setRange(int x)
    {
        range = x;
    }
    public int getRange()
    {
        return range;
    }

	public bool acted()
	{
		return hasActed;
	}
	
	public void setActed(bool x) {
		hasActed=x;
	}
	
	public Unit.MovementType getMovementType() {
		return mvmtType;
	}
	
	public void setMovementType(Unit.MovementType x) {
		mvmtType=x;
	}
	
	public Unit.WeaponType getWeaponType() {
		return atkType;
	}
	
	public void setWeaponType(Unit.WeaponType x) {
		atkType=x;
	}
	
    public abstract void move();

    public abstract void damage();
	
	
	public enum MovementType {
		Infantry, Mech, TireA, TireB, Tank,
		Air, Ship, Transport,
	}
	
	public enum WeaponType {
		Infantry, Vehicle,
		Air, Helicopter,
		Ship, Submarine,
	}
}