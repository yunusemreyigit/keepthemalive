using UnityEngine;
public class RotatingButton : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float value = 0f;
    private RectTransform buttonRectTransform;
    private bool isDragging = false;
    private Vector2 initialMousePos;
    void Start()
    {
        buttonRectTransform = GetComponent<RectTransform>();
        value = Random.Range(0f,1f);
    }
    void Update()
    {
        if (isDragging)
        {
            Vector2 currentMousePos = Input.mousePosition;
            Vector2 delta = currentMousePos - initialMousePos;

            float angle = delta.x * rotationSpeed * Time.deltaTime;
            buttonRectTransform.Rotate(Vector3.forward, -angle);

            value += angle / 360f;
            if (value < 0 || value > 1) value = (value + 1f) % 1f;
            initialMousePos = currentMousePos;
        }
    }
    public void OnPointerDown()
    {
        isDragging = true;
        initialMousePos = Input.mousePosition;
    }
    public void OnPointerUp()
    {
        isDragging = false;
    }
}