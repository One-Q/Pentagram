using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour {

	public string itemType;
	public string itemID;
	public Sprite itemSprite;
	public string itemDescription;

	// Use this for initialization
	void Start () {
		GetComponent<Image> ().sprite = itemSprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ItemEnter() {
		Debug.Log ("Enter");
	}

	public void ItemLeave() {
		Debug.Log ("Leave");
	}
}
