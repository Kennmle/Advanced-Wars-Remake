using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour1 {

	private int captureProgress;
	//private Team currentTeam;
	//private Team capturingTeam;
	//private Unit containedUnit;
	private Tile underTile;
	
	void Awake() {
		underTile=this.GetComponentInParent<Tile>();
		
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public virtual void onClick() {
		//Only needs to be implemented for production buildings
	}
	
		/** Setters and getters **/
	
}
