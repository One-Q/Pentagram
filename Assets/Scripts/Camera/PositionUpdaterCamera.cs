using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionUpdaterCamera : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		//Camera follow on X but don't rotate on Y
		transform.rotation = new Quaternion (0.7f,0f,0f,0.7f);
	}
}
