using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Game))]
public class GameScore : MonoBehaviour {
	public int score { get; private set; }

	public TextMeshProUGUI scoreText;
	public string scoreTextFormat = "Score: {0}";

	public Text scoreEndText;
	public string scoreEndTextFormat = "Final Score: {0}";

	/// <summary>
	/// 將分數添加到當前分數
	/// </summary>
	/// <param name="score">Amount</param>
	public void AddScore(int score) {
		this.score += score;
		UpdateScore();
	}

	/// <summary>
	/// 清除當前分數
	/// </summary>
	public void ClearScore() {
		score = 0;
		UpdateScore();
	}

	/// <summary>
	/// 使用正確的格式更新分數 UI 元素
	/// </summary>
	void UpdateScore() {
		scoreText.text = string.Format(scoreTextFormat, this.score);
		scoreEndText.text = string.Format(scoreEndTextFormat, this.score);
	}
}
