using UnityEngine;
using UnityEngine.UI;

public class ButtonUnlocker : MonoBehaviour
{
    public Button unlockButton;
    public Image buttonImage;


    void Start()
    {
        CheckAndUnlockButton();
    }

    public void CheckAndUnlockButton()
    {
        int finalScore = ScoreManager.GetFinalScore();
        if (finalScore >= 500)
        {
            unlockButton.interactable = true; // 解锁按钮
            buttonImage.gameObject.SetActive(false); // 隐藏按钮中的图片
        }
        else
        {
            unlockButton.interactable = false; // 锁定按钮
            buttonImage.gameObject.SetActive(true); // 显示按钮中的图片
        }
    }
}