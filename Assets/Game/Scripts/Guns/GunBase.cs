using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public bool isPlayer;

    [Range(0, 5)] public float shootCooldown;

    [Header("VFX")]
    public GameObject shootVFX;
    [Range(0, 1)] public float vfxDuration;

    [Header("SFX")]
    //public SFXType sfxType;
    AudioSource audioSource;

    [HideInInspector] public float timer = 0;


    private void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
    }

    public void Shoot(Transform pos)
    {
        timer = shootCooldown;
        var projectile = CannonBallPooler.Instance.GetPooledObject();
        projectile.SetActive(true);
        projectile.transform.SetPositionAndRotation(pos.position, pos.rotation);
        StartCoroutine(VFXCoroutine(pos));
    }

    protected void PlayShootSFX()
    {
        //SFXPool.Instance.Play(sfxType);
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
