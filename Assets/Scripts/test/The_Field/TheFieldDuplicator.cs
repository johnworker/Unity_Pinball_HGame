using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Make sure OnCollisionEnter will get called on this object
// �T�O�N�b���ﹳ�W�ե� OnCollisionEnter
[RequireComponent(typeof(Collider))]
public class TheFieldDuplicator : MonoBehaviour
{
	public int ballCount = 1;
	public float cooldown = 1f;

	private GameSet game;
	private float nextCooldown;

	void Start()
	{
		game = GameSet.instance;
	}

	/// <summary>
	/// Will check if a ball collided with this object
	/// Has a set cooldown, if it has passed it will spawn a set amount of balls on the same spot
	/// �N�ˬd�y�O�_�P�ӹ�H�o�͸I��
	/// ���T�w���N�o�ɶ��A�p�G���w�g�L�h�A���|�b�P�@�Ӧa�貣�ͤ@�w�ƶq���y
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter(Collision collision)
	{
		Ball ball = collision.transform.GetComponent<Ball>();

		if (ball && Time.time > nextCooldown)
		{
			nextCooldown = Time.time + cooldown;

			for (int i = 0; i < ballCount; i++)
			{
				Instantiate(game.ballPrefab, ball.transform.position, ball.transform.rotation);
			}
		}
	}
}
