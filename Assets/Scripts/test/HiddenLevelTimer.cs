using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HiddenLevelTimer : MonoBehaviour
{
    public float levelDuration = 30f; // 隐藏关卡的时长，单位为秒
    private float timer; // 当前倒计时时间

    [Header("顯示倒數計時文字")]
    public TextMeshProUGUI timerText; 

    private void Start()
    {
        timer = levelDuration;
    }

    private void Update()
    {
        // 更新倒计时时间
        timer -= Time.deltaTime;

        // 更新UI Text显示
        UpdateTimerUI();

        // 检查倒计时是否结束
        if (timer <= 0f)
        {
            // 返回原本场景
            ReturnToOriginalScene();
        }

    }

    private void UpdateTimerUI()
    {
        // 将倒计时时间转换为字符串格式，并显示在UI Text上
        string timeString = string.Format("剩餘時間:{1:00}", Mathf.FloorToInt(timer / 60), Mathf.FloorToInt(timer % 60));
        timerText.text = timeString;
    }

    private void ReturnToOriginalScene()
    {

        // 加载原本场景
        SceneManager.LoadScene("測試彈珠台");
    }
}