using UnityEngine;

public class PlayerFrontalGunBase : MonoBehaviour
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

        inputs.PlayerInputs.FrontalSingleShoot.performed += ctx => StartShoot();
    }

    private void Start()
    {
        if (gunBase == null) gunBase = GameObject.Find("FrontalShootPoint").GetComponent<GunBase>();
    }

    private void StartShoot()
    {
        if (gunBase.timer <= 0)
        {
            gunBase.Shoot(this.transform);
        }
    }
}
