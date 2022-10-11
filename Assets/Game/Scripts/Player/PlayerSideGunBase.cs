using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSideGunBase : GunBase
{
    public GunBase gunBase;
    public List<Transform> leftGunsPositions;
    public List<Transform> rightGunsPositions;

    public float shootCooldown = 3;
    float timer = 0;

    protected PlayerInputActions inputs;

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    private void Awake()
    {
        inputs = new PlayerInputActions();

        inputs.PlayerInputs.RightSideTripleShoot.performed += ctx => StartShoot(false);
        inputs.PlayerInputs.LeftSideTripleShoot.performed += ctx => StartShoot(true);
    }

    private void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
    }

    private void StartShoot(bool isLeftSide)
    {
        if (timer <= 0)
        {
            timer = shootCooldown;
            //gunBase.Shoot();
            StartCoroutine(ShootCoroutine(isLeftSide));
        }
    }

    IEnumerator ShootCoroutine(bool isLeftSide)
    {
        if (isLeftSide)
        {
            foreach (var cannon in leftGunsPositions)
            {
                var pos = cannon.transform;
                Shoot(pos);
            }
        }

        if (!isLeftSide)
        {
            foreach (var cannon in rightGunsPositions)
            {
                var pos = cannon.transform;
                Shoot(pos);
            }
        }

        yield return null;
    }
}
