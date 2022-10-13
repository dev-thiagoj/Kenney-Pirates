using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSideGun : MonoBehaviour
{
    [SerializeField] GunBase gunBase;

    [SerializeField] public List<Transform> leftGunsPositions;
    [SerializeField] public List<Transform> rightGunsPositions;

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
        //
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
        }
    }
}
