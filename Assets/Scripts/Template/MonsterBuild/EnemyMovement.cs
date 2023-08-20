using UnityEngine;
using System.Collections;
using UnityEditor;

public class EnemyMovement : MonoBehaviour
{
    public DataBasic dataBasic;

    public float moveRange = 5.0f; // 移動範圍的半徑
    public Vector3 targetPosition;
    private bool isMoving = false;

    private void Update()
    {
        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    private void onDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, moveRange); // 繪製移動範圍的圓圈
    }

    public void SetTargetPosition(Vector3 newPosition)
    {
        // 確保目標位置在移動範圍內
        targetPosition.x = Mathf.Clamp(targetPosition.x, transform.position.x - moveRange, transform.position.x + moveRange);
        newPosition.x = Mathf.Clamp(newPosition.x, -4.0f, 4.0f); // 限制在 [-4, 4] 範圍內
        newPosition.y = 1.1f; // 限制 Y 軸高度為 1
        newPosition.z = Mathf.Clamp(newPosition.z, transform.position.z - 2.0f, transform.position.z); // 限制在生成點到 -6 之間的隨機值
        targetPosition = newPosition;
        isMoving = true;
    }

    private void MoveTowardsTarget()
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, dataBasic.moveSpeed * Time.deltaTime);
        transform.position = newPosition;

        if (transform.position == targetPosition)
        {
            isMoving = false;
            // 在到達目標位置時執行相應的操作，比如停止移動或改變行為
        }
    }
}