using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsValue : MonoBehaviour {


	public GameObject parent;

	//TODO GameObject change to Monster

	public int value;

	// Use this for initialization
	void Start () {
		value = GenerateValue ();
	}

	private int GenerateValue(){
		int value;
		if (parent) {
			//From Monsters
			if (parent.tag == "Boss") {
				value = Random.Range (200, 300);
			} else if (parent.tag == "Epic") {
				value = Random.Range (100, 200);
			} else {
				value = Random.Range (1, 100);
			}
		} else {
			//From Others Possibilities
			value = Random.Range (1, 100);
		}

		return value;
	}
}
