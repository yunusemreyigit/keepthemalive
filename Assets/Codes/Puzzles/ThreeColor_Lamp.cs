using UnityEngine;
using UnityEngine.UI;
public class ThreeColor_Lamp : MonoBehaviour
{
    private Image imageRenderer;
    public Sprite[] sprites; // Green-Red-Yellow
    public int spriteIndex = 0;
    public bool isGreen;
    public void ChangeColor()
    {
        imageRenderer = GetComponent<Image>();
        if (spriteIndex == 0)
        {
            isGreen = false;
            imageRenderer.sprite = sprites[++spriteIndex];
        }
        else if (spriteIndex == 1)
        {
            isGreen = false;
            imageRenderer.sprite = sprites[++spriteIndex];
        }
        else
        {
            isGreen = true;
            imageRenderer.sprite = sprites[spriteIndex = 0];
        }
    }
    public void ResetColor() {isGreen = true;}
}