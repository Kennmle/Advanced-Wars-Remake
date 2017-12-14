using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitVector : MonoBehaviour {
	private Unit[] array;
	private int size;
	private int capacity;
	private Unit commander;
	static readonly int MAX_SIZE=50;
	
	public UnitVector() {
		array=new Unit[10];
		capacity=10;
		size=0;
		commander=null;
	}
	/*
	public UnitVector(int s) {
		array=new Unit[s];
		capacity=s;
		size=0;
		commander=null;
	}
	*/
	public bool add(Unit unit) {
		if(size==MAX_SIZE)
			return false;
		else {
			if(size==capacity) {
				Unit[] temp = new Unit[capacity=Math.Min(capacity*2, MAX_SIZE)];
				for(int i = 0; i<size; i++)
					temp[i]=array[i];
				array=temp;
			}
			array[size]=unit;
			size++;	
			return true;
		}
	}
	public bool remove (Unit unit) {
		for(int i = 0; i<size; i++) {
			if(array[i]==unit) {
				//shift everything else over
				for(int j= i+1; j<size; j++)
					array[j-1]=array[j];
				size--;
				return true;
			}
		}
		
		return false; //wasn't found
	}
	
	public void setCommander(Unit unit) {
		if(commander!=null)
			Debug.Log("Overwritting commander!");
		commander = unit;
	}
	
	public Unit getCommander(Unit unit) {
		return commander;
	}
	
	public Unit getUnit(int x, int y) {
		for(int i = 0; i<size; i++) {
			//for now we use Unity's positions. We can later use ints defined in Unit
			if((int)array[i].transform.position.x==x&&(int)array[i].transform.position.y==y)
				return array[i];
		}
		
		return null; //such a unit is not found
	}
	
	public bool contains(Unit u) {
		for(int i = 0; i<size; i++) {
			if(array[i]=u)
				return true;
		}
		
		return false; //such a unit is not found
		
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
