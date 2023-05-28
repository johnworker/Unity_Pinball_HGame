using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            // 增加得分
            score += 100;
            // 更新得分顯示
            scoreText.text = "Score: " + score.ToString();
            // 播放音效或粒子效果等
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // 減少生命或其他處罰
            // 播放音效或粒子效果等
        }
    }
}
