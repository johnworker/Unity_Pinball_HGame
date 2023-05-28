using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [Header("回到原位置")]
    public float restPosition = 0f;
    [Header("壓下位置")]
    public float pressedPosition = 45f;
    [Header("打擊力量")]
    public float hitStrenght = 10000f;
    [Header("擋板控制器")]
    public float flipperDamper = 150f;

    [Header("輸入名稱")]
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
