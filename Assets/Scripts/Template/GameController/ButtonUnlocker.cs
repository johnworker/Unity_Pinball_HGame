using UnityEngine;
using UnityEngine.UI;

public class ButtonUnlocker : MonoBehaviour
{
    [System.Serializable]
    public class UnlockableButton
    {
        public Button button;
        public int unlockScore;
        public Image[] buttonImages;
    }

    public UnlockableButton[] buttons;

    void Start()
    {
        CheckAndUnlockButtons();
    }

    public void CheckAndUnlockButtons()
    {
        int finalScore = ScoreManager.GetFinalScore();

        foreach (UnlockableButton buttonInfo in buttons)
        {
            bool unlock = finalScore >= buttonInfo.unlockScore;

            // 设置按钮的交互性
            buttonInfo.button.interactable = unlock;

            // 遍历按钮图片数组并设置显示状态
            foreach (Image image in buttonInfo.buttonImages)
            {
                image.gameObject.SetActive(!unlock);
            }
        }
    }
}