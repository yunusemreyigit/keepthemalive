using UnityEngine;
public class CollectGarbage_Garbage : MonoBehaviour
{
    public GameObject ThisObject;
    private SpriteRenderer spriteRenderer;
    public Vector2 minBounds;
    public Vector2 maxBounds;
    private bool isDragging;
    private float timer = 0f;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (timer > 0.5f) ThisObject.SetActive(false);
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;
            if (spriteRenderer.bounds.Contains(mousePosition)) 
            {
                isDragging = true;
            }
        }
        else if (Input.GetMouseButtonUp(0)) 
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;
            mousePosition.x = Mathf.Clamp(mousePosition.x, minBounds.x, maxBounds.x);
            mousePosition.y = Mathf.Clamp(mousePosition.y, minBounds.y, maxBounds.y);
            transform.position = mousePosition;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        timer = 0f;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
            timer += Time.deltaTime;
    }
}
