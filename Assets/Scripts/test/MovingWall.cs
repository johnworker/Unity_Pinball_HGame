using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public float moveDistance = 5f;  // 牆壁移動的距離
    public float moveSpeed = 2f;     // 牆壁移動的速度
    public float interval = 10f;      // 移動的時間間隔

    private float originalY;         // 原始的Y坐標
    private float targetY;           // 目標的Y坐標
    private float timer;             // 計時器
    private bool movingUp = true;    // 是否向上移動


    private void Awake()
    {
        originalY = transform.position.y;  // 記錄原始的Y坐標
        targetY = (originalY + moveDistance) * moveSpeed * Time.deltaTime; // 設置初始目標位置為原始位置加上移動距離

    }

    private void Update()
    {

        // 計時器隨著時間增加並依時間影格分配每個裝置
        timer += Time.deltaTime;

        // 檢查是否到達時間間隔
        if (timer >= interval)
        {
            timer = 0f;
            movingUp = !movingUp;  // 切換移動方向
            // 下降要和上升距離一致
            targetY = movingUp ? originalY - moveDistance / 1.1f : originalY + moveDistance; // 根據移動方向更新目標位置
        }

        // 平滑移動牆壁
        float newY = Mathf.Lerp(transform.position.y, targetY, moveSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

    }

}
