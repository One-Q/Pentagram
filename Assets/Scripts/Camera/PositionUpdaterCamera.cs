using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionUpdaterCamera : MonoBehaviour {

	public GameObject toFollow;
	
	// Update is called once per frame
	void Update () {
		//Camera follow on X but don't rotate on Y
		transform.position = new Vector3(toFollow.transform.position.x,toFollow.transform.position.y+30f,toFollow.transform.position.z);
		transform.rotation = new Quaternion (0.7f,0f,0f,0.7f);
	}
}
