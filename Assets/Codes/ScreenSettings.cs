using UnityEngine;
using TMPro;  // TextMesh Pro namespace
using UnityEngine.UI;

public class ScreenSettings : MonoBehaviour
{
    public Toggle fullscreenToggle;          // Tam Ekran Toggle
    public TMP_Dropdown resolutionDropdown;  // Çözünürlük Dropdown (TMP)

    void Start()
    {
        // Toggle için listener ekle
        fullscreenToggle.onValueChanged.AddListener(OnFullscreenToggled);

        // Çözünürlükleri dropdown'a ekleme
        PopulateResolutionDropdown();

        // Ekran modunu ve çözünürlüğü güncelle
        UpdateScreenMode();
        UpdateResolution();
    }

    // Fullscreen modunu açma veya kapama
    void OnFullscreenToggled(bool isFullscreen)
    {
        Debug.Log("Fullscreen Toggle Changed: " + isFullscreen); // Toggle durumu
        Screen.fullScreen = isFullscreen;
        UpdateScreenMode();
    }

    // Çözünürlük listesini TMP_Dropdown'a ekleme
    void PopulateResolutionDropdown()
    {
        Debug.Log("Populating Resolution Dropdown..."); // Dropdown'a çözünürlük ekleme başlangıcı
        resolutionDropdown.ClearOptions();
        var resolutions = Screen.resolutions;

        // Çözünürlükleri dropdown'a ekle
        var options = new System.Collections.Generic.List<string>();
        foreach (var resolution in resolutions)
        {
            options.Add(resolution.width + " x " + resolution.height);
            Debug.Log("Adding Resolution: " + resolution.width + " x " + resolution.height); // Her çözünürlük ekleniyor
        }
        resolutionDropdown.AddOptions(options);

        // Seçilen çözünürlüğü başlangıçta ayarla
        resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
    }

    // Çözünürlük değiştiğinde yapılacak işlemler
    void OnResolutionChanged(int index)
    {
        Debug.Log("Resolution Selected: " + index); // Seçilen çözünürlük index
        var resolutions = Screen.resolutions;
        Resolution selectedResolution = resolutions[index];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
        Debug.Log("Changing Resolution to: " + selectedResolution.width + " x " + selectedResolution.height); // Çözünürlük değişimi
    }

    // Çözünürlük dropdown'unu güncelle
    void UpdateResolution()
    {
        var resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        // Şu anki çözünürlüğü bul
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
                break;
            }
        }

        resolutionDropdown.value = currentResolutionIndex;
        Debug.Log("Current Resolution: " + resolutions[currentResolutionIndex].width + " x " + resolutions[currentResolutionIndex].height); // Mevcut çözünürlük
    }

    // Ekran modunu UI'ya yansıtma
    void UpdateScreenMode()
    {
        Debug.Log("Updating Screen Mode: " + Screen.fullScreen); // Ekran modu durumu
        fullscreenToggle.isOn = Screen.fullScreen;
    }
}
