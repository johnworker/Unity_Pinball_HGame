using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HiddenLevelScore : MonoBehaviour
{
	public int score;

	public TextMeshProUGUI scoreText;
	public string scoreTextFormat = "Score: {0}";

	/// <summary>
	/// 將分數添加到當前分數
	/// </summary>
	/// <param name="score">Amount</param>
	public void AddScore(int score)
	{
		this.score += score;
		UpdateLevelScore();
	}

	/// <summary>
	/// 清除當前分數
	/// </summary>
	public void ClearScore()
	{
		score = 0;
		UpdateLevelScore();
	}

	/// <summary>
	/// 使用正確的格式更新分數 UI 元素
	/// </summary>
	public void UpdateLevelScore()
	{
		scoreText.text = string.Format(scoreTextFormat, this.score);

		// ScoreManager.SetFinalScore(this.score);
	}

}
