using UnityEngine;

public class SceneStartPoint : MonoBehaviour
{
    public Vector3 spawnPosition;
    private void Start()
    {
        spawnPosition = transform.position;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = spawnPosition;
        }
    }
}
