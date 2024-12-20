using UnityEngine;
public class Puzzle : MonoBehaviour
{
    public GameObject UIPanel;
    public void ClosePanel()
    {
        UIPanel.SetActive(false);
    }
    public void Exit()
    {
        UIPanel.transform.position = new Vector3(UIPanel.transform.position.x, UIPanel.transform.position.y, 10);
    }
}
