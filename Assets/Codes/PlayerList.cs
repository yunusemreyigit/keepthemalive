using System.Collections.Generic;
using UnityEngine;

public class PlayerList : MonoBehaviour
{
    public static PlayerList Instance;
    public List<GameObject> list;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
