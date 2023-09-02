using UnityEngine;

public class BuildState : MonoBehaviour
{
    private int hitCount = 0; // 記錄被打的次數
    [Header("可被打擊次數")]
    public int canHitCountNumbers = 1; // 記錄被打的次數
    [SerializeField, Header("帳篷撞擊音效")]
    private AudioClip soundTentHit;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitCount++;
            SystemSound.instance.PlaySound(soundTentHit, new Vector2(0.9f, 1.6f));


            if (hitCount >= canHitCountNumbers)
            {
                Destroy(gameObject);
            }
        }
    }
}
