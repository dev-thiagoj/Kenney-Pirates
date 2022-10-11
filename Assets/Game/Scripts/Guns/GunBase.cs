using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    //public Transform positionToShoot;

    [Header("SFX")]
    //public SFXType sfxType;
    public AudioSource audioSource;

    protected void Shoot(Transform pos)
    {
        var projectile = CannonBallPooler.Instance.GetPooledObject();
        projectile.SetActive(true);
        projectile.transform.SetPositionAndRotation(pos.position, pos.rotation);
    }

    protected void PlayShootSFX()
    {
        //SFXPool.Instance.Play(sfxType);
    }
}
