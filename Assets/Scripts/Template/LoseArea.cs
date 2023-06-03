using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 確保將在此對像上調用 OnCollisionEnter
[RequireComponent(typeof(Collider))]
public class LoseArea : MonoBehaviour {

	/// <summary>
	/// 將檢查球是否與該對象發生碰撞
	/// </summary>
	/// <param name="collider"></param>
	void OnTriggerEnter(Collider collider) {
		Ball ball = collider.transform.GetComponent<Ball>();

		if (ball) {
			// 如果我們想要整個東西消失，可以將其更改為 .gameObject
			// 但現在我們只是毀掉腳本，讓球留下來
			Destroy(ball.gameObject);

			// 有時 摧毀 足夠快，有時又不夠快
			Game.instance.CheckGameState();
			StartCoroutine(UpdateGame());
		}
	}

	/// <summary>
	/// 由於 Destroy(...) 速度較慢，一幀後調用 CheckGameState
	/// </summary>
	/// <returns></returns>
	IEnumerator UpdateGame() {
		yield return null;

		Game.instance.CheckGameState();
	}
}
