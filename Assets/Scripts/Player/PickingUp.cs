using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUp : MonoBehaviour {

	public int nbSlots = 20;
	public Transform inventorySlots;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("Item")) {
			//Affiche le texte de celui ci peut etre
		}
	}

	public void PutInInventory(GameObject item){
		if (inventorySlots.childCount < nbSlots) {
			
		} else {
			Debug.Log ("Pas de place");
		}
	}
}
