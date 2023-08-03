using System.Collections;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;       // 障礙物的預製體
    public float generationInterval = 5f;   // 障礙物生成的時間間隔
    public Vector3 spawnSize;               // 障礙物生成範圍的尺寸
    [Header("障礙物總數"), Range(0, 10)]
    public int canSpawnTotal = 10;

    public float moveDuration = 5f;         // 移動間格時間
    public float moveRange = 2f;            // 移動範圍

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

            // 檢查生成位置是否在不希望生成障礙物的區域內
            if (IsInForbiddenArea(spawnPoint))
            {
                continue; // 跳過本次循環，不生成障礙物
            }

            // 實例化障礙物預製體
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPoint, Quaternion.identity);
            // obstacle.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            obstacleCount++;

            StartCoroutine(MoveObstacle(obstacle));
            // 等待指定的時間間隔 // 無效果?
            yield return new WaitForSeconds(generationInterval);
        }
    }

    private bool IsInForbiddenArea(Vector3 position)
    {
        // 在此處編寫檢查生成位置是否在不希望生成障礙物的區域的邏輯
        // 返回 true 表示在禁止區域，返回 false 表示不在禁止區域
        // 您可以根據特定的場景需求進行自定義
        // 例如，可以使用Collider來表示禁止區域，然後使用Collider的接口進行檢測
        // 還可以使用特定的坐標範圍或其他邏輯來判斷位置是否在禁止區域

        // 示例：假設禁止區域是一個球形區域，半徑為0.5，位於(1.36, 0.2, -1.29)和(-1.361934, 0.15, -2.553626)

        float forbiddenRadius = 0.5f;
        Vector3 forbiddenCenter = new Vector3(1.36f, 0.2f, -1.29f);
        Vector3 forbiddenOther = new Vector3(-1.361934f, 0.15f, -2.553626f);

        if (Vector3.Distance(position, forbiddenCenter) <= forbiddenRadius || Vector3.Distance(position, forbiddenOther) <= forbiddenRadius)
        {
            return true; // 在禁止區域
        }

        return false; // 不在禁止區域
    }

    private IEnumerator MoveObstacle(GameObject obstacle)
    {
        // 添加碰撞器組件
        Collider obstacleCollider = obstacle.GetComponent<Collider>();
        // obstacleCollider.isTrigger = true;

        bool hasCollided = false;

        if (obstacle == null)
        {
            yield break; // 協程提前結束
        }

        Vector3 startPos = obstacle.transform.position;
        Vector3 endPos = startPos + new Vector3(
            Random.Range(-moveRange, moveRange),
            0f,
            Random.Range(-moveRange, moveRange));

        Quaternion startRot = obstacle.transform.rotation;
        Quaternion endRot = Quaternion.LookRotation(endPos - startPos, Vector3.up);

        // 檢查障礙物是否為空，或者已經被銷毀
        if (obstacle == null)
        {
            yield break; // 協程提前結束
        }

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / moveDuration;

            if (obstacle != null)
            {
                obstacle.transform.position = Vector3.Lerp(startPos, endPos, t);
                obstacle.transform.rotation = Quaternion.Slerp(startRot, endRot, t);
            }

            if (hasCollided)
            {
                endPos = startPos + new Vector3(
                    Random.Range(-moveRange, moveRange),
                    0f,
                    Random.Range(-moveRange, moveRange));

                endRot = Quaternion.LookRotation(endPos - startPos, Vector3.up);

                // 重置碰撞狀態
                hasCollided = false;
            }

            yield return null;
        }

        // 緩慢旋轉面向 (0f, 180f, 0f)
        Quaternion currentRot = obstacle.transform.rotation;
        Quaternion targetRot = Quaternion.Euler(0f, 180f, 0f);

        float rotateDuration = 2f;
        float rotateT = 0f;

        while (rotateT < 1f && obstacle != null) // 添加 obstacle != null 這裡檢查
        {
            rotateT += Time.deltaTime / rotateDuration;
            obstacle.transform.rotation = Quaternion.Slerp(currentRot, targetRot, rotateT);
            yield return null;
        }

    }
}