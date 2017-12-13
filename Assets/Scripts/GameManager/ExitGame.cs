using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour {

	public void ExitTheGame(){
		//No Save!
		SceneManager.LoadScene("Menu");
	}
}
