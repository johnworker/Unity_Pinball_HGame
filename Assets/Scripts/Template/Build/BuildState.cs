using UnityEngine;

public class BuildState : MonoBehaviour
{
    private int hitCount = 0; // 記錄被打的次數
    [Header("可被打擊次數")]
    public int canHitCountNumbers = 1; // 記錄被打的次數

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitCount++;

            if (hitCount >= canHitCountNumbers)
            {
                Destroy(gameObject);
            }
        }
    }
}
