using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Behaviours/ModifyHealthWithPotionsBehaviour")]
public class ModifyHealthWithPotionsBehaviour : ObjectBehaviour {


	public override void Execute (GameObject obj){
		HealthValue hv = obj.GetComponent<HealthValue> ();
		if (hv) {
			int value = hv.value;
			GameObject o = GameObject.FindGameObjectWithTag ("Player");
			HealthPlayer p = o.GetComponent<HealthPlayer> ();
			p.AddHealth (value);
		}
	}
}