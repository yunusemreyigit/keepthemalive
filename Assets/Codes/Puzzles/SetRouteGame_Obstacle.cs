using UnityEngine;
public class SetRouteGame_Obstacle : MonoBehaviour
{
    public float gravityStrength = 5f;
    public Vector2 CalculateGravity(Vector2 targetPosition)
    {
        Vector2 direction = (Vector2)transform.position - targetPosition;
        float distance = direction.magnitude;
        if (distance == 0) return Vector2.zero;

        float force = gravityStrength / (distance * distance);
        return direction.normalized * force;
    }
}