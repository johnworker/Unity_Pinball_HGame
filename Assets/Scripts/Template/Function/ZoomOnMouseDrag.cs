using UnityEngine;

public class ZoomOnMouseDrag : MonoBehaviour
{
    private Vector3 dragOrigin;
    private float dragSpeed = 0.1f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 dragDelta = currentMousePosition - dragOrigin;

            // 计算缩放值并应用于摄影机的位置
            float zoomAmount = dragDelta.y * dragSpeed;
            Camera.main.transform.Translate(0, 0, zoomAmount);

            // 更新拖动的起始点
            dragOrigin = currentMousePosition;
        }
    }
}