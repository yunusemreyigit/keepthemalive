using TMPro;
using UnityEngine;
public class MissionTrigger : MonoBehaviour
{
    public float frequency = 10f;
    public Mission[] missions;
    public TextMeshProUGUI activeMissionsText;
    public float timer = 10f;
    void Update()
    {
        Puzzle.isAnyPanelActive = IsAnyPanelActive();

        timer += Time.deltaTime;
        if (timer > frequency)
            ActivateRandomMission();

        string activeMissions = "Active Missions : ";

        foreach (Mission m in missions)
        {
            if (m.isMissionActive && m.time > m.timeLimit)
                Debug.Log($"Time limit is exceeded for subject : {m.name}");
            
            if (m.isMissionActive)
                activeMissions += $"\n{m.name} : {(int)(m.timeLimit - m.time)}";
            else if (m.puzzle.isCompleted) m.puzzle.isCompleted = false;
        }
        if (activeMissionsText != null)
            activeMissionsText.text = activeMissions;
    }

    private void ActivateRandomMission()
    {
        Mission mission = missions[Random.Range(0, missions.Length)];
        if (mission.isMissionActive)
            timer -= 2f;
        else
        {
            Debug.Log($"{mission.name} is activated");
            mission.ActivateMission(true);
            mission.isMissionCompleted = false;
            timer -= frequency;
        }
    }
    private bool IsAnyPanelActive()
    {
        foreach (Mission m in missions)
            if (m.puzzle.UIPanel.activeSelf)
                return true;
        return false;
    }
}