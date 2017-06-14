using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class MonoBehaviour1 : MonoBehaviour {
	
	//Here we add any methods we want for our classes in general (i.e., certain rounded behaviour)
	
	int Dround(double d)
	{
		return (int)Math.Round(d);
	}
	
	
}
