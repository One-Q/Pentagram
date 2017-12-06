using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	bool activation = false;
	public GameObject player;
	public GameObject inventoryPanel;

	private Canvas inventory;

	// Use this for initialization
	void Start () {
		inventory = GetComponent<Canvas> ();
		inventory.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.I)) {
			
			activation = !activation;
			if (activation) {
				
			}

			inventory.enabled = activation;
		}
	}
}
