using UnityEngine;
public class PressureGame_Pointer : MonoBehaviour
{
    public float rangeY = 2f;
    public float speed = 2f;
    private Vector3 pointA;
    private Vector3 pointB;
    private bool isMovingToB = true;
    public bool isOnTheGoal = false;
    public bool isDone = false;
    private Vector3 StartPosition;
    void Start()
    {
        StartPosition = transform.position;
    }
    void OnEnable()
    {
        isMovingToB = true;
        isOnTheGoal = false;
        isDone = false;
        pointA = new Vector3(transform.position.x, transform.position.y - rangeY, transform.position.z);
        pointB = new Vector3(transform.position.x, transform.position.y + rangeY, transform.position.z);
    }
    void OnDisable()
    {
        transform.position = StartPosition;
    }
    void Update()
    {
        if (isDone) return;
        if (isMovingToB)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, pointB) < 0.3f) isMovingToB = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, pointA) < 0.3f) isMovingToB = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
            isOnTheGoal = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
            isOnTheGoal = false;
    }
}