using UnityEngine;

public class ChangeAlbedoColor : MonoBehaviour
{
    public Color initialColor = Color.yellow; // 初始的Albedo颜色

    private Renderer objectRenderer; // 当前物体的渲染器组件
    private Material originalMaterial; // 原始材质
    private Color originalColor; // 原始Albedo颜色

    private void Start()
    {
        // 获取当前物体的渲染器组件
        objectRenderer = GetComponent<Renderer>();

        // 保存原始材质和Albedo颜色
        originalMaterial = objectRenderer.material;
        originalColor = originalMaterial.color;

        // 将初始颜色设置给目标物体
        SetAlbedoColor(initialColor);
    }

    // 设置Albedo颜色
    public void SetAlbedoColor(Color color)
    {
        // 克隆原始材质
        Material newMaterial = new Material(originalMaterial);

        // 设置新的Albedo颜色
        newMaterial.color = color;

        // 将新的材质设置为物体的材质
        objectRenderer.material = newMaterial;
    }

    // 恢复原始Albedo颜色
    public void ResetAlbedoColor()
    {
        objectRenderer.material.color = originalColor;
    }
}