using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
	public static Game instance { get; private set; }

	public bool isActive = false;
	public bool ballReady = true;
	public int ballCount = 3;
	public Text ballCountText;

	[Header("Game UI")]
	public RectTransform menuPanel;
	public RectTransform gamePanel;
	public RectTransform endPanel;

	[Header("Ball")]
	public int ballStartCount = 3;
	public GameObject ballDisplay;
	public Ball ballPrefab;
	public Transform ballSpawnPoint;

	public GameScore score { get; private set; }
	public GameController controller { get; private set; }

	void Awake() {
		instance = this;

		score = GetComponent<GameScore>();
		controller = GetComponent<GameController>();
	}

	void Start() {
		isActive = false;

		SetBallReady(false);

		// 顯示右側的 UI 面板
		menuPanel.gameObject.SetActive(true);
		gamePanel.gameObject.SetActive(false);
		endPanel.gameObject.SetActive(false);
	}

	/// <summary>
	/// 開始遊戲, 將套用正確的活動並顯示右側面板
	/// </summary>
	public void StartGame() {
		isActive = true;
		ballCount = ballStartCount;
		ballCountText.text = ballCount.ToString();

		SetBallReady(true);

		score.ClearScore();

		// 隱藏右側面板
		menuPanel.gameObject.SetActive(false);
		gamePanel.gameObject.SetActive(true);
		endPanel.gameObject.SetActive(false);
	}

	/// <summary>
	/// 結束遊戲, 將套用正確的活動並顯示右側面板
	/// </summary>
	public void EndGame() {
		isActive = false;

		// 隱藏右側面板
		menuPanel.gameObject.SetActive(false);
		gamePanel.gameObject.SetActive(false);
		endPanel.gameObject.SetActive(true);
	}

	/// <summary>
	/// 發射球來自生成點 和 設定推力
	/// </summary>
	/// <param name="force"></param>
	public void ShootBall(float force) {
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
	public void CheckGameState() {
		// 查找當前場景中的所有球
		int activeBallCount = FindObjectsOfType<Ball>().Length;

		// 如果沒有剩餘，則採取行動
		if (activeBallCount <= 0) {
			// 如果我們不能生成其他球，我們遊戲結束
			if (ballCount <= 0) {
				EndGame();
				SetBallReady(false);
			}
			else {
				SetBallReady(true);
			}
		}
	}

	/// <summary>
	/// 讓遊戲準備好發射球
	/// 還將更新虛擬顯示球和UI界面
	/// </summary>
	/// <param name="ready"></param>
	void SetBallReady(bool ready) {
		ballReady = ready;
		ballDisplay.SetActive(ready);
		ballCountText.text = ballCount.ToString();
	}
}
