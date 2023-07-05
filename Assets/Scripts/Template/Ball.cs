using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 確保它有一個剛體來執行 取得組件
[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {
	public Rigidbody rigidBody { get; private set; }

	public float speed = 5f;

	void Awake() {
		rigidBody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		// 根據剛體的速度更新球的旋轉
		if (rigidBody.velocity != Vector3.zero)
		{
			transform.rotation = Quaternion.LookRotation(rigidBody.velocity.normalized);
		}
	}

    /// <summary>
    /// 給球加一個瞬間力
    /// </summary>
    /// <param name="force"></param>
    public void AddForce(Vector3 force) 
	{
		rigidBody.AddForce(force, ForceMode.VelocityChange);

	}
}
