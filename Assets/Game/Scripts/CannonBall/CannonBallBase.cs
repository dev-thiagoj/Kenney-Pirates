using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonBallBase : MonoBehaviour
{
    [Header("Setup")]
    public int damageAmount = 1;
    public float speed;

    [Header("Tags")]
    public List<string> tagsToHit;
    public List<string> tagsToIgnore;

    [Header("VFX")]
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject hitExplosionPrefab;
    [SerializeField] float hitExplosionDuration = .1f;
    Vector3 _hitPoint;

    private void OnValidate()
    {
        if(spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnBecameInvisible()
    {
        SetProjectileDisable();
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);

        Debug.DrawRay(transform.position, transform.up / 5, Color.magenta);
    }

    void SetProjectileDisable()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var t in tagsToHit)
        {

            if (collision.transform.CompareTag(t))
            {
                var damageable = collision.transform.GetComponent<IDamageable>();
                IdentifyHitPoint();

                if (damageable != null)
                {
                    /*Vector3 dir = collision.transform.position - transform.position;
                    dir = -dir.normalized;
                    dir.y = 0;*/

                    damageable.Damage(damageAmount);
                }
                break;
            }
        }

        foreach (var t in tagsToIgnore)
        {
            if (collision.transform.CompareTag(t))
                return;
        }

        SetProjectileDisable();
    }


    void IdentifyHitPoint()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up / 5, 5, enemyLayer);

        if (hit.collider != null)
        {
            _hitPoint = hit.point;

            var localExplosion = Instantiate(hitExplosionPrefab);
            localExplosion.transform.position = _hitPoint;
        }
    }
}
