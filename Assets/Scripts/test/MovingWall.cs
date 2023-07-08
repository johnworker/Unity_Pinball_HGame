using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public float moveDistance = 5f;  // 墙壁移动的距离
    public float moveSpeed = 2f;     // 墙壁移动的速度
    public float interval = 10f;      // 移动的时间间隔

    private float originalY;         // 原始的Y坐标
    private float targetY;           // 目标的Y坐标
    private float timer;             // 计时器
    private bool movingUp = true;    // 是否向上移动

    private void Start()
    {
        originalY = transform.position.y;  // 记录原始的Y坐标
        targetY = (originalY + moveDistance) * moveSpeed * Time.deltaTime; // 设置初始目标位置为原始位置加上移动距离
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // 检查是否到达时间间隔
        if (timer >= interval)
        {
            timer = 0f;
            movingUp = !movingUp;  // 切换移动方向
            // 下降要和上升距離一致
            targetY = movingUp ? originalY - moveDistance / 1.1f : originalY + moveDistance ; // 根据移动方向更新目标位置
        }

        // 平滑移动墙壁
        float newY = Mathf.Lerp(transform.position.y, targetY, moveSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

    }
}
