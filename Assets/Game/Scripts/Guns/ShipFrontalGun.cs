using UnityEngine;

public class ShipFrontalGun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GunBase gunBase;
    [SerializeField] AudioSource audioSource;

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
        if (gunBase == null) gunBase = GetComponentInParent<GunBase>();
        if(audioSource == null) audioSource = GetComponent<AudioSource>();
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
            audioSource.Play();
        }
    }
}
