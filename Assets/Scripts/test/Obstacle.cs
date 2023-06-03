using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // 檢測到碰撞的對像是球時
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 銷毀障礙物
            Destroy(gameObject);
        }
    }
};