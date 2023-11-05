using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUpPanel : MonoBehaviour
{
    [SerializeField] float attackValue;
    [SerializeField] float attackIntervalValue;
    [SerializeField] int maxHpValue;
    [SerializeField] CharacterStats playerStats;
    [SerializeField]TMP_Text abilityPointCount;
    private void OnEnable()
    {
        OnPointChange();
    }
    public void UpgradeAttack(CharacterStats stats)
    {
        if (playerStats.AbilityPoint > 0 && stats.CurrentUpgradedTimes <= stats.UpgradeLimit)
        {
            playerStats.AbilityPoint--;
            stats.CurrentUpgradedTimes++;
            stats.Attack += attackValue;
        }
    }
    public void UpgradeFireInterval(CharacterStats stats)
    {
        if (playerStats.AbilityPoint > 0 && stats.CurrentUpgradedTimes <= stats.UpgradeLimit)
        {
            playerStats.AbilityPoint--;
            stats.CurrentUpgradedTimes++;
            stats.FireInterval -= attackIntervalValue;
        }
    }
    public void UpgradeMaxHp(CharacterStats stats)
    {
        if (playerStats.AbilityPoint > 0 && stats.CurrentUpgradedTimes <= stats.UpgradeLimit)
        {
            playerStats.AbilityPoint--;
            stats.CurrentUpgradedTimes++;
            stats.MaxHp += maxHpValue;
        }
    }
    public void OnPointChange()
    {
        abilityPointCount.SetText("Point : " + playerStats.AbilityPoint);
    }
    public void OnAbilityChange(TMP_Text text,int value)
    {
        text.SetText(value.ToString());
    }
}
