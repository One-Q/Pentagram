using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileProperties : MonoBehaviour {

	public int damage;
	public int delay=5;

	public ObjectBehaviourList dieBehaviour;

	void OnEnable(){
		StartLiving ();
	}


	void OnCollisionEnter(Collision col){

		HealthEnemy enemy = col.gameObject.GetComponent<HealthEnemy>();
		if (enemy || col.gameObject.name == "Obstacle") {
			if (enemy) {
				enemy.takeDamage (damage);
			}
			if (dieBehaviour){
				StopLiving ();
			}
		}

	}



	void StopLiving(){
		StopCoroutine ("Live");
		if (dieBehaviour) {
			dieBehaviour.Execute (gameObject);
		}
	}


	void StartLiving(){
		StartCoroutine ("Live");
	}

	IEnumerator Live(){
		yield return new WaitForSeconds (delay);
		StopLiving ();
	}

}
