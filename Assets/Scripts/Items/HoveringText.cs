using UnityEngine;
using System.Collections;

public class HoveringText: MonoBehaviour {

	public Transform target;
	public string textToDisplay;

	public bool displayName = true;
	public string type;

	// Update is called once per frame
	void Update () {
		nameDisplayer();
	}

	void LateUpdate (){
		//Make the text allways face the camera
		transform.rotation = Camera.main.transform.rotation;
	}

	//displays the name of the parent
	void nameDisplayer(){
		if(displayName){
			changeTextColor();
		}
	}



	//Changes the color
	public void changeTextColor() {

		if(this.type == "Legendary"){
			//Legendary Orange
			GetComponent<Renderer> ().material.color = new Color (255, 153, 51);
		}else if(this.type== "Rare"){
			//Rare Blue
			GetComponent<Renderer>().material.color = new Color (51, 51, 255);
		}else if(this.type == "Epic"){
			//Epic Violet
			GetComponent<Renderer> ().material.color = new Color (153, 51, 255);
		}else{
			//Common White
			GetComponent<Renderer> ().material.color = new Color (255,255,255);
		}

		// Access the TextMesh component and change it for "textToDisplay" value
		// Modo de acessar o component TextMesh do Texto3d e mudá-lo para "textToDisplay"  
		TextMesh tm = GetComponent<TextMesh>();
		tm.text = textToDisplay;
	}
}