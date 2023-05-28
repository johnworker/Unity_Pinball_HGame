using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForceAtOffet : MonoBehaviour
{
    public float force = 100.0f;
    public Vector3 forceDirection = Vector3.forward;

    // �}��²�������T�w��V

    public string buttonName = "Fire1";
    public Vector3 offset;


    void Update()
    {
        if (Input.GetButton(buttonName))
        {

            GetComponent<Rigidbody>().AddForceAtPosition(forceDirection.normalized * force, transform.position + offset);
        }
        else
        {
            GetComponent<Rigidbody>().AddForceAtPosition(forceDirection.normalized * -force, transform.position + offset);
        }
    }
}
