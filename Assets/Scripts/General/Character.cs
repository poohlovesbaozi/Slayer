using UnityEngine.Events;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{
    [Header("数值")]
    public CharacterStats stats;

    [Header("免疫伤害")]
    [SerializeField] float invulnerableDuration;
    float invulnerableCounter;
    public bool isInvulnerable;
    [Header("事件")]
    [SerializeField]VoidEventSO newGameEvent;
    public UnityEvent<Character>OnExpChange;
    public UnityEvent<Character> OnGemChange;
    public UnityEvent<Character> OnHealthChange;
    public UnityEvent<Transform> OnTakeDamage;
    public UnityEvent OnDie;

    private void Start()
    {
        
    }
    private void OnEnable()
    {
        stats.CurrentHp = stats.MaxHp;
        newGameEvent.OnEventRaised+=NewGame;
        
    }
    private void OnDisable() {
        newGameEvent.OnEventRaised-=NewGame;
    }

    private void NewGame()
    {
        stats.AzureGem=0;
        stats.Level=1;
        stats.Exp=0;
        stats.ExpToNextLevel=stats.Level*50;
    }

    private void Update()
    {
        if (isInvulnerable)
        {
            invulnerableCounter -= Time.deltaTime;
            if (invulnerableCounter <= 0)
            {
                isInvulnerable = false;
            }
        }
    }
    public void TakeDamage(Attack attacker)
    {
        if (isInvulnerable)
        {
            return;
        }
        if (stats.CurrentHp >= attacker.damage)
        {
            stats.CurrentHp -= attacker.damage;
            TriggerInvulnerable();
            OnTakeDamage?.Invoke(attacker.transform);
        }
        else
        {
            stats.CurrentHp = 0;
            //死了
            OnDie?.Invoke();
        }
        OnHealthChange?.Invoke(this);
    }
    public void LevelUp(){
        if (stats.Exp>=stats.ExpToNextLevel){
            stats.Level+=stats.Exp/stats.ExpToNextLevel;
            stats.Exp=stats.Exp%stats.ExpToNextLevel;
            stats.ExpToNextLevel=stats.Level*50;
        }
    }
    public void TriggerInvulnerable()
    {
        if (!isInvulnerable)
        {
            isInvulnerable = true;
            invulnerableCounter = invulnerableDuration;
        }
    }
}
