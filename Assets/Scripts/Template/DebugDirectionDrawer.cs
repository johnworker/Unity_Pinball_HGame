using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 快速測試腳本以查看在前進上物體是什麼
public class DebugDirectionDrawer : MonoBehaviour {
	public float length = 1f;

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.position + (transform.forward * length));
	}
}
