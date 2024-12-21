using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private bool isSelected;
    [SerializeField] private Vector2Int position;
    private Image image;

    public Vector2Int Position { get => position; set => position = value; }
    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void ChangeStatus()
    {
        isSelected = !isSelected;
    }
    public void ResetStatus()
    {
        isSelected = false;
    }
    public bool IsSelected()
    {
        return isSelected;
    }
    public void ChangeColor(Color color)
    {
        if (isSelected)
            image.color = color;
        else
            image.color = Color.white;
    }
}


