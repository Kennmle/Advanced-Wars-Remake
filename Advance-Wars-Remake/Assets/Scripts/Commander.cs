﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public abstract class Commander : MonoBehaviour {


    private String co; // It doesn't matter if its already something, each class is different so its okay to have two different names
	//From Kenneth: name is a keyword for Unity objects. You can check compilation errors and warnings in Unity's "console" tab (at the bottom)
    private int cozone;
    private int copower;
    private Image img; // Yes it is, https://msdn.microsoft.com/en-us/library/system.drawing.image(v=vs.110).aspx 
	//From Kenneth: You have to use UnityEngine.UI (you bitch)


    // returns name of the commander
    public String getName()
    {
        return name;
    }
    // returns range of the cozone;
    public int getCozone()
    {
        return cozone;
    }
    // returns the copower bar value
    public int getCopower()
    {
        return copower;
    }
    //returns the image of the commander
    public Image getImg()
    {
        return img;
    }
    // sets the name of the commander, probably not necessary
    public void setName(String s)
    {
        name = s;
    }
    // sets the cozone range
    public void setCozone(int i)
    {
        cozone = i;
    }
    //sets the copower bar
    public void setCopower(int i)
    {
        copower = i;
    }
    //sets the image
    public void setImg(Image i)
    {
        img = i;
    }
    // increases copower by the given amount
    public void increaseCopower(int i)
    {
        copower = copower + i;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}