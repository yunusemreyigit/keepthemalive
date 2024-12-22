using UnityEngine;
using UnityEngine.SceneManagement;  // SceneManagement namespace'ini dahil et

public class BackButton : MonoBehaviour
{
    public void OnBackButtonClicked()
    {
        // MainMenu sahnesine geçiş
        SceneManager.LoadScene("MainMenu");  // "MainMenu" sahnesinin adını yazın
    }
}
