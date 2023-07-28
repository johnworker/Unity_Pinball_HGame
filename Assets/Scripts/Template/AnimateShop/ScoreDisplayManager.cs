using UnityEngine;
using TMPro;

public class ScoreDisplayManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // 获取保存的分数
        int finalScore = ScoreManager.GetFinalScore();

        // 显示分数在UI文本组件上
        scoreText.text = "{累計ポイント}" + "最終スコア: " + finalScore.ToString();
    }
}