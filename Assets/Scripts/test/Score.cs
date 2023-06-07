using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(GameSet))]
public class Score : MonoBehaviour
{
	public int score { get; private set; }

	public TextMeshProUGUI scoreText;
	public string scoreTextFormat = "Score: {0}";

	public TextMeshProUGUI scoreEndText;
	public string scoreEndTextFormat = "Final Score: {0}";

	/// <summary>
	/// �N���ƲK�[���e����
	/// </summary>
	/// <param name="score">Amount</param>
	public void AddScore(int score)
	{
		this.score += score;
		UpdateScore();
	}

	/// <summary>
	/// �M����e����
	/// </summary>
	public void ClearScore()
	{
		score = 0;
		UpdateScore();
	}

	/// <summary>
	/// �ϥΥ��T���榡��s���� UI ����
	/// </summary>
	void UpdateScore()
	{
		scoreText.text = string.Format(scoreTextFormat, this.score);
		scoreEndText.text = string.Format(scoreEndTextFormat, this.score);
	}
}
