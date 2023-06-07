using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSet : MonoBehaviour
{
    // instance：這是一個靜態屬性，用於存儲 GameManager 類別的唯一實例。
    // 可以通過 GameManager.instance 來訪問這個實例。
    public static GameSet instance { get; private set; }

    [Header("遊戲是否處於活動狀態")]
    public bool isActive = false;
    [Header("彈珠是否準備好射擊")]
    public bool ballReady = true;
    [Header("遊戲中剩餘的彈珠數量")]
    public int ballCount = 3;
    [Header("遊戲是否處於活動狀態")]
    public TextMeshProUGUI ballCountText;

    [Header("遊戲 UI")]
    [Header("遊戲中的選單")]
    public RectTransform menuPanel;
    [Header("遊戲畫面")]
    public RectTransform gamePanel;
    [Header("結束畫面")]
    public RectTransform endPanel;

    [Header("彈珠")]
    [Header("用於顯示彈珠的圖像或模型")]
    public GameObject ballDisplay;
    [Header("彈珠的預製物件")]
    public Ball ballPrefab;
    [Header("彈珠生成的位置")]
    public Transform ballSpawnPoint;
    internal GameScore score;

    public GameUse use { get; private set; }

    private void Awake()
    {
        instance = this;

        use = GetComponent<GameUse>();
    }

    public void StartGame()
    {
        isActive = true;
        ballCount = 3;
        ballDisplay.SetActive(true);

        SetBallReady(true);

        score.ClearScore();

        // 顯示右側的 UI 面板
        menuPanel.gameObject.SetActive(true);
        gamePanel.gameObject.SetActive(false);
        endPanel.gameObject.SetActive(false);

    }

    public void EndGame()
    {
        isActive = false;
        ballReady = false;
        ballDisplay.SetActive(false);

        // 隱藏右側面板
        menuPanel.gameObject.SetActive(false);
        gamePanel.gameObject.SetActive(true);
        endPanel.gameObject.SetActive(false);

    }

    /// <summary>
    /// 發射球來自生成點 和 設定推力
    /// </summary>
    /// <param name="force"></param>
    public void ShootBall(float force)
    {
        // 移除一顆球的數量 和 更新 UI界面
        ballCount--;
        SetBallReady(false);

        // 從生成點生成 和 添加推力
        Ball ball = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
        ball.AddForce(ballSpawnPoint.forward * force);
    }

    /// <summary>
    /// 當一個球被帶出遊戲時，這將被調用
    /// 它會產生一個新球或結束遊戲
    /// </summary>
    public void CheckGameState()
    {
        // 查找當前場景中的所有球
        int activeBallCount = FindObjectsOfType<Ball>().Length;

        // 如果沒有剩餘，則採取行動
        if (activeBallCount <= 0)
        {
            // 如果我們不能生成其他球，我們遊戲結束
            if (ballCount <= 0)
            {
                EndGame();
                SetBallReady(false);
            }
            else
            {
                SetBallReady(true);
            }
        }
    }

    /// <summary>
    /// 讓遊戲準備好發射球
    /// 還將更新虛擬顯示球和UI界面
    /// </summary>
    /// <param name="ready"></param>
    public void SetBallReady(bool ready)
    {
        ballReady = ready;
        ballDisplay.SetActive(ready);
        ballCountText.text = ballCount.ToString();
    }
}