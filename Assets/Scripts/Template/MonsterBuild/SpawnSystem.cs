using UnityEngine;
using System.Collections;

public class SpawnSystem : MonoBehaviour
{
    [Header("生成怪物預置物")]
    public GameObject preEnemy;
    [Header("生成怪物間隔時間"),Range(0, 300)]
    public float interval = 5f;
	[Header("怪物生成點")]
	public Transform spawnPoint;

	public DataBasic dataBasic;

	public GameObject movePointLeft;

	public GameObject movePointRight;

	private void Start()
	{
		InvokeRepeating("SpawnEnemy", 3, interval);
	}

    private void SpawnEnemy()
    {
        GameObject spawnNewEnemy = Instantiate(preEnemy, spawnPoint.position, Quaternion.Euler(0,180,0));
        EnemyMovement enemyMovement = spawnNewEnemy.GetComponent<EnemyMovement>();

        if (enemyMovement != null)
        {
            float randomX = Random.Range(movePointLeft.transform.position.x, movePointRight.transform.position.x);
            Vector3 newPosition = new Vector3(randomX, 1.0f, Random.Range(spawnPoint.position.z - 6.0f, spawnPoint.position.z));
            enemyMovement.SetTargetPosition(newPosition * dataBasic.moveSpeed);
        }
    }
}
