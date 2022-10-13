using System.Collections.Generic;
using UnityEngine;

public class EnemySingleShooter : MonoBehaviour
{
    [Header("References")]
    public GunBase gunBase;
    public GameObject enemyCannonBallPrefab;
    public Transform player;
    public EnemyRadarTrigger radarTrigger;

    [Header("List of Guns")]
    public List<Transform> frontalGun;

    [Header("Layer Reference")]
    public LayerMask playerLayer;

    [Header("Setup")]
    public float rotationSpeed = .2f;
    //[HideInInspector] public bool canAim = false;
    public bool canAim = false;

    private void OnValidate()
    {
        if (gunBase == null) gunBase = GetComponentInParent<GunBase>();
        if (radarTrigger == null) radarTrigger = GetComponentInChildren<EnemyRadarTrigger>();
    }

    private void Awake()
    {
        if (player == null) player = GameObject.Find("=== PLAYER ===").GetComponent<Transform>();
    }

    private void Update()
    {
        if (radarTrigger.triggered == true) canAim = true;

        transform.Rotate(Vector3.forward * rotationSpeed);

        if (canAim)
        {
            var left45 = (transform.up - transform.right).normalized;
            var right45 = (transform.up + transform.right).normalized;

            RaycastHit2D hitFrontLeft = Physics2D.Raycast(transform.position, left45 * 5, 5, playerLayer);
            RaycastHit2D hitFrontRight = Physics2D.Raycast(transform.position, right45 * 5, 5, playerLayer);
            RaycastHit2D hitBackRight = Physics2D.Raycast(transform.position, -left45 * 5, 5, playerLayer);
            //RaycastHit2D hitBackLeft = Physics2D.Raycast(transform.position, -right45 * 5, 5, playerLayer);

            Debug.DrawRay(transform.position, left45 * 5, Color.magenta);
            Debug.DrawRay(transform.position, right45 * 5, Color.magenta);
            Debug.DrawRay(transform.position, -left45 * 5, Color.magenta);
            //Debug.DrawRay(transform.position, -right45 * 5, Color.magenta);

            if (gunBase.timer <= 0)
            {
                if (hitFrontLeft.collider != null)
                {
                    EnemyShoot(0);
                }

                if(hitFrontRight.collider != null)
                {
                    EnemyShoot(1);
                    rotationSpeed *= -1;
                }

                if(hitBackRight.collider != null)
                {
                    rotationSpeed *= -1;
                }
            }
        }
    }

    void EnemyShoot(int i)
    {
        gunBase.timer = gunBase.shootCooldown;

        gunBase.StartCoroutine(gunBase.VFXCoroutine(frontalGun[i].transform));

        var cannonBall = Instantiate(enemyCannonBallPrefab);
        cannonBall.transform.SetPositionAndRotation(frontalGun[i].transform.position, frontalGun[i].transform.rotation);
    }
}
