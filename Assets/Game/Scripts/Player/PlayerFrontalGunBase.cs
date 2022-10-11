using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrontalGunBase : GunBase
{
    public Transform gunPosition;

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

        inputs.PlayerInputs.FrontalSingleShoot.performed += ctx => StartShoot();
    }

    private void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
    }

    private void StartShoot()
    {
        if (timer <= 0)
        {
            timer = shootCooldown;
            Shoot(this.transform);
        }
    }
}
