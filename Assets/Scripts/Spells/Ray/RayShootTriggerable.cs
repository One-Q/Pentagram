using UnityEngine;
using System.Collections;

public class RayShootTriggerable : MonoBehaviour {

	[HideInInspector] public int gunDamage = 1;                         
	[HideInInspector] public float weaponRange = 20f;                   
	[HideInInspector] public float hitForce = 100f;                    
	public Transform player;                                           
	[HideInInspector] public LineRenderer laserLine;    
                              

	public void Initialize ()
	{
		laserLine = GetComponent<LineRenderer> ();


	}

	public void Fire()
	{
		laserLine.enabled = true;
			
		Debug.DrawRay (player.position, player.forward * weaponRange, Color.blue);
		
		//Declare a raycast hit to store information about what our raycast has hit.
		RaycastHit hit;

		Vector3 rayPosition = player.position;
		rayPosition.y += 2;
		laserLine.SetPosition(0, rayPosition);
		laserLine.SetPosition(1, rayPosition + player.forward * weaponRange); 

		//Set the start position for our visual effect for our laser to the position of gunEnd

		//Check if our raycast has hit anything
		if (Physics.Raycast(player.position,player.forward, out hit, weaponRange))
		{
			//Set the end position for our laser line 


			Collider col = hit.collider;


			HealthEnemy enemy = col.gameObject.GetComponent<HealthEnemy>();
			if (enemy || col.gameObject.tag == "Walls")
			{
				laserLine.SetPosition(1, hit.point); 
				if (enemy) {
					enemy.takeDamage (gunDamage);
				}
		

			}
		}
	}

}