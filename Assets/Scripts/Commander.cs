using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Commander : MonoBehaviour {


    private String name; // name is better
    private int cozone;
    private int copower;
    private Image img; // this is necessary you POS

    //private ImageIcon img; motherfucker

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
