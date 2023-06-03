using System.Collections;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;       // 障礙物的預製體
    public float generationInterval = 5f;   // 障礙物生成的時間間隔
    public Vector3 spawnSize;               // 障礙物生成範圍的尺寸
    [Header("障礙物總數"), Range(0, 10)]
    public int canSpawnTotal = 10;

    private int obstacleCount = 0;          // 已生成的障礙物數量

    private void Start()
    {
        // 開始生成障礙物的協程
        StartCoroutine(GenerateObstacles());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.1f, 0.1f, 0.1f, 1f);
        Gizmos.DrawWireCube(transform.position, spawnSize);
    }

    private IEnumerator GenerateObstacles()
    {
     
        while (obstacleCount < canSpawnTotal)
        {
            // 在指定的時間間隔生成障礙物
            // 在指定範圍内生成障礙物
            Vector3 spawnPoint = new Vector3
                (Random.Range(transform.position.x - spawnSize.x / 2, transform.position.x + spawnSize.x / 2),
                 Random.Range(transform.position.y - spawnSize.y / 2, transform.position.y + spawnSize.y / 2),
                 Random.Range(transform.position.z - spawnSize.z / 2, transform.position.z + spawnSize.z / 2));

            // 實例化障礙物預製體
            Instantiate(obstaclePrefab, spawnPoint, Quaternion.identity);

            obstacleCount++;

            // 等待指定的時間間隔 // 無效果?
            yield return new WaitForSeconds(generationInterval);
        }
    }
}