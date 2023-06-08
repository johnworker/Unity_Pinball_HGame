using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Leo/data")]
public class DataEnemy : ScriptableObject
{
	[Header("��q"), Range(0, 1000)]
	public float hp;
}
