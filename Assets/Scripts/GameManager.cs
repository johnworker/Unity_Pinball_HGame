using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            // �W�[�o��
            score += 100;
            // ��s�o�����
            scoreText.text = "Score: " + score.ToString();
            // ���񭵮ĩβɤl�ĪG��
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // ��֥ͩR�Ψ�L�B�@
            // ���񭵮ĩβɤl�ĪG��
        }
    }
}
