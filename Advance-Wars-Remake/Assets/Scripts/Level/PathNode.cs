using System.Collections;
using System.Collections.Generic;

public unsafe class PathNode {

	private Tile value;
	private int weight;

	/** Constructors **/
	public PathNode() {
		value=null;
		weight=0;
	}

	public PathNode(Tile t, int w) {
		value=t;
		weight=w;
	}

	public Tile getValue() {
		return value;
	}

	public int getWeight() {
		return weight;
	}
}
