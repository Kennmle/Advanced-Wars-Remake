using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public abstract class Commander{

  protected int zone;
     //might need to make this in Team.cs
  //since we also need the location of the co unit. (if applicable)
    private String co; // It doesn't matter if its already something, each class is different so its okay to have two different names
	//From Kenneth: name is a keyword for Unity objects. You can check compilation errors and warnings in Unity's "console" tab (at the bottom)
    private int coZone;
    private int coPowerAttack;
    
  public abstract void power(); //Possibly take UnitVector as param
    // returns name of the commander
    public String getName()
    {
        return name;
    }
    // sets the name of the commander, probably not necessary
    public void setName(String s)
    {
        name = s;
    }
    // returns range of the cozone;
    public int getCoZone()
    {
        return coZone;
    }
    // sets the cozone range
    public void setCozone(int i)
    {
        coZone = i;
    }
    // returns the copower bar value
    public int getCoPowerAttack()
    {
        return coPower;
    }
    //sets the copower bar
    public void setCopowerAttack(int i)
    {
        coPowerAttack = i;
    }
    public int getCoPowerDefense()
    {
        return coPowerDefense;
    }
    //sets the copower bar
    public void setCopowerDefense(int i)
    {
        coPowerDefense = i;
    }
}
