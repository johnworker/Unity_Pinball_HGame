using UnityEngine;

public class FieldObject : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool isVisible;

    private void Start()
    {
        // 在開始時記錄初始位置和旋轉
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        isVisible = true;
    }

    private void Update()
    {
        // 在 Update 方法中更新物體狀態和行為
        // 這裡只是示例，您可以根據需要進行擴展

        // 檢測輸入示例：按下空格鍵重置物體位置和旋轉
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetObject();
        }

        // 檢測輸入示例：按下 V 鍵切換物體可見性
        if (Input.GetKeyDown(KeyCode.V))
        {
            ToggleVisibility();
        }
    }

    private void ResetObject()
    {
        // 將物體位置和旋轉重置為初始狀態
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }

    private void ToggleVisibility()
    {
        // 切換物體可見性
        isVisible = !isVisible;
        gameObject.SetActive(isVisible);
    }
}