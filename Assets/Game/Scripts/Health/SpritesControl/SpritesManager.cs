using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] List<Sprite> shipHealthSprites;
    [SerializeField] SpriteRenderer shipSpriteRenderer;
    [SerializeField] Health health;

    [Header("Checks")]
    public bool isFinalSprite = false;
    [SerializeField] int _index = 0;

    [Header("Death VFX")]
    [SerializeField] GameObject finalExplosionAnimPrefab;
    [SerializeField] float explosionDuration = .3f;
    [SerializeField] GameObject fireAnimPrefab;
    [SerializeField] bool hasExploded;

    [Header("SFX")]
    [SerializeField] SFXPool sfxPool;

    private void OnValidate()
    {
        if (shipSpriteRenderer == null) 
            shipSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (health == null) 
            health = GetComponent<Health>();
    }

    #region Actions
    private void OnEnable()
    {
        Actions.performDeathExplosion += ChangeSpriteToDeath;
    }

    private void OnDisable()
    {
        Actions.performDeathExplosion -= ChangeSpriteToDeath;
    }
    #endregion

    private void Awake()
    {
        if(sfxPool == null) 
            sfxPool = GameObject.Find("=== MANAGERS ===").GetComponentInChildren<SFXPool>();
    }

    void Start()
    {
        _index = 0;
        shipSpriteRenderer.sprite = shipHealthSprites[_index];
    }
    
    public void TakeDamage()
    {
        _index++;

        if (_index == shipHealthSprites.Count - 1)
        {
            shipSpriteRenderer.sprite = shipHealthSprites[_index];
            isFinalSprite = true;
            return;
        }

        shipSpriteRenderer.sprite = shipHealthSprites[_index];
    }

    void ChangeSpriteToDeath()
    {
        if (!health.isAlive && !hasExploded)
        {
            var index = shipHealthSprites.Count - 1;
            StartCoroutine(PerformDeathExplosion());
            hasExploded = true;
            shipSpriteRenderer.sprite = shipHealthSprites[index];
        }
    }

    IEnumerator PerformDeathExplosion()
    {
        GameObject explosion = Instantiate(finalExplosionAnimPrefab);
        explosion.transform.SetParent(transform);
        explosion.transform.position = transform.position;
        sfxPool.Play(SFXType.DEATH_EXPLOSION);
        
        GameObject fire = Instantiate(fireAnimPrefab);
        fire.transform.SetParent(transform);
        fire.transform.SetPositionAndRotation(transform.position, transform.rotation);

        yield return new WaitForSeconds(explosionDuration);
        Destroy(explosion);
        Actions.executeDeath.Invoke();
        StopCoroutine(PerformDeathExplosion());
    }
}
