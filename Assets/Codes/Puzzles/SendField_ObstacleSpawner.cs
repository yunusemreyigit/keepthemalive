using UnityEngine;
using System.Collections;
public class SendField_ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int obstacleCount = 20;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;
    public Transform parentTransform;
    public float obstacleSize = 0.3f;
    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }
    IEnumerator SpawnObstacles()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            Vector2 randomPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.x)
            );

            GameObject newObstacle = Instantiate(obstaclePrefab, randomPosition, Quaternion.identity);
            newObstacle.transform.SetParent(parentTransform);
            newObstacle.transform.localScale = new Vector3(obstacleSize, obstacleSize, 1f);
            newObstacle.SetActive(true);

            SendField_Obstacle movement = newObstacle.GetComponent<SendField_Obstacle>();
            if (movement != null)
            {
                movement.rangeX = Random.Range(0, 2) == 1 ? -2f : 2f;
                movement.rangeY = Random.Range(0, 2) == 1 ? -2f : 2f;
            }

            yield return new WaitForSeconds(2f/obstacleCount);
        }
    }
}