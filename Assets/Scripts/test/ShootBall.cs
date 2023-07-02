using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    [Header("力量")]
    public float force = 100.0f;
    public string buttonName = "Fire1";

    private List<Rigidbody> ballList = new List<Rigidbody>();

    // Update is called once per frame
    void Update()
    {
        // 如果 輸入按鈕(buttonName)
        if (Input.GetButtonDown(buttonName))
        {
            foreach (Rigidbody ball in ballList)
            {
                ball.AddForce(Vector3.forward * force);
            }
        }
    }



    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Object Entered");
        if (col.GetComponent<Rigidbody>())
        {
            Debug.Log("Object Has Rigidbody");
            ballList.Add(col.GetComponent<Rigidbody>());
        }
    }



    void OnTriggerExit(Collider col)
    {
        Debug.Log("Object Exited");
        if (col.GetComponent<Rigidbody>())
        {
            Debug.Log("Object Has Rigidbody");
            ballList.Remove(col.GetComponent<Rigidbody>());
        }
    }
}