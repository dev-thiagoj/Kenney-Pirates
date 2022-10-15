using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSideGun : MonoBehaviour
{
    [Header("- References")]
    [SerializeField] GunBase gunBase;

    [Header("- Lists of Cannons")]
    [SerializeField] public List<Transform> leftGunsPositions;
    [SerializeField] public List<Transform> rightGunsPositions;

    [Header("- SFX")]
    [SerializeField] List<AudioSource> audioSources;
    [Range(1f, 10f)]
    [SerializeField] float delayBetweenShoots;

    protected PlayerInputActions inputs;

    void OnEnable()
    {
        inputs.Enable();
    }

    void OnDisable()
    {
        inputs.Disable();
    }

    void OnValidate()
    {
        if (gunBase == null) gunBase = GetComponentInParent<GunBase>();
    }

    void Awake()
    {
        inputs = new PlayerInputActions();

        inputs.PlayerInputs.RightSideTripleShoot.performed += ctx => StartShoot(false);
        inputs.PlayerInputs.LeftSideTripleShoot.performed += ctx => StartShoot(true);
    }

    void StartShoot(bool isLeftSide)
    {
        if (gunBase.timer <= 0)
        {
            if (isLeftSide)
            {
                foreach (var cannon in leftGunsPositions)
                {
                    var pos = cannon.transform;
                    gunBase.Shoot(pos);
                }
            }

            if (!isLeftSide)
            {
                foreach (var cannon in rightGunsPositions)
                {
                    var pos = cannon.transform;
                    gunBase.Shoot(pos);
                }
            }

            StartCoroutine(TripleShootSFXCoroutine());
        }
    }

    IEnumerator TripleShootSFXCoroutine()
    {
        for(int i = 0; i < audioSources.Count; i++)
        {
            audioSources[i].Play();
            yield return new WaitForSeconds(delayBetweenShoots/100);
        }
    }
}
