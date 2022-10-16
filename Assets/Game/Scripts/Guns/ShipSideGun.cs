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

    #region Enable Inputs
    void OnEnable()
    {
        inputs.Enable();
    }

    void OnDisable()
    {
        inputs.Disable();
    }
    #endregion

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

    void StartShoot(bool b)
    {
        StartCoroutine(TripleSideShootCoroutine(b));
    }

    IEnumerator TripleSideShootCoroutine(bool isLeftSide)
    {
        if (gunBase.timer <= 0)
        {
            if (isLeftSide)
            {
                for (int i = 0; i < leftGunsPositions.Count; i++)
                {
                    var position = leftGunsPositions[i].transform;
                    gunBase.Shoot(position);
                    yield return new WaitForSeconds(.05f);
                }
            }

            if (!isLeftSide)
            {
                for (int i = 0; i < rightGunsPositions.Count; i++)
                {
                    var position = rightGunsPositions[i].transform;
                    gunBase.Shoot(position);
                    yield return new WaitForSeconds(.05f);
                }
            }

            StartCoroutine(TripleShootSFXCoroutine());
        }
    }

    IEnumerator TripleShootSFXCoroutine()
    {
        for (int i = 0; i < audioSources.Count; i++)
        {
            audioSources[i].Play();
            yield return new WaitForSeconds(delayBetweenShoots / 100);
        }
    }
}
