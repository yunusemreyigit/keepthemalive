using UnityEngine;
public class WateringPlants_Plant : MonoBehaviour
{
    public float HP = 0f;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex = 0;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (NeedWater() && HP >= spriteIndex)
        {
            spriteRenderer.sprite = sprites[spriteIndex];
            spriteIndex++;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Pot"))
            HP += Time.deltaTime * 3;
    }
    public bool NeedWater()
    {
        return !(spriteIndex >= sprites.Length);
    }
}