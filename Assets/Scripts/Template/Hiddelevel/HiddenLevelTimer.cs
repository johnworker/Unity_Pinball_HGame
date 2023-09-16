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

    [Header("返回關卡")]
    public string parLevelReturn = "彈珠台草原場景";  // 車移動 bool

    [Header("返回不同關卡")]
    public string[] scenesToLoad; // 存储场景名称的字符串数组

    [Header("返回不同關卡編號")]
    public int currentLevel = 1; // 例如，假设当前是第一个关卡

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
        

        // 根据当前关卡选择要加载的场景
        if (currentLevel >= 1 && currentLevel <= scenesToLoad.Length)
        {
            string sceneToLoad = scenesToLoad[currentLevel - 1]; // 注意数组索引从0开始，所以要减1
            SceneManager.LoadScene(sceneToLoad);
        }

        // 将分数添加到主场景分数
        GameScore gameScore = FindObjectOfType<GameScore>();
        if (gameScore)
        {
            gameScore.AddScore(hiddenLevelScore);
        }
    }
}