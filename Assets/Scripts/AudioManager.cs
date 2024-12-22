using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Sahne yönetimi için gerekli

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicAudioSource;  // Müzik için AudioSource
    public AudioSource buttonClickAudioSource;  // Buton tıklama sesi için AudioSource
    public AudioClip buttonClickSound;  // Buton tıklama ses dosyası
    public float musicVolume = 1f;  // Müzik ses seviyesi

    void Awake()
    {
        // Eğer zaten bir instance varsa bu objeyi yok et
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Eğer yoksa instance'ı kur ve objeyi sahne geçişlerinde koru
        instance = this;
        DontDestroyOnLoad(gameObject);  // Bu objenin sahne geçişlerinde yok olmamasını sağlar
    }

    // Müzik ses seviyesini ayarlama fonksiyonu
    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        musicAudioSource.volume = volume;  // Müzik sesini ayarla
    }

    // Başlangıçta müzik sesi ayarlarını uygula
    void Start()
    {
        musicAudioSource.volume = musicVolume;
        musicAudioSource.Play();  // Müzik çalmaya başla

        AddButtonListeners();  // Butonlara dinleyici ekle
    }

    // Sahne geçişi sonrası butonlara dinleyici eklemeyi sağlamak için
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;  // Yeni sahne yüklendiğinde çalışacak
    }

    // Sahne geçişi tamamlandığında butonlara tıklama dinleyici ekle
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Sahne yüklendiğinde butonlara dinleyici ekle
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AddButtonListeners();
    }

    // Butonlara tıklama dinleyicisi ekleme fonksiyonu
    private void AddButtonListeners()
    {
        Button[] buttons = FindObjectsOfType<Button>();  // Sahnedeki tüm butonları al
        foreach (Button button in buttons)
        {
            button.onClick.RemoveListener(OnButtonClick);  // Önceden eklenen dinleyiciyi kaldır
            button.onClick.AddListener(OnButtonClick);  // Her butona tıklama dinleyicisi ekle
        }
    }

    // Buton tıklama sesini çalacak fonksiyon
    void OnButtonClick()
    {
        if (buttonClickAudioSource != null && buttonClickSound != null)
        {
            buttonClickAudioSource.PlayOneShot(buttonClickSound);  // Tıklama sesini çal
        }
    }
}
