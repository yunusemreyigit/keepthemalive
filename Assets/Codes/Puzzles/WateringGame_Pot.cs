using UnityEngine;
public class WateringGamePot : MonoBehaviour
{
    public GameObject WateringPlantGameUIPanel;
    public WateringPlants_Plant[] plants;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    public Sprite[] sprites;
    private int spriteIndex;
    public Vector2 minBounds;
    public Vector2 maxBounds;
    private bool isDragging;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        InvokeRepeating(nameof(AnimateSprite), 0.1f, 0.1f);
    }
    void Update()
    {
        if (isGameOver()) ClosePanel();
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;
            if (spriteRenderer.bounds.Contains(mousePosition)) 
            {
                isDragging = true;
                boxCollider.enabled = true;
            }
        }
        else if (Input.GetMouseButtonUp(0)) 
        {
            isDragging = false;
            boxCollider.enabled = false;
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
    private void AnimateSprite()
    {
        if (isDragging)
        {
            spriteIndex++;
            if (spriteIndex >= sprites.Length) spriteIndex = 1;
            spriteRenderer.sprite = sprites[spriteIndex];
        }
        else spriteRenderer.sprite = sprites[0];
    }
    private bool isGameOver()
    {
        foreach (WateringPlants_Plant plant in plants)
            if (plant.NeedWater()) return false;
        return true;
    }
    public void OpenPanel()
    {
        WateringPlantGameUIPanel.SetActive(true);
    }
    private void ClosePanel()
    {
        WateringPlantGameUIPanel.SetActive(false);
    }
}