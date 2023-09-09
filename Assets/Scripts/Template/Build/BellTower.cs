using System.Collections;
using UnityEngine;

public class BellTower : MonoBehaviour
{
    private int hitCount = 0; // 記錄被打的次數
    [Header("可被打擊次數")]
    public int canHitCountNumbers = 10; // 記錄被打的次數
    [SerializeField, Header("鐘塔撞擊音效")]
    private AudioClip soundBellTowerHit;
    [Header("動畫控制器")]
    public Animator ani;
    [Header("搖動參數")]
    public string parShake = "擺動";
    [Header("搖動結束參數")]
    public string parShakeEnd = "擺動結束";

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitCount++;
            ani.SetTrigger(parShake);
            SystemSound.instance.PlaySound(soundBellTowerHit, new Vector2(0.9f, 1.6f));


            if (hitCount >= canHitCountNumbers)
            {
                Destroy(gameObject);
            }

            else
            {
                // 在擺動動畫播放完後，設置搖動結束參數
                float shakeAnimationLength = ani.GetCurrentAnimatorStateInfo(0).length;
                StartCoroutine(ResetShakeParameter(shakeAnimationLength));
            }
        }
    }

    private IEnumerator ResetShakeParameter(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ani.SetTrigger(parShakeEnd);
    }
}
