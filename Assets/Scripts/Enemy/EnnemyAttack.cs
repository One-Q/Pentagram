using UnityEngine;

public class EnnemyAttack : MonoBehaviour {

    public EnemyStats enemyStats;

    GameObject player;
	public HealthPlayer playerHealth;
	HealthEnemy ennemyHealth;
    bool playerInRange;
    float timer;
    private Transform target = null;

    private void Start()
    {
        ennemyHealth = this.GetComponent<HealthEnemy>();
    }

    void Awake()
    {
        player = (GameObject)GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<HealthPlayer>();
        

    }
   
    void OnTriggerEnter (Collider col)
    {
        if(col.CompareTag("Player"))
        {
            playerHealth = player.GetComponent<HealthPlayer>();
           // Debug.Log("player is in range !");
            playerInRange = true; // le joueur est entré dans la zone
            target = col.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
          //  Debug.Log("player is out range !");
            playerInRange = false; // le joueur est sorti de la zone
        }
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        if (playerHealth.currentHealth > 0 && !playerHealth.isDead && playerInRange)
        {

            float distance = Vector3.Distance(target.position, transform.position);
 
            if (distance < 3.0f)
            {
                if (timer >= enemyStats.attackRate && playerInRange && ennemyHealth.currentHealth > 0)
                {
                    // can attack
                    Attack();
                }
            }
           
        }
    }

    public void Attack()
    {
        timer = 0f;
        GameObject damageSource = gameObject;
       // Debug.Log(" enemy can fight ! ");
       // Debug.Log("playerInRange ? " + playerInRange);
        if (playerInRange && !playerHealth.isDead)
        {
           // Debug.Log("fight ! ");
            playerHealth.TakeDamage(enemyStats.attackDamage, damageSource);

        }

    }

   /* void Walk()
    {
        if (target == null) return;
        timer += Time.deltaTime;
        transform.LookAt(target);

        //float distance = Vector3.Distance(transform.position, target.position);
        //ool tooClose = distance < minRange;
        //Vector3 direction = tooClose ? Vector3.back : Vector3.forward;
        //transform.Translate(direction * Time.deltaTime * speed);
    }*/

}
