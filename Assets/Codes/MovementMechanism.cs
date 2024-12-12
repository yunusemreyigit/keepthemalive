using UnityEngine;

public class MovementMechanism : MonoBehaviour
{
    public float speed = 1f;
    private float move;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }
}