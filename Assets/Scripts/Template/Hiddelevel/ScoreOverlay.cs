using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreOverlay
{
    public static int overlayScore;

    public static void SetOverlayScore(int score)
    {
        overlayScore = score;
    }

    public static int GetOverlayScore()
    {
        return overlayScore;
    }


}
