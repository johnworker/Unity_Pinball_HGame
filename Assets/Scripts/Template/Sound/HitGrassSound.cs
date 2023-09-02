using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGrassSound : MonoBehaviour
{
    [SerializeField, Header("滾過草地音效")]
    private AudioClip soundGrassAcross;

    private void OnCollisionEnter(Collision collision)
    {
        // 檢查是否和球碰撞
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 播放碰撞音效
            SystemSound.instance.PlaySound(soundGrassAcross, new Vector2(0.7f, 1.1f));
        }
    }
}
