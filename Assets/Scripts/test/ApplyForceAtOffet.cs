using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForceAtOffet : MonoBehaviour
{
    [Header("力量")]
    public float force = 100.0f;
    [Header("力量方向")]
    public Vector3 forceDirection = Vector3.forward;

    [Header("按鈕名稱")]
    public string buttonName = "Fire1";
    [Header("偏移路徑")]
    public Vector3 offset;


    void Update()
    {
        // 輸入按鈕
        if (Input.GetButton(buttonName))
        {
            // 取得剛體.添加推力方位(力量方向.歸一化 * 力量, 方位 + 偏移)
            GetComponent<Rigidbody>().AddForceAtPosition(forceDirection.normalized * force, transform.position + offset);
        }
        else
        {
            // 取得剛體.添加推力方位(力量方向.歸一化 * -力量, 方位 + 偏移)
            GetComponent<Rigidbody>().AddForceAtPosition(forceDirection.normalized * -force, transform.position + offset);
        }
    }
}
