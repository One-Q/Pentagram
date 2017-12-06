using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class JSONReader : MonoBehaviour {

	public Object jsonFile;
	[SerializeField]
	public Dictionary<string, string> dico = new Dictionary<string, string>();

	void Start(){
		dico.Add ("001", "sdqsddq");
		dico.Add ("002", "sqddsdsdsdsdsd");
		WriteItems ();
	}

	public ItemSlot ReadItem(string name) {
		string jsonString = jsonFile.ToString ();
		JSONNode json = JSON.Parse (jsonString);
		JSONNode currentJson = json [name];
		Debug.Log (currentJson);
		return new ItemSlot ();
	}

	public ItemSlot ReadItems() {
		string jsonString = jsonFile.ToString ();
		JSONNode json = JSON.Parse (jsonString);
		JSONNode currentJson = json ["items"];
		JSONArray array = currentJson.AsArray;
		foreach (var item in array) {
			Debug.Log (item);
		}
		return new ItemSlot ();
	}

	public void WriteItems(){
		// GameObject inventory = GameObject.Find("Inventory Panel");
		string json = JsonUtility.ToJson (dico);
		Debug.Log (json);
	}
}
