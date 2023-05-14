using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 確保它有一個剛體來執行 取得組件
[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {
	public Rigidbody rigidBody { get; private set; }

	void Awake() {
		rigidBody = GetComponent<Rigidbody>();
	}

	/// <summary>
	/// 給球加一個瞬間力
	/// </summary>
	/// <param name="force"></param>
	public void AddForce(Vector3 force) {
		rigidBody.AddForce(force, ForceMode.VelocityChange);
	}
}
