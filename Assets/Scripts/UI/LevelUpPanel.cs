using UnityEngine;
using TMPro;

public class LevelUpPanel : MonoBehaviour
{
    [SerializeField] int attackValue;
    [SerializeField] float attackIntervalValue;
    [SerializeField] int maxHpValue;
    [SerializeField] private CharacterStats playerStats;
    [SerializeField] private TMP_Text smithAtk;
    [SerializeField] private TMP_Text susAtk;
    [SerializeField] private TMP_Text digAtk;
    [SerializeField] private TMP_Text hunAtk;
    [SerializeField] private TMP_Text nunAtk;
    [SerializeField] private TMP_Text smithFireInterval;
    [SerializeField] private TMP_Text susFireInterval;
    [SerializeField] private TMP_Text digFireInterval;
    [SerializeField] private TMP_Text hunFireInterval;
    [SerializeField] private TMP_Text nunFireInterval;
    [SerializeField] private TMP_Text smithMaxHp;
    [SerializeField] private TMP_Text susMaxHp;
    [SerializeField] private TMP_Text digMaxHp;
    [SerializeField] private TMP_Text hunMaxHp;
    [SerializeField] private TMP_Text nunMaxHp;
    [SerializeField] TMP_Text abilityPointCount;
    private void OnEnable()
    {
        OnPointChange();
    }
    public void UpgradeAttack(CharacterStats stats)
    {
        if (playerStats.AbilityPoint > 0 && stats.CurrentAtkUpgradedTimes < stats.UpgradeLimit)
        {
            playerStats.AbilityPoint--;
            OnPointChange();
            stats.CurrentAtkUpgradedTimes++;
            stats.Attack += attackValue;
        }
    }
    public void UpgradeFireInterval(CharacterStats stats)
    {
        if (playerStats.AbilityPoint > 0 && stats.CurrentFireIntervalUpgradedTimes < stats.UpgradeLimit)
        {
            playerStats.AbilityPoint--;
            OnPointChange();
            stats.CurrentFireIntervalUpgradedTimes++;
            stats.FireInterval -= attackIntervalValue;
        }
    }
    public void UpgradeMaxHp(CharacterStats stats)
    {
        if (playerStats.AbilityPoint > 0 && stats.CurrentMaxHpUpgradedTimes < stats.UpgradeLimit)
        {
            playerStats.AbilityPoint--;
            OnPointChange();
            stats.CurrentMaxHpUpgradedTimes++;
            stats.MaxHp += maxHpValue;
        }
    }
    public void OnPointChange()
    {
        abilityPointCount.SetText("Point : " + playerStats.AbilityPoint);
    }
    #region on attack change
    public void OnSmithAbilityChange(CharacterStats stats)
    {
        smithAtk.SetText(stats.CurrentAtkUpgradedTimes.ToString());
    }
    public void OnDiggerAbilityChange(CharacterStats stats)
    {
        digAtk.SetText(stats.CurrentAtkUpgradedTimes.ToString());
    }
    public void OnSuspiciousAbilityChange(CharacterStats stats)
    {
        susAtk.SetText(stats.CurrentAtkUpgradedTimes.ToString());
    }
    public void OnHunterAbilityChange(CharacterStats stats)
    {
        hunAtk.SetText(stats.CurrentAtkUpgradedTimes.ToString());
    }
    public void OnNunAbilityChange(CharacterStats stats)
    {
        nunAtk.SetText(stats.CurrentAtkUpgradedTimes.ToString());
    }
    #endregion
    #region on fire interval change
    public void OnSmithFireIntervalChange(CharacterStats stats)
    {
        smithFireInterval.SetText(stats.CurrentFireIntervalUpgradedTimes.ToString());
    }
    public void OnSusFireIntervalChange(CharacterStats stats)
    {
        susFireInterval.SetText(stats.CurrentFireIntervalUpgradedTimes.ToString());
    }
    public void OnDiggerFireIntervalChange(CharacterStats stats)
    {
        digFireInterval.SetText(stats.CurrentFireIntervalUpgradedTimes.ToString());
    }
    public void OnHunterFireIntervalChange(CharacterStats stats)
    {
        hunFireInterval.SetText(stats.CurrentFireIntervalUpgradedTimes.ToString());

    }
    public void OnNunFireIntervalChange(CharacterStats stats)
    {
        nunFireInterval.SetText(stats.CurrentFireIntervalUpgradedTimes.ToString());
    }
    #endregion
    #region on max hp change
    public void OnSmithMaxHpChange(CharacterStats stats)
    {
        smithMaxHp.SetText(stats.CurrentMaxHpUpgradedTimes.ToString());
    }
    public void OnSusMaxHpChange(CharacterStats stats)
    {
        susMaxHp.SetText(stats.CurrentMaxHpUpgradedTimes.ToString());
    }
    public void OnDigMaxHpChange(CharacterStats stats)
    {
        digMaxHp.SetText(stats.CurrentMaxHpUpgradedTimes.ToString());
    }
    public void OnHunMaxHpChange(CharacterStats stats)
    {
        hunMaxHp.SetText(stats.CurrentMaxHpUpgradedTimes.ToString());
    }
    public void OnNunMaxHpChange(CharacterStats stats)
    {
        nunMaxHp.SetText(stats.CurrentMaxHpUpgradedTimes.ToString());
    }
    #endregion
}

