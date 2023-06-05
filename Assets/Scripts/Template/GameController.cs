using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Game))]
public class GameController : MonoBehaviour {

	/* 這裡使用了 RequireComponent 屬性，這是一個 Unity 引擎提供的特殊屬性。
	 * 它可以確保附加到同一個 GameObject 上的類別具有指定的組件。
	 * 在這個例子中，RequireComponent(typeof(Game)) 表示這個 GameController 類別需要附加一個 Game 組件。
	 * 這個 Game 組件可能是一個自定義的組件，可能包含了遊戲邏輯、遊戲狀態管理等相關功能。
	 * 這個 GameController 類別可能負責協調和控制整個遊戲的行為，並在遊戲運行時與 Game 組件進行交互。
	 * 通過使用 RequireComponent 屬性，可以確保當你將 GameController 腳本附加到 GameObject 上時，它將自動附加一個 Game 組件。
	 * 這有助於確保遊戲運行所需的相關組件始終存在並一起使用。
	 
	 * 總結來說，這個 GameController 類別是一個控制遊戲行為的類別，並要求附加一個 Game 組件。
	 * 這個 Game 組件可能包含了遊戲的核心邏輯和狀態管理。 */

	[Header("彈簧")]
	public HingeJoint leftFlipper;
	public HingeJoint rightFlipper;
	[Header("彈簧活動角度")]
	public float flipperActiveAngle = 45;

	[Header("彈珠")]
	[Header("力量範圍")]
	public Vector2 minMaxForce = new Vector2(10, 20);
	[Header("力量增益")]
	public float powerGain = 1.2f;
	[Header("UI 圖像")]
	public Image powerImage;

	// 用於儲存 Game 類別的實例
	private Game game;

	// 浮點數 力量
	private float power;

	void Awake() {
		// 它會獲取這個腳本所附加的 GameObject 上的 Game 類別組件並將其賦值給 game 變數
		game = GetComponent<Game>();
	}

	void Update() {
		// 在遊戲運行時做我們想做的事
		if (game.isActive) {
			if (game.ballReady) {
				ShootInput();
			}
		}
		/*首先，它檢查 game.isActive 的值。
		 * game 是之前在 Awake() 方法中賦值的 Game 類別的實例。
		 * 如果 game.isActive 為真，則表示遊戲正在運行中。
		 * 接下來，它檢查 game.ballReady 的值。
		 * 這可能是一個布林（bool）型別的變數，用於檢查球是否準備好射擊。
		 * 如果 game.ballReady 為真，則執行 ShootInput() 方法。
		 * 該方法可能包含了處理射擊球的邏輯。*/

		// 在主菜單中允許擋板
		FlipperInput();
	}

	/// <summary>
	/// 根據輸入管理彈簧角度值
	/// </summary>
	void FlipperInput() {
		// 左彈簧
		JointSpring leftSpring = leftFlipper.spring;
		/*使用條件運算符 ? 來根據按鍵輸入設置左彈簧的目標位置。
		 * 如果按下 A 鍵或左箭頭鍵，則將目標位置設置為 flipperActiveAngle，否則設置為 0。
		 */
		leftSpring.targetPosition = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ? flipperActiveAngle : 0f;
		leftFlipper.spring = leftSpring;

		// 右彈簧
		JointSpring rightSpring = rightFlipper.spring;
		/*使用條件運算符 ? 來根據按鍵輸入設置右彈簧的目標位置。
		 * 如果按下 A 鍵或右箭頭鍵，則將目標位置設置為 flipperActiveAngle，否則設置為 0。
		 */
		rightSpring.targetPosition = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ? flipperActiveAngle : 0f;
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
	 在這個方法中，有幾個邏輯判斷：
	 
	 首先，它檢查是否按下了空白鍵（KeyCode.Space）。
	 如果是，則根據 powerGain 值和 Time.deltaTime（當前幀的時間間隔）來增加 power 變數的值。
	 這段程式碼的目的是在按住空白鍵時增加力量值（power）。
	 
	 接下來，它檢查是否釋放了空白鍵。
	 如果是，則根據 power 的值計算出射擊力量，並呼叫 game.ShootBall() 方法將球射出。
	 射擊力量的計算是基於 minMaxForce 的範圍，並使用 Mathf.Clamp01() 方法將 power 限制在 0 到 1 之間。
	 然後，使用線性插值來計算在 minMaxForce 範圍內的具體力量值，並將其作為參數傳遞給 game.ShootBall() 方法。

	 最後，它將 power 的值用於更新 UI，具體來說是更新 powerImage 的 fillAmount 屬性。
	 這個屬性表示填充圖像的比例，這裡使用 power 的值作為填充比例，因此當力量增加時，UI 會反映出力量的變化。

	 總結來說，這個方法在按下和釋放空白鍵時管理射擊彈珠的邏輯。
	 它追蹤並增加力量值，根據力量值計算射擊力量並觸發射擊行為，同時也更新了 UI 以反映力量的變化。
	*/
}
