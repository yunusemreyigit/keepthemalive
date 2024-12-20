using UnityEngine;
using UnityEngine.UI;

public class SwitchGame : MonoBehaviour
{
    public GameObject SwitchGameUIPanel;
    public Sprite[] sprites;
    public Button[] Buttons;
    public const int size = 6;
    public bool[] AnswerArray = new bool[size];
    private bool[] CurrentArray = new bool[size];
    void Start()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            int x = i;
            AnswerArray[x] = Random.Range(0,2) == 1 ? true : false;
            CurrentArray[x] = false;
            Buttons[x].onClick.AddListener(() => OnButtonClick(x));
        }
    }
    private void OnButtonClick(int index)
    {
        CurrentArray[index] = !CurrentArray[index];
        Buttons[index].image.sprite = sprites[CurrentArray[index] ? 1 : 0];
        if (IsGameOver()) ClosePanel();
    }
    private bool IsGameOver()
    {
        for (int i = 0; i < Buttons.Length; i++)
            if (CurrentArray[i] != AnswerArray[i])
                return false;
        return true;
    }
    public void OpenPanel()
    {
        SwitchGameUIPanel.SetActive(true);
    }
    private void ClosePanel()
    {
        SwitchGameUIPanel.SetActive(false);
    }
}