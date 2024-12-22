using UnityEngine;
using UnityEngine.UI;
public class Mission : MonoBehaviour
{
    public Puzzle puzzle;
    public float time = 0f;
    public float timeLimit = 120f;
    public bool isMissionActive = false;
    public bool isMissionCompleted = false;
    
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => OnButtonClick());
    }
    void Update()
    {
        if (puzzle.isCompleted) ActivateMission(false);
        if (isMissionActive) time += Time.deltaTime;
    }
    private void OnButtonClick()
    {
        if (!isMissionActive || Puzzle.isAnyPanelActive) return;
        puzzle.OpenPanel();
    }
    public void ActivateMission(bool b)
    {
        isMissionActive = b;
        if (b) time = 0f;
    }
}