using UnityEngine;
public class OxygenGame_Pointer : MonoBehaviour
{
    public OxygenGame_Goal goal;
    public float force = 4f;
    private Rigidbody2D rb;
    public float timer = 0f;
    public bool isDone = false;
    public bool isInTheCollider = false;
    private Vector3 StartPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartPosition = transform.position;
    }
    void OnEnable()
    {
        timer = 0f;
        isDone = false;
        isInTheCollider = false;
    }
    void OnDisable()
    {
        transform.position = StartPosition;
        rb.gravityScale = 1f;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    void Update()
    {
        if (timer > 0f && !isInTheCollider)
            timer -= Time.deltaTime;
        if (isDone)
            timer += Time.deltaTime;
        if (timer > 25f)
        {
            rb.gravityScale = 1f;
            rb.bodyType = RigidbodyType2D.Dynamic;
            goal.isDone = isDone = false;
            timer = 0f;
        }
    }
    public void Flap()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, force);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            isInTheCollider = true;
            timer += Time.deltaTime;
            if (timer > 3f) 
            {
                rb.linearVelocity = Vector2.zero;
                rb.gravityScale = 0f;
                rb.bodyType = RigidbodyType2D.Kinematic;
                goal.isDone = isDone = true;
                timer = 0f;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isInTheCollider = false;
    }
}