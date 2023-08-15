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

    private int hiddenLevelScore = 0; // 隐藏关卡得分


    private void Start()
    {

        timer = levelDuration;

        // 获取隐藏关卡得分（这里假设HiddenLevelScore脚本是附加在当前物体上的）
        HiddenLevelScore hiddenScore = GetComponent<HiddenLevelScore>();
        if (hiddenScore != null)
        {
            hiddenLevelScore = hiddenScore.score;
        }
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
        string timeString = string.Format("残り時間:{1:00}", Mathf.FloorToInt(timer / 60), Mathf.FloorToInt(timer % 60));
        timerText.text = timeString;
    }

    private void ReturnToOriginalScene()
    {
        // 获取隐藏关卡得分并保存到主场景分数
        int hiddenLevelScore = PlayerPrefs.GetInt("HiddenLevelScore", 0);
        PlayerPrefs.SetInt("HiddenLevelScore", 0); // 清除隐藏关卡得分

        // 加载原始场景
        SceneManager.LoadScene("彈珠台草原場景");

        // 将分数添加到主场景分数
        GameScore gameScore = FindObjectOfType<GameScore>();
        if (gameScore)
        {
            gameScore.AddScore(hiddenLevelScore);
        }
    }
}