using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthValue : MonoBehaviour {

	public int value;

	void Start () {
		value = GenerateValue ();
	}

	private int GenerateValue(){
		//10 - 20 - 30 
		value = Random.Range (1, 3) * 10;
		return value;
	}
}
