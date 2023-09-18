using UnityEngine;

public class RotateOnMouseDrag : MonoBehaviour
{
    private Vector3 dragOrigin;
    private Vector3 offset;
    private bool isDragging = false;

    void Update()
    {
        // 检测鼠标左键的按下和抬起
        if (Input.GetMouseButtonDown(0))
        {
            // 记录拖曳的起始点
            dragOrigin = Input.mousePosition;
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // 如果正在拖曳，计算鼠标移动的距离并旋转场景
        if (isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            offset = currentMousePosition - dragOrigin;

            // 旋转场景，这里可以根据需求调整旋转速度
            float rotationSpeed = 1.0f;
            transform.Rotate(Vector3.up * -offset.x * rotationSpeed, Space.World);

            // 更新拖曳的起始点
            dragOrigin = currentMousePosition;
        }
    }
}