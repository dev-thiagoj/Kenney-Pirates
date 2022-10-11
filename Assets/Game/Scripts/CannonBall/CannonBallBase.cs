using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBase : MonoBehaviour
{
    public float timeToDestroy;

    public int damageAmount;
    public float speed;

    [Header("Tags")]
    public List<string> tagsToHit;
    public string tagToIgnore;

    private void OnEnable()
    {
        Invoke(nameof(SetProjectileDisable), timeToDestroy);
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
    }

    void SetProjectileDisable()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (var t in tagsToHit)
        {
            if (collision.transform.CompareTag(t))
            {
                var damageable = collision.transform.GetComponent<IDamageable>();

                if (damageable != null)
                {
                    Vector3 dir = collision.transform.position - transform.position;
                    dir = -dir.normalized;
                    dir.y = 0;

                    damageable.Damage(damageAmount);
                }

                break;
            }
        }

        if (collision.transform.CompareTag(tagToIgnore)) return;

        gameObject.SetActive(false);
        Destroy(gameObject, 1f);
    }
}
