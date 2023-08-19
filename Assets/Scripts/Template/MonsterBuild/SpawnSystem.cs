using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [Header("生成怪物預置物")]
    public GameObject preEnemy;
    [Header("生成怪物間隔時間"),Range(0, 60)]
    public float interval = 5f;
	[Header("生成怪物預置物")]
	public Transform spawnPoint;


	private void SpawnEnemy()
	{
		Instantiate(preEnemy, spawnPoint);
	}

	private void Awake()
	{
		InvokeRepeating("SpawnEnemy", 3, interval);
	}
}
