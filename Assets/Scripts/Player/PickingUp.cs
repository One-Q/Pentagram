using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUp : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("Item")) {
			//Affiche le texte de celui ci peut etre
		}
	}
}
