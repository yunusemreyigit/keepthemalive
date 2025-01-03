using UnityEngine;
public class SetRouteGame_Player : Puzzle
{
    public Vector2 initialVelocity;
    private Vector3 PlayerStartPosition;
    private Rigidbody2D rb;
    private Vector2 launchStart;
    private bool isMoving = false;
    private bool isDragging = false;
    void Start()
    {
        PlayerStartPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = initialVelocity;
    }
    void OnDisable()
    {
        transform.position = PlayerStartPosition;
        rb.linearVelocity = initialVelocity;
        isMoving = false;
        isDragging = false;
    }
    void FixedUpdate()
    {
        if (!isMoving || rb.linearVelocity.magnitude <= 0.01f) return;
        SetRouteGame_Obstacle[] gravitySources = FindObjectsOfType<SetRouteGame_Obstacle>();
        Vector2 totalForce = Vector2.zero;

        foreach (SetRouteGame_Obstacle source in gravitySources)
            totalForce += source.CalculateGravity(transform.position);

        rb.AddForce(totalForce);
    }
    void Update()
    {
        if (!isMoving && Input.GetMouseButtonDown(0))
        {
            launchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }
        if (!isMoving && Input.GetMouseButtonUp(0) && isDragging)
        {
            Vector2 launchEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 launchDirection = (launchStart - launchEnd).normalized;
            float launchSpeed = (launchStart - launchEnd).magnitude;
            rb.linearVelocity = launchDirection.normalized * launchSpeed * 3f; // Doğrudan Rigidbody'ye hız uygula
            isDragging = false;
            isMoving = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
            ClosePanel();
        if (other.CompareTag("Obstacle")) {
            transform.position = PlayerStartPosition;
            rb.linearVelocity = Vector2.zero;
            isMoving = false;
        }
    }
}