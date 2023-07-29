using UnityEngine;
using TMPro;

public class ScoreDisplayManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public string currentScoreTextFormat = "累計ポイント: {0}";

   
    void Start()
    {
        int totalScore = PlayerPrefs.GetInt("TotalScore", 0);
        currentScoreText.text = string.Format(currentScoreTextFormat, totalScore);
        // 显示分数在UI文本组件上
        //scoreText.text = "{累計ポイント}" + "最終スコア: " + finalScore.ToString();

    }
}