using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour {

    public int initHealth;
    public int currentHealth;
    bool isDead;

    public void OnEnable(){
        currentHealth = initHealth;
    }

    public void takeDamage(int damage){
        if (!isDead){
            Debug.Log("Enemy take " + damage + "damages !");
            currentHealth -= damage;
            if (currentHealth == 0)
                Die();
        }
        
    }

    void Die(){
        isDead = true;
        Debug.Log("Enemy is dead !");
        Destroy(gameObject);
    }
	
	
}
