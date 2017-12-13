using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.UI;

public class ChargeGame : MonoBehaviour {

	public Transform itempSlotPrefab;
	public Transform inventorySlots;
	public GameObject valueCoins;

	public void ChargeSettings(){
		JsonData save = GetComponent<JSONReader> ().ReadItems ();
		//To retrieve value of coins
		int value =(int) save["coins"];
		valueCoins.GetComponent<Text> ().text = value+"";

		//To retrieve array of items


		for(var i=0;i<save["inventory"].Count;i++){
			Transform newItem = Instantiate (itempSlotPrefab, Vector3.zero, Quaternion.identity) as Transform;
			newItem.SetParent (inventorySlots, false);
			ItemSlot itemInventory = newItem.GetComponent<ItemSlot> ();
			itemInventory.itemDescription = (string) save ["inventory"] [i] ["description"];
			itemInventory.itemID = (string) save ["inventory"] [i] ["id"];
			itemInventory.itemType = (string) save["inventory"][i]["type"];
			itemInventory.itemSprite = (Sprite) Resources.Load ( (string) save["inventory"][i]["sprite"], typeof(Sprite));
		}


		Debug.Log ("J'essaie de charger");
	}
}
