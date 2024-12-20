using UnityEngine;
public class DustOff_Brush : MonoBehaviour
{
    public GameObject WateringPlantGameUIPanel;
    public WateringPlants_Plant[] dirts;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    public Sprite[] sprites;
    private int spriteIndex;
    public Vector2 minBounds;
    public Vector2 maxBounds;
    private bool isDragging;

    void Start()
    {
        foreach (WateringPlants_Plant dirt in dirts)
        {
            float randomX = Random.Range(minBounds.x, maxBounds.x);
            float randomY = Random.Range(minBounds.y, maxBounds.y - 0.3f);
            dirt.transform.position = new Vector3(randomX, randomY, dirt.transform.position.z);
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        InvokeRepeating(nameof(AnimateSprite), 0.1f, 0.1f);
    }
    void Update()
    {
        if (IsGameOver()) ClosePanel();
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
    }
    private bool IsGameOver()
    {
        foreach (WateringPlants_Plant dirt in dirts)
            if (dirt.NeedWater()) return false;
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
