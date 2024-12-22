using UnityEngine;
public class Puzzle : MonoBehaviour
{
    public GameObject UIPanel;
    public bool isCompleted = false;
    public static bool isAnyPanelActive = false;
    public void OpenPanel()
    {
        if (isAnyPanelActive) return;
        UIPanel.SetActive(true);
        isAnyPanelActive = true;
    }
    public void ClosePanel()
    {
        isCompleted = true;
        Exit();
    }
    public void Exit()
    {
        UIPanel.SetActive(false);
        isAnyPanelActive = false;
    }
}
