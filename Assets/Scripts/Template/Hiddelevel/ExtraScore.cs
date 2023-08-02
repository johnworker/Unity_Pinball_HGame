using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraScore : MonoBehaviour
{
	public int score;

	private GameScore gameScore;

	void Start()
	{

		gameScore = FindObjectOfType<GameScore>();
	}

	/// <summary>
	/// Will check if a ball collided with this object
	/// If there is a ball it will add the score to GameScore script
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter(Collision collision)
	{
		Ball ball = collision.transform.GetComponent<Ball>();

		if (ball)
		{
			gameScore.AddScore(score);
			/*
			if (gameScore)
			{
				int currentScore = GameScore.score;
				gameScore.AddScore(currentScore); // 将当前场景分数累加到主场景的得分中
				gameScore.UpdateScore(); // 更新主场景的 UI 元素
			}*/
		}

	}
}
