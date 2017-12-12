using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName="Behaviours/ModifyTextCoinsBehaviour")]
public class ModifyValueCoinsBehaviour : ObjectBehaviour {

	
	public override void Execute (GameObject obj){
		int value = obj.GetComponent<CoinsValue> ().value;
		GameObject o = GameObject.FindWithTag ("ValueCoins");
		string s = o.GetComponent<Text> ().text;
		int newValue =value  +int.Parse (s);
		o.GetComponent<Text> ().text = newValue + " ";
	}
}
