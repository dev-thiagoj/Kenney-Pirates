using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [Header("References")]
    SpritesManager spritesManager;

    [Header("Setup")]
    public int initialHealth;
    [SerializeField] float timeToDestroy = 5;

    [Header("Checks")]
    public bool isAlive;
    [SerializeField] int _currHealth;

    private void OnValidate()
    {
        if (spritesManager == null) spritesManager = GetComponent<SpritesManager>();
    }

    private void OnEnable()
    {
        Actions.executeDeath += Death;
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
        if (spritesManager.isFinalSprite == true) isAlive = false;
    }

    public void Damage(int damage)
    {
        _currHealth -= damage;
        
        if (isAlive) spritesManager.TakeDamage();

        if (_currHealth <= 0)
        {
            isAlive = false;
            Actions.performDeathExplosion.Invoke();
        }
    }

    public void Suicide()
    {
        isAlive = false;
        spritesManager.ChangeSpriteToDeath();
    }

    void Death()
    {
        if (!isAlive)
        {
            Destroy(gameObject, timeToDestroy);
        }
        else return;
    }
}
