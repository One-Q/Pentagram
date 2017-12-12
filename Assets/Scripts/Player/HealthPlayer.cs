using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour {

	public int initHealth;
	public int maxHealth;
    [HideInInspector] public int currentHealth;

	public ObjectBehaviourList dieBehaviour;

	public GameObject damageDealer;

	public Slider sliderHealth;


	void OnEnable(){
		currentHealth = initHealth;
		sliderHealth.maxValue = maxHealth;
		sliderHealth.value = currentHealth;
	}

	private void SliderChangeValue(){
		sliderHealth.value = currentHealth;
	}

	private void SliderDisabled (){
		Transform t = sliderHealth.transform.GetChild (1);
		t.gameObject.SetActive (false);
	}
		


	public void TakeDamage(int damage , GameObject source = null ){
		if (source) {
			damageDealer = source;
		}

		currentHealth -= damage;

		SliderChangeValue ();

		if (currentHealth <= 0) {
			SliderDisabled ();
			Die ();
		}
	}

	public void Die(){
		if (dieBehaviour) {
			dieBehaviour.Execute (gameObject);
		}
	}
}
