using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBePicked : MonoBehaviour {

	public bool hasPlayer=false;

	public int nbSlots = 20;
	public GameObject inventoryCanvas;
	public Transform itempSlotPrefab;
	public Transform inventorySlots;

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
		PutInInventory (gameObject);
		Destroy (gameObject);
	}

	void OnMouseDown(){
		if (hasPlayer) {
			GiveToPlayer ();
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
}
