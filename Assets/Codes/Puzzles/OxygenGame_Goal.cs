using UnityEngine;
public class OxygenGame_Goal : MonoBehaviour
{
    private float range = 1.6f;
    private float speed = 1.5f;
    private Vector3 pointA;
    private Vector3 pointB;
    private bool isMovingToB = true;
    public bool isDone = false;
    private Vector3 StartPosition;
    void Start()
    {
        StartPosition = transform.position;
    }
    void OnEnable()
    {
        pointA = new Vector3(transform.position.x, transform.position.y - Random.Range(range/2,range), transform.position.z);
        pointB = new Vector3(transform.position.x, transform.position.y + Random.Range(range/2,range), transform.position.z);
        isMovingToB = true;
        isDone = false;
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
            if (Vector3.Distance(transform.position, pointB) < 0.1f) isMovingToB = false;
        }
        else 
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, pointA) < 0.1f) isMovingToB = true;
        }
    }
}