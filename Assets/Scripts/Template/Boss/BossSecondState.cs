using System.Collections;
using UnityEngine;

public class BossSecondState : MonoBehaviour
{
    [Header("動畫控制器")]
    public Animator ani;
    [Header("敵人角色"), SerializeField]
    private GameObject BossGirl;
    [Header("粉碎特效")]
    public GameObject crushEffect;

    [Header("更改姿勢的時間")]
    public float changePoseTime = 5f;
    [Header("等待動畫播放時間")]
    public float waitDuration = 1f;
    [Header("等待變換動畫播放時間")]
    public float waitDurationChangeAni = 10f;
    [Header("坐下結束的時間")]
    public float endSitTime = 15f;
    [Header("走路結束的時間")]
    public float endwalkTime = 25f;

    //private bool isHurt = false; // 標記以跟踪魔王是否受傷

    private int hitCount = 0; // 記錄被打的次數
    [Header("可被打擊次數")]
    public int canHitCountNumbers = 3; // 記錄被打的次數

    [Header("站立等待搖動參數")]
    public string parStandIdle = "站立等待";  // 站立等待 bool
    [Header("站立受傷搖動參數")]
    public string parStandHurt = "站立受傷";  // 站立受傷 bool
    [Header("恢復站立參數")]
    public string parResumeStand = "恢復站立";  // 恢復站立 bool
    [Header("走路參數")]
    public string parWalk = "走路";  // 走路 bool
    [Header("走路受傷參數")]
    public string parWalkHurt = "走路受傷";  // 走路受傷 bool
    [Header("走路參數")]
    public string parSit = "坐下";  // 坐下 bool
    [Header("走路受傷參數")]
    public string parSitHurt = "坐下受傷";  // 坐下受傷 bool


    private bool isWalking = false; // 用于标记是否正在走路
    private bool isSitting = false; // 用于标记是否正在坐下

    private bool isHurtAnimationPlaying = false; // 用于标记受伤动画是否正在播放

    private void Start()
    {
        // 开始时，调用协程执行动画循环
        StartCoroutine(AnimationLoop());
    }

    private void Update()
    {
        // 在 Update 中检测是否需要走路，站立等待或坐下
        if (isWalking)
        {
            ani.SetBool(parWalk, true);
            ani.SetBool(parStandIdle, false);
        }
        else if (isSitting)
        {
            ani.SetBool(parSit, true);
            ani.SetBool(parWalk, false);
            ani.SetBool(parStandIdle, false);
        }
        else
        {
            // 如果不是在走路或坐下状态，那就是站立等待状态
            ani.SetBool(parStandIdle, true);
            ani.SetBool(parResumeStand, true);
            ani.SetBool(parWalk, false);
            ani.SetBool(parSit, false);
        }
    }

    private IEnumerator AnimationLoop()
    {
        while (true)
        {
            // 等待一段时间后开始走路
            yield return new WaitForSeconds(changePoseTime);
            isWalking = true;
      

            // 等待一段时间后停止走路，进入站立等待状态
            yield return new WaitForSeconds(endwalkTime);
            isWalking = false;

            // 等待一段时间后坐下
            yield return new WaitForSeconds(waitDurationChangeAni);
            isSitting = true;

            // 坐下持續10秒

            // 等待一段时间后恢复站立
            yield return new WaitForSeconds(endSitTime);
            // 恢復站立
            Vector3 newPosition = BossGirl.transform.position;
            newPosition.y = 0.89f;
            BossGirl.transform.position = newPosition;
            isSitting = false;

            // 等待一段时间后进入站立等待状态，重复循环
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

            if (!isHurtAnimationPlaying)
            {
                // 受伤动画未播放时才播放
                ani.SetBool(parStandHurt, true);
                ani.SetBool(parWalkHurt, true);
                ani.SetBool(parSitHurt, true);
                isHurtAnimationPlaying = true;
            }

            if (hitCount == 1)
            {
                DestroyEffect();

                // 銷毀角色的服裝
                Destroy(BossGirl.transform.Find("裙子").gameObject);

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
        ani.SetBool(parStandHurt, false);
        ani.SetBool(parWalkHurt, false);
        ani.SetBool(parSitHurt, false);

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
