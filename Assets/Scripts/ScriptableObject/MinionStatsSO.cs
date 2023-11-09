using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Data", menuName = "CharacterStat/Minion Data")]
public class MinionStatsSO : ScriptableObject
{
    public int maxHp;
    public int currentHp;
    public float checkRadius;
    public float normalSpd;
    public float dashSpd;
    public float currentSpd;
    public float hitForce;
    public int dropRate;
    public float waitDuration;
    public float waitDistance;
}
