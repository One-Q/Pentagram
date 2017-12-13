using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class JSONReader : MonoBehaviour {

	[SerializeField]
	public Dictionary<string, string> dico = new Dictionary<string, string>();

	public  ItemSlot ReadItem(string name) {
		/*string jsonString = jsonFile.ToString ();
		JSONNode json = JSON.Parse (jsonString);
		JSONNode currentJson = json [name];
		Debug.Log (currentJson);
		return new ItemSlot ();*/
		return null;
	}

	public JsonData ReadItems() {
		string jsonString = File.ReadAllText (@"./save.json");
		JsonData itemData =JsonMapper.ToObject (jsonString);
		return itemData;
	}

	public void WriteItems(){
		// GameObject inventory = GameObject.Find("Inventory Panel");
		/*string json = JsonUtility.ToJson (dico);
		Debug.Log (json);*/
	}

	public void WriteItem(ScriptableObject obj){
		string itemJson = JsonMapper.ToJson (obj);
		Debug.Log ("Apres");
		File.WriteAllText (@"./save.json", itemJson);
	}
}
