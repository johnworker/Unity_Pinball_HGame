using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "DARKNESS/Data Basic")]
public class DataBasic : ScriptableObject
{
    [Header("移動速度"), Range(0, 100)]
    public float moveSpeed;
    [Header("攻擊速度"), Range(0, 50)]
    public float attackSpeed;
}
