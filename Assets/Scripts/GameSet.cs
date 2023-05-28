using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSet : MonoBehaviour
{
	public static GameSet instance { get; private set; }

	public bool isActive = false;
	public bool ballReady = true;
	public int ballCount = 3;

	[Header("Ball")]
	public int ballStartCount = 3;
	public GameObject ballDisplay;
	public Ball ballPrefab;
	public Transform ballSpawnPoint;

	public GameController controller { get; private set; }

	void Awake()
	{
		instance = this;

		controller = GetComponent<GameController>();
	}

	void Start()
	{
		isActive = false;

		SetBallReady(false);
	}

	/// <summary>
	/// �}�l�C��, �N�M�Υ��T�����ʨ���ܥk�����O
	/// </summary>
	public void StartGame()
	{
		isActive = true;
		ballCount = ballStartCount;

		SetBallReady(true);

	}

	/// <summary>
	/// �����C��, �N�M�Υ��T�����ʨ���ܥk�����O
	/// </summary>
	public void EndGame()
	{
		isActive = false;

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
	void SetBallReady(bool ready)
	{
		ballReady = ready;
		ballDisplay.SetActive(ready);
	}
}
