using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour {

    [SerializeField]
    float timeBetweenAttacks = 5f, distance;
    [SerializeField]
    int attackDamage = 10;
	[SerializeField]
	Animator animator;
    GameObject enemy;
    HealthPlayer playerHealth;
    HealthEnemy enemyHealth;
    bool enemyInRange, isHiting;
    float timer;
    Transform target = null;




    void Start()
    {
        playerHealth = this.GetComponent<HealthPlayer>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && enemyInRange)
        {
			isHiting = true;
        }
        if (Input.GetButtonUp("Fire1") && !enemyInRange)
        {
			isHiting = false;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            enemy = (GameObject)GameObject.FindGameObjectWithTag("Enemy");
            enemyHealth = col.GetComponent<HealthEnemy>();
            target = col.transform;
            transform.LookAt(target);

            enemyInRange = true; // le joueur est entré dans la zone
			StartCoroutine (FireCoroutine ());
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            enemyInRange = false; // le joueur est sorti de la zone
			StopAllCoroutines();
        }
    }

    void Attack()
    {
        timer = 0f;
        GameObject damageSource = gameObject;
        enemyHealth.takeDamage(attackDamage, damageSource);
        if (enemyHealth.isDead)
        {
            enemyInRange = false;
        }

    }

    public void Fire()
    {
        
        if (!playerHealth.isDead && !enemyHealth.isDead)
        {
            if (!enemyHealth.isDead && enemyInRange)
            {
				animator.SetTrigger ("Attack1Trigger");
                Attack();
            }
        }
    }

    IEnumerator FireCoroutine()
    {
        while (true)
        {
			if (isHiting) {
				Fire();
				yield return new WaitForSeconds(timeBetweenAttacks);
			}
			yield return new WaitForSeconds(0.1f);
        }
    }

}
