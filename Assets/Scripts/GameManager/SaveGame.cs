	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour {

	public GameObject inventory;
	
	public void SaveGameSettings(bool Quit){
		var length = inventory.transform.childCount;
		for (var i = 0; i < length; i++) {
			Transform child = inventory.transform.GetChild (i);
			ItemSlot childSlot = child.GetComponent<ItemSlot> ();
			Debug.Log (childSlot);
			Debug.Log (childSlot.itemDescription);
			Debug.Log (childSlot.itemID);
			Debug.Log (childSlot.itemSprite);
		}

	
	}
}
