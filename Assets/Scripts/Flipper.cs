using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [Header("�^����m")]
    public float restPosition = 0f;
    [Header("���U��m")]
    public float pressedPosition = 45f;
    [Header("�����O�q")]
    public float hitStrenght = 10000f;
    [Header("�תO���")]
    public float flipperDamper = 150f;

    [Header("��J�W��")]
    public string inputName;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetAxis(inputName) == 1)
        {

        }
    }
}
