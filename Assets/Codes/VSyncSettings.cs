using UnityEngine;
using UnityEngine.UI;

public class VSyncSettings : MonoBehaviour
{
    public Toggle vSyncToggle; // V-Sync Toggle

    void Start()
    {
        // V-Sync için mevcut durumu oku
        vSyncToggle.isOn = QualitySettings.vSyncCount == 1;

        // Toggle'a tıklama olayını ekleyin
        vSyncToggle.onValueChanged.AddListener(ToggleVSync);
    }

    // V-Sync açma/kapama
    void ToggleVSync(bool isOn)
    {
        QualitySettings.vSyncCount = isOn ? 1 : 0;
    }
}
