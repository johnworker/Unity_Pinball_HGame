using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSound : MonoBehaviour
{
    [SerializeField, Header("動畫音效")]
    private AudioClip soundAnimate;

    public void PlaySoundEffect()
    {
        // 音效系統.靜態實體.撥放音效(音效，實體);
        SystemSound.instance.PlaySound(soundAnimate, new Vector2(0.9f, 1.5f));
    }
}
