using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private int hitCount = 0; // 記錄被打的次數


    [Header("動畫控制器")]
    public Animator ani;
    [Header("受傷搖動參數")]
    public string parHurtMove = "受傷";
    public float waitDuration = 1f; // 等待動畫播放時間

    [Header("受傷材質")]
    public Material hurtMaterial;

    private void OnCollisionEnter(Collision collision)
    {
        // 檢測到碰撞的對像是球時
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Destroy(gameObject);

            ani.SetBool(parHurtMove, true);
            hitCount++; // 增加被打的次數
            TakeDamage();

            // 如果被打次數達到3次，則銷毀障礙物
            if (hitCount >= 3)
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
        ani.SetBool(parHurtMove, false);
    }

    private void DestroyObstacle()
    {
        // 在此處執行銷毀障礙物的操作
        Destroy(gameObject);
    }

    private void TakeDamage()
    {
        // 獲取模型的所有渲染器組件
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        // 遍歷所有渲染器，設置材質為受傷材質
        foreach (Renderer renderer in renderers)
        {
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = hurtMaterial;
            }
            renderer.materials = materials;
        }
    }
}



