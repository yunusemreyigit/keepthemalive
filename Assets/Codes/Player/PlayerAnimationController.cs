using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private MovementMechanism movement;
    private Battery battery;
    private float scale = 0.4f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        battery = GetComponent<Battery>();
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
        BatteryDeadAnim(battery.isBatteryDead);

    }
    private void BatteryDeadAnim(bool value)
    {
        animator.SetBool("battery_dead", value);
    }
}
