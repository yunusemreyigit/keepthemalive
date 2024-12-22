using UnityEngine;
using UnityEngine.UI;
public class OxygenGame : Puzzle
{
    public OxygenGame_Pointer[] pointers;
    public Button[] buttons;
    void OnEnable()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }
    void OnDisable()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.RemoveAllListeners();
        }
    }
    void Update()
    {
        if (IsGameOver()) ClosePanel();
    }
    private bool IsGameOver()
    {
        foreach (OxygenGame_Pointer ptr in pointers)
            if (!ptr.isDone) return false;
        return true;
    }
    private void OnButtonClick(int index)
    {
        if (!pointers[index].isDone)
            pointers[index].Flap();
    }
}