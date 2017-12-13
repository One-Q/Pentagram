using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbInventory : ScriptableObject {

	public List<DumbItem> inventory = new List<DumbItem>();
	public int coins;

	public void Init(List<DumbItem> list, int coins){
		this.inventory = list;
		this.coins = coins;
	}

	public void Init(int coins){
		this.coins = coins;
	}

	public void AddDumbItem(DumbItem obj){
		inventory.Add (obj);
	}
}
