using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGame : MonoBehaviour {

	public GameObject inventory;
	public GameObject coinsField;
	
	public void SaveGameSettings(bool Quit){
		var length = inventory.transform.childCount;
		DumbInventory dumbInventory = ScriptableObject.CreateInstance<DumbInventory> ();
		Text value = coinsField.GetComponent<Text>();
		for (var i = 0; i < length; i++) {
			Transform child = inventory.transform.GetChild (i);
			ItemSlot childSlot = child.GetComponent<ItemSlot> ();
			DumbItem di = ScriptableObject.CreateInstance<DumbItem> ();
			di.Init(childSlot.itemID, childSlot.itemDescription, childSlot.itemSprite.name, childSlot.itemType);
			dumbInventory.AddDumbItem (di);
		}

		dumbInventory.Init (int.Parse (value.text));
		GetComponent<JSONReader> ().WriteItem (dumbInventory);

	
	}
}
