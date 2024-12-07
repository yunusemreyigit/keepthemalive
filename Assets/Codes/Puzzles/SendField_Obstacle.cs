using UnityEngine;

public class SendField_Obstacle : MonoBehaviour
{
    public float rangeX = 2f;
    public float rangeY = 2f;
    public float speed = 2f;
    private Vector3 pointA;
    private Vector3 pointB;
    private bool isMovingToB = true;
    void Start()
    {
        pointA = new Vector3(transform.position.x - rangeX, transform.position.y - rangeY, transform.position.z);
        pointB = new Vector3(transform.position.x + rangeX, transform.position.y + rangeY, transform.position.z);
    }
    void Update()
    {
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
}