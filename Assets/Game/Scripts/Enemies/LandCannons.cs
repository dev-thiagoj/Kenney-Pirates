using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandCannons : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GunBase gunBase;

    [Header("Setup")]
    [Range(2f, 10f)]
    [SerializeField] float cannonRange = 5f;
    [SerializeField] LayerMask layerToShoot;
    [SerializeField] Transform positionToShoot;
    [SerializeField] GameObject cannonBallPrefab;

    private void OnValidate()
    {
        if(gunBase == null) gunBase = GetComponent<GunBase>();
        if (positionToShoot == null) positionToShoot = GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.right * cannonRange, Color.magenta);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * cannonRange, 5, layerToShoot);

        if(gunBase.timer <= 0)
        {
            if(hit.collider != null)
            {
                LandCannonShoot();
            }
        }
    }

    void LandCannonShoot()
    {
        gunBase.timer = gunBase.shootCooldown;

        gunBase.StartCoroutine(gunBase.VFXCoroutine(positionToShoot));

        var cannonBall = Instantiate(cannonBallPrefab);
        cannonBall.transform.SetPositionAndRotation(positionToShoot.position, positionToShoot.rotation);
    }
}
