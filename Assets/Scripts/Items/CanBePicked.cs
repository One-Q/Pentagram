using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBePicked : MonoBehaviour {

	public bool hasPlayer=false;

	private GameObject player;
	private GameObject childObj;

	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			hasPlayer = true;
			childObj.SetActive (true);
			print (hasPlayer);
		}
	}

	void OnTriggerExit(Collider col){
		if (col.CompareTag ("Player")) {
			hasPlayer = false;
			childObj.SetActive (false);
			print (hasPlayer);
		}
	}

	void OnEnable(){
		player = GameObject.FindGameObjectWithTag ("Player");
		childObj = transform.GetChild (0).gameObject;
	}

	public void GiveToPlayer(){
		Destroy (gameObject);
	}

	void OnMouseDown(){
		if (hasPlayer) {
			GiveToPlayer ();
		}
	}
}
