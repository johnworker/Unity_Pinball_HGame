using System.Collections;
using UnityEngine;

public class ColumnController : MonoBehaviour
{
    public float fallSpeed = 2f; // 下降速度
    public float spawnInterval = 2f; // 生成間隔時間（秒）

    private void Start()
    {
        // 啟動協程以定期生成"天柱"
        StartCoroutine(SpawnColumn());
    }

    private IEnumerator SpawnColumn()
    {
        while (true)
        {
            // 在一定時間後生成"天柱"
            yield return new WaitForSeconds(spawnInterval);

            // 生成"天柱"的新實例，位置在屏幕上方以外
            Vector3 spawnPosition = new Vector3(Random.Range(-4f, 4f), 10f, 0f);
            Instantiate(gameObject, spawnPosition, Quaternion.identity);
        }
    }

    private void Update()
    {
        // 讓"天柱"向下移動
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    // 在Scene視圖中繪製Gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(1f, 1f, 1f)); // 顯示"天柱"的邊界框
    }

}
