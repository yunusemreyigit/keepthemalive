using UnityEngine;
using UnityEngine.UI;
public class ThreeColor_Lamp : MonoBehaviour
{
    private Image imageRenderer;
    public Sprite[] sprites; // Green-Red-Yellow
    public int spriteIndex = 0;
    public bool isGreen = true;
    void OnEnable()
    {
        imageRenderer = GetComponent<Image>();
        imageRenderer.sprite = sprites[spriteIndex];
    }
    public void ChangeColor()
    {
        if (spriteIndex == 0)
        {
            isGreen = false;
            imageRenderer.sprite = sprites[++spriteIndex];
        }
        else if (spriteIndex == 1)
        {
            imageRenderer.sprite = sprites[++spriteIndex];
        }
        else
        {
            isGreen = true;
            imageRenderer.sprite = sprites[spriteIndex = 0];
        }
    }
}