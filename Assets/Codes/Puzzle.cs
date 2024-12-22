using UnityEngine;
public class Puzzle : MonoBehaviour
{
    public GameObject UIPanel;
    public bool isCompleted = false;
    public void OpenPanel()
    {
        UIPanel.SetActive(true);
    }
    public void ClosePanel()
    {
        isCompleted = true;
        UIPanel.SetActive(false);
    }
    public void Exit()
    {
        UIPanel.SetActive(false);
    }
}
