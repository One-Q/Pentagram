using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour {

    [HideInInspector] public int currentHealth;
    public EnemyStats enemyStats;


    public ObjectBehaviourList dieBehaviour;
    [HideInInspector] public GameObject damageDealer;
    [HideInInspector] public bool isDead;



    public void OnEnable(){
        currentHealth = enemyStats.initHealth;
        isDead = false;
    }

    public void takeDamage(int damage, GameObject source = null)
    {
        if (source)
        {
            damageDealer = source;
        }
        currentHealth -= damage;
        if (currentHealth <= 0 && !isDead)
            Die();
        
        
    }

    void Die(){
        isDead = true;

        if (dieBehaviour)
        {
            gameObject.SetActive(false);
            dieBehaviour.Execute(gameObject);
        }
    }
	
	
}
