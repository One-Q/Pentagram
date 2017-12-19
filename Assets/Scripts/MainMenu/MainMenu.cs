using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject dontDestroy;

	void Update(){
		bool exist = File.Exists (@"./save.json");

		GetComponentInChildren<Button> ().interactable = exist;
	}

	public void PlayGame(){
		dontDestroy.GetComponent<PersistentObject> ().newGame = true;
		DontDestroyOnLoad (dontDestroy);
		//Take the next in the index
		SceneManager.LoadScene ("Level");
	}

	public void ExitGame(){
		Application.Quit ();
	}

	public void ContinueGame(){
		dontDestroy.GetComponent<PersistentObject> ().newGame = false;
		DontDestroyOnLoad (dontDestroy);
		SceneManager.LoadScene ("Level");

	}

	public void ExitToMenu(){
		SceneManager.LoadScene ("Menu");
	}
}
