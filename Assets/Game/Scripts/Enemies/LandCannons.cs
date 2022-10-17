using UnityEngine;

public class LandCannons : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GunBase gunBase;
    [SerializeField] GameObject cannonBallPrefab;

    [Header("Setup")]
    [SerializeField] bool canRotate;
    [Range(30f, 180f)][SerializeField] int maxAngleRotation;
    [Range(1f, 15f)][SerializeField] float speedRotation;
    float initialRotationPositionZ;
    float timer;
    [Range(2f, 10f)][SerializeField] float distanceRange = 5f;
    [SerializeField] LayerMask layerToShoot;
    [SerializeField] Transform positionToShoot;

    [Header("Checks")]
    [SerializeField] bool playerLives = true;

    private void OnValidate()
    {
        if (gunBase == null) 
            gunBase = GetComponent<GunBase>();
        if (positionToShoot == null) 
            positionToShoot = GetComponentInChildren<Transform>();
    }

    #region Actions
    private void OnEnable()
    {
        Actions.playerDied += CheckPlayerDeath;
    }

    private void OnDisable()
    {
        Actions.playerDied -= CheckPlayerDeath;
    }
    #endregion

    private void Start()
    {
        playerLives = true;
        initialRotationPositionZ = transform.eulerAngles.z;
        if (speedRotation == 0) speedRotation = Random.Range(10, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLives) SearchForTarget();

        if (canRotate) LandCannonRotation();
    }

    void CheckPlayerDeath()
    {
        playerLives = false;
    }

    void SearchForTarget()
    {
        Debug.DrawRay(transform.position, transform.right * distanceRange, Color.magenta);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * distanceRange, 5, layerToShoot);

        if (gunBase.timer <= 0)
        {
            if (hit.collider != null)
            {
                LandCannonShoot();
            }
        }
    }

    void LandCannonShoot()
    {
        gunBase.timer = gunBase.shootCooldown;

        gunBase.StartCoroutine(gunBase.VFXCoroutine(positionToShoot));

        GameObject cannonBall = Instantiate(cannonBallPrefab);
        cannonBall.transform.SetPositionAndRotation(positionToShoot.position, positionToShoot.rotation);
        gunBase.sfxPool.Play(SFXType.CANNON_SHOOT);
    }

    void LandCannonRotation()
    {
        float currRotation = transform.eulerAngles.z;

        if (timer > 0) timer -= Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, speedRotation * Time.deltaTime));

        if (currRotation > initialRotationPositionZ + maxAngleRotation || currRotation < initialRotationPositionZ)
        {
            if (timer <= 0)
            {
                timer = 1;
                speedRotation *= -1;
            }
        }
    }
}
