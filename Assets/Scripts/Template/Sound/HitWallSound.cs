using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWallSound : MonoBehaviour
{
    [SerializeField, Header("木牆撞擊音效")]
    private AudioClip soundWoodWallHit;

    private void OnCollisionEnter(Collision collision)
    {
        // 檢查是否和球碰撞
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 播放碰撞音效
            SystemSound.instance.PlaySound(soundWoodWallHit, new Vector2(0.7f, 1.1f));
        }
    }
}
