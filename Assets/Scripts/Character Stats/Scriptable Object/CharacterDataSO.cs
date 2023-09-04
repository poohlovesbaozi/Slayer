using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Character Stats/Data")]
public class CharacterDataSO : ScriptableObject {
[Header("基本数值")]
public float maxHp;
public int level;
public float hp;
}
