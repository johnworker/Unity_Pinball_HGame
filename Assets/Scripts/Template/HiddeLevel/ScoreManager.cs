using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    // public Text scoreText; // 分數的UI文本

    private int originalScore = 0;

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + originalScore.ToString();
    }
}