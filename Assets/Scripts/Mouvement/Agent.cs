using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour {

	NavMeshAgent agent;
	public Animator animator;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Input.GetMouseButton(0)) {
			animator.SetBool("Moving", true);
			animator.SetBool("Running", true);
			//agent.isStopped = true;
			//agent.ResetPath ();
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
				agent.SetDestination(hit.point);

		}
		if (agent.remainingDistance == 0) {
			animator.SetBool("Moving", false);
			animator.SetBool("Running", false);
		}
		if (Input.GetKey ("z")) {
			agent.isStopped = true;
			agent.ResetPath ();
			animator.SetBool("Moving", false);
			animator.SetBool("Running", false);
		}
		agent.isStopped = false;
	}
}
