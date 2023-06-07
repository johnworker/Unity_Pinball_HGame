using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �T�O�N�b���ﹳ�W�ե� OnCollisionEnter
[RequireComponent(typeof(Collider))]
public class TheFieldBumper : MonoBehaviour
{
	// �y�Ϯg���j�צ��h�j
	public float bounceForce = 1.3f;

	/// <summary>
	/// �N�ˬd�y�O�_�P�ӹ�H�o�͸I��
	/// �p�G�O�o�ˡA�ЬI�[�Ĥ@�ӱ�Ĳ�I���H�u���O���t�O
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter(Collision collision)
	{
		Ball ball = collision.transform.GetComponent<Ball>();

		if (ball)
		{
			ball.AddForce(-(collision.contacts[0].normal * bounceForce));
		}
	}
}
