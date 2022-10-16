using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Health health;

    [Header("Health Bar")]
    [SerializeField] List<Sprite> healthBarSprites;
    [SerializeField] SpriteRenderer healthBarSpriteRenderer;
    int _index;

    private void OnValidate()
    {
        if (healthBarSprites == null) healthBarSpriteRenderer = GetComponent<SpriteRenderer>();
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
        if (health == null) health = GetComponentInParent<Health>();
        _index = 0;
        healthBarSpriteRenderer.sprite = healthBarSprites[_index];
    }

    public void TakeDamage()
    {
        _index++;

        if (_index == healthBarSprites.Count - 1)
        {
            healthBarSpriteRenderer.sprite = healthBarSprites[_index];
            return;
        }

        healthBarSpriteRenderer.sprite = healthBarSprites[_index];
    }

    public void ChangeSpriteToDeath()
    {
        if (!health.isAlive)
        {
            var index = healthBarSprites.Count - 1;
            healthBarSpriteRenderer.sprite = healthBarSprites[index];
        }
    }
}
