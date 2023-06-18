using UnityEngine;
using TMPro;

public static class ScoreManager
{
    public static int finalScore;


    public static void SetFinalScore(int score)
    {
        finalScore = score;
    }

    public static int GetFinalScore()
    {
        return finalScore;
    }

}