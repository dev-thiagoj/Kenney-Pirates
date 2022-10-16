using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensorToSpawnEnemy : MonoBehaviour
{
    [SerializeField] CircleCollider2D trigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Respawn"))
        {
            var respawn = collision.transform.GetComponent<SpawnCheckPlayerPosition>();

            if (respawn != null)
            {
                respawn.canSpawn = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Respawn"))
        {
            var respawn = collision.transform.GetComponent<SpawnCheckPlayerPosition>();

            if (respawn != null)
            {
                respawn.canSpawn = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Respawn"))
        {
            var respawn = collision.transform.GetComponent<SpawnCheckPlayerPosition>();

            if (respawn != null)
            {
                respawn.canSpawn = true;
            }
        }
    }
}
