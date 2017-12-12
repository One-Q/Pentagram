using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBePicked : MonoBehaviour {

	public bool hasPlayer=false;

	[SerializeField]
	private GameObject inventory;

	private GameObject player;
	private GameObject childObj;

	private bool isPaused = false;

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
		PutInInventory (gameObject);
		Destroy (gameObject);
	}

	public void PutInInventory(GameObject go){
		inventory.GetComponent<Inventory> ().PutInInventory (go);
	}

	void OnMouseDown(){
		if (hasPlayer && !isPaused) {
			GiveToPlayer ();
		}
	}
		
	private void OnPauseGame(){
		isPaused = true;
	}


	private void OnResumeGame(){
		isPaused = false;
	}
}
