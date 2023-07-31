﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 確保將在此對像上調用 OnCollisionEnter
[RequireComponent(typeof(Collider))]
public class FieldBumper : MonoBehaviour {
	// 球反射的強度有多大
	public float bounceForce = 1.2f;

	[SerializeField, Header("彈力音效")]
	private AudioClip soundRebound;

	/// <summary>
	/// 將檢查球是否與該對象發生碰撞
	/// 如果是這樣，請施加第一個接觸點乘以彈跳力的負力
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter(Collision collision) {
		Ball ball = collision.transform.GetComponent<Ball>();

		if (ball) {
			ball.AddForce(-(collision.contacts[0].normal * bounceForce));
			SystemSound.instance.PlaySound(soundRebound, new Vector2(0.9f, 1.4f));
		}
	}
}
