using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillAllEnemies : MonoBehaviour {

	public GameObject valueToChange;

	private void ChangeValue(int value){
		valueToChange.GetComponent<Text> ().text = value + "";
		if (value == 0) {
			FinishTheGame ();
		}
	}

	public void Update(){
		int length = GameObject.FindGameObjectsWithTag ("Enemy").Length;
		ChangeValue (length);
		Debug.Log (length);
	}

	private void FinishTheGame (){
		GameObject obj = GameObject.Find ("GameController");
		obj.GetComponent<SaveGame> ().SaveGameSettings ();
		obj.GetComponent<WinGame> ().Win ();
	}

}
