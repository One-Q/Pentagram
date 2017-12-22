using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbInventory : ScriptableObject {

	public List<DumbItem> inventory = new List<DumbItem>();
	public int score;

	public void Init(List<DumbItem> list, int score){
		this.inventory = list;
		this.score = score;
	}

	public void Init(int score){
		this.score = score;
	}

	public void AddDumbItem(DumbItem obj){
		inventory.Add (obj);
	}
}
