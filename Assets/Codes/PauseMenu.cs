using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject settingsPanelUI;

    private bool isPaused = false;

    void Start()
    {
        // Pause menüsünü başlangıçta gizle
        pauseMenuUI.SetActive(false);
        Debug.Log("PauseMenuUI başlangıçta gizlendi.");
    }

    void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape))
{
    Debug.Log("Esc tuşuna basıldı.");
    if (isPaused)
    {
        Resume();
    }
    else
    {
        OpenPauseMenu();
    }
}
}

    // Pause menüsünü aç
    public void OpenPauseMenu()
    {
        Debug.Log("Pause menüsü açılıyor...");
        pauseMenuUI.SetActive(true);  // Pause menüsünü göster
        isPaused = true;  // Menü açıldığını belirle
    }

    // Pause menüsünü kapat
    public void Resume()
    {
        Debug.Log("Pause menüsü kapanıyor...");
        pauseMenuUI.SetActive(false);  // Pause menüsünü gizle
        isPaused = false;  // Menü kapandığını belirle
    }

    // Settings panelini aç
    public void OpenSettings()
    {
        pauseMenuUI.SetActive(false);  // Pause menüsünü gizle
        settingsPanelUI.SetActive(true);  // Settings panelini göster
    }

    // Settings panelini kapat
    public void CloseSettings()
    {
        settingsPanelUI.SetActive(false);  // Settings panelini gizle
        pauseMenuUI.SetActive(true);  // Pause menüsünü tekrar göster
    }

    // Ana menüye dön
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");  // Ana menüye geçiş
    }
}
