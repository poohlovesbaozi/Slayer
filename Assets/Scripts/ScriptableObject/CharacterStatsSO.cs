using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Data",menuName = "CharacterStat/Character Data")]
public class CharacterStatsSO : ScriptableObject
{
    [Header("Base Info")]
    public int maxHp;
    public int currentHp;
    public int azureGem;
    public float invulnerableDuration;
    public float checkRadius;
    public float spd;
    public float fireInterval;
    public int level;
    public int exp;
    public int expToNextLevel;
}
