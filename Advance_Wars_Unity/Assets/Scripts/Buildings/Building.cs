using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour {

	private int captureProgress;
	//private Team currentTeam;
	//private Team capturingTeam;
	
	void Awake() {
		captureProgress=0;
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
	
	public void increaseCapureProgress(int x) {
		captureProgress+=x;
		if(captureProgress>20)
			captureProgress=20;
		//Include animation?
	}
	
	/** Pseudo-code for capturing buildings; to be implemented in infantry class
	Note: assumes that capture button was correctly shown (i.e. doesn't belong to unit's team)
	public void capture() {
		this.getBuilding().increaseCaptureProgress(getUnit().getHealth()/10); //Here I assume max health is 100 (in bars of 10)
		if(this.getBuilding().getProgress()==20)
		{
			this.getBuilding().currentTeam=
		}
	}
	
	**/
		/** Setters and getters **/
	
}
