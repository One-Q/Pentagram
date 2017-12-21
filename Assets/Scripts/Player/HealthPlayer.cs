﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour {

	public int initHealth;
	public int maxHealth;

    public int currentHealth;
    [HideInInspector] public bool isDead;

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

	public void AddHealth(int value){
		currentHealth += value;
		UpdateHealthIfAboveMax ();
		SliderChangeValue ();
	}

	public void UpdateHealthIfAboveMax (){
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
	}

	public void TakeDamage(int damage , GameObject source = null ){
		if (source) {
			damageDealer = source;
		}

		currentHealth -= damage;

		SliderChangeValue ();

		if (currentHealth <= 0 && !isDead) {
			Die ();
		}
	}

	public void Die(){
        isDead = true;
		if (dieBehaviour) {
            gameObject.SetActive(false);
			dieBehaviour.Execute (gameObject);
		}
	}
}
