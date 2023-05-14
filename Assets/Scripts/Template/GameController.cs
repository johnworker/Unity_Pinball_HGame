using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Game))]
public class GameController : MonoBehaviour {

	[Header("Flippers")]
	public HingeJoint leftFlipper;
	public HingeJoint rightFlipper;
	public float flipperActiveAngle = 45;

	[Header("Ball")]
	public Vector2 minMaxForce = new Vector2(10, 20);
	public float powerGain = 1.2f;
	public Image powerImage;

	private Game game;

	private float power;

	void Awake() {
		game = GetComponent<Game>();
	}

	void Update() {
		// 在遊戲運行時做我們想做的事
		if (game.isActive) {
			if (game.ballReady) {
				ShootInput();
				// StartCoroutine(AutoShootWait());
			}
		}

		// 在主菜單中允許擋板
		FlipperInput();
	}

	/// <summary>
	/// 根據輸入管理彈簧角度值
	/// </summary>
	void FlipperInput() {
		// 左彈簧
		JointSpring leftSpring = leftFlipper.spring;
		leftSpring.targetPosition = Input.GetKey(KeyCode.A) ? -flipperActiveAngle : 0f;
		leftFlipper.spring = leftSpring;

		// 右彈簧
		JointSpring rightSpring = rightFlipper.spring;
		rightSpring.targetPosition = Input.GetKey(KeyCode.D) ? flipperActiveAngle : 0f;
		rightFlipper.spring = rightSpring;
	}

	/// <summary>
	/// 按鈕輸入射擊彈珠管理
	/// </summary>
	void ShootInput() {
		// 如果按下鍵獲得發射 能量
		if (Input.GetKey(KeyCode.Space)) {
			power += powerGain * Time.deltaTime;
		}

		// 釋放時在 minMaxForce 之間添加基於 0..1
		if (Input.GetKeyUp(KeyCode.Space)) {
			game.ShootBall(minMaxForce.x + (Mathf.Clamp01(power) * (minMaxForce.y - minMaxForce.x)));
			power = 0f;
		}

		// 更新 UI（將自動夾在 0..1 之間）
		powerImage.fillAmount = power;
	}
	
	/*
	// 按下開始按鈕幾秒後自動發射彈珠
	IEnumerator AutoShootWait()
	{
		yield return new WaitForSeconds(3f);

		GameObject.FindObjectOfType<Game>().StartGame();
		game.ShootBall(minMaxForce.x + (Mathf.Clamp01(minMaxForce.y - minMaxForce.x)));

		// 發射一顆彈珠停止
	}
	*/

}
