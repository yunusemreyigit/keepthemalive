using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class Sin_Graph : MonoBehaviour
{
    public int resolution = 100;
    public float amplitude = 1f; // Range -> [-1.5f , 1.5f]
    public float frequency = 1f; // Range -> [1f , 10f]
    public float length = 6.3f;
    public Vector2 offset = new Vector2(-3.15f, 1.2f);
    public Color color = Color.black;
    private float zOffset = -6f;
    private LineRenderer lineRenderer;
    void OnEnable()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.material.color = color;
        amplitude = Random.Range(0.5f, 1.5f);
        frequency = Random.Range(1f, 10f);
    }
    void Update()
    {
        lineRenderer.positionCount = resolution + 1;
        Vector3[] points = new Vector3[resolution + 1];

        for (int i = 0; i <= resolution; i++)
        {
            float x = i / (float)resolution * length + offset.x;
            float y = Mathf.Sin(x * frequency) * amplitude + offset.y;
            float z = zOffset;
            points[i] = new Vector3(x, y, z);
        }
        lineRenderer.SetPositions(points);
    }
}