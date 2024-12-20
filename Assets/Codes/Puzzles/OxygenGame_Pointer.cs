using UnityEngine;
public class OxygenGame_Pointer : MonoBehaviour
{
    public OxygenGame_Goal goal;
    public float force = 4f;
    private Rigidbody2D rb;
    public float timer = 0f;
    public bool isDone = false;
    public bool isInTheCollider = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            rb.isKinematic = false;
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
        isInTheCollider = true;
        timer += Time.deltaTime;
        if (timer > 3f) {
            rb.linearVelocity = Vector2.zero;
            rb.gravityScale = 0f;
            rb.isKinematic = true;
            goal.isDone = isDone = true;
            timer = 0f;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isInTheCollider = false;
    }
}