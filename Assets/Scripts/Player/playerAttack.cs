using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour {

    [SerializeField]
    float timeBetweenAttacks = 0.5f, distance;
    [SerializeField]
    int attackDamage = 10;


    GameObject enemy;
    HealthPlayer playerHealth;
    HealthEnemy enemyHealth;
    bool enemyInRange;
    float timer;
    Transform target = null;



    void Start()
    {
        playerHealth = this.GetComponent<HealthPlayer>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Fire();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            enemy = (GameObject)GameObject.FindGameObjectWithTag("Enemy");
            Debug.Log("enemy is in range !");
            enemyHealth = col.GetComponent<HealthEnemy>();
            target = col.transform;
            transform.LookAt(target);

            enemyInRange = true; // le joueur est entré dans la zone
            Attack();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            Debug.Log("enemy is out range !");
            enemyInRange = false; // le joueur est sorti de la zone
        }
    }

    void Attack()
    {
        timer = 0f;
        Debug.Log("player attack ! ");
        GameObject damageSource = gameObject;
        enemyHealth.takeDamage(attackDamage, damageSource);

    }

    public void Fire()
    {
        timer += Time.deltaTime;
        if (playerHealth.currentHealth > 0)
        {
            Debug.Log("health ?=0 ");
            distance = Vector3.Distance(target.position, transform.position);
            if (distance < 3.0f)
            {
                Debug.Log("distance ");
                if (timer >= timeBetweenAttacks && enemyInRange && enemyHealth.currentHealth > 0)
                {
                    Debug.Log("before attack ");
                    // can attack
                    Attack();
                }
            }
            else
            {
                Debug.Log("not yet in view ");
            }
        }
    }

}
