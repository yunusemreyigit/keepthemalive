using UnityEngine;
using UnityEngine.UI;
public class Mission : MonoBehaviour
{
    public GameObject PuzzlePanel;
    private GameObject ClonePanel;
    public Transform PanelParent;
    public bool isMissonActive = false;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => OnButtonClick());
    }
    void Update()
    {
        if (ClonePanel != null && !ClonePanel.activeSelf)
        {
            Destroy(ClonePanel);
            ClonePanel = null;
        }
    }
    private void OnButtonClick()
    {
        if (!isMissonActive) return;
        if (ClonePanel == null)
        {
            ClonePanel = Instantiate(PuzzlePanel, PanelParent);
            ClonePanel.SetActive(true);
        }
        else if (!ClonePanel.activeSelf)
        {
            ClonePanel.SetActive(true);
        }
    }
}