using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	void Update(){
		bool exist = File.Exists (@"./save.json");

		GetComponentInChildren<Button> ().interactable = exist;
	}

	public void PlayGame(){
		//Take the next in the index
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void ExitGame(){
		Application.Quit ();
	}

	public void ContinueGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);

	}
}
