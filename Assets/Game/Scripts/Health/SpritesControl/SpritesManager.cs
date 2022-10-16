using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] GameObject finalExplosionPrefab;
    [SerializeField] float explosionDuration = .3f;
    [SerializeField] bool hasExploded;

    private void OnValidate()
    {
        if (shipSpriteRenderer == null) shipSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (health == null) health = GetComponent<Health>();
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

    // Start is called before the first frame update
    void Start()
    {
        _index = 0;
        shipSpriteRenderer.sprite = shipHealthSprites[_index];
    }

    [NaughtyAttributes.Button]
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

    public void ChangeSpriteToDeath()
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
        var explosion = Instantiate(finalExplosionPrefab);
        explosion.transform.SetParent(transform);
        explosion.GameObject().transform.position = transform.position;

        yield return new WaitForSeconds(explosionDuration);
        Destroy(explosion);
        Actions.executeDeath.Invoke();
        StopCoroutine(PerformDeathExplosion());
    }

}
