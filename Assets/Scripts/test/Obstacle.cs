using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private int hitCount = 0; // �O���Q��������

    private void OnCollisionEnter(Collision collision)
    {
        // �˴���I�����ﹳ�O�y��
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitCount++; // �W�[�Q��������

            // �p�G�Q�����ƹF��3���A�h�P����ê��
            if (hitCount >= 3)
            {
                Destroy(gameObject);
            }
        }
    }
}




