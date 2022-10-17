using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform player;
    [SerializeField] EnemyRadarTrigger radarTrigger;
    [SerializeField] Health health;
    [SerializeField] SpritesManager spritesManager;

    [Header("Setup")]
    [SerializeField] float pursuitSpeed = 1f;
    [SerializeField] int collisionDamage = 1; 

    [Header("Checks")]
    [SerializeField] bool canPursuit = true;
    bool playerLives = true;

    private void OnValidate()
    {
        if (radarTrigger == null) 
            radarTrigger = GetComponentInChildren<EnemyRadarTrigger>();
        if (health == null) 
            health = GetComponent<Health>();
        if (spritesManager == null) 
            spritesManager = GetComponent<SpritesManager>();
    }

    #region Actions
    private void OnEnable()
    {
        Actions.playerDied += CheckPlayerDeath;
    }
    private void OnDisable()
    {
        Actions.playerDied -= CheckPlayerDeath;
    }
    #endregion

    private void Awake()
    {
        if (player == null) 
            player = GameObject.Find("=== PLAYER ===").GetComponent<Transform>();
    }

    private void Update()
    {
        if (radarTrigger.triggered == true) canPursuit = true;

        if (health.isAlive && playerLives)
        {
            transform.up = Vector3.Lerp(transform.up, (player.position - transform.position), 1f * Time.deltaTime);

            if (canPursuit)
            {
                Vector3 lookDirection = (player.transform.position - transform.position).normalized;

                transform.position += (lookDirection * pursuitSpeed) * Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            IDamageable damageable = collision.transform.GetComponent<IDamageable>();

            if(damageable != null)
            {
                damageable.Damage(collisionDamage);
            }

            health.Suicide();
        }
    }

    void CheckPlayerDeath()
    {
        playerLives = false;
    }
}
