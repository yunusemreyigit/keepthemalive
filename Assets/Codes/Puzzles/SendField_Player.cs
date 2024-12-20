using UnityEngine;
public class PlayerMovement : Puzzle
{
    public float speed = 3f;
    private Vector3 PlayerStartPosition;
    void Start()
    {
        PlayerStartPosition = transform.position;
    }
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;
        transform.position += movement;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
            ClosePanel();
        if (other.CompareTag("Obstacle"))
            transform.position = PlayerStartPosition;
    }
}