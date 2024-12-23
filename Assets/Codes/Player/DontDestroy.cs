using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy instance;
    // private void Awake()
    // {
    //     if (instance != null && instance != this)
    //     {
    //         Destroy(gameObject);
    //         return;
    //     }

    //     instance = this;
    //     DontDestroyOnLoad(gameObject);
    // }
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
