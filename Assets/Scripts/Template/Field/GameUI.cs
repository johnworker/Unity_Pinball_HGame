﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreEndText;
    public string scoreEndTextFormat = "最終スコア: {0}";


    private void Start()
    {
        int finalScore = ScoreManager.GetFinalScore();
        scoreEndText.text = string.Format(scoreEndTextFormat, finalScore);
    }

    // UI按鈕觸發遊戲場景載入
    public void StartGame()
    {
        SceneManager.LoadScene("測試彈珠台");

        /*
        Scene otherScene = SceneManager.GetSceneByName("OtherScene");

        GameObject[] rootObjects = otherScene.GetRootGameObjects();

        foreach (GameObject obj in rootObjects)
        {
            Game gameSet = obj.GetComponent<Game>();
            if (gameSet != null)
            {
                // 訪問布林值變量
                bool otherBoolValue = gameSet.isActive;
                // 在這裡使用otherBoolValue做你想要的操作

                otherBoolValue = true;
                break;
            }
        }
        */

    }


    public void EndGame()
    {
        SceneManager.LoadScene("結束畫面選單");
    }

    public void LoadAnimationScene()
    {
        SceneManager.LoadScene("動畫展示所");
    }

    public void PlayAnimationScene()
    {
        SceneManager.LoadScene("動畫展示");
    }

}