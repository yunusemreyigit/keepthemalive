using UnityEngine;
public class Wifi : MonoBehaviour
{
    public GameObject WifiGameUIPanel;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _offset;
    private Camera _mainCamera;
    public Vector2 minBoundary;
    public Vector2 maxBoundary;
    private Vector2 currentPosition;
    private Vector2 destination;
    public float timeAtTarget = 0f;
    private bool isAtTarget = false;
    private void Start()
    {
        _mainCamera = Camera.main;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentPosition = transform.position;
        destination = GenerateRandomDestination();
    }
    private void Update()
    {
        if (isAtTarget) {
            timeAtTarget += Time.deltaTime;
            if (timeAtTarget >= 2f) ClosePanel();
        }
        else timeAtTarget = 0; 
    }
    private void OnMouseDown()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        _offset = transform.position - mousePosition;
    }
    private void OnMouseDrag()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        Vector3 targetPosition = mousePosition + _offset;

        targetPosition.x = Mathf.Clamp(targetPosition.x, minBoundary.x, maxBoundary.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minBoundary.y, maxBoundary.y);

        _rigidbody2D.MovePosition(targetPosition);

        currentPosition = targetPosition;

        CheckIfDestinationReached();
    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Mathf.Abs(_mainCamera.transform.position.z);
        return _mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }
    private Vector2 GenerateRandomDestination()
    {
        float randomX = Random.Range(minBoundary.x, maxBoundary.x);
        float randomY = Random.Range(minBoundary.y, maxBoundary.y);
        return new Vector2(randomX, randomY);
    }
    private void CheckIfDestinationReached()
    {
        float distanceToDestination = Vector2.Distance(currentPosition, destination);

        if (distanceToDestination >= 3f)
        {
            spriteRenderer.sprite = sprites[0];
            isAtTarget = false;
        }
        else if (distanceToDestination >= 1.5f)
        {
            spriteRenderer.sprite = sprites[1];
            isAtTarget = false;
        }
        else if (distanceToDestination >= 0.7f)
        {
            spriteRenderer.sprite = sprites[2];
            isAtTarget = false;
        }
        else if (distanceToDestination >= 0.3f)
        {
            spriteRenderer.sprite = sprites[3];
            isAtTarget = false;
        }
        else
        {
            spriteRenderer.sprite = sprites[4];
            isAtTarget = true;
        }
    }
    public void OpenPanel()
    {
        WifiGameUIPanel.SetActive(true);
    }
    private void ClosePanel()
    {
        WifiGameUIPanel.SetActive(false);
    }
}
