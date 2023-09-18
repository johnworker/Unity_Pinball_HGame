using UnityEngine;
using System.Collections;
using UnityEditor;

public class EnemyMovement : MonoBehaviour
{
    public DataBasic dataBasic;

    [Header("移動範圍的半徑")]
    public float moveRange = 5.0f;
    private Vector3 targetPosition;
    private bool isMoving = false;

    private Vector3 lastGeneratedPosition; // 最後生成位置

    [SerializeField, Header("受傷音效")]
    private AudioClip obstacleSoundHurt;

    private void Start()
    {
        lastGeneratedPosition = transform.position;
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    public void SetTargetPosition(Vector3 newPosition)
    {
        // 確保目標位置在移動範圍內
        targetPosition.x = Mathf.Clamp(targetPosition.x, transform.position.x - moveRange, transform.position.x + moveRange);
        newPosition.x = GenerateUniqueXPosition(newPosition.x);
        newPosition.y = -0.6f; // 限制 Y 軸高度為 1
        newPosition.z = Mathf.Clamp(newPosition.z, transform.position.z - 2.0f, transform.position.z); // 限制在生成點到 -2 之間的隨機值
        targetPosition = newPosition;
        isMoving = true;
    }

    private float GenerateUniqueXPosition(float x)
    {
        float uniqueX = x;

        while (Mathf.Abs(uniqueX - lastGeneratedPosition.x) < 1.0f) // 確保新生成的位置不與上一個位置過於接近
        {
            uniqueX = Random.Range(-1.0f, 1.0f); // 重新生成 X 位置
        }

        lastGeneratedPosition.x = uniqueX;
        return uniqueX;
    }


    private void MoveTowardsTarget()
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, dataBasic.moveSpeed * Time.deltaTime);
        transform.position = newPosition;

        if (transform.position == targetPosition)
        {
            isMoving = false;
            // 在到達目標位置時執行相應的操作，比如停止移動或改變行為
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            SystemSound.instance.PlaySound(obstacleSoundHurt, new Vector2(2f, 2.3f));
            Destroy(gameObject);
        }
    }
}