using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HiddenLevelScore : MonoBehaviour
{
	public int score;
	private GameScore gameScore;

	public TextMeshProUGUI scoreText;
	public string scoreTextFormat = "スコア: {0}";


	private void Awake()
    {
		int finalScore = ScoreManager.GetFinalScore();
		this.score = finalScore;
		scoreText.text = string.Format(scoreTextFormat, this.score);
	}

	/// <summary>
	/// 將分數添加到當前分數
	/// </summary>
	/// <param name="score">Amount</param>
	public void AddScore(int scoreToAdd)
	{
		// 根據紀錄的 SetFinalScore(GameScore.score); 開始疊加分數
		score += scoreToAdd;
		UpdateLevelScore();

	}


	/// <summary>
	/// 使用正確的格式更新分數 UI 元素
	/// </summary>
	public void UpdateLevelScore()
	{
		scoreText.text = string.Format(scoreTextFormat, this.score);

	}

}
