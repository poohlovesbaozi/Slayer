using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] CharacterStatsSO characterStats;
    [SerializeField] CharacterStatsSO templateStats;
    private void Awake()
    {
        if (templateStats != null)
            characterStats = Instantiate(templateStats);
    }
    #region Read from DataSO
    public int MaxHp
    {
        get { if (characterStats == null) return 0; else return characterStats.maxHp; }
        set { characterStats.maxHp = value; }
    }
    public int CurrentHp
    {
        get { if (characterStats == null) return 0; else return characterStats.currentHp; }
        set { characterStats.currentHp = value; }
    }
    public int AzureGem
    {
        get { if (characterStats == null) return 0; else return characterStats.azureGem; }
        set { characterStats.azureGem = value; }
    }
    public float InvulnerableDuration
    {
        get { if (characterStats == null) return 0; else return characterStats.invulnerableDuration; }
        set { characterStats.invulnerableDuration = value; }
    }
    public float CheckRadius
    {
        get { if (characterStats == null) return 0; else return characterStats.checkRadius; }
    }
    public float Spd
    {
        get { if (characterStats == null) return 0; else return characterStats.spd; }
        set { characterStats.spd = value; }
    }
    public float FireInterval
    {
        get { if (characterStats == null) return 0; else return characterStats.fireInterval; }
        set { characterStats.fireInterval = value; }
    }
    public int Level
    {
        get { if (characterStats == null) return 0; else return characterStats.level; }
        set { characterStats.level = value; }
    }
    public int Exp
    {
        get { if (characterStats == null) return 0; else return characterStats.exp; }
        set { characterStats.exp = value; }
    }
    public int ExpToNextLevel
    {
        get { if (characterStats == null) return 0; else return characterStats.expToNextLevel; }
        set { characterStats.expToNextLevel = value; }
    }
    public int AbilityPoint
    {
        get { if (characterStats == null) return 0; else return characterStats.abilityPoint; }
        set { characterStats.abilityPoint = value; }
    }
    public int Attack
    {
        get { if (characterStats == null) return 0; else return characterStats.attack; }
        set { characterStats.attack = value; }
    }
    public int UpgradeLimit
    {
        get { if (characterStats == null) return 0; else return characterStats.upgradeLimit; }
        set { characterStats.upgradeLimit = value; }
    }
    public int CurrentAtkUpgradedTimes
    {
        get { if (characterStats == null) return 0; else return characterStats.currentAtkUpgradedTimes; }
        set { characterStats.currentAtkUpgradedTimes = value; }
    }
    public int CurrentFireIntervalUpgradedTimes
    {
        get { if (characterStats == null) return 0; else return characterStats.currentFireIntervalUpgradedTimes; }
        set { characterStats.currentFireIntervalUpgradedTimes = value; }
    }
    public int CurrentMaxHpUpgradedTimes
    {
        get { if (characterStats == null) return 0; else return characterStats.currentMaxHpUpgradedTimes; }
        set { characterStats.currentMaxHpUpgradedTimes = value; }
    }
    #endregion
}
