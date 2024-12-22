using UnityEngine;
using System.Collections;
public class SendField_ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int obstacleCount = 20;
    public Transform parentTransform;
    private GameObject ParentOfClones;
    private float obstacleSize = 0.3f;
    void OnEnable()
    {
        ParentOfClones = new GameObject();
        ParentOfClones.transform.SetParent(parentTransform);
        ParentOfClones.transform.localScale = new Vector3(1f, 1f, 1f);
        StartCoroutine(SpawnObstacles());
    }
    void OnDisable()
    {
        Destroy(ParentOfClones);
        ParentOfClones = null;
    }
    IEnumerator SpawnObstacles()
    {
        Vector2 spawnAreaMin = new Vector2(-2f, -2f);
        Vector2 spawnAreaMax = new Vector2(2f, 2f);
        
        for (int i = 0; i < obstacleCount; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.x), -5
            );

            GameObject newObstacle = Instantiate(obstaclePrefab, randomPosition, Quaternion.identity);
            newObstacle.transform.SetParent(ParentOfClones.transform);
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