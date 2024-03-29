﻿using System.Collections;
using UnityEngine;

public class ColumnController : MonoBehaviour
{
    public float fallSpeed = 2f; // 下降速度
    public float spawnInterval = 60f; // 生成间隔时间（秒）

    public Vector2 spawnAreaSize = new Vector2(4f, 4f); // 生成区域大小

    private float nextSpawnTime = 0f;

    public GameObject column;


    private void Start()
    {
        // 初始生成时间
        nextSpawnTime = Time.time + spawnInterval;
    }

    private void Update()
    {
        // 检查是否可以生成
        if (Time.time >= nextSpawnTime)
        {
            // 随机生成位置
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                spawnAreaSize.y,
                0f
            );

            // 随机生成旋转角度
            Quaternion spawnRotation = Quaternion.Euler(-90f, 0f, 0f);

            // 生成"天柱"的新实例
            Instantiate(column, spawnPosition, spawnRotation);

            // 更新下一次生成时间
            nextSpawnTime = Time.time + spawnInterval;
        }
    }


    // 在Scene视图中绘制Gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaSize.x, 1f, spawnAreaSize.y));
    }
}
