using UnityEngine;

public class ExplosionSelfDestruction : MonoBehaviour
{
    [SerializeField] float timeToSelfDestroy = .2f;

    private void OnEnable()
    {
        Invoke(nameof(SelfDestruction), timeToSelfDestroy);
    }

    void SelfDestruction()
    {
        Destroy(gameObject);
    }
}
