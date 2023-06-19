using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private int hitCount = 0; // 記錄被打的次數

    private void OnCollisionEnter(Collision collision)
    {
        // 檢測到碰撞的對像是球時
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitCount++; // 增加被打的次數

            // 如果被打次數達到3次，則銷毀障礙物
            if (hitCount >= 3)
            {
                Destroy(gameObject);
            }
        }
    }
}




