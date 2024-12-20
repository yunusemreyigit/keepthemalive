using UnityEngine;
using UnityEngine.UI;
public class OxygenGame : MonoBehaviour
{
    public GameObject OxygenGameUIPanel;
    public OxygenGame_Pointer[] pointers;
    public Button[] buttons;
    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
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
    public void OpenPanel()
    {
        OxygenGameUIPanel.SetActive(true);
    }
    private void ClosePanel()
    {
        OxygenGameUIPanel.SetActive(false);
    }
}