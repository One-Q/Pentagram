using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu ( menuName="Abilities/RaycastAbility")]
public class RayAbility : Ability {

	public int gunDamage = 1;
	public float weaponRange = 50f;
	public Color laserColor = Color.white;

	private RayShootTriggerable rcShoot;

	public override void Initialize(GameObject go){
		rcShoot = go.GetComponent<RayShootTriggerable> ();
		rcShoot.Initialize ();

		rcShoot.gunDamage = gunDamage;
		rcShoot.weaponRange = weaponRange;


		rcShoot.laserLine.material.color = laserColor;


	}

	public override void TriggerAbility(){
		rcShoot.Fire ();
	}
	public override void ShutDown(){
		rcShoot.laserLine.enabled = false;
	}
}
