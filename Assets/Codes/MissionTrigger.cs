using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MissionTrigger : MonoBehaviour
{
    public float frequency = 10f;
    public Mission[] missions;
    public TextMeshProUGUI activeMissionsText;
    private float timer = 10f;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > frequency)
            ActivateRandomMission();

        bool anyCloneActive = false;
        string activeMissions = "Active Missions : ";

        foreach (Mission m in missions)
        {
            if (m.isMissionActive && m.time > m.timeLimit)
                Debug.Log($"Time limit is exceeded for subject : {m.name}");

            if (m.isCloneActive())
                anyCloneActive = true;
            
            if (m.isMissionActive)
                activeMissions += $"\n{m.name} : {(int)(m.timeLimit - m.time)}";
        }

        SetPressable(!anyCloneActive);

        if (activeMissionsText != null)
            activeMissionsText.text = activeMissions;
    }

    private void ActivateRandomMission()
    {
        Mission mission = missions[Random.Range(0, missions.Length)];
        if (mission.isMissionActive)
            ActivateRandomMission();
        else
        {
            mission.ActivateMission(true);
            mission.isMissionCompleted = false;
            timer -= frequency;
        }
    }

    private void SetPressable(bool isPressable)
    {
        foreach (Mission m in missions)
        {
            m.isPressable = isPressable;
        }
    }
}
