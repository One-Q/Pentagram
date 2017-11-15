using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBePicked : MonoBehaviour {

	private GameObject player;
	private bool hasPlayer=false;
	private bool beingCarried=false;

	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			hasPlayer = true;
			print (hasPlayer);
		}
	}

	void OnTriggerExit(Collider col){
		if (col.CompareTag ("Player")) {
			hasPlayer = false;
			print (hasPlayer);
		}
	}

	void OnEnable(){
		player = GameObject.FindGameObjectWithTag ("Player");
	}
		

	void Update(){
		if (hasPlayer && Input.GetMouseButtonDown(0)) {
			Destroy (gameObject);
			beingCarried = true;
		}
	}
}
