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
    [Header("生成敵人建築")]
    public GameObject spawnEnemyBuild;
    [Header("生成敵人建築動畫控制器")]
    public Animator ani;
    [Header("生成敵人建築開門參數")]
    public string openDoor = "開門";


    private void Start()
	{
		InvokeRepeating("SpawnEnemy", 3, interval);
	}

    private void SpawnEnemy()
    {
        GameObject spawnNewEnemy = Instantiate(preEnemy, spawnPoint.position, Quaternion.Euler(0, 180, 0));
        EnemyMovement enemyMovement = spawnNewEnemy.GetComponent<EnemyMovement>();

        if (spawnNewEnemy != null && enemyMovement != null)
        {
            // 播放開門動畫
            ani.SetBool(openDoor, true);

            float randomX = Random.Range(movePointLeft.transform.position.x, movePointRight.transform.position.x);
            Vector3 newPosition = new Vector3(randomX, 1.0f, Random.Range(spawnPoint.position.z - 6.0f, spawnPoint.position.z));
            enemyMovement.SetTargetPosition(newPosition * dataBasic.moveSpeed);

            StartCoroutine(ResetOpenDoorAnimation()); // 啟動協程，重置開門動畫
        }
    }

    /// <summary>
    /// 重置開門動畫
    /// </summary>
    /// <returns></returns>
    private IEnumerator ResetOpenDoorAnimation()
    {
        yield return new WaitForEndOfFrame(); // 等待到當前幀結束
                                              // 等待開門動畫播放完畢
        while (ani.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        // 動畫播放完畢，重置開門動畫狀態
        ani.SetBool(openDoor, false);
    }
}
