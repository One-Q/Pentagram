using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour {

    public int initHealth;
    public int currentHealth;

    public ObjectBehaviourList dieBehaviour;
    public GameObject damageDealer;



    public void OnEnable(){
        currentHealth = initHealth;
    }

    public void takeDamage(int damage, GameObject source = null)
    {
        if (source)
        {
            damageDealer = source;
        }
        Debug.Log("Enemy take " + damage + "damages !");
        currentHealth -= damage;
        if (currentHealth == 0)
            Die();
        
        
    }

    void Die(){
        Debug.Log("Enemy is dead !");
        if (dieBehaviour)
        {
            dieBehaviour.Execute(gameObject);
        }
    }
	
	
}
