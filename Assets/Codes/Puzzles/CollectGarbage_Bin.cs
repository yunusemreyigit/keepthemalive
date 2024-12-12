using UnityEngine;
public class CollectGarbage_Bin : MonoBehaviour
{
    public GameObject CollectGarbageUIPanel;
    public CollectGarbage_Garbage[] Garbages;
    public Vector2 minBounds;
    public Vector2 maxBounds;
    void Start()
    {
        foreach (CollectGarbage_Garbage garbage in Garbages)
        {
            float randomX = Random.Range(minBounds.x, maxBounds.x);
            float randomY = Random.Range(minBounds.y, maxBounds.y);
            garbage.transform.position = new Vector3(randomX, randomY, garbage.transform.position.z);
        }
    }
    void Update()
    {
        if (IsGameOver()) ClosePanel();
    }
    private bool IsGameOver()
    {
        foreach(CollectGarbage_Garbage garbage in Garbages)
            if (garbage.isActiveAndEnabled) return false;
        return true;
    }
    public void OpenPanel()
    {
        CollectGarbageUIPanel.SetActive(true);
    }
    private void ClosePanel()
    {
        CollectGarbageUIPanel.SetActive(false);
    }
}