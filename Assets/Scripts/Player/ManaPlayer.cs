using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaPlayer : MonoBehaviour {

	public int initMana;
	public int maxMana;
	public float delay;
	public Slider sliderMana;

	private int currentMana;
	private bool started = false;



	void OnEnable (){
		currentMana = initMana;
		sliderMana.maxValue = maxMana;
	}

	void Update () {
		StartOrStopRegeneration ();
		SliderChangeValue ();
	}
		

	private void StartOrStopRegeneration(){
		if (currentMana < maxMana && !started) {
			StartRegeneration ();
		} else if (currentMana == maxMana) {
			StopRegeneration ();
		} else {
			return;
		}
	}

	private void SliderChangeValue(){
		if (currentMana == 0) {
			SliderDisabled ();
		} else {
			SliderEnabled ();
			sliderMana.value = currentMana;
		}

	}

	private void SliderDisabled (){
		Transform t = sliderMana.transform.GetChild (1);
		t.gameObject.SetActive (false);
	}

	private void SliderEnabled (){
		Transform t = sliderMana.transform.GetChild (1);
		t.gameObject.SetActive (true);
	}

	public bool CastASpell(int mana){
		if (currentMana < mana) {
			print("Can't cast bg");
			return false;
		}
		currentMana -= mana;

		return true;

	}

	void StartRegeneration(){
		started = true;
		StartCoroutine ("Regeneration");
	}

	void StopRegeneration(){
		started = false;
		StopCoroutine ("Regeneration");
	}

	IEnumerator Regeneration(){
		while (true) {
			currentMana++;
			yield return new WaitForSeconds (delay);
		}
	}
}
