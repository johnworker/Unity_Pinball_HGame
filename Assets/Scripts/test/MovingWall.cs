using System.Collections;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public float moveDistance = 5f;   // 牆壁移動的距離
    public float moveSpeed = 2f;      // 牆壁移動的速度
    [Header("牆壁初始移動延遲時間")]

    public float interval = 10f;      // 移動的時間間隔
    [Header("牆壁初始移動延遲時間")]
    public float initialDelay = 3f;   // 第一次等待的時間

    private float originalY;          // 原始的Y坐標
    private float targetY;            // 目標的Y坐標
    private float timer;              // 計時器
    private bool movingUp = true;     // 是否向上移動
    private bool isMoving = false;    // 是否正在移動

    private void Awake()
    {
        originalY = transform.position.y;  // 記錄原始的Y坐標
    }

    private void Start()
    {
        // 延遲 initialDelay 秒後執行 MoveWall 協程
        StartCoroutine(StartMoving());
    }

    private IEnumerator StartMoving()
    {
        // 等待 initialDelay 秒後開始移動
        yield return new WaitForSeconds(initialDelay);

        // 執行 MoveWall 協程
        StartCoroutine(MoveWall());
    }

    private IEnumerator MoveWall()
    {
        while (true)
        {
            // 檢查是否牆壁未在移動中
            if (!isMoving)
            {
                movingUp = !movingUp;  // 切換移動方向
                // 下降要和上升距離一致
                targetY = movingUp ? originalY - moveDistance / 1.1f : originalY + moveDistance; // 根據移動方向更新目標位置

                // 設置 isMoving 為 true，表示牆壁需要移動
                isMoving = true;
            }

            // 平滑移動牆壁
            float newY = Mathf.MoveTowards(transform.position.y, targetY, moveSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // 檢查是否到達目標位置
            if (Mathf.Abs(transform.position.y - targetY) < 0.01f)
            {
                // 到達目標位置後，將 isMoving 設置為 false，表示牆壁停止移動
                isMoving = false;

                // 移動完成後等待 interval 秒
                yield return new WaitForSeconds(interval);
            }

            yield return null;
        }
    }
}