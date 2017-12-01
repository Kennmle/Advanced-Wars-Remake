using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public unsafe class PathNode : MonoBehaviour {

	private PathNode next;
	private PathNode previous;
	private Tile value;
	private int weight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//No action required
	}
	
	/** Constructors **/
	public PathNode() {
		next=null;
		previous=null;
	}
	
	public PathNode(Tile t, int w) {
		value=t;
		weight=w;
	}
	
	public void setPrevious(PathNode n) {
		previous = n;
	}
	
	public PathNode getPrevious() {
		return previous;
	}
	
	public void setNext(PathNode n) {
		next = n;
	}
	
	public PathNode getNext() {
		return next;
	}
	
	public Tile getValue() {
		return value;
	}
	
	public int getWeight() {
		return weight;
	}
}