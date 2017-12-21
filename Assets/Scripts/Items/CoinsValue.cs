using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsValue : MonoBehaviour {

	public int value;

	void Start () {
		value = GenerateValue ();
	}

	private int GenerateValue(){
		value = Random.Range (1, 100);
		return value;
	}
}
