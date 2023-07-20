using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreControl : MonoBehaviour
{
	public TextMeshProUGUI scoreText;
	private int originalScore = 0;
	
	private void UpdateScoreUI()
	{
		scoreText.text = "Score" + originalScore.ToString();
	}
}
