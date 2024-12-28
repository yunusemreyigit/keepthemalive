using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private MovementMechanism movement;
    private float scale = 0.4f;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        movement = GetComponent<MovementMechanism>();
        animator.SetBool("walking", false);
    }

    void Update()
    {
        if (movement.move != 0)
        {
            animator.SetBool("walking", true);
            if (movement.move > 0) transform.localScale = new Vector3(scale, scale, scale);
            if (movement.move < 0) transform.localScale = new Vector3(-scale, scale, scale);
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }
}