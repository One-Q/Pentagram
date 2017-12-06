using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {
	public Transform canvas;
	private bool isPaused = false;

	void Start(){
		canvas.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause ();
		}
	}

	public void Pause(){
			if (!isPaused) {
				isPaused = true;
				canvas.gameObject.SetActive (true);
				Object[] objects = FindObjectsOfType (typeof(GameObject));
				foreach (GameObject go in objects) {
					go.SendMessage ("OnPauseGame", SendMessageOptions.DontRequireReceiver);
				}
				Time.timeScale = 0;
			} else {
				isPaused = false;
				canvas.gameObject.SetActive (false);
				Object[] objects = FindObjectsOfType (typeof(GameObject));
				foreach (GameObject go in objects) {
					go.SendMessage ("OnResumeGame", SendMessageOptions.DontRequireReceiver);
				}
				Time.timeScale = 1;
			}

	}
}
