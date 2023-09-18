using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [Header("速度")]
    public float speed = 1f;

    private void Update()
    {
        transform.Rotate(0f, 5f * speed * Time.deltaTime, 0f);
    }
}
