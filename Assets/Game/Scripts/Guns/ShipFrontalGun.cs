using UnityEngine;

public class ShipFrontalGun : MonoBehaviour
{
    public GunBase gunBase;

    protected PlayerInputActions inputs;

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    private void OnValidate()
    {
        gunBase = GetComponentInParent<GunBase>();
    }

    private void Awake()
    {
        inputs = new PlayerInputActions();

        if (gunBase.isPlayer) inputs.PlayerInputs.FrontalSingleShoot.performed += ctx => StartShoot();
    }

    private void Start()
    {
        if (gunBase == null) gunBase = GameObject.Find("FrontalShootPoint").GetComponent<GunBase>();
    }

    public void StartShoot()
    {
        if (gunBase.timer <= 0)
        {
            gunBase.Shoot(this.transform);
        }
    }

    /*public void EnemyStartShoot(bool isPlayer)
    {
        if (isPlayer)
            if (!isPlayer)
            {
                if (gunBase.timer <= 0)
                {
                    gunBase.Shoot(this.transform);
                }
            }
    }*/
}
