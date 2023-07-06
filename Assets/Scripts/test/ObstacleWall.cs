using System.Collections;
using UnityEngine;

public class ObstacleWall : MonoBehaviour
{
    [Header("升起/下降的延迟时间")]
    public float delay = 3f;
    [Header("升起/下降的持续时间")]
    public float duration = 1f;
    [Header("障碍物墙壁")]
    public GameObject wallTrap;
    [Header("障碍物墙壁的Transform组件")]
    public Transform wallTransform;
    [Header("陷阱預定移動點")]
    public Transform trapTransform;

    private Vector3 originalPosition;    // 原始位置
    private Vector3 targetPosition;    // 目標位置

    private bool isMovingUp = false;    // 是否正在向上移动
    private bool isMovingDown = false;    // 是否正在向下移动

    private void Awake()
    {
        originalPosition = transform.position;
        targetPosition = trapTransform.position;    // 升起的目标位置为地板的位置
    }

    private void Update()
    {
        StartCoroutine(ObstacleRoutine());
    }

    private IEnumerator ObstacleRoutine()
    {
        while (true)
        {
            // 等待延迟时间
            yield return new WaitForSeconds(delay);

            // 开始升起
            StartCoroutine(MoveToTarget(targetPosition));

            // 等待升起的持续时间
            yield return new WaitForSeconds(duration);

            // 开始下降
            StartCoroutine(MoveToTarget(originalPosition));
        }
    }

    private IEnumerator MoveToTarget(Vector3 target)
    {
        if (isMovingUp || isMovingDown) yield break;    // 如果正在移动中，退出协程

        isMovingUp = true;
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            transform.position = Vector3.Lerp(startingPosition, target, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 确保位置准确，避免浮点数精度问题
        transform.position = target;

        if (target == originalPosition)
        {
            isMovingDown = true;
        }
        else
        {
            isMovingUp = false;
        }
    }
}