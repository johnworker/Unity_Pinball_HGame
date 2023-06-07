using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Make sure OnCollisionEnter will get called on this object
// 確保將在此對像上調用 OnCollisionEnter
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
	/// 將檢查球是否與該對象發生碰撞
	/// 有固定的冷卻時間，如果它已經過去，它會在同一個地方產生一定數量的球
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
