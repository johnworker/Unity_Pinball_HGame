using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private int hitCount = 0; // �O���Q��������


    [Header("�ʵe���")]
    public Animator ani;
    [Header("���˷n�ʰѼ�")]
    public string parHurtMove = "����";


    private void OnCollisionEnter(Collision collision)
    {
        // �˴���I�����ﹳ�O�y��
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Destroy(gameObject);

            ani.SetBool(parHurtMove, true);
            hitCount++; // �W�[�Q��������
            
            // �p�G�Q�����ƹF��3���A�h�P����ê��
            if (hitCount >= 3)
            {
                Destroy(gameObject);
            }
            
        }
        else
        {
            ani.SetBool(parHurtMove, false);
        }
    }
}



