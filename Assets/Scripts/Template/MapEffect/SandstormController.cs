using System.Collections;
using UnityEngine;

public class SandstormController : MonoBehaviour
{
    public GameObject sandstormParticles; // 沙塵暴的粒子系統
    public float timeBetweenSandstorms = 5.0f; // 沙塵暴之間的間隔時間，單位為秒
    public float timeNextSandstormsInterval = 60.0f; // 沙塵暴之間的間隔時間，單位為秒
    public float movementSpeed = 1.0f; // 沙塵暴的左右移動速度
    private bool isSandstormActive = false; // 標記沙塵暴是否正在進行

    [SerializeField, Header("風聲音效")]
    private AudioClip soundWindAcross;
    [SerializeField, Header("沙子音效")]
    private AudioClip soundSandAcross;


    private void Start()
    {
        sandstormParticles.SetActive(false);
        // 等待5秒後執行協同程序
        StartCoroutine(TriggerSandstorms());
    }

    private IEnumerator TriggerSandstorms()
    {
        while (true)
        {
            // 如果沙塵暴不在進行中，則開始沙塵暴
            if (!isSandstormActive)
            {
                SystemSound.instance.PlaySound(soundWindAcross, new Vector2(0.9f, 1.6f));

                isSandstormActive = true;
                sandstormParticles.SetActive(true);
                StartCoroutine(MoveSandstorm()); // 開始移動沙塵暴
                yield return new WaitForSeconds(timeBetweenSandstorms);
                // 停止沙塵暴
                sandstormParticles.SetActive(false);
                isSandstormActive = false;
                yield return new WaitForSeconds(timeNextSandstormsInterval);
            }
            yield return null;
        }
    }

    private IEnumerator MoveSandstorm()
    {
        while (isSandstormActive)
        {
            // 往左右移動
            Vector3 currentPosition = sandstormParticles.transform.position;
            float horizontalMovement = Mathf.Sin(Time.time * movementSpeed) * 0.005f; // 控制移動的幅度
            sandstormParticles.transform.position = new Vector3(currentPosition.x + horizontalMovement, currentPosition.y, currentPosition.z);
            yield return null;
        }
        SystemSound.instance.PlaySound(soundSandAcross, new Vector2(0.2f, 0.4f));
    }
}