using UnityEngine;

public class MovementMechanism : MonoBehaviour
{
    public bool canMove;
    public float speed = 1f;
    [SerializeField] public float move;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!canMove) return;
        move = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
    }
}