using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] CharacterDataSO characterData;
    public float maxHp
    {
        get => characterData?.maxHp ?? 0;
        set => characterData.maxHp = value;
    }
    float hp
    {
        get => characterData?.hp ?? 0;
        set => characterData.hp = value;
    }
    int level
    {
        get => characterData?.level ?? 0;
        set => characterData.level = value;
    }
}
