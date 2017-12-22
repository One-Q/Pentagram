using UnityEngine;

public class EnnemyAttack : MonoBehaviour {

    public EnemyStats enemyStats;

    GameObject player;
	public HealthPlayer playerHealth;
	HealthEnemy ennemyHealth;
    bool playerInRange;
    float timer;
    private Transform target = null;
	public Animator animator;

    void Start()
    {
        ennemyHealth = this.GetComponent<HealthEnemy>();
        player = (GameObject)GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<HealthPlayer>();
    }
  

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {

            player = col.gameObject;
            playerHealth = player.GetComponent<HealthPlayer>();
            playerInRange = true; // le joueur est entré dans la zone
            target = col.transform;


            if (!playerHealth.isDead)
            {
                float distance = Vector3.Distance(target.position, transform.position);
                if (distance < enemyStats.attackRange)
                {
                    if (timer >= enemyStats.attackRate && playerInRange && !ennemyHealth.isDead)
                    {
                        transform.LookAt(target);
                        // can attack
                        Attack();
                    }
                }
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false; // le joueur est sorti de la zone
        }
    }
    
    void Update()
    {
        timer += Time.deltaTime;
		animator.SetBool("Moving", true);
		animator.SetBool ("Running", true);
    }

    public void Attack()
    {
        timer = 0f;
        GameObject damageSource = gameObject;
        if (playerInRange && !playerHealth.isDead)
        {
			animator.SetTrigger("Attack1Trigger");
            playerHealth.TakeDamage(enemyStats.attackDamage, damageSource);

        }
		animator.SetBool("Moving", true);
		animator.SetBool ("Running", true);
    }

}
