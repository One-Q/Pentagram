﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsValue : MonoBehaviour {

	//From Ennemies
	public GameObject parent;


	public int value;

	void Start () {
		value = GenerateValue ();
	}

	private int GenerateValue(){
		int value;
		if (parent) {
			//From Ennemies
			string type = parent.GetComponent<EnemyStats>().type;
			if (type == "Legendary") {
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
