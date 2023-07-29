using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenLevelController : MonoBehaviour
{
    public Light hiddenLevelLight; // 对应隐藏关卡中的灯光

    private void Awake()
    {
        // 开启灯光
        if (hiddenLevelLight != null)
        {
            hiddenLevelLight.enabled = true;
        }
    }
}
