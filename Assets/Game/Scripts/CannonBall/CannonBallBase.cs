using System.Collections.Generic;
using UnityEngine;

public class CannonBallBase : MonoBehaviour
{
    public float timeToDestroy;

    public int damageAmount;
    public float speed;

    [Header("Tags")]
    public List<string> tagsToHit;
    public List<string> tagsToIgnore;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
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

        gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        SetProjectileDisable();
    }
}
