using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScore : MonoBehaviour
{
    public int score { get; private set; }

    public TextMeshProUGUI scoreText;
    public string scoreTextFormat = "Score: {0}";

    public TextMeshProUGUI scoreEndText;
    public string scoreEndTextFormat = "Final Score: {0}";

    private void Awake()
    {
        // 获取隐藏关卡得分并合并到当前得分
        int hiddenLevelScore = PlayerPrefs.GetInt("HiddenLevelScore", 0);
        ReturnToMainScore(hiddenLevelScore);

        // 更新显示在游戏面板上
        UpdateScore();
    }


    /// <summary>
    /// 将分数添加到当前分数
    /// </summary>
    /// <param name="score">Amount</param>
    public void AddScore(int score)
    {
        this.score += score;
        UpdateScore();
    }

    /// <summary>
    /// 清除当前分数
    /// </summary>
    public void ClearScore()
    {
        score = 0;
        UpdateScore();
    }

    /// <summary>
    /// 使用正確的格式更新分数 UI 元素
    /// </summary>
    void UpdateScore()
    {
        UpdateLevelScore();
        scoreText.text = string.Format(scoreTextFormat, this.score);
        // 記錄儲存分數
        // 游戏结束或切换场景时保存分数到玩家的偏好设置中
        PlayerPrefs.SetInt("Score", this.score);
        scoreEndText.text = string.Format(scoreEndTextFormat, this.score);

        ScoreManager.SetFinalScore(this.score);
    }

    // 合并隐藏关卡得分到主场景
    public void ReturnToMainScore(int extraScore)
    {
        score += extraScore;
    }

    // 合并HiddenLevelScore的UpdateLevelScore到GameScore的UpdateScore
    public void UpdateLevelScore()
    {
        // 获取HiddenLevelScore组件
        HiddenLevelScore hiddenLevelScore = GetComponent<HiddenLevelScore>();
        if (hiddenLevelScore)
        {
            // 调用UpdateLevelScore方法
            hiddenLevelScore.UpdateLevelScore();
        }
    }
}