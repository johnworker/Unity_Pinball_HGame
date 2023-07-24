using UnityEngine;
using UnityEngine.SceneManagement;

public class HiddenLevelTimer : MonoBehaviour
{
    public float levelDuration = 30f; // 隐藏关卡的时长，单位为秒
    private float timer; // 当前倒计时时间

    private void Start()
    {
        timer = levelDuration;
    }

    private void Update()
    {
        // 更新倒计时时间
        timer -= Time.deltaTime;

        // 检查倒计时是否结束
        if (timer <= 0f)
        {
            // 返回原本场景
            ReturnToOriginalScene();
        }
    }

    private void ReturnToOriginalScene()
    {

        // 加载原本场景
        SceneManager.LoadScene("測試彈珠台");
    }
}