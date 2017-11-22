using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUp : MonoBehaviour {

	public int nbSlots = 20;
	public GameObject inventoryCanvas;
	public Transform itempSlotPrefab;
	public Transform inventorySlots;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("Item")) {
			//Affiche le texte de celui ci peut etre
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
