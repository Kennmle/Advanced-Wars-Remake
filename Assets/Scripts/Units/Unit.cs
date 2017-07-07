using System.Collections;
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
	//WHO THE FUCK????
	
	
	private Dictionary<Tile.TileType, int> movementCosts; //To be defined by each movement type
	private MovementType mvntType;
	private WeaponType atkType;
	
	void Awake()
	{
		movementCosts=new Dictionary<Tile.TileType, int>();
		this.setMovementCosts();
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

    public abstract void move();

    public abstract void damage();
	
	void setMovementCosts() {
	//Note: This is slightly crude, can be simplified depending on classes created for units.
		if(mvntType==Unit.MovementType.Infantry) {
			movementCosts.Add(Tile.TileType.HQ,1);
			movementCosts.Add(Tile.TileType.City,1);
			movementCosts.Add(Tile.TileType.Factory,1);
			movementCosts.Add(Tile.TileType.Airport,1);
			movementCosts.Add(Tile.TileType.Seaport,1);
			movementCosts.Add(Tile.TileType.TempAir,1);
			movementCosts.Add(Tile.TileType.TempSea,1);
			movementCosts.Add(Tile.TileType.Plain,1);
			movementCosts.Add(Tile.TileType.River,2);
			movementCosts.Add(Tile.TileType.Road,1);
			movementCosts.Add(Tile.TileType.Wood,1);
			movementCosts.Add(Tile.TileType.Wasteland,1);
			movementCosts.Add(Tile.TileType.Ruins,1);
			movementCosts.Add(Tile.TileType.Mountain,2);
			movementCosts.Add(Tile.TileType.Beach,1);
			movementCosts.Add(Tile.TileType.Bridge,1);
			movementCosts.Add(Tile.TileType.Sea,0);
			movementCosts.Add(Tile.TileType.Reef,0);
			movementCosts.Add(Tile.TileType.RoughSea,0);
			movementCosts.Add(Tile.TileType.Mist,0);
		}
		
		if(mvntType==Unit.MovementType.Mech) {
			movementCosts.Add(Tile.TileType.HQ,1);
			movementCosts.Add(Tile.TileType.City,1);
			movementCosts.Add(Tile.TileType.Factory,1);
			movementCosts.Add(Tile.TileType.Airport,1);
			movementCosts.Add(Tile.TileType.Seaport,1);
			movementCosts.Add(Tile.TileType.TempAir,1);
			movementCosts.Add(Tile.TileType.TempSea,1);
			movementCosts.Add(Tile.TileType.Plain,1);
			movementCosts.Add(Tile.TileType.River,1);
			movementCosts.Add(Tile.TileType.Road,1);
			movementCosts.Add(Tile.TileType.Wood,1);
			movementCosts.Add(Tile.TileType.Wasteland,1);
			movementCosts.Add(Tile.TileType.Ruins,1);
			movementCosts.Add(Tile.TileType.Mountain,1);
			movementCosts.Add(Tile.TileType.Beach,1);
			movementCosts.Add(Tile.TileType.Bridge,1);
			movementCosts.Add(Tile.TileType.Sea,0);
			movementCosts.Add(Tile.TileType.Reef,0);
			movementCosts.Add(Tile.TileType.RoughSea,0);
			movementCosts.Add(Tile.TileType.Mist,0);
		}
		
		if(mvntType==Unit.MovementType.TireA) {
			movementCosts.Add(Tile.TileType.HQ,1);
			movementCosts.Add(Tile.TileType.City,1);
			movementCosts.Add(Tile.TileType.Factory,1);
			movementCosts.Add(Tile.TileType.Airport,1);
			movementCosts.Add(Tile.TileType.Seaport,1);
			movementCosts.Add(Tile.TileType.TempAir,1);
			movementCosts.Add(Tile.TileType.TempSea,1);
			movementCosts.Add(Tile.TileType.Plain,2);
			movementCosts.Add(Tile.TileType.River,0);
			movementCosts.Add(Tile.TileType.Road,1);
			movementCosts.Add(Tile.TileType.Wood,3);
			movementCosts.Add(Tile.TileType.Wasteland,3);
			movementCosts.Add(Tile.TileType.Ruins,2);
			movementCosts.Add(Tile.TileType.Mountain,0);
			movementCosts.Add(Tile.TileType.Beach,2);
			movementCosts.Add(Tile.TileType.Bridge,1);
			movementCosts.Add(Tile.TileType.Sea,0);
			movementCosts.Add(Tile.TileType.Reef,0);
			movementCosts.Add(Tile.TileType.RoughSea,0);
			movementCosts.Add(Tile.TileType.Mist,0);
		}
		
		if(mvntType==Unit.MovementType.TireB) {
			movementCosts.Add(Tile.TileType.HQ,1);
			movementCosts.Add(Tile.TileType.City,1);
			movementCosts.Add(Tile.TileType.Factory,1);
			movementCosts.Add(Tile.TileType.Airport,1);
			movementCosts.Add(Tile.TileType.Seaport,1);
			movementCosts.Add(Tile.TileType.TempAir,1);
			movementCosts.Add(Tile.TileType.TempSea,1);
			movementCosts.Add(Tile.TileType.Plain,1);
			movementCosts.Add(Tile.TileType.River,0);
			movementCosts.Add(Tile.TileType.Road,1);
			movementCosts.Add(Tile.TileType.Wood,3);
			movementCosts.Add(Tile.TileType.Wasteland,3);
			movementCosts.Add(Tile.TileType.Ruins,1);
			movementCosts.Add(Tile.TileType.Mountain,0);
			movementCosts.Add(Tile.TileType.Beach,2);
			movementCosts.Add(Tile.TileType.Bridge,1);
			movementCosts.Add(Tile.TileType.Sea,0);
			movementCosts.Add(Tile.TileType.Reef,0);
			movementCosts.Add(Tile.TileType.RoughSea,0);
			movementCosts.Add(Tile.TileType.Mist,0);
		}
		
		if(mvntType==Unit.MovementType.Tank) {
			movementCosts.Add(Tile.TileType.HQ,1);
			movementCosts.Add(Tile.TileType.City,1);
			movementCosts.Add(Tile.TileType.Factory,1);
			movementCosts.Add(Tile.TileType.Airport,1);
			movementCosts.Add(Tile.TileType.Seaport,1);
			movementCosts.Add(Tile.TileType.TempAir,1);
			movementCosts.Add(Tile.TileType.TempSea,1);
			movementCosts.Add(Tile.TileType.Plain,1);
			movementCosts.Add(Tile.TileType.River,0);
			movementCosts.Add(Tile.TileType.Road,1);
			movementCosts.Add(Tile.TileType.Wood,2);
			movementCosts.Add(Tile.TileType.Wasteland,2);
			movementCosts.Add(Tile.TileType.Ruins,1);
			movementCosts.Add(Tile.TileType.Mountain,0);
			movementCosts.Add(Tile.TileType.Beach,1);
			movementCosts.Add(Tile.TileType.Bridge,1);
			movementCosts.Add(Tile.TileType.Sea,0);
			movementCosts.Add(Tile.TileType.Reef,0);
			movementCosts.Add(Tile.TileType.RoughSea,0);
			movementCosts.Add(Tile.TileType.Mist,0);
		}
		
		if(mvntType==Unit.MovementType.Air) {
			movementCosts.Add(Tile.TileType.HQ,1);
			movementCosts.Add(Tile.TileType.City,1);
			movementCosts.Add(Tile.TileType.Factory,1);
			movementCosts.Add(Tile.TileType.Airport,1);
			movementCosts.Add(Tile.TileType.Seaport,1);
			movementCosts.Add(Tile.TileType.TempAir,1);
			movementCosts.Add(Tile.TileType.TempSea,1);
			movementCosts.Add(Tile.TileType.Plain,1);
			movementCosts.Add(Tile.TileType.River,1);
			movementCosts.Add(Tile.TileType.Road,1);
			movementCosts.Add(Tile.TileType.Wood,1);
			movementCosts.Add(Tile.TileType.Wasteland,1);
			movementCosts.Add(Tile.TileType.Ruins,1);
			movementCosts.Add(Tile.TileType.Mountain,1);
			movementCosts.Add(Tile.TileType.Beach,1);
			movementCosts.Add(Tile.TileType.Bridge,1);
			movementCosts.Add(Tile.TileType.Sea,1);
			movementCosts.Add(Tile.TileType.Reef,1);
			movementCosts.Add(Tile.TileType.RoughSea,1);
			movementCosts.Add(Tile.TileType.Mist,1);
		}
		
		if(mvntType==Unit.MovementType.Ship) {
			movementCosts.Add(Tile.TileType.HQ,0);
			movementCosts.Add(Tile.TileType.City,0);
			movementCosts.Add(Tile.TileType.Factory,0);
			movementCosts.Add(Tile.TileType.Airport,0);
			movementCosts.Add(Tile.TileType.Seaport,1);
			movementCosts.Add(Tile.TileType.TempAir,0);
			movementCosts.Add(Tile.TileType.TempSea,1);
			movementCosts.Add(Tile.TileType.Plain,0);
			movementCosts.Add(Tile.TileType.River,0);
			movementCosts.Add(Tile.TileType.Road,0);
			movementCosts.Add(Tile.TileType.Wood,0);
			movementCosts.Add(Tile.TileType.Wasteland,0);
			movementCosts.Add(Tile.TileType.Ruins,0);
			movementCosts.Add(Tile.TileType.Mountain,0);
			movementCosts.Add(Tile.TileType.Beach,0);
			movementCosts.Add(Tile.TileType.Bridge,1);
			movementCosts.Add(Tile.TileType.Sea,1);
			movementCosts.Add(Tile.TileType.Reef,2);
			movementCosts.Add(Tile.TileType.RoughSea,2);
			movementCosts.Add(Tile.TileType.Mist,1);
		}
		
		if(mvntType==Unit.MovementType.Transport) {
			movementCosts.Add(Tile.TileType.HQ,0);
			movementCosts.Add(Tile.TileType.City,0);
			movementCosts.Add(Tile.TileType.Factory,0);
			movementCosts.Add(Tile.TileType.Airport,0);
			movementCosts.Add(Tile.TileType.Seaport,1);
			movementCosts.Add(Tile.TileType.TempAir,0);
			movementCosts.Add(Tile.TileType.TempSea,1);
			movementCosts.Add(Tile.TileType.Plain,0);
			movementCosts.Add(Tile.TileType.River,0);
			movementCosts.Add(Tile.TileType.Road,0);
			movementCosts.Add(Tile.TileType.Wood,0);
			movementCosts.Add(Tile.TileType.Wasteland,0);
			movementCosts.Add(Tile.TileType.Ruins,0);
			movementCosts.Add(Tile.TileType.Mountain,0);
			movementCosts.Add(Tile.TileType.Beach,1);
			movementCosts.Add(Tile.TileType.Bridge,1);
			movementCosts.Add(Tile.TileType.Sea,1);
			movementCosts.Add(Tile.TileType.Reef,2);
			movementCosts.Add(Tile.TileType.RoughSea,2);
			movementCosts.Add(Tile.TileType.Mist,1);
		}
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