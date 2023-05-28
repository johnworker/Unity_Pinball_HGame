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
            // 糤眔だ
            score += 100;
            // 穝眔だ陪ボ
            scoreText.text = "Score: " + score.ToString();
            // 冀┪采狦单
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // 搭ぶネ㏑┪ㄤ矪籃
            // 冀┪采狦单
        }
    }
}
