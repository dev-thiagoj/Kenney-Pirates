using UnityEngine;

public class EnemyRadarTrigger : MonoBehaviour
{
    [HideInInspector] public bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            triggered = true;
        }
    }
}
