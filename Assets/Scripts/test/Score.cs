using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public GameScore gameScore;

    void ShowTotalScore()
    {
        int totalScore = gameScore.score;
        // 使用總分進行後續操作
    }
}
