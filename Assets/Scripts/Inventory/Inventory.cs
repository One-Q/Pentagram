using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	//Comment
	bool activation = false;
	public GameObject player;
	public GameObject inventoryPanel;

	public bool isPaused = false;

	private Canvas inventory;

	public int nbSlots = 20;
	public Transform itempSlotPrefab;
	public Transform inventorySlots;


	// Use this for initialization
	void Start () {
		inventory = GetComponent<Canvas> ();
		inventory.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.I) && !isPaused) {
			
			activation = !activation;
			if (activation) {
				
			}

			inventory.enabled = activation;
		}
	}

	public void PutInInventory(GameObject item){
		if (inventorySlots.childCount < nbSlots) {
			Transform newItem = Instantiate (itempSlotPrefab, Vector3.zero, Quaternion.identity) as Transform;
			newItem.SetParent (inventorySlots, false);
			ItemSlot itemInventory = newItem.GetComponent<ItemSlot> ();
			ItemScene itemScene = item.GetComponent<ItemScene> ();
			itemInventory.itemDescription = itemScene.itemDescription;
			itemInventory.itemID = itemScene.itemID;
			itemInventory.itemType = itemScene.itemType;
			itemInventory.itemSprite = itemScene.itemSprite;
		} else {
			Debug.Log ("Pas de place");
		}
	}


	void OnPauseGame(){
		isPaused = true;
	}

	void OnResumeGame(){
		isPaused = false;
	}
}
