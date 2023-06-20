using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private int hitCount = 0; // 記錄被打的次數


    [Header("動畫控制器")]
    public Animator ani;
    [Header("受傷搖動參數")]
    public string parHurtMove = "受傷";


    private void OnCollisionEnter(Collision collision)
    {
        // 檢測到碰撞的對像是球時
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Destroy(gameObject);

            ani.SetBool(parHurtMove, true);
            hitCount++; // 增加被打的次數
            
            // 如果被打次數達到3次，則銷毀障礙物
            if (hitCount >= 3)
            {
                Destroy(gameObject);
            }
            
        }
        else
        {
            ani.SetBool(parHurtMove, false);
        }
    }
}



