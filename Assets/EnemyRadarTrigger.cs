using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadarTrigger : MonoBehaviour
{
    public EnemyShooter enemyShooter;

    private void OnValidate()
    {
        if (enemyShooter == null) enemyShooter = GetComponentInParent<EnemyShooter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            enemyShooter.canAim = !enemyShooter.canAim;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            enemyShooter.canAim = !enemyShooter.canAim;
        }
    }
}
