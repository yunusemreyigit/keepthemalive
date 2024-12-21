using UnityEngine;
public class Puzzle : MonoBehaviour
{
    public GameObject UIPanel;
    public Mission mission;
    public void ClosePanel()
    {
        if (mission != null) 
            mission.isMissionCompleted = true;
        UIPanel.SetActive(false);
    }
    public void Exit()
    {
        UIPanel.SetActive(false);
    }
}
