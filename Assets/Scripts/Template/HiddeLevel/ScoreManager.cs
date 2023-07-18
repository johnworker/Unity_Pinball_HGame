using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // 分數的UI文本

    private int originalScore = 0;

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + originalScore.ToString();
    }
}