using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    
    [Range(.1f, 1)] [SerializeField] float animationSpeed = 1;

    private void OnValidate()
    {
        if (animator == null) 
            animator = GetComponent<Animator>();
    }

    void Start()
    {
        animator.Play("VCamStartAnim", -1, 0);
        animator.speed = animationSpeed;
    }
}
