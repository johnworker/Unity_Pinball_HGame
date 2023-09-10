using UnityEngine;

public class CloudControl : MonoBehaviour
{
    //緩緩往左移動到彈珠台左牆穿越彈珠台右牆再度出現
    public float moveSpeed = 0.5f; // 移動速度
    public float leftBoundary = -6f; // 左邊界位置
    public float rightBoundary = 6f; // 右邊界位置

    void Update()
    {
        // 移動雲朵向左
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // 如果雲朵移到了左邊界
        if (transform.position.x < leftBoundary)
        {
            // 移動到右邊界再度出現
            Vector3 newPosition = new Vector3(rightBoundary, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
