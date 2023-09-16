using System.Collections;
using UnityEngine;

public class AxController : MonoBehaviour
{
    [Header("大斧擺動")]
    public string parAxMove = "擺動";  // 車移動 bool
    public float AxChangeStopTime = 60.0f;
    public float stopDuration = 5.0f; // 停止的時間（秒）

    private Vector3 initialPosition = new Vector3(0.02f, 12f, -4f); // 保存初始位置

    private Animator axAnimator;

    [Header("可被打擊次數")]
    public int canHitCountNumbers = 3; // 記錄被打的次數

    [SerializeField, Header("斧頭傷音效")]
    private AudioClip soundAxDamage;


    private void Start()
    {
        axAnimator = GetComponent<Animator>();

        // 保存初始位置
        initialPosition = transform.position;

        // 啟動協程開始車輛運動循環
        StartCoroutine(AxMotionLoop());
    }


    private IEnumerator AxMotionLoop()
    {
        while (true)
        {
            // 重置物体位置到初始位置
            transform.position = initialPosition;

            // 大斧擺動
            axAnimator.SetBool(parAxMove, true);
            // 前進
            yield return new WaitForSeconds(AxChangeStopTime);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 檢測到碰撞的對像是球時
        if (collision.gameObject.CompareTag("Ball"))
        {
            SystemSound.instance.PlaySound(soundAxDamage, new Vector2(1.5f, 1.8f));
        }
    }
}
