using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionUpdater : MonoBehaviour {

	public GameObject origin;
	public GameObject model;
	
	// Update is called once per frame
	void Update () {
		model.transform.position = origin.transform.position;
	}
}
