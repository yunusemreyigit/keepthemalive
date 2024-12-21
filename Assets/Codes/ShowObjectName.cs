using TMPro;
using UnityEngine;

public class ShowObjectName : MonoBehaviour
{
    public TextMeshProUGUI objectText;
    void Start()
    {
        objectText.text = "";
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject.tag.CompareTo("object") == 0)
        {
            objectText.text = hit.collider.gameObject.name;
        }
        else
        {
            objectText.text = "";
        }
    }
}
