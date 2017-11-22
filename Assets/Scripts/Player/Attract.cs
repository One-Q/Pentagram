using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract : MonoBehaviour {

	public float speed;
	public float minRange;

	public ObjectBehaviourList dieBehaviour;

	private HashSet<GameObject> set_of_gameObject = new HashSet<GameObject>();
	private HashSet<GameObject> set_of_gameObjectDuplicate = new HashSet<GameObject>();

	void OnTriggerEnter(Collider col) {
		if (col) {
			if (col.GetComponent<Attractable>()) {
				set_of_gameObject.Add (col.gameObject);
			}
		}
	}

	void OnTriggerExit(Collider col) {
		if (col) {
			if (col.GetComponent<Attractable>()) {
				RemoveFromSet (col.gameObject);
			}
		}
	}

	private void AddToRemove(GameObject obj){
		set_of_gameObjectDuplicate.Add (obj);
	}

	private void RemoveFromSet(GameObject obj){
		set_of_gameObject.Remove (obj);
	}

	private void ClearSet(){
		foreach (GameObject go in set_of_gameObjectDuplicate) {
			RemoveFromSet (go);
			dieBehaviour.Execute (go);
	
		}
		set_of_gameObjectDuplicate.Clear ();
	}


	void Update() {
		if (set_of_gameObject.Count != 0) {
			foreach (GameObject go in set_of_gameObject) {
				float distance = Vector3.Distance (transform.position, go.transform.position);
				bool veryClose = distance < minRange;
				if (veryClose) {
					if (dieBehaviour) {
						AddToRemove (go);
					}
				}
				go.transform.LookAt(transform);
				go.transform.Translate(Vector3.forward * Time.deltaTime * speed);
			}
			ClearSet ();
		}
	}
}
