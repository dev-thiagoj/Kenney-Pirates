using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [Header("References")]
    [SerializeField] SpritesManager spritesManager;
    [SerializeField] CapsuleCollider2D capsuleCollider;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] HealthBarManager healthBarManager;

    [Header("Setup")]
    [SerializeField] int initialHealth;
    [SerializeField] float timeToDestroy = 5;

    [Header("Checks")]
    public bool isAlive;
    [SerializeField] int _currHealth;

    private void OnValidate()
    {
        if (capsuleCollider == null) 
            capsuleCollider = GetComponent<CapsuleCollider2D>();
        if (spritesManager == null) 
            spritesManager = GetComponent<SpritesManager>();
        if (healthBarManager == null) 
            healthBarManager = GetComponentInChildren<HealthBarManager>();
    }

    private void OnEnable()
    {
        Actions.executeDeath += Death;

        if (scoreManager == null) 
            scoreManager = GameObject.Find("=== MANAGERS ===").GetComponentInChildren<ScoreManager>();
    }

    private void OnDisable()
    {
        Actions.executeDeath -= Death;
    }

    void Start()
    {
        isAlive = true;
        _currHealth = initialHealth;
    }

    private void Update()
    {
        if (spritesManager.isFinalSprite == true) 
            isAlive = false;
    }

    public void Damage(int damage)
    {
        if (isAlive)
        {
            _currHealth -= damage;
            spritesManager.TakeDamage();

            if(healthBarManager != null) 
                healthBarManager.TakeDamage();
        }

        if (_currHealth == 0)
        {
            capsuleCollider.enabled = false;
            isAlive = false;
            Actions.addPlayerPoint.Invoke();
            Actions.performDeathExplosion.Invoke();
        }
    }

    public void Suicide()
    {
        capsuleCollider.enabled = true;
        isAlive = false;
        Actions.performDeathExplosion.Invoke();
    }

    void Death()
    {
        if (!isAlive)
        {
            Destroy(gameObject, timeToDestroy);
        }
        else 
            return;
    }
}
