using UnityEngine;
using UnityEngine.UI;

public class ButtonUnlocker : MonoBehaviour
{
    public Button unlockButton;
    public Image[] buttonImages; // 修改为 Image 数组

    private int requiredScore = 0; // 每个按钮所需的最低分数

    void Start()
    {
        // 设置每个按钮所需的最低分数
        if (gameObject.name == "ButtonOne") // 假设你的按钮有一个唯一的名称
        {
            requiredScore = 1000;
        }
        else if (gameObject.name == "ButtonTwo") // 假设你的第二个按钮也有一个唯一的名称
        {
            requiredScore = 2000;
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