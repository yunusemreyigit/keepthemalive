using UnityEngine;
public class CollectGarbage_Bin : Puzzle
{
    public CollectGarbage_Garbage[] Garbages;
    public Vector2 minBounds;
    public Vector2 maxBounds;
    void OnEnable()
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
}