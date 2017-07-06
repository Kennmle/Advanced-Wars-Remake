using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    private int health;
    private int vision;
    private int move;
    private int ammo;
    private int cost;
    private int attack;
    private int defense;
    private int fuel;
    private int range;

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
    public void setVision(int x)
    {
        vision = x;
    }
    public int geVision()
    {
        return vision;
    }
    public void setMove(int x)
    {
        move = x;
    }
    public int getMove()
    {
        return move;
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
    public void setAttack(int x)
    {
        attack = x;
    }
    public int getAttack()
    {
        return attack;
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
}