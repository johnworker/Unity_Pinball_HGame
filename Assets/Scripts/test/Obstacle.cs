using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // �˴���I�����ﹳ�O�y��
        if (collision.gameObject.CompareTag("Ball"))
        {
            // �P����ê��
            Destroy(gameObject);
        }
    }
};