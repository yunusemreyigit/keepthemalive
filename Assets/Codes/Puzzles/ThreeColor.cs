using UnityEngine;
using UnityEngine.UI;
public class ThreeColor : Puzzle
{
    public Button[] Buttons;
    public ThreeColor_Lamp[] Lamps;
    public float timer = 0f;
    private bool GameOver = false;
    void Start()
    {
        while (IsGameOver()) mixArray();
        for (int i = 0; i < Buttons.Length; i++)
        {
            int buttonIndex = i;
            Buttons[i].onClick.AddListener(() => OnButtonClick(buttonIndex));
        }
    }
    void Update()
    {
        if (GameOver)
        {
            timer += Time.deltaTime;
            if (timer >= 1.5f) ClosePanel();
        }
    }
    private void OnButtonClick(int index)
    {
        if (GameOver) return;

        Lamps[6].ChangeColor();
        Lamps[index].ChangeColor();
        Lamps[(index + 1) % 6].ChangeColor();

        if (IsGameOver()) GameOver = true;
    }
    public void mixArray()
    {
        int loopCount = Random.Range(2, 7);
        while (loopCount-- >= 0)
            OnButtonClick(Random.Range(0, Buttons.Length));
    }
    public bool IsGameOver()
    {
        foreach (ThreeColor_Lamp lamp in Lamps)
            if (!lamp.isGreen) return false;
        return true;
    }
} 