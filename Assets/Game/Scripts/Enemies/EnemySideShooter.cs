using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySideShooter : MonoBehaviour
{
    [Header("References")]
    public GunBase gunBase;
    public ShipSideGun sideGun;
    public GameObject enemyCannonBallPrefab;
    public Transform player;
    public EnemyRadarTrigger radarTrigger;

    [Header("Layer Reference")]
    public LayerMask playerLayer;

    public bool canAim = false;

    private void OnValidate()
    {
        if (sideGun == null) sideGun = GetComponentInChildren<ShipSideGun>();
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

        //if (!canAim) transform.Rotate(Vector3.forward * .2f);

        transform.Rotate(Vector3.forward * .2f);

        if (canAim)
        {
            //transform.right = Vector3.Lerp(transform.right, (player.position - transform.position), .3f * Time.deltaTime);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * 8, 5, playerLayer);
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position, transform.right * 8, 5, playerLayer);

            Debug.DrawRay(transform.position, transform.right * 15, Color.magenta);
            Debug.DrawRay(transform.position, transform.right * -15, Color.magenta);

            if (gunBase.timer <= 0)
            {
                Debug.Log("Hit0");

                if (hit.collider != null)
                {
                    Debug.Log("hit1");
                    StartShoot(false);
                }

                if(hit2.collider != null)
                {
                    Debug.Log("hit2");
                    StartShoot(true);
                }
            }
        }
    }

    /*void EnemyShoot()
    {
        gunBase.timer = gunBase.shootCooldown;

        gunBase.StartCoroutine(gunBase.VFXCoroutine(sideGun.transform));

        var cannonBall = Instantiate(enemyCannonBallPrefab);
        cannonBall.transform.SetPositionAndRotation(sideGun.transform.position, sideGun.transform.rotation);
    }*/

    void StartShoot(bool isLeftSide)
    {
       

        if (gunBase.timer <= 0)
        {
            if (isLeftSide)
            {
                foreach (var cannon in sideGun.leftGunsPositions)
                {
                    gunBase.timer = gunBase.shootCooldown;
                    gunBase.StartCoroutine(gunBase.VFXCoroutine(cannon.transform));

                    var cannonBall = Instantiate(enemyCannonBallPrefab);
                    cannonBall.transform.SetPositionAndRotation(cannon.transform.position, cannon.transform.rotation);
                }
            }

            if (!isLeftSide)
            {
                foreach (var cannon in sideGun.rightGunsPositions)
                {
                    gunBase.timer = gunBase.shootCooldown;
                    gunBase.StartCoroutine(gunBase.VFXCoroutine(cannon.transform));

                    var cannonBall = Instantiate(enemyCannonBallPrefab);
                    cannonBall.transform.SetPositionAndRotation(cannon.transform.position, cannon.transform.rotation);
                }
            }
        }
        //else return;
    }
}
