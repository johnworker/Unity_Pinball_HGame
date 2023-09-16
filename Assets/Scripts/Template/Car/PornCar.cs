using System.Collections;
using UnityEngine;

public class PornCar : MonoBehaviour
{
    [Header("移動")]
    public string parCarMove = "移動";  // 車移動 bool
    public float carSpeed = 3.0f;
    public float stopDuration = 2.0f; // 停止的時間（秒）

    private Animator carAnimator;

    [Header("粉碎特效")]
    public GameObject crushEffect;

    private int hitCount = 0; // 記錄被打的次數
    [Header("可被打擊次數")]
    public int canHitCountNumbers = 3; // 記錄被打的次數

    [SerializeField, Header("受傷爆炸音效")]
    private AudioClip soundExplode;

    [SerializeField, Header("車損傷音效")]
    private AudioClip soundCarDamage;


    private void Start()
    {
        carAnimator = GetComponent<Animator>();


        // 啟動協程開始車輛運動循環
        StartCoroutine(CarMotionLoop());
    }


    private IEnumerator CarMotionLoop()
    {
        while (true)
        {
            // 車體移動
            carAnimator.SetBool(parCarMove, true);
            // 前進
            yield return new WaitForSeconds(carSpeed);

            // 靜止
            carAnimator.SetBool(parCarMove, false);

            yield return new WaitForSeconds(stopDuration);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 檢測到碰撞的對像是球時
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 如果被打擊兩次則播放粒子特效，角色的(子物件)衣服消失
            hitCount++; // 增加被打的次數
            SystemSound.instance.PlaySound(soundCarDamage, new Vector2(1.5f, 1.8f));


            // 如果被打次數達到，則銷毀障礙物
            if (hitCount >= canHitCountNumbers)
            {
                SystemSound.instance.PlaySound(soundExplode, new Vector2(1.1f, 1.5f));
                Destroy(gameObject);
                DestroyEffect();
            }
        }
    }

    private void DestroyEffect()
    {
        GameObject effectIns = Instantiate(crushEffect, transform.position, transform.rotation);

        Destroy(effectIns, 5f);
    }


}
