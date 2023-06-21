using System.Collections;
using UnityEngine;

public class HurtAnimation : MonoBehaviour
{
    public Renderer[] renderers;            // 模型的渲染器數組
    public Material hurtMaterial;           // 受傷時的材質
    public float blinkDuration = 0.2f;      // 閃爍的時間間隔
    public int blinkCount = 3;              // 閃爍的次數

    private Material[] originalMaterials;   // 模型原始的材質
    private bool isHurt;                     // 是否正在受傷中

    private void Start()
    {
        // 保存模型原始的材質
        originalMaterials = new Material[renderers.Length];
        for (int i = 0; i < renderers.Length; i++)
        {
            originalMaterials[i] = renderers[i].material;
        }
    }

    public void TakeDamage()
    {
        if (!isHurt)
        {
            // 開始受傷動畫
            StartCoroutine(HurtAnimationCoroutine());
        }
    }

    private IEnumerator HurtAnimationCoroutine()
    {
        isHurt = true;

        for (int i = 0; i < blinkCount; i++)
        {
            // 設置模型材質為受傷材質
            SetModelMaterial(hurtMaterial);

            // 等待指定的時間間隔
            yield return new WaitForSeconds(blinkDuration);

            // 恢復模型原始材質
            SetModelMaterial(originalMaterials);

            // 等待指定的時間間隔
            yield return new WaitForSeconds(blinkDuration);
        }

        isHurt = false;
    }

    private void SetModelMaterial(Material material)
    {
        // 設置模型渲染器的材質
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material = material;
        }
    }

    private void SetModelMaterial(Material[] materials)
    {
        // 恢復模型渲染器的材質為原始材質
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material = materials[i];
        }
    }
}