using UnityEngine;
using UnityEngine.UI;
public class Mission : MonoBehaviour
{
    public Puzzle puzzle;
    private GameObject ClonePanel;
    public Transform PanelParent;
    public bool isMissionActive = false;
    private Image imageRenderer;
    public Sprite[] sprites;
    public float time = 0f;
    public float timeLimit = 120f;
    public bool isPressable = true;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => OnButtonClick());
        imageRenderer = GetComponent<Image>();
    }
    void Update()
    {
        if (isMissionActive) time += Time.deltaTime;
        if (ClonePanel != null && !ClonePanel.activeSelf)
        {
            Destroy(ClonePanel);
            ClonePanel = null;
        }
        if (ClonePanel != null && ClonePanel.activeSelf)
        {
            ActivateMission(false);
        }
    }
    private void OnButtonClick()
    {
        if (!isMissionActive || !isPressable) return;
        if (ClonePanel == null)
        {
            ClonePanel = Instantiate(puzzle.UIPanel, PanelParent);
            ClonePanel.transform.position = new Vector3(ClonePanel.transform.position.x, ClonePanel.transform.position.y, -4);
            ClonePanel.SetActive(true);
        }
        else if (!ClonePanel.activeSelf)
        {
            ClonePanel.SetActive(true);
        }
    }
    public void ActivateMission(bool b)
    {
        imageRenderer.sprite = sprites[(isMissionActive = b) ? 1 : 0];
    }
    public bool isCloneActive()
    {
        if (ClonePanel != null) return ClonePanel.activeSelf;
        return false;
    }
}