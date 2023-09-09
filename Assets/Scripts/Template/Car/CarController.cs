using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("車體移動")]
    public string parCarBodyMove = "車體移動";  // 車體移動 bool
    [Header("右前輪滾動")]
    public string parRightFrontRoll = "右前輪滾動";  // 右前輪滾動 bool
    [Header("右後輪滾動")]
    public string parRightBackRoll = "右後輪滾動";  // 右後輪滾動 bool
    [Header("左前輪滾動")]
    public string parLeftFrontRoll = "左前輪滾動";  // 左前輪滾動 bool
    [Header("左後輪滾動")]
    public string parLeftBackRoll = "左後輪滾動";  // 左後輪滾動 bool

    public float forwardSpeed = 10.0f;
    public float backwardSpeed = -5.0f;
    public float stopDuration = 2.0f; // 停止的時間（秒）

    private Animator carBodyAnimator;
    public Animator wheelRightFrontAnimator;
    public Animator wheelRightBackAnimator;
    public Animator wheelLeftFrontAnimator;
    public Animator wheelLeftBackAnimator;


    private void Start()
    {
        carBodyAnimator = GetComponent<Animator>();


        // 啟動協程開始車輛運動循環
        StartCoroutine(CarMotionLoop());
    }

    private IEnumerator CarMotionLoop()
    {
        while (true)
        {
            // 車體移動
            carBodyAnimator.SetBool(parCarBodyMove, true);
            wheelRightFrontAnimator.SetBool(parRightFrontRoll, true);
            wheelRightBackAnimator.SetBool(parRightBackRoll, true);
            wheelLeftFrontAnimator.SetBool(parLeftFrontRoll, true);
            wheelLeftBackAnimator.SetBool(parLeftBackRoll, true);

            // 前進
            yield return new WaitForSeconds(forwardSpeed);

            // 靜止
            carBodyAnimator.SetBool(parCarBodyMove, false); 
            wheelRightFrontAnimator.SetBool(parRightFrontRoll, false);
            wheelRightBackAnimator.SetBool(parRightBackRoll, false);
            wheelLeftFrontAnimator.SetBool(parLeftFrontRoll, false);
            wheelLeftBackAnimator.SetBool(parLeftBackRoll, false);

            yield return new WaitForSeconds(stopDuration);

        }
    }
}
