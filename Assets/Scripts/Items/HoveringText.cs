using UnityEngine;
using System.Collections;

public class HoveringText: MonoBehaviour {

	public Transform target;
	public string textToDisplay;

	public bool displayName = true;
	public bool displayTAG = false;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		nameDisplayer();
		tagDisplayer();
	}

	void LateUpdate (){
		//Make the text allways face the camera
		transform.rotation = Camera.main.transform.rotation;
	}

	//displays the name of the parent
	void nameDisplayer(){
		if(displayName){
			displayTAG = false;
			//changes the text to the Name
			changeTextColor();
		}
	}

	//displays the TAG of the parent
	void tagDisplayer(){
		if(displayTAG){
			displayName = false;
			//changes the text to the TAG
			changeTextColor();
		}
	}


	//Changes the color
	public void changeTextColor() {

		if(this.transform.tag == "Legendary"){
			GetComponent<Renderer> ().material.color = new Color (255, 153, 51);
		}
			
		if(this.transform.tag == "Rare"){
			GetComponent<Renderer>().material.color = new Color (51, 51, 255);
		}
			
		if(this.transform.tag == "Epic"){
			GetComponent<Renderer> ().material.color = new Color (153, 51, 255);
		}
			
		if(this.transform.tag == "Common"){
			GetComponent<Renderer> ().material.color = new Color (255,255,255);
		}

		// Access the TextMesh component and change it for "textToDisplay" value
		// Modo de acessar o component TextMesh do Texto3d e mudá-lo para "textToDisplay"  
		TextMesh tm = GetComponent<TextMesh>();
		tm.text = textToDisplay;
	}
}