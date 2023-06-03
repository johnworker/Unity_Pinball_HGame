using System.Collections;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;       // 障礙物的預製體
    public float generationInterval = 120f;   // 障礙物生成的時間間隔
    public Vector3 spawnSize;               // 障礙物生成範圍的尺寸

    private void Start()
    {
        // 開始生成障礙物的協程
        StartCoroutine(GenerateObstacles());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, spawnSize);
    }

    private IEnumerator GenerateObstacles()
    {
        while (true)
        {
            // 在指定的時間間隔生成障礙物
            GenerateObstacle();
            
            // 等待指定的時間間隔
            yield return new WaitForSeconds(generationInterval);
        }
    }

    private void GenerateObstacle()
    {
        // 在指定範圍内生成障礙物
        Vector3 spawnPoint = new Vector3
            (Random.Range(transform.position.x - spawnSize.x / 2, transform.position.x + spawnSize.x / 2),
             Random.Range(transform.position.y - spawnSize.y / 2, transform.position.y + spawnSize.y / 2),
             Random.Range(transform.position.z - spawnSize.z / 2, transform.position.z + spawnSize.z / 2));

        // 實例化障礙物預製體
        Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
    }
}