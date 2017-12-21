using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Behaviours/DropBehaviour")]
public class DropBehaviour : ObjectBehaviour {

	public GameObject[] drops;

	public override void Execute (GameObject obj)
	{
		HealthEnemy he = obj.GetComponent<HealthEnemy> ();
		if (he) {
			Debug.Log (he.enemyStats.type);
		//Coins
			if (he.enemyStats.type == "Legendary") {
				int random = Random.Range (1, 10);
				for (int i = 0; i < random; i++) {
					Instantiate (drops [0], new Vector3 (obj.transform.position.x + (i % 2), obj.transform.position.y + (i % 2), obj.transform.position.z + (i % 2)), obj.transform.rotation);
				}
			} else if (he.enemyStats.type == "Epic") {
				int random = Random.Range (1, 5);
				for (int i = 0; i < random; i++) {
					Instantiate (drops [0], new Vector3 (obj.transform.position.x + (i % 2), obj.transform.position.y + (i % 2), obj.transform.position.z + (i % 2)), obj.transform.rotation);
				}
			} else {
				Instantiate (drops [0], new Vector3(obj.transform.position.x,obj.transform.position.y,obj.transform.position.z),obj.transform.rotation);	
			}
		//Health 
		Instantiate (drops [1], new Vector3(obj.transform.position.x,obj.transform.position.y,obj.transform.position.z),obj.transform.rotation);	
		}
	}
}
