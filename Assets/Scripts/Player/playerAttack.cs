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
            SetHiting(true);
        }
        if (Input.GetButtonUp("Fire1") && !enemyInRange)
        {
            SetHiting(false);
        }
    }


    public void SetHiting(bool mode)
    {
        isHiting = mode;
        StopAllCoroutines();
        if (mode)
        {
            StartCoroutine(FireCoroutine());
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
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            enemyInRange = false; // le joueur est sorti de la zone
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
        timer += Time.deltaTime;
        if (!playerHealth.isDead && !enemyHealth.isDead)
        {
            if (timer >= timeBetweenAttacks && !enemyHealth.isDead && enemyInRange)
            {
                // can attack
                Attack();
            }
        }
    }

    IEnumerator FireCoroutine()
    {
        while (true)
        {
            if (isHiting)
                Fire();
            yield return new WaitForSeconds(timeBetweenAttacks);
        }
    }

}
