using System;
using System.Collections;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    [Header("References")]
    public Health health;
    public SFXPool sfxPool;

    [Header("Checks")]
    public bool isPlayer;

    [Range(0, 5)] public float shootCooldown = 2.5f;

    [Header("VFX")]
    public GameObject shootVFX;
    [Range(0, 1)] public float vfxDuration = .3f;

    [Header("SFX")]
    [SerializeField] SFXManager sfxManager;

    [HideInInspector] public float timer = 0;

    private void Awake()
    {
        if (sfxPool == null) 
            sfxPool = GameObject.Find("=== MANAGERS ===").GetComponentInChildren<SFXPool>();
        if (sfxManager == null) 
            sfxManager = GameObject.Find("=== MANAGERS ===").GetComponentInChildren<SFXManager>();
    }

    private void Start()
    {
        if (isPlayer)
        {
            if (health == null) 
                health = GetComponent<Health>();
        }
    }

    private void Update()
    {
        if (timer > 0) 
            timer -= Time.deltaTime;

        if (isPlayer && !health.isAlive)
        {
            Actions.saveDataInPlayerPrefs.Invoke();

            if(timer <= 0)
            {
                timer = 5;
                sfxManager.PlayMusicbyType(MusicType.LEVEL_LOSE);
            }
        }

    }

    public void Shoot(Transform pos)
    {
        if (health.isAlive)
        {
            timer = shootCooldown;
            var projectile = CannonBallPooler.Instance.GetPooledObject();
            projectile.SetActive(true);
            projectile.transform.SetPositionAndRotation(pos.position, pos.rotation);
            StartCoroutine(VFXCoroutine(pos));
            PlayShootSFX();
            return;
        }
        return;
    }

    protected void PlayShootSFX()
    {
        sfxPool.Play(SFXType.CANNON_SHOOT);
    }

    public IEnumerator VFXCoroutine(Transform pos)
    {
        var vfx = Instantiate(shootVFX).transform;
        vfx.SetParent(pos);
        vfx.SetPositionAndRotation(pos.position, pos.rotation);
        yield return new WaitForSeconds(vfxDuration);
        Destroy(vfx.gameObject);
    }
}
