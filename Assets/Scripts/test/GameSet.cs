using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSet : MonoBehaviour
{
    // instance�G�o�O�@���R�A�ݩʡA�Ω�s�x GameManager ���O���ߤ@��ҡC
    // �i�H�q�L GameManager.instance �ӳX�ݳo�ӹ�ҡC
    public static GameSet instance { get; private set; }

    [Header("�C���O�_�B�󬡰ʪ��A")]
    public bool isActive = false;
    [Header("�u�]�O�_�ǳƦn�g��")]
    public bool ballReady = true;
    [Header("�C�����Ѿl���u�]�ƶq")]
    public int ballCount = 3;
    [Header("�C���O�_�B�󬡰ʪ��A")]
    public TextMeshProUGUI ballCountText;

    [Header("�C�� UI")]
    [Header("�C���������")]
    public RectTransform menuPanel;
    [Header("�C���e��")]
    public RectTransform gamePanel;
    [Header("�����e��")]
    public RectTransform endPanel;

    [Header("�u�]")]
    [Header("�Ω���ܼu�]���Ϲ��μҫ�")]
    public GameObject ballDisplay;
    [Header("�u�]���w�s����")]
    public Ball ballPrefab;
    [Header("�u�]�ͦ�����m")]
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

        // ��ܥk���� UI ���O
        menuPanel.gameObject.SetActive(true);
        gamePanel.gameObject.SetActive(false);
        endPanel.gameObject.SetActive(false);

    }

    public void EndGame()
    {
        isActive = false;
        ballReady = false;
        ballDisplay.SetActive(false);

        // ���åk�����O
        menuPanel.gameObject.SetActive(false);
        gamePanel.gameObject.SetActive(true);
        endPanel.gameObject.SetActive(false);

    }

    /// <summary>
    /// �o�g�y�Ӧۥͦ��I �M �]�w���O
    /// </summary>
    /// <param name="force"></param>
    public void ShootBall(float force)
    {
        // �����@���y���ƶq �M ��s UI�ɭ�
        ballCount--;
        SetBallReady(false);

        // �q�ͦ��I�ͦ� �M �K�[���O
        Ball ball = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
        ball.AddForce(ballSpawnPoint.forward * force);
    }

    /// <summary>
    /// ��@�Ӳy�Q�a�X�C���ɡA�o�N�Q�ե�
    /// ���|���ͤ@�ӷs�y�ε����C��
    /// </summary>
    public void CheckGameState()
    {
        // �d���e���������Ҧ��y
        int activeBallCount = FindObjectsOfType<Ball>().Length;

        // �p�G�S���Ѿl�A�h�Ĩ����
        if (activeBallCount <= 0)
        {
            // �p�G�ڭ̤���ͦ���L�y�A�ڭ̹C������
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
    /// ���C���ǳƦn�o�g�y
    /// �ٱN��s������ܲy�MUI�ɭ�
    /// </summary>
    /// <param name="ready"></param>
    public void SetBallReady(bool ready)
    {
        ballReady = ready;
        ballDisplay.SetActive(ready);
        ballCountText.text = ballCount.ToString();
    }
}