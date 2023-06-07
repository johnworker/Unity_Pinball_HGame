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
	/// 盢だ计睰讽玡だ计
	/// </summary>
	/// <param name="score">Amount</param>
	public void AddScore(int score)
	{
		this.score += score;
		UpdateScore();
	}

	/// <summary>
	/// 睲埃讽玡だ计
	/// </summary>
	public void ClearScore()
	{
		score = 0;
		UpdateScore();
	}

	/// <summary>
	/// ㄏノタ絋Α穝だ计 UI じ
	/// </summary>
	void UpdateScore()
	{
		scoreText.text = string.Format(scoreTextFormat, this.score);
		scoreEndText.text = string.Format(scoreEndTextFormat, this.score);
	}
}
