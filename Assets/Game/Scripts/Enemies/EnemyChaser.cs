using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public EnemyRadarTrigger radarTrigger;

    public bool canPursuit;

    private void OnValidate()
    {
        if (radarTrigger == null) radarTrigger = GetComponentInChildren<EnemyRadarTrigger>();
        if(rb == null) rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        if (player == null) player = GameObject.Find("=== PLAYER ===").GetComponent<Transform>();
    }

    private void Update()
    {
        if (radarTrigger.triggered == true) canPursuit = true;

        transform.up = Vector3.Lerp(transform.up, (player.position - transform.position), 1f * Time.deltaTime);

        if (canPursuit)
        {
            var lookDirection = (player.transform.position - rb.transform.position).normalized;

            transform.position += lookDirection * .01f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Implementar a troca de sprite p/ destruido");
        }
    }
}
