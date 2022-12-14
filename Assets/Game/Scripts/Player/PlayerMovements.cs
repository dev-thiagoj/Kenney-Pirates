using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Header("References")]
    [SerializeField] SpritesManager spritesManager;
    [SerializeField] Health health;

    [Header("Movement Speed")]
    [Range(0, 3)] public float playerDefaultSpeed = 1f;
    float _currPlayerSpeed;

    [Header("Rotate Speed")]
    [Range(0, 3)] public float rotationDefaultSpeed = 2f;
    float _currRotationSpeed;

    [Header("Checks")]
    public bool canMove = true;

    protected PlayerInputActions playerInputs;

    #region Actions
    private void OnEnable()
    {
        playerInputs.PlayerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.PlayerInputs.Disable();
    }
    #endregion

    private void OnValidate()
    {
        if (spritesManager == null) 
            spritesManager = GetComponent<SpritesManager>();
        if (health == null) 
            health = GetComponent<Health>();
    }

    private void Awake()
    {
        playerInputs = new PlayerInputActions();
    }

    private void Start()
    {
        _currPlayerSpeed = playerDefaultSpeed;
        _currRotationSpeed = rotationDefaultSpeed;
    }

    private void Update()
    {
        if (!health.isAlive)
        {
            canMove = false;
            Actions.playerDied.Invoke();
        }   
    }

    private void FixedUpdate()
    {
        if (canMove) 
            PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 _moveInputs = playerInputs.PlayerInputs.Movement.ReadValue<Vector2>();
        Vector2 _movement = new Vector3(0f, _moveInputs.y);
        transform.Translate(_currPlayerSpeed * Time.deltaTime * _movement, Space.Self);

        float _rotate = playerInputs.PlayerInputs.Movement.ReadValue<Vector2>().x;
        transform.Rotate(_currRotationSpeed * _rotate * -1 * Time.deltaTime * Vector3.forward);
    }
}
