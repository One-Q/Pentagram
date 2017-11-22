using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	bool activation = false;
	public GameObject player;
	public GameObject inventoryPanel;

	// Use this for initialization
	void Start () {
		if(inventoryPanel == null)
			inventoryPanel = GameObject.Find("Inventory Panel");
		inventoryPanel.SetActive (activation);
		player = GameObject.FindGameObjectWithTag ("Player");	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.I)) {
			
			activation = !activation;
			if (activation) {
				
			}
			inventoryPanel.SetActive (activation);
		}
	}
}
