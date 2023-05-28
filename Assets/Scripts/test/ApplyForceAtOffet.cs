using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForceAtOffet : MonoBehaviour
{
    [Header("�O�q")]
    public float force = 100.0f;
    [Header("�O�q��V")]
    public Vector3 forceDirection = Vector3.forward;

    [Header("���s�W��")]
    public string buttonName = "Fire1";
    [Header("�������|")]
    public Vector3 offset;


    void Update()
    {
        // ��J���s
        if (Input.GetButton(buttonName))
        {
            // ���o����.�K�[���O���(�O�q��V.�k�@�� * �O�q, ��� + ����)
            GetComponent<Rigidbody>().AddForceAtPosition(forceDirection.normalized * force, transform.position + offset);
        }
        else
        {
            // ���o����.�K�[���O���(�O�q��V.�k�@�� * -�O�q, ��� + ����)
            GetComponent<Rigidbody>().AddForceAtPosition(forceDirection.normalized * -force, transform.position + offset);
        }
    }
}
