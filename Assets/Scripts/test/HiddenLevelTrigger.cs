using UnityEngine;
using UnityEngine.SceneManagement;

public class HiddenLevelTrigger : MonoBehaviour
{
    public string hiddenLevelSceneName;   // 隱藏關卡的場景名稱

    private bool isHiddenLevelUnlocked = false;

    private void OnTriggerEnter(Collider other)
    {
        // 檢查玩家是否觸發觸發器並且隱藏關卡未解鎖
        if (other.CompareTag("Ball") && !isHiddenLevelUnlocked)
        {
            UnlockHiddenLevel();
        }
    }

    // 在此處實現隱藏關卡解鎖的邏輯
    private void UnlockHiddenLevel()
    {
        isHiddenLevelUnlocked = true;
        // 可以在此處播放解鎖音效或顯示解鎖提示等

        // 加載隱藏關卡場景
        SceneManager.LoadScene(hiddenLevelSceneName);
    }
}