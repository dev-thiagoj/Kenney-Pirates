using UnityEngine;

public class ShipFrontalGun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GunBase gunBase;

    protected PlayerInputActions inputs;

    #region Enable Inputs
    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }
    #endregion

    private void OnValidate()
    {
        if (gunBase == null) 
            gunBase = GetComponentInParent<GunBase>();
    }

    private void Awake()
    {
        inputs = new PlayerInputActions();
    }

    private void Start()
    {
        inputs.PlayerInputs.FrontalSingleShoot.performed += ctx => StartShoot();
    }

    public void StartShoot()
    {   
        if (gunBase.timer <= 0 && gunBase.isPlayer)
        {
            gunBase.Shoot(this.transform);
        }
    }
}
