using System.Collections.Generic;
using UnityEngine;

public class EnemySingleShooter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GunBase gunBase;
    [SerializeField] GameObject enemyCannonBallPrefab;
    [SerializeField] EnemyRadarTrigger radarTrigger;
    [SerializeField] Health health;

    [Header("List of Guns")]
    [SerializeField] List<Transform> frontalGun;

    [Header("Layer Reference")]
    [SerializeField] LayerMask playerLayer;

    [Header("Setup")]
    [SerializeField] float rotationSpeed = .2f;

    [Header("Checks")]
    [SerializeField] bool canAim = false;
    [SerializeField] bool isAlive = true;

    private void OnValidate()
    {
        if (gunBase == null) 
            gunBase = GetComponentInParent<GunBase>();
        if (radarTrigger == null) 
            radarTrigger = GetComponentInChildren<EnemyRadarTrigger>();
        if (health == null) 
            health = GetComponent<Health>();
    }

    #region Actions
    private void OnEnable()
    {
        Actions.playerDied += CheckPlayerDeath;
    }
    private void OnDisable()
    {
        Actions.playerDied -= CheckPlayerDeath;
    }
    #endregion

    private void Update()
    {
        if (radarTrigger.triggered == true) canAim = true;

        if (health.isAlive)
        {
            transform.Rotate(Vector3.forward * rotationSpeed);

            if (canAim)
            {
                Vector3 left45 = (transform.up - transform.right).normalized;
                Vector3 right45 = (transform.up + transform.right).normalized;

                Debug.DrawRay(transform.position, left45 * 8, Color.magenta);
                Debug.DrawRay(transform.position, right45 * 8, Color.magenta);
                Debug.DrawRay(transform.position, -left45 * 8, Color.magenta);

                RaycastHit2D hitFrontLeft = Physics2D.Raycast(transform.position, left45 * 8, 5, playerLayer);
                RaycastHit2D hitFrontRight = Physics2D.Raycast(transform.position, right45 * 8, 5, playerLayer);
                RaycastHit2D hitBackRight = Physics2D.Raycast(transform.position, -left45 * 8, 5, playerLayer);

                if (gunBase.timer <= 0)
                {
                    if (hitFrontLeft.collider != null) EnemyShoot(0);

                    if (hitFrontRight.collider != null)
                    {
                        EnemyShoot(1);
                        rotationSpeed *= -1;
                    }

                    if (hitBackRight.collider != null) rotationSpeed *= -1;
                }
            }
        }
    }

    void EnemyShoot(int i)
    {
        gunBase.timer = gunBase.shootCooldown;

        gunBase.StartCoroutine(gunBase.VFXCoroutine(frontalGun[i].transform));

        GameObject cannonBall = Instantiate(enemyCannonBallPrefab);
        cannonBall.transform.SetPositionAndRotation(frontalGun[i].transform.position, frontalGun[i].transform.rotation);
        gunBase.sfxPool.Play(SFXType.CANNON_SHOOT);
    }

    void CheckPlayerDeath()
    {
        canAim = false;
    }
}
