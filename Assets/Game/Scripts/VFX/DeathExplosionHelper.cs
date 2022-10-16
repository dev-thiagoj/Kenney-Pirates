using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathExplosionHelper : MonoBehaviour
{
    public Transform fireAnim;

    public void InstantiateFireAtTheEnd()
    {
        var fire = Instantiate(fireAnim);
        var fireRotation = new Quaternion(0, 0, 0, 0);
        fire.transform.SetPositionAndRotation(transform.position, fireRotation);

        Destroy(gameObject);
    }
}
