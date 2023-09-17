﻿using UnityEngine;
using UnityEngine.UI;

public class ButtonUnlocker : MonoBehaviour
{
    public Button unlockButton;
    public Image[] buttonImages; // 修改为 Image 数组

    private int requiredScore = 0; // 每个按钮所需的最低分数

    void Start()
    {
        // 设置每个按钮所需的最低分数
        if (gameObject.name == "搓湯圓") // 假设你的按钮有一个唯一的名称
        {
            requiredScore = 500;
        }
        else if (gameObject.name == "乘坐起飛式") 
        {
            requiredScore = 600;
        }
        else if (gameObject.name == "掛鎖式")
        {
            requiredScore = 700;
        }
        else if (gameObject.name == "擁抱式")
        {
            requiredScore = 800;
        }
        else if (gameObject.name == "老漢綁架式")
        {
            requiredScore = 900;
        }
        else if (gameObject.name == "腳踏車式")
        {
            requiredScore = 1000;
        }
        else if (gameObject.name == "老漢推車") 
        {
            requiredScore = 2500;
        }

        CheckAndUnlockButton();
    }

    public void CheckAndUnlockButton()
    {
        int finalScore = ScoreManager.GetFinalScore();
        if (finalScore >= requiredScore)
        {
            unlockButton.interactable = true; // 解锁按钮

            // 遍历每个按钮图片并隐藏
            foreach (Image buttonImage in buttonImages)
            {
                buttonImage.gameObject.SetActive(false);
            }
        }
        else
        {
            unlockButton.interactable = false; // 锁定按钮

            // 遍历每个按钮图片并显示
            foreach (Image buttonImage in buttonImages)
            {
                buttonImage.gameObject.SetActive(true);
            }
        }
    }
}