using UnityEngine;
using UnityEngine.UI;
public class PressureGame : Puzzle
{
    public GameObject[] Goals;
    public PressureGame_Pointer[] pointers;
    public Button[] buttons;
    void Awake()
    {
        foreach (GameObject g in Goals)
            g.transform.position = new Vector3(g.transform.position.x, Random.Range(-1f, 1f), g.transform.position.z);
    }
    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i;
            buttons[i].onClick.AddListener(() => OnButtonClick(buttonIndex));
        }
    }
    void Update()
    {
        if (IsGameOver()) ClosePanel();
    }
    private bool IsGameOver()
    {
        foreach (PressureGame_Pointer ptr in pointers)
            if (!ptr.isDone) return false;
        return true;
    }
    private void OnButtonClick(int index)
    {
        if (pointers[index].isOnTheGoal)
            pointers[index].isDone = true;
        else for (int i = 0; i < pointers.Length; i++)
            pointers[i].isDone = false;
    }
}