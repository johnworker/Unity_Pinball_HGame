using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraScore : MonoBehaviour
{
	public int score;

	private HiddenLevelScore hiddenLevelScore;

	void Start()
	{
		// 获取HiddenLevelScore组件
		hiddenLevelScore = GameObject.Find("隱藏關卡計數器").GetComponent<HiddenLevelScore>();
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
			hiddenLevelScore.AddScore(score);
		}
	}
}
