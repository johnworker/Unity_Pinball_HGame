using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddelLevelGirl : MonoBehaviour
{
    [Header("動畫控制器")]
    public Animator ani;
    [Header("受傷搖動參數")]
    public string parHurt = "受傷";  // 受傷 bool
    [SerializeField, Header("受傷音效")]
    private AudioClip hiddelSoundHurt;

    private bool isHurt = false;

    private void OnCollisionEnter(Collision collision)
    {
        // 檢測到碰撞的對像是球時
        if (collision.gameObject.CompareTag("Ball") && !isHurt)
        {
            StartCoroutine(PlayHurtAnimation());
        }
    }

    private IEnumerator PlayHurtAnimation()
    {
        // 例如，您可以使用WaitForSeconds在播放動畫之前添加1秒的延遲。
        // 產量返回新的WaitForSeconds(1f);

        // 播放“受傷”動畫
        ani.SetBool(parHurt, true);
        // 播放受傷音效
        // 音效系統.靜態實體.撥放音效(音效，實體);
        SystemSound.instance.PlaySound(hiddelSoundHurt, new Vector2(5f, 5.3f));

        isHurt = true;


        // 等待動畫播放結束
        yield return new WaitForSeconds(1.5f);

        // 重置受傷標誌
        isHurt = false;
        ani.SetBool(parHurt, false);
    }
}
