using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    public Slider volumeSlider;  // Ses kontrolü için slider
    public Button muteButton;    // Mute butonu
    public Image buttonImage;    // Mute butonundaki simge
    public Sprite speakerOn;     // Ses açık simgesi
    public Sprite speakerOff;    // Ses kapalı simgesi
    private bool isMuted = false; // Mute durumunu kontrol eder

    void Start()
    {
        // Slider'ın başlangıç değeri
        volumeSlider.value = AudioManager.instance.musicVolume;

        // Slider'a değer değiştiğinde ses seviyesini ayarla
        volumeSlider.onValueChanged.AddListener(SetVolume);

        // Mute butonuna tıklandığında ses açıp kapatmayı sağlar
        muteButton.onClick.AddListener(ToggleMute);

        // Başlangıçta doğru simgeyi göster
        UpdateMuteButton();
    }

    // Ses seviyesini ayarlamak için slider fonksiyonu
    void SetVolume(float volume)
    {
        if (!isMuted)
        {
            AudioManager.instance.SetMusicVolume(volume);  // Müzik sesini ayarla
        }

        // Eğer ses sıfırsa simgeyi kapalı yap
        if (volume == 0)
        {
            isMuted = true;
        }
        else
        {
            isMuted = false;
        }

        // Simgeyi güncelle
        UpdateMuteButton();
    }

    // Mute butonuna tıklandığında ses açıp kapamayı sağlayan fonksiyon
    public void ToggleMute()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            // Ses sıfırlanırsa, slider'dan gelen değeri kullan
            AudioManager.instance.SetMusicVolume(0);
        }
        else
        {
            // Ses açıldığında, slider'dan gelen mevcut değeri kullan
            AudioManager.instance.SetMusicVolume(volumeSlider.value);
        }

        // Slider'ı ses seviyesine göre güncelle
        volumeSlider.value = AudioManager.instance.musicVolume;
        UpdateMuteButton();
    }

    // Mute butonunun simgesini güncelleyen fonksiyon
    void UpdateMuteButton()
    {
        if (isMuted || AudioManager.instance.musicVolume == 0)
        {
            buttonImage.sprite = speakerOff;
        }
        else
        {
            buttonImage.sprite = speakerOn;
        }
    }
}
