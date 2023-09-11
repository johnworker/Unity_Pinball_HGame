using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFourth : MonoBehaviour
{
    [Header("動畫控制器")]
    public Animator ani;
    [Header("敵人角色"), SerializeField]
    private GameObject BossGirl;
    [Header("粉碎特效")]
    public GameObject crushEffect;

    [Header("更改姿勢的時間")]
    public float changePoseTime = 1f;
    [Header("等待動畫播放時間")]
    public float waitDuration = 1f;
    [Header("等待變換動畫播放時間")]
    public float waitDurationChangeAni = 0.5f;
    [Header("亂動結束的時間")]
    public float endshakeTime = 60f;

    //private bool isHurt = false; // 標記以跟踪魔王是否受傷

    private int hitCount = 0; // 記錄被打的次數
    [Header("可被打擊次數")]
    public int canHitCountNumbers = 50; // 記錄被打的次數

    [Header("等待搖動參數")]
    public string parIdle = "等待";  // 站立等待 bool
    [Header("等待受傷搖動參數")]
    public string parIdleHurt = "等待受傷";  // 站立受傷 bool
    [Header("搖動參數")]
    public string parShake = "亂動";  // 走路 bool
    [Header("搖動受傷參數")]
    public string parShakeHurt = "亂動受傷";  // 走路受傷 bool


    private bool isShake = false; // 用于标记是否正在走路
    private bool isSitting = false; // 用于标记是否正在坐下

    private bool isHurtAnimationPlaying = false; // 用于标记受伤动画是否正在播放

    [SerializeField, Header("受傷爆炸音效")]
    private AudioClip soundExplode;
    [SerializeField, Header("受傷音效")]
    private AudioClip soundHurt;


    private void Start()
    {
        // 开始时，调用协程执行动画循环
        StartCoroutine(AnimationLoop());
    }

    private void Update()
    {
        // 在 Update 中检测是否需要走路，站立等待或坐下
        if (isShake)
        {
            ani.SetBool(parShake, true);
            ani.SetBool(parIdle, false);
        }
        else
        {
            // 如果不是在走路或坐下状态，那就是站立等待状态
            ani.SetBool(parIdle, true);
            ani.SetBool(parShake, false);
        }
    }

    private IEnumerator AnimationLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(changePoseTime);
            isShake = true;


            yield return new WaitForSeconds(endshakeTime);
            isShake = false;

            yield return new WaitForSeconds(waitDurationChangeAni);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 檢測到碰撞的對像是球時
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 如果被打擊兩次則播放粒子特效，角色的(子物件)衣服消失
            hitCount++; // 增加被打的次數
            SystemSound.instance.PlaySound(soundHurt, new Vector2(4.8f, 5.3f));


            if (!isHurtAnimationPlaying)
            {
                // 受伤动画未播放时才播放
                ani.SetBool(parIdleHurt, true);
                ani.SetBool(parShakeHurt, true);
                isHurtAnimationPlaying = true;
            }

            if (hitCount == 1)
            {
                DestroyEffect();

                // 銷毀角色的服裝
                Destroy(BossGirl.transform.Find("衣服").gameObject);
                Destroy(BossGirl.transform.Find("褲子").gameObject);

                SystemSound.instance.PlaySound(soundExplode, new Vector2(0.5f, 0.8f));

            }

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
        ani.SetBool(parIdleHurt, false);
        ani.SetBool(parShakeHurt, false);

        // 恢复播放循环动画
        isHurtAnimationPlaying = false;

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
