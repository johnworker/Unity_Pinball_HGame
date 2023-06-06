using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSet : MonoBehaviour
{
	// instance：這是一個靜態屬性，用於存儲 Game 類別的唯一實例。
	// 可以通過 Game.instance 來訪問這個實例。
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
	[Header("初始彈珠數量")]
	public int ballStartCount = 3;

	// 管理遊戲的分數
	public GameScore score { get; private set; }
	// 用於控制遊戲的行為
	public GameController controller { get; private set; }
	[Header("表示其他的 Canvas（畫布）")]
	public GameObject otherCanvas;

	void Awake()
	{
		instance = this;

		score = GetComponent<GameScore>();
		controller = GetComponent<GameController>();
	}

	/*在 Awake() 方法中，首先將 instance 屬性設置為當前的 Game 實例。
	 * 這樣可以在其他地方通過 Game.instance 訪問這個實例。

	 *接下來，使用 GetComponent<T>() 方法，從當前物件上獲取 GameScore 組件並將其賦值給 score 屬性。
	 *這意味著當前的 Game 物件具有一個 GameScore 組件，並且可以通過 score 屬性來訪問該組件。

	 *同樣地，使用 GetComponent<T>() 方法，從當前物件上獲取 GameController 組件並將其賦值給 controller 屬性。
	 *這意味著當前的 Game 物件具有一個 GameController 組件，並且可以通過 controller 屬性來訪問該組件。

	 *總結來說，Awake() 方法在遊戲物件被創建時被調用，它將設置 Game 類別的 instance 屬性、獲取並設置 GameScore 和 GameController 組件的參考。
	 *這樣可以在遊戲運行期間輕鬆地訪問這些組件並執行相關的操作。
	 */

	void Start()
	{
		isActive = false;


		// 顯示右側的 UI 面板
		menuPanel.gameObject.SetActive(true);
		gamePanel.gameObject.SetActive(false);
		endPanel.gameObject.SetActive(false);

		otherCanvas.SetActive(true);
	}
	/*
	 * 在 Start() 方法中，首先將 isActive 屬性設置為 false，表示遊戲目前不處於活動狀態。
	 * 接下來，調用 SetBallReady(false) 方法，將 ballReady 屬性設置為 false，表示彈珠目前不準備射擊。
	 * 然後，通過設置 menuPanel、gamePanel 和 endPanel 的 gameObject.SetActive(true/false)，來顯示或隱藏對應的 UI 面板。
	 * 這裡將 menuPanel 設置為顯示，而 gamePanel 和 endPanel 設置為隱藏。
	 * 最後，將 otherCanvas 的 SetActive(true) 設置為啟用，以顯示其他的 Canvas（畫布）。

	 總結來說，Start() 方法在遊戲物件啟用時被調用，它設置了遊戲的初始狀態，包括設置遊戲為非活動狀態、
	 彈珠不準備射擊、顯示相應的 UI 面板以及啟用其他的 Canvas。
	 這些設置可以在遊戲開始時呈現正確的初始畫面和狀態。
	*/

	/// <summary>
	/// 開始遊戲, 將套用正確的活動並顯示右側面板
	/// </summary>
	public void StartGame()
	{
		isActive = true;
		ballCount = ballStartCount;
		ballCountText.text = ballCount.ToString();

		score.ClearScore();

		// 隱藏右側面板
		menuPanel.gameObject.SetActive(false);
		gamePanel.gameObject.SetActive(true);
		endPanel.gameObject.SetActive(false);

		otherCanvas.SetActive(false);
	}

	/// <summary>
	/// 結束遊戲, 將套用正確的活動並顯示右側面板
	/// </summary>
	public void EndGame()
	{

		isActive = false;

		otherCanvas.SetActive(true);


		// 隱藏右側面板
		menuPanel.gameObject.SetActive(false);
		gamePanel.gameObject.SetActive(false);
		endPanel.gameObject.SetActive(true);


	}

}
