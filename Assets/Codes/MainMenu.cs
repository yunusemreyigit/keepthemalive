using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void GoToSettingsMenu()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}