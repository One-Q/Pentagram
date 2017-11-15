using UnityEngine;

public class EnnemyAttack : MonoBehaviour {
    [SerializeField]
    float timeBetweenAttacks = 0.5f;
    [SerializeField]
    int attackDamage = 10;

    GameObject player;
	HealthPlayer playerHealth;
	HealthEnemy ennemyHealth;
    bool playerInRange;
    float timer;

    void Awake()
    {
        player = (GameObject) GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<HealthPlayer>();
		ennemyHealth = this.GetComponent<HealthEnemy>();

    }

    void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("enemy can attack !");
            playerInRange = true; // le joueur est entré dans la zone
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("enemy can't attack !");
            playerInRange = false; // le joueur est sorti de la zone
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && ennemyHealth.currentHealth > 0)
        {
            // on peut attacker
            this.Attack();
        }

    }

    void Attack()
    {
        timer = 0f;
        Debug.Log("fight ! ");
            playerHealth.TakeDamage(attackDamage);

    }

}
