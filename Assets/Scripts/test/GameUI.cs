using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [Header("遊戲 UI")]

    public bool isActive;
    private Game game;

    [Header("GameSet 參考")]
    public GameSet gameSet;


    private void Start()
    {
        game = GameObject.FindObjectOfType<Game>();
    }

    // UI按鈕觸發遊戲場景載入
    public void StartGame()
    {
        SceneManager.LoadScene("測試彈珠台");
        isActive = true;
        game.ballCount = 3;
        game.ballDisplay.SetActive(true);
        
        game.SetBallReady(true);
        
        game.score.ClearScore();

        // 顯示右側的 UI 面板
        game.menuPanel.gameObject.SetActive(false);
        game.gamePanel.gameObject.SetActive(true);
        game.endPanel.gameObject.SetActive(false);

    }


    public void EndGame()
    {
        SceneManager.LoadScene("開始畫面");
    }
}