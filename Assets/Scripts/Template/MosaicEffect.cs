using UnityEngine;

public class MosaicEffect : MonoBehaviour
{
    public Material mosaicMaterial; // 马赛克材质球

    void Start()
    {
        ApplyMosaicEffect();
    }

    void ApplyMosaicEffect()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (mosaicMaterial != null && renderer != null)
        {
            renderer.material = mosaicMaterial;
        }
        else
        {
            Debug.LogError("Mosaic material or renderer not found.");
        }
    }
}