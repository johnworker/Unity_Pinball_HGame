using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BossState : MonoBehaviour
{
    [Header("動畫控制器")]
    public Animator ani;
    [Header("敵人角色"),SerializeField]
    private GameObject BossGirl;
    [Header("粉碎特效")]
    public GameObject crushEffect;

    [Header("趴下受傷搖動參數")]
    public string parGetDownHurt = "趴下受傷";  // 趴下受傷 bool
    [Header("恢復站立參數")]
    public string parResumeStand = "恢復站立";  // 恢復站立 trigger
    [Header("站立等待搖動參數")]
    public string parStandIdle = "站立等待";  // 站立等待 bool
    [Header("站立受傷搖動參數")]
    public string parStandHurt = "站立受傷";  // 趴下受傷 bool

    public float waitDuration = 1f; // 等待動畫播放時間
    public float waitDurationChangeAni = 10f; // 等待動畫播放時間

    private bool isHurt = false; // 標記以跟踪魔王是否受傷

    private int hitCount = 0; // 記錄被打的次數
    [Header("可被打擊次數")]
    public int canHitCountNumbers = 3; // 記錄被打的次數

    private void Start()
    {
        StartCoroutine(WaitAndChangeToStand());
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 站立時被打到時撥放 站立受傷動畫，趴下被打到時，則趴下受傷動畫
        // 檢測到碰撞的對像是球時
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 如果被打擊兩次則播放粒子特效，角色的(子物件)衣服消失
            hitCount++; // 增加被打的次數

            if (hitCount == 2)
            {
                DestroyEffect();

                // 銷毀角色的衣服
                Destroy(BossGirl.transform.Find("衣服").gameObject);
                Destroy(BossGirl.transform.Find("褲子").gameObject);
            }

            // 如果被打次數達到，則銷毀障礙物
            if (hitCount >= canHitCountNumbers)
            {
                DestroyObstacle();
            }
            else
            {
                // 播放趴下受傷動畫
                ani.SetBool(parGetDownHurt, true); 
                ani.SetBool(parStandHurt, true);

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
        ani.SetBool(parStandHurt, false);

        ani.SetBool(parStandIdle, true);
    }

    private IEnumerator WaitAndChangeToStand()
    {
        // 等待一段時間后
        yield return new WaitForSeconds(waitDurationChangeAni);

        // 恢復站立
        ani.SetTrigger(parResumeStand);
        //且position 的 y 移動到-1.15
        // 移動 BossGirl 的位置
        Vector3 newPosition = BossGirl.transform.position;
        newPosition.y = -1.15f;
        BossGirl.transform.position = newPosition;


        // 等待動畫完成
        yield return new WaitForSeconds(0.4f);

        // 播放站立等待動畫
        ani.SetBool(parStandIdle, true);

    }

    private void DestroyObstacle()
    {
        // 在此處執行銷毀障礙物的操作
        Destroy(gameObject);
    }

    private void DestroyEffect()
    {
        GameObject effectIns = Instantiate(crushEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);
    }
}