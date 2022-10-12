using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Header("References")]
    public CharacterController characterController;

    [Header("Movement Speed")]
    [Range(0, 3)] public float playerDefaultSpeed = 1f;
    float _currPlayerSpeed;

    [Header("Slow")]
    public float desacelerationTime;

    [Header("Rotate Speed")]
    [Range(0, 3)] public float rotationDefaultSpeed = 2f;
    float _currRotationSpeed;

    protected PlayerInputActions playerInputs;

    private void OnValidate()
    {
        if (characterController == null) characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        playerInputs.PlayerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.PlayerInputs.Disable();
    }

    private void Awake()
    {
        playerInputs = new PlayerInputActions();
    }

    private void Start()
    {
        _currPlayerSpeed = playerDefaultSpeed;
        _currRotationSpeed = rotationDefaultSpeed;

        Debug.Log("Fazer a aceleração e desaceleração dos barcos");
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 _moveInputs = playerInputs.PlayerInputs.Movement.ReadValue<Vector2>();
        Vector2 _movement = new Vector3(0f, _moveInputs.y);
        transform.Translate(_movement * Time.deltaTime * _currPlayerSpeed, Space.Self);

        float _rotate = playerInputs.PlayerInputs.Movement.ReadValue<Vector2>().x;
        transform.Rotate(_currRotationSpeed * _rotate * Time.deltaTime * Vector3.forward * -1);
    }
}
