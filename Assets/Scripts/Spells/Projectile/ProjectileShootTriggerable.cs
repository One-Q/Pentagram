using UnityEngine;
using System.Collections;

public class ProjectileShootTriggerable : MonoBehaviour {

	[HideInInspector] public Rigidbody projectile;
	public Transform bulletSpawn;   
	public int speed;
	[HideInInspector] public float projectileForce = 250f;

	public void Launch()
	{
		Rigidbody clonedBullet = (Rigidbody) Instantiate (projectile, bulletSpawn.position, transform.rotation);

		clonedBullet.AddForce(bulletSpawn.transform.forward * projectileForce * speed);
	}
}
