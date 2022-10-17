using UnityEngine;

public class EnemyRadarTrigger : MonoBehaviour
{
    [SerializeField] CircleCollider2D radar;
    [Range(5f, 15f)][SerializeField] float radarRadius = 12;
    [HideInInspector] public bool triggered = false;

    private void OnValidate()
    {
        if (radar == null) 
            radar = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        radar.radius = radarRadius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            triggered = true;
        }
    }
}
