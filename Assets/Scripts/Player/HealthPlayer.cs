using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour {

	public int initHealth;
	private int currentHealth;

	public ObjectBehaviourList dieBehaviour;

	public GameObject damageDealer;

	void OnEnable(){
		currentHealth = initHealth;
	}

	public void TakeDamage(int damage , GameObject source = null ){
		if (source) {
			damageDealer = source;
		}

		currentHealth -= damage;
		if (currentHealth <= 0) {
			Die ();
		}
	}

	public void Die(){
		if (dieBehaviour) {
			dieBehaviour.Execute (gameObject);
		}
	}
}
