using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public ShipFrontalGun frontalGun;
    public GunBase gunBase;

    public GameObject enemyCannonBallPrefab;
    public Transform player;
    public bool canAim;
    public LayerMask playerLayer;

    private void OnValidate()
    {
        if (frontalGun == null) frontalGun = GetComponentInChildren<ShipFrontalGun>();
        if (gunBase == null) gunBase = GetComponentInParent<GunBase>();
    }

    private void Start()
    {
        if (player == null) player = GameObject.Find("=== PLAYER ===").GetComponent<Transform>();
    }

    private void Update()
    {
        if (!canAim) transform.Rotate(Vector3.forward * .2f);

        if (canAim)
        {
            transform.up = Vector3.Lerp(transform.up, (player.position - transform.position), .3f * Time.deltaTime);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up * 5, 5, playerLayer);
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position, transform.right * 5, 5, playerLayer);

            Debug.DrawRay(transform.position, transform.up * 5, Color.magenta);
            Debug.DrawRay(transform.position, transform.right * 5, Color.green);
            Debug.DrawRay(transform.position, transform.right * -5, Color.green);

            if (gunBase.timer <= 0)
            {
                if (hit.collider != null)
                {
                    Debug.Log("Player detectado");
                    //TODO: enemy shoot
                    //frontalGun.StartShoot();
                    EnemyShoot();
                }
                else
                {
                    Debug.Log("Nao detectado");
                    //TODO: enemy stop shoot
                }
            }
        }
    }

    void EnemyShoot()
    {
        gunBase.timer = gunBase.shootCooldown;

        gunBase.StartCoroutine(gunBase.VFXCoroutine(frontalGun.transform));

        var cannonBall = Instantiate(enemyCannonBallPrefab);
        cannonBall.transform.SetPositionAndRotation(frontalGun.transform.position, frontalGun.transform.rotation);
    }
}
