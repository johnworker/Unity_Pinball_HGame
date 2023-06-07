using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [Header("�C�� UI")]

    public bool isActive;
    private Game game;

    [Header("GameSet �Ѧ�")]
    public GameSet gameSet;


    private void Start()
    {
        game = GameObject.FindObjectOfType<Game>();
    }

    // UI���sĲ�o�C���������J
    public void StartGame()
    {
        SceneManager.LoadScene("���ռu�]�x");
        isActive = true;
        game.ballCount = 3;
        game.ballDisplay.SetActive(true);
        
        game.SetBallReady(true);
        
        game.score.ClearScore();

        // ��ܥk���� UI ���O
        game.menuPanel.gameObject.SetActive(false);
        game.gamePanel.gameObject.SetActive(true);
        game.endPanel.gameObject.SetActive(false);

    }


    public void EndGame()
    {
        SceneManager.LoadScene("�}�l�e��");
    }
}