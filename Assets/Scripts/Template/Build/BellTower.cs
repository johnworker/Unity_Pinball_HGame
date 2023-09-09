using System.Collections;
using UnityEngine;

public class BellTower : MonoBehaviour
{
    private int hitCount = 0; // �O���Q��������
    [Header("�i�Q��������")]
    public int canHitCountNumbers = 10; // �O���Q��������
    [SerializeField, Header("����������")]
    private AudioClip soundBellTowerHit;
    [Header("�ʵe���")]
    public Animator ani;
    [Header("�n�ʰѼ�")]
    public string parShake = "�\��";
    [Header("�n�ʵ����Ѽ�")]
    public string parShakeEnd = "�\�ʵ���";

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitCount++;
            ani.SetTrigger(parShake);
            SystemSound.instance.PlaySound(soundBellTowerHit, new Vector2(0.9f, 1.6f));


            if (hitCount >= canHitCountNumbers)
            {
                Destroy(gameObject);
            }

            else
            {
                // �b�\�ʰʵe���񧹫�A�]�m�n�ʵ����Ѽ�
                float shakeAnimationLength = ani.GetCurrentAnimatorStateInfo(0).length;
                StartCoroutine(ResetShakeParameter(shakeAnimationLength));
            }
        }
    }

    private IEnumerator ResetShakeParameter(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ani.SetTrigger(parShakeEnd);
    }
}
