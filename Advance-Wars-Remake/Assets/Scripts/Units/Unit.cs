using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Unit : MonoBehaviour {
    protected int health; //go to hellth
    protected int movement; //you best move your ass out of the way
    protected int ammo; //I'll use this ammo to bust your cap
    protected int cost; //This is gonna cost you pal
    protected int attack1; //Attack on titan gives me cancer
    protected int attack2;
    protected int defense; //Dee-fuck you
    protected int fuel; //You have too much gas
    protected int range; //y: (0, 6) U (7, 90]
    protected bool direct; //Defines whether the unit is a direct or indirect attacker
    protected bool hasActed; //reflects whether the unit has acted (movcd and/or attacked+) this turn. To be reset each turn
	//WHO THE FUCK????

	protected MovementType mvmtType;
	protected WeaponType atkType;

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
    public void setMovement(int x)
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
    public bool isDirect() {
      return direct;
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
  public int getMoves()
  {
      return Math.Min(movement,fuel);
  }

    public void move(List<Tile> path) {
      Vector3 offset;
      Vector3 startingPos;
      float scalar=0.000005f;
      for(int i = 1; i<path.Count; i++) {
        offset = new Vector3(path[i].gameObject.transform.position.x-path[i-1].gameObject.transform.position.x,path[i].gameObject.transform.position.y-path[i-1].gameObject.transform.position.y,0f);
        startingPos = new Vector3(path[i-1].gameObject.transform.position.x,path[i-1].gameObject.transform.position.y,this.gameObject.transform.position.z);
        for(float j = 0; j<=1; j+=scalar) {
          this.gameObject.transform.position=startingPos+offset*j;
        }
      }
      path[0].setUnit(null);
      path[path.Count-1].setUnit(this);
    }

    public void damage(int d) {
      this.health-=d;
      //Let Battle System take care of whether this unit is dead
    }


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
