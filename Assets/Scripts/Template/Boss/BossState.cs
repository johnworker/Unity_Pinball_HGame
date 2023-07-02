using System.Collections;
using UnityEngine;

public class BossState : MonoBehaviour
{
    [Header("動畫控制器")]
    public Animator ani;

    [Header("趴下受傷搖動參數")]
    public string parGetDownHurt = "趴下受傷";  // 趴下受傷 bool

    public float waitDuration = 1f; // 等待動畫播放時間

    private bool isHurt = false; // 標記以跟踪魔王是否受傷

    private int hitCount = 0; // 記錄被打的次數
    [Header("可被打擊次數")]
    public int canHitCountNumbers = 3; // 記錄被打的次數

    private void OnCollisionEnter(Collision collision)
    {
        // 檢測到碰撞的對像是球時
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 如果被打擊兩次則播放例子特效，衣服消失

            ani.SetBool(parGetDownHurt, true);
            hitCount++; // 增加被打的次數

            // 如果被打次數達到，則銷毀障礙物
            if (hitCount >= canHitCountNumbers)
            {
                DestroyObstacle();
            }
            else
            {
                // 繼續播放等待動畫
                StartCoroutine(WaitAndContinueAnimation());
            }
        }
    }

    private IEnumerator WaitAndContinueAnimation()
    {
        // 等待指定的時間
        yield return new WaitForSeconds(waitDuration);

        // 停止受傷動畫
        ani.SetBool(parGetDownHurt, false);
    }

    private void DestroyObstacle()
    {
        // 在此處執行銷毀障礙物的操作
        Destroy(gameObject);
    }
}
